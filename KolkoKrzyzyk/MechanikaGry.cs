using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyzyk
{
    public enum Status { Kontynuuj, WygranaKolko, WygranaKrzyzyk, Remis }
    public class MechanikaGry
    {
        private Plansza plansza = null;

        public MechanikaGry(Plansza plansza)
        {
            this.plansza = plansza;
        }

        public Status SprawdzPlansze()
        {
            Status wynik;
            if ((wynik = Sprawdz(0, 1, 2)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(3, 4, 5)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(6, 7, 8)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(0, 3, 6)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(1, 4, 7)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(2, 5, 8)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(0, 4, 8)) != Status.Kontynuuj)
                return wynik;
            if ((wynik = Sprawdz(2, 4, 6)) != Status.Kontynuuj)
                return wynik;

            if (CzyRemis() == Status.Remis)
                return Status.Remis;

            return Status.Kontynuuj;
        }

        private Status Sprawdz(int pole0, int pole1, int pole2)
        {
            Pole wynik0 = plansza.GetPole(pole0);
            Pole wynik1 = plansza.GetPole(pole1);
            Pole wynik2 = plansza.GetPole(pole2);

            return PorownajPola(wynik0, wynik1, wynik2);
        }
        private Status CzyRemis()
        {
            if (plansza.GetPole(0) != Pole.Puste &&
                plansza.GetPole(1) != Pole.Puste &&
                plansza.GetPole(2) != Pole.Puste &&
                plansza.GetPole(3) != Pole.Puste &&
                plansza.GetPole(4) != Pole.Puste &&
                plansza.GetPole(5) != Pole.Puste &&
                plansza.GetPole(6) != Pole.Puste &&
                plansza.GetPole(7) != Pole.Puste &&
                plansza.GetPole(8) != Pole.Puste)
                return Status.Remis;
            else
                return Status.Kontynuuj;
        }
        private Status PorownajPola(Pole wynik0, Pole wynik1, Pole wynik2)
        {
            if ((wynik0 == wynik1) && (wynik1 == wynik2))
                if (wynik0 == Pole.Kolko)
                    return Status.WygranaKolko;
                else if (wynik0 == Pole.Krzyzyk)
                    return Status.WygranaKrzyzyk;

            return Status.Kontynuuj;
        }
    }
}
