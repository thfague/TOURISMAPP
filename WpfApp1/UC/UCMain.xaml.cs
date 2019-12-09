using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Affiche la carte avec les Pins et leur description.
    /// </summary>

    public partial class UCMain : UserControl
    {
        public MainWindow Main { get; set; }

        public List<Pushpin> listeLieu;

        private const string fic = @"PushpinList.bin";

        /// <summary>
        /// Affiche les paramètres.
        /// </summary>
        private void Parametre_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCParametre { Main = Main };
        }

        /// <summary>
        /// Désérialise le fichier "PushpinList.bin" et mets les FakePushpin dans la liste fakepinList.
        /// Crée ensuite de vrai pins pour chaque faux pins, redéfinie leur style et les ajoutent à la
        /// liste de lieux et à la carte.
        /// </summary>
        public UCMain()
        {
            InitializeComponent();
            DataContext = this;

            listeLieu = new List<Pushpin>();
            List<FakePushpin> fakepinList = new List<FakePushpin>();

            using (Stream reader = File.Open(fic,FileMode.OpenOrCreate))
            {
                if(reader.Length != 0)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    fakepinList = serializer.Deserialize(reader) as List<FakePushpin>;
                    foreach (FakePushpin fakepin in fakepinList)
                    {
                        Pushpin pin = new Pushpin(fakepin.titre, fakepin.description);
                        pin.Location.Latitude = fakepin.latitude;
                        pin.Location.Longitude = fakepin.longitude;

                        ToolTipService.SetToolTip(pin, new ToolTip() { DataContext = pin, Style = Application.Current.Resources["InfoStyle"] as Style });
                        listeLieu.Add(pin);
                    }

                    foreach (Pushpin pushpin in listeLieu)
                    {
                        myMap.Children.Add(pushpin);
                    }
                }
                reader.Close();
            }
        }
    }
}