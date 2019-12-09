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
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.TextFormatting;

namespace WpfApp1
{
    /// <summary>
    /// Ouvre une fenêtre permettant l'inscription d'un utilisateur.
    /// </summary>

    public partial class CreateAccWindow : Window
    {
        private List<Compte> listCompte = new List<Compte>();

        private const string fic = @"LoginList.bin";

        /// <summary>
        /// Vérifie que l'utilisateur n'existe pas, a tout renseigné, que l'email est conforme et que les mots de passe sont identiques.
        /// Crée ensuite un compte et l'ajoute à la liste d'utilisateur qui est ensuite sérialisé dans le fichier "LoginList.bin".
        /// </summary>
        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            string email = textBoxEmail.Text;

            List<Compte> verifCompteExistant = (from compte in listCompte
                                                where compte.Email.Equals(email)
                                                select compte).ToList();

            if (textBoxPrenom.Text.Length == 0)
            {
                errorMessage.Text = "ERREUR: Veuillez entrer votre prénom.";
                textBoxPrenom.Focus();
            }

            else if (textBoxNom.Text.Length == 0)
            {
                errorMessage.Text = "ERREUR: Veuillez entrer votre nom.";
                textBoxNom.Focus();
            }

            else if (textBoxEmail.Text.Length == 0)
            {
                errorMessage.Text = "ERREUR: Veuillez entrer une adresse email.";
                textBoxEmail.Focus();
            }

            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errorMessage.Text = "ERREUR: Veuillez entrer une adresse email valide.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }

            else if (verifCompteExistant.Count == 1)
            {
                errorMessage.Text = "ERREUR: Un compte existe déjà avec cette adresse email.";
            }

            else if (passwordBoxMdp.Password.Length == 0)
            {
                errorMessage.Text = "ERREUR: Veuillez entrer un mot de passe.";
                passwordBoxMdp.Focus();
            }

            else if (passwordBoxConfMdp.Password.Length == 0)
            {
                errorMessage.Text = "ERREUR: Veuillez confirmer le mot de passe.";
                passwordBoxConfMdp.Focus();
            }

            else if (passwordBoxMdp.Password != passwordBoxConfMdp.Password)
            {
                errorMessage.Text = "ERREUR: Les mots de passe sont différents.";
                passwordBoxConfMdp.Focus();
            }

            else
            {
                listCompte.Add(new Compte(textBoxPrenom.Text, textBoxNom.Text, textBoxEmail.Text, passwordBoxMdp.Password));

                using (Stream stream = File.Open(fic, FileMode.OpenOrCreate))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, listCompte);
                    stream.Close();
                }

                errorMessage.Text = "Vous êtes bien inscrit.";
            }
        }

        private void Quitter_Click(object sender, RoutedEventArgs e) => Close();

        /// <summary>
        /// Lors de l'ouverture de la fenêtre, désérialise le fichier "LoginList.bin" et met (s'il y en a) les comptes déjà enregistrés
        /// dans la liste "listCompte".
        /// </summary>
        public CreateAccWindow()
        {
            InitializeComponent();
            errorMessage.Text = "";

            using (Stream reader = File.Open(fic, FileMode.OpenOrCreate))
            {
                if (reader.Length != 0)
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    listCompte = serializer.Deserialize(reader) as List<Compte>;
                    reader.Close();
                }
            }
        }
    }
}