using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl;
using Microsoft.Maps.MapControl.WPF;

namespace WpfApp1
{
    /// <summary>
    /// Classe PushPinCustom. Elle permet d'ajouter aux Pushpins(Microsoft.Maps.MapControl.WPF.Pushpin) un titre ainsi qu'une description.
    /// Un PushPinCustom contient: -Les attributs d'un Pushpin(Microsoft.Maps.MapControl.WPF.Pushpin)
    ///                            -Un titre(privé)                 -Une description(privée)
    /// </summary>

    public partial class Pushpin : Microsoft.Maps.MapControl.WPF.Pushpin
    {
        private string titre;
        private string description;

        public string Titre
        {
            get
            {
                return this.titre;
            }
            set
            {
                if(this.titre == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    this.titre = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public Pushpin(string titre, string description)
        {
            if(titre == null || titre == "")
            {
                throw new ArgumentException();
            }
            else
            {
                this.titre = titre;
            }

            this.description = description;
            Location = new Location();
        }
    }
}