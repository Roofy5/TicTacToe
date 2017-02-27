using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolkoKrzyzyk
{
    public partial class Form1 : Form
    {
        Plansza plansza;
        MechanikaGry mechanika;
        bool gracz = false;
        int pointsX = 0;
        int pointsO = 0;
        public Form1()
        {
            InitializeComponent();
            plansza = new Plansza();
            mechanika = new MechanikaGry(plansza);
        }

        private void Ruch(int pole, object button)
        {
            UstawNaPlanszy(pole);
            ZmienWyglad(button, pole);
            SprawdzPlansze();
        }

        private void UstawNaPlanszy(int pole)
        {
            if (gracz)
                plansza.SetPole(pole, Pole.Kolko);
            else
                plansza.SetPole(pole, Pole.Krzyzyk);

            gracz = !gracz;
        }

        private void ZmienWyglad(object button, int pozycja)
        {
            Button przycisk = button as Button;
            przycisk.Enabled = false;

            Pole pole = plansza.GetPole(pozycja);
            if (pole == Pole.Kolko)
                przycisk.Text = "O";
            if (pole == Pole.Krzyzyk)
                przycisk.Text = "X";
        }
        private void SprawdzPlansze()
        {
            Status wynik = mechanika.SprawdzPlansze();
            if (wynik == Status.WygranaKolko)
            {
                pointsO++;
                UstawPrzyciski(false);
            }
            if (wynik == Status.WygranaKrzyzyk)
            {
                pointsX++;
                UstawPrzyciski(false);
            }

            punktyO.Text = pointsO.ToString();
            punktyX.Text = pointsX.ToString();
        }
        private void UstawPrzyciski(bool status)
        {
            foreach (Object ob in this.Controls)
            {
                Button przycisk = ob as Button;
                if (przycisk != null)
                    przycisk.Enabled = status;
            }
            buttonJeszceRaz.Enabled = true;
        }
        #region przyciski
        private void button0_Click(object sender, EventArgs e)
        {
            Ruch(0, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ruch(1, sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ruch(2, sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ruch(3, sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ruch(4, sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Ruch(5, sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ruch(6, sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Ruch(7, sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ruch(8, sender);
        }
        #endregion

        private void buttonJeszceRaz_Click(object sender, EventArgs e)
        {
            foreach (Object ob in this.Controls)
            {
                Button przycisk = ob as Button;
                if (przycisk != null)
                    przycisk.Text = "";
            }
            buttonJeszceRaz.Text = "Jeszcze Raz";

            UstawPrzyciski(true);
            plansza.Zeruj();
        }
    }
}
