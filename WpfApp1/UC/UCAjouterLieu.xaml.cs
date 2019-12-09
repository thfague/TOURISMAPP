using Microsoft.Maps.MapControl.WPF;
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
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Permet d'ajouter un lieu grâce au double-clic de l'utilisateur sur la carte.
    /// </summary>

    public partial class UCAjouterLieu : UserControl
    {
        public MainWindow Main { get; set; }

        private List<FakePushpin> fakepinList = new List<FakePushpin>();

        private const string fic = @"PushpinInfo.txt";
        private const string fic2 = @"PushpinList.bin";

        /// <summary>
        /// Lorsque l'utilisateur va double-cliquer sur la carte, la méthode va récupérer la position.
        /// Elle va ensuite récupérer les informations données par l'utilisateur dans le fichier "PushpinInfo.txt"
        /// et récupérer la liste de faux pins pour ensuite lui ajouter ce nouveau faux pin et le sérialiser dans le
        /// fichier "PushpinList.bin".
        /// </summary>
        private void AddPushPins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ///Desactive l'action de base du double-clic.
            e.Handled = true;
            
            string titre;
            string desc;

            ///Récupère la position de la souris et la transforme en une localisation.
            Point mousePosition = e.GetPosition(this);
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            using (StreamReader reader = new StreamReader(fic))
            {
                titre = reader.ReadLine();
                desc = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(desc))
                {
                    desc = "Aucune description";
                }
                reader.Close();
            }

            ///Désérialise la liste de faux pins pour pouvoir ensuite la re-sérialiser avec le nouveau.
            using (Stream reader = File.Open(fic2, FileMode.OpenOrCreate))
            {
                if (reader.Length != 0)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    fakepinList = serializer.Deserialize(reader) as List<FakePushpin>;
                }
                reader.Close();
            }

            fakepinList.Add(new FakePushpin(titre, desc, pinLocation.Latitude, pinLocation.Longitude));

            using (StreamWriter writer = new StreamWriter(fic2))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(writer.BaseStream, fakepinList);
                writer.Close();
            }

            Main.CurrentControl = new UCMain { Main = Main };
        }

        /// <summary>
        /// Ferme la page et retourne sur la page principale.
        /// </summary>
        private void Quitter_Click (object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCMain { Main = Main };
        }

        public UCAjouterLieu()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}