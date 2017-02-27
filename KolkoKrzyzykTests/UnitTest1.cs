using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using KolkoKrzyzyk;

namespace KolkoKrzyzykTests
{
    [TestClass]
    public class PlanszaTests
    {
        private static Plansza plansza = new Plansza();

        [TestMethod]
        public void TestKonstruktora()
        {
            plansza = new Plansza();

            Assert.AreEqual(Pole.Puste, plansza.GetPole(0));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(1));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(2));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(3));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(4));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(5));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(6));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(7));
            Assert.AreEqual(Pole.Puste, plansza.GetPole(8));
        }
        [TestMethod]
        public void UstawKolko()
        {
            plansza.SetPole(0, Pole.Kolko);
            Pole pole = plansza.GetPole(0);
            Assert.AreEqual(Pole.Kolko, pole);
        }
        [TestMethod]
        public void UstawKrzyzyk()
        {
            plansza.SetPole(3, Pole.Krzyzyk);
            Pole pole = plansza.GetPole(3);
            Assert.AreEqual(Pole.Krzyzyk, pole);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UstawPole_WartoscUjemna()
        {
            plansza.SetPole(-1, Pole.Krzyzyk);
            Assert.Fail();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UstawPole_PozaPlansza()
        {
            plansza.SetPole(9, Pole.Puste);
            Assert.Fail();
        }
        [TestMethod]
        public void UstawPole_Granica()
        {
            plansza.SetPole(8, Pole.Puste);
            Pole pole = plansza.GetPole(8);
            Assert.AreEqual(Pole.Puste, pole);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CzytajPole_WartoscUjemna()
        {
            plansza.GetPole(-1);
            Assert.Fail();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CzytajPole_WartoscPozaPlansza()
        {
            plansza.GetPole(9);
            Assert.Fail();
        }
    }

    [TestClass]
    public class MechanikaGryTests
    {
        private Plansza plansza = new Plansza();
        private MechanikaGry mech = null;

        [TestInitialize]
        public void Initialize()
        {
            mech = new MechanikaGry(plansza);
        }
        [TestMethod]
        public void Sprawdz_Gora_Poziomo()
        {
            // Arrange
            plansza.SetPole(0, Pole.Kolko);
            plansza.SetPole(1, Pole.Kolko);
            plansza.SetPole(2, Pole.Kolko);

            // Act
            Status wynik = mech.SprawdzPlansze();

            // Assert
            Assert.AreEqual(Status.WygranaKolko, wynik);
        }
        [TestMethod]
        public void Sprawdz_Dol_Poziomo()
        {
            // Arrange
            plansza.SetPole(6, Pole.Krzyzyk);
            plansza.SetPole(7, Pole.Krzyzyk);
            plansza.SetPole(8, Pole.Krzyzyk);

            // Act
            Status wynik = mech.SprawdzPlansze();

            // Assert
            Assert.AreEqual(Status.WygranaKrzyzyk, wynik);
        }
        [TestMethod]
        public void Sprawdz_Lewo_Pionowo()
        {
            // Arrange
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(3, Pole.Krzyzyk);
            plansza.SetPole(6, Pole.Krzyzyk);

            // Act
            Status wynik = mech.SprawdzPlansze();

            // Assert
            Assert.AreEqual(Status.WygranaKrzyzyk, wynik);
        }
        [TestMethod]
        public void Sprawdz_Skos()
        {
            // Arrange
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(4, Pole.Krzyzyk);
            plansza.SetPole(8, Pole.Krzyzyk);

            // Act
            Status wynik = mech.SprawdzPlansze();

            // Assert
            Assert.AreEqual(Status.WygranaKrzyzyk, wynik);
        }
        [TestMethod]
        public void Losowe()
        {
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(1, Pole.Krzyzyk);
            plansza.SetPole(2, Pole.Kolko);

            Status wynik = mech.SprawdzPlansze();

            Assert.AreEqual(Status.Kontynuuj, wynik);
        }
        [TestMethod]
        public void Losowe2()
        {
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(8, Pole.Krzyzyk);
            plansza.SetPole(3, Pole.Kolko);

            Status wynik = mech.SprawdzPlansze();

            Assert.AreEqual(Status.Kontynuuj, wynik);
        }
        [TestMethod]
        public void Losowe3()
        {
            plansza.SetPole(3, Pole.Krzyzyk);
            plansza.SetPole(4, Pole.Kolko);
            plansza.SetPole(5, Pole.Krzyzyk);

            Status wynik = mech.SprawdzPlansze();

            Assert.AreEqual(Status.Kontynuuj, wynik);
        }
        [TestMethod]
        public void Remis()
        {
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(1, Pole.Kolko);
            plansza.SetPole(2, Pole.Krzyzyk);
            plansza.SetPole(3, Pole.Krzyzyk);
            plansza.SetPole(4, Pole.Kolko);
            plansza.SetPole(5, Pole.Kolko);
            plansza.SetPole(6, Pole.Kolko);
            plansza.SetPole(7, Pole.Krzyzyk);
            plansza.SetPole(8, Pole.Krzyzyk);

            Status wynik = mech.SprawdzPlansze();

            Assert.AreEqual(Status.Remis, wynik);
        }
        [TestMethod]
        public void AntyRemis()
        {
            plansza.SetPole(0, Pole.Krzyzyk);
            plansza.SetPole(1, Pole.Kolko);
            plansza.SetPole(2, Pole.Krzyzyk);
            plansza.SetPole(3, Pole.Krzyzyk);
            plansza.SetPole(4, Pole.Kolko);
            plansza.SetPole(5, Pole.Krzyzyk);
            plansza.SetPole(6, Pole.Kolko);
            plansza.SetPole(7, Pole.Krzyzyk);
            plansza.SetPole(8, Pole.Krzyzyk);

            Status wynik = mech.SprawdzPlansze();

            Assert.AreEqual(Status.WygranaKrzyzyk, wynik);
        }
    }
}
