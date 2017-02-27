using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoKrzyzyk
{
    public enum Pole { Puste, Kolko, Krzyzyk }

    public class Plansza
    {
        private Pole[] plansza;

        public Plansza()
        {
            plansza = new Pole[9];
        }
        public void SetPole(int pozycja, Pole wartosc)
        {
            if (pozycja < 0 || pozycja > 8)
                throw new ArgumentException("Wartosc mniejsza od 0 lub wieksza od 8");

            plansza[pozycja] = wartosc;
        }
        public Pole GetPole(int pozycja)
        {
            if (pozycja < 0 || pozycja > 8)
                throw new ArgumentException("Wartosc mniejsza od 0 lub wieksza od 8");

            return plansza[pozycja];
        }

        internal void Zeruj()
        {
            for (int i = 0; i < 9; i++)
                plansza[i] = Pole.Puste;
        }
    }
}
