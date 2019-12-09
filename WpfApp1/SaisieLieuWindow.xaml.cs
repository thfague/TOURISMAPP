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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Ouvre une fenêtre permettant la saisie d'un nouveau lieu.
    /// La fenêtre possède deux boutons: un permettant de revenir en arrière et donc de fermer la fenêtre
    /// et l'autre permettant de saisir le lieu, qui va ensuite être enregistré dans un fichier(PushpinInfo.txt).
    /// </summary>

    public partial class SaisieLieuWindow : Window
    {
        private List<FakePushpin> fakepinList = new List<FakePushpin>();

        private const string fic = @"PushpinInfo.txt";
        private const string fic2 = @"PushpinList.bin";

        /// <summary>
        /// Elle vérifie d'abord que l'utilisateur a renseigné un nom pour le lieu,
        /// si oui, elle vérifie que le lieu n'est pas déjà renseigné et si non, elle écrit le nom
        /// et la description(si renseignée car non obligatoire) du lieu dans le fichier "PushpinInfo.txt" et ferme la fenêtre.
        /// </summary>
        private void Saisir_Click(object sender, RoutedEventArgs e)
        {
            List<FakePushpin> verifLieuExistant = (from fakepin in fakepinList
                                                   where fakepin.titre.Equals(textBoxNom.Text)
                                                   select fakepin).ToList();

            if (textBoxNom.Text.Length == 0)
            {
                errorMessage.Text = "ERREUR: Le nom du lieu est obligatoire.";
                textBoxNom.Focus();
            }

            else if (verifLieuExistant.Count == 1)
            {
                errorMessage.Text = "ERREUR: Ce lieu est déjà renseigné.";
            }

            else
            {

                string titre = textBoxNom.Text;
                string desc = textBoxDesc.Text;

                using (StreamWriter writer = new StreamWriter(fic))
                {
                    writer.WriteLine(titre);
                    writer.WriteLine(desc);
                    writer.Close();
                }

                Close();
            }
        }

        /// <summary>
        /// Ferme la fenêtre et vide le fichier pour éviter les bugs.
        /// </summary>
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(fic))
            {
                writer.WriteLine();
                writer.WriteLine();
                writer.Close();
            }
            Close();
        }

        /// <summary>
        /// Lors de l'ouverture de la fenêtre, désérialise le fichier "PushpinList.bin" et met les lieux déjà enregistrés
        /// dans la liste "fakepinList".
        /// </summary>
        public SaisieLieuWindow()
        {
            InitializeComponent();
            errorMessage.Text = "";

            using (Stream reader = File.Open(fic2, FileMode.OpenOrCreate))
            {
                if(reader.Length != 0)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    fakepinList = serializer.Deserialize(reader) as List<FakePushpin>;
                    reader.Close();
                }
            }
        }
    }
}