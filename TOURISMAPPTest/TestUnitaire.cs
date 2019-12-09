using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WpfApp1
{
    [TestClass]
    public class Test_Unitaire
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_NewPushPin_AvecTitreNull_LeveException()
        {
            Pushpin pin = new Pushpin(null,null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_NewFakePushpin_AvecLongitudeLatitude_OutOfRange_LeveException()
        {
            FakePushpin fakepin = new FakePushpin("Test","",-300,0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_NewFakePushpin_AvecTitreNull_LeveException()
        {
            FakePushpin fakepin = new FakePushpin("", "", 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_NewCompte_AvecNomNull_LeveException()
        {
            Compte compte = new Compte(null,null,null,null);
        }
    }
}