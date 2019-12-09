using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Affiche les paramètres de l'application et permet la connection des utilisateurs.
    /// </summary>
    public partial class UCParametre : UserControl
    {
        public MainWindow Main { get; set; }

        /// <summary>
        /// Affiche la liste des lieux.
        /// </summary>
        private void ListeLieu_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCListeLieu { Main = Main };
        }

        /// <summary>
        /// Ouvre une fenêtre de connection pour l'utilisateur.
        /// </summary>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
        }

        /// <summary>
        /// Retourne sur la page principal.
        /// </summary>
        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCMain { Main = Main };
        }

        public UCParametre()
        {
            InitializeComponent();
            DataContext = this;
        }    
    }
}