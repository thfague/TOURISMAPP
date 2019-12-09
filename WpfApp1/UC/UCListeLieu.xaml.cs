using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Affiche la liste des lieux déjà renseigné.
    /// </summary>

    public partial class UCListeLieu : UserControl
    {
        public MainWindow Main { get; set; }

        private List<Lieu> listeLieu = new List<Lieu>();
        private List<FakePushpin> fakepinList = new List<FakePushpin>();

        private const string fic = @"PushpinList.bin";

        /// <summary>
        /// Permet de rechercher un lieu parmit la liste des lieux.
        /// </summary>
        private void search_Click(object sender, EventArgs e)
        {
            List<Lieu> listeLieuSearch = new List<Lieu>();

            IEnumerable<Lieu> foundItem = from lieu in listeLieu
                                          where lieu.Titre.Contains(searchBox.Text)
                                          select lieu;
            foreach(Lieu lieu in foundItem)
            {
                listeLieuSearch.Add(lieu);
            }
            ListLieu.ItemsSource = listeLieuSearch;
        }

        /// <summary>
        /// Ouvre la fenêtre qui permet d'ajouter un lieu à la liste.
        /// </summary>
        private void ajouterLieu_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCAjouterLieu { Main = Main };
            SaisieLieuWindow saisieLieu = new SaisieLieuWindow();
            saisieLieu.ShowDialog();
        }

        /// <summary>
        /// Permet de supprimer un lieu de la liste.
        /// </summary>
        private void supprimerLieu_Click(object sender, RoutedEventArgs e)
        {
            if((Lieu)ListLieu.SelectedItem != null)
            {
                ///Récupère le titre et la decsription du lieu sélectionné.
                string deleteItemTitre = ((Lieu)ListLieu.SelectedItem).Titre;
                string deleteItemDescription = ((Lieu)ListLieu.SelectedItem).Description;

                ///Recherche le faux pin pour lequel son titre et sa description sont égaux à ceux du lieu sélectionné
                ///et le supprime de la liste après confirmation de l'utilisateur.
                foreach (FakePushpin fakepin in fakepinList)
                {
                    if (fakepin.titre.Equals(deleteItemTitre) && fakepin.description.Equals(deleteItemDescription) && (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce lieu ?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        fakepinList.Remove(fakepin);
                        break;
                    }
                }

                ///Sérialise la liste de faux pins dans le fichier "PushpinList.bin".
                using (StreamWriter writer = new StreamWriter(fic))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(writer.BaseStream, fakepinList);
                    writer.Close();
                }

                ///Affiche la liste des lieux mise à jour.
                Main.CurrentControl = new UCListeLieu { Main = Main };
            }
            else
            {
                errorMessage2.Text = "ERREUR: Aucun lieu séléctionné.";
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCParametre { Main = Main };
        }

        /// <summary>
        /// Désérialise le fichier "PushpinList.bin" et met les faux pins dans la liste fakepinList ou renvoie un message
        /// si aucun lieu existe.
        /// Ajoute ensuite ces faux pins dans la liste des lieux grâce à leur titre et leur description.
        /// Précise la source des lieux pour les mettre dans la liste qui les affichera.
        /// </summary>
        public UCListeLieu()
        {
            InitializeComponent();
            DataContext = this;

            errorMessage.Text = "";

            using (Stream reader = File.Open(fic, FileMode.OpenOrCreate))
            {
                if (reader.Length != 0)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    fakepinList = serializer.Deserialize(reader) as List<FakePushpin>;
                    foreach (FakePushpin fakepin in fakepinList)
                    {
                        listeLieu.Add(new Lieu() { Titre = fakepin.titre, Description = fakepin.description });
                    }
                }
                else
                {
                    errorMessage.Text = "Aucun lieux enregistrés.";
                }
                reader.Close();
            }
            ListLieu.ItemsSource = listeLieu;
        }
    }
}