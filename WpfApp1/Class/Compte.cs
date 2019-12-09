using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Classe Compte. Elle permet la création d'un compte pour pouvoir ensuite le sérialiser. 
    /// Un compte contient: -Un prenom(public)          -Un email(privé)
    ///                     -Un nom(public)             -Un mot de passe(privé)
    /// </summary>

    [Serializable]
    public class Compte
    {
        public string prenom { get; set; }
        public string nom { get; set; }
        private string email;
        private string mdp;


        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }
        public string Mdp
        {
            get
            {
                return this.mdp;
            }
            set
            {
                this.mdp = value;
            }
        }

        public Compte(string prenom, string nom, string email, string mdp)
        {
            if (prenom == null || prenom == "" || nom == null || nom == "" || email == null || email == "" || mdp == null || mdp == "")
            {
                throw new ArgumentException();
            }
            else
            {
                this.prenom = prenom;
                this.nom = nom;
                this.email = email;
                this.mdp = mdp;
            }          
        }
    }
}