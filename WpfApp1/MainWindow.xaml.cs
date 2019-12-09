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
    /// Fenêtre principale de l'application.
    /// Son contenu change en fonction des demandes de l'utilisateur grâce au ContentPresenter bindé a currentControl.
    /// </summary>

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Control currentControl;

        /// <summary>
        /// Permet de modifier ce qui est affiché sur la fenêtre.
        /// Lorsque l'événement PropertyChanged va être déclenché, il va modifier le contentPresenter avec comme valeur le currentControl.
        /// </summary>
        public Control CurrentControl
        {
            get { return currentControl; }
            set
            {
                currentControl = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentControl"));
            }
        }

        /// <summary>
        /// La fenêtre affiche de base la page d'accueil avec la carte et les differents Pins avec leurs description.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            CurrentControl = new UCPageAccueil { Main = this };
        }
    }
}