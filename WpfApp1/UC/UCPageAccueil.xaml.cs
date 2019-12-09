using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Affiche la page d'accueil.
    /// </summary>

    public partial class UCPageAccueil : UserControl
    {
        public MainWindow Main { get; set; }

        /// <summary>
        /// Affiche la page principal.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.CurrentControl = new UCMain { Main = Main };
        }

        public UCPageAccueil()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
