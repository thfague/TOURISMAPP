using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Classe FakePushpin. Elle permet la sérialisation de PushPin(Microsoft.Maps.MapControl.WPF.Pushpin) qui sont eux non sérialisables.
    /// Un FakePushpin contient: -Un titre(public)          -Une description(publique)
    ///                          -Une localisation(Microsoft.Maps.MapControl.WPF.Location) = latitude, longitude et altitude(toutes publiques).
    /// 
    /// </summary>

    [Serializable]
    public class FakePushpin
    {
        public string titre;
        public string description;
        public double latitude;
        public double longitude;

        public const double MaxLatitude = 90;
        public const double MinLatitude = -90;
        public const double MaxLongitude = 180;
        public const double MinLongitude = -180;

        public FakePushpin()
        {
            titre = "";
            description = "";
            latitude = 0;
            longitude = 0;
        }

        public FakePushpin(string titre, string description, double latitude, double longitude)
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

            if(latitude < MinLatitude || latitude > MaxLatitude || longitude < MinLongitude ||longitude > MaxLongitude)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.latitude = latitude;
                this.longitude = longitude;
            }
        }
    }
}