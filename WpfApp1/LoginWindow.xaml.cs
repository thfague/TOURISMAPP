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
    /// Ouvre une fenêtre permettant de se connecter (où d'appeler la fenêtre d' inscription si besoin).
    /// Pour se connecter, l'utilisateur doit renseigner son adresse email et son mot de passe pour pouvoir se connecter.
    /// </summary>

    public partial class LoginWindow : Window
    {
        List<Compte> listCompte = new List<Compte>();

        private const string fic = "LoginList.bin";

        /// <summary>
        /// Lit le fichier "LoginList.bin" et regarde s'il est vide. Si oui, renvoie un message d'erreur.
        /// Sinon, met les comptes dans la liste de comptes et verifie si le compte existe. Si oui, connecte l'utilisateur,
        /// sinon renvoie un message d'erreur.
        /// </summary>
        private void Connecter_Click(object sender, RoutedEventArgs e)
        {
            string email = textBoxEmail.Text;
            string mdp = passwordBoxMdp.Password;

            if (textBoxEmail.Text == "")
            {
                errorMessage.Text = "ERREUR: Email manquant.";
            }

            else if (passwordBoxMdp.Password == "")
            {
                errorMessage.Text = "ERREUR: Mot de passe manqant.";
            }

            else
            {
                using (Stream reader = File.Open(fic, FileMode.OpenOrCreate))
                {
                    if (reader.Length != 0)
                    {
                        BinaryFormatter serializer = new BinaryFormatter();
                        listCompte = serializer.Deserialize(reader) as List<Compte>;

                        List<Compte> verifCompteEmail = (from compte in listCompte
                                                         where email.Equals(compte.Email)
                                                         select compte).ToList();

                        List<Compte> verifCompteMdp = (from compte in listCompte
                                                       where compte.Mdp.Equals(mdp)
                                                       select compte).ToList();

                        if (verifCompteEmail.Count == 0 || verifCompteMdp.Count == 0)
                        {
                            errorMessage.Text = "ERREUR: Ce compte n'existe pas.";
                        }
                        else
                        {
                            errorMessage.Text = "Vous êtes maintenant connecté(e).";
                        }
                    }
                    else
                    {
                        errorMessage.Text = "ERREUR: Il n'y a pas de compte enregistré à ce jour.";
                    }
                    reader.Close();
                }
            }
            
        }

        private void Retour_Click(object sender, RoutedEventArgs e) => Close();

        /// <summary>
        /// Ouvre la fenêtre d'inscription.
        /// </summary>
        private void Inscrire_Click(object sender, RoutedEventArgs e)
        {
            CreateAccWindow creercompte = new CreateAccWindow();
            creercompte.ShowDialog();
        }

        public LoginWindow()
        {
            InitializeComponent();
            errorMessage.Text = "";
        }
    }
}