using System;
using System.Windows.Forms;

namespace WO
{

    public partial class okno_glowne : Form
    {
        public static double kpw;
        public okno_glowne()
        {
            InitializeComponent();

            label12.Text = kpw.ToString();

        }

        private void PID_I_Click(object sender, EventArgs e)
        {

        }

        private void PID_E_Click(object sender, EventArgs e)
        {

        }

        private void PROCESS_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menu_Paint(object sender, PaintEventArgs e)
        {
          
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PID_WEW_Click(object sender, EventArgs e)
        {

        }

        private void zakładka_równolegle_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            double[,] X = new double[4, 100]; //inicjalizacja tablicy stanów

            //PARAMETRY SYMULACJI
            double h = 0.2; // krok 
            double x = 0; // zmienna pomocniczna czas wykonywania pętli

            int i = 1; // zmienna pomocnicza w pętli symuljącej czas

            double zad_p = 5;//wartość zadana
            double zad_k = 0;
            double u = 0;//wartości sterująca

            // nastawy
            double kpz = 0.05;
            double kdz = 0.7;

            double kpw = 1;
            double kiw = 0.1;
            double kdw = 1;

            //warunki poczatkowe
            double suma_p = 0;
            double uchyb = 0;
            double calka2 = 0;
            double uchyb_p1 = 0;
            double uchyb_p2 = 0;
            double rozniczka1;
            double rozniczka2;
            X[0, i - 1] = 90;


            // parametry wahadła
            double M, m, g, l, b, I;
            M = 0.5;
            m = 0.2;
            g = 9.80665;
            l = 0.3;
            b = 0.1;
            I = 0.006;

            while (x <= 10)
            {
                //PD ZEWNETRZNY
                uchyb = zad_p - X[1, i - 1]; // przy wahadle: zadana- polozenie
                rozniczka1 = (uchyb - uchyb_p1) / h;
                u = kpz * uchyb  + kdz * rozniczka1;
                uchyb_p1 = uchyb;

                //PID WEWENETRZNY
                uchyb = zad_k-u;           // przy wahadle: poporsu wyjście z regulatora zew
                calka2 = calka2 + uchyb * h;
                rozniczka2 = (uchyb - uchyb_p2) / h;
                u = kpw * uchyb + kiw * calka2 + kdw * rozniczka2;
                uchyb_p2 = uchyb;


                // kat wychylenia
                X[0, i] = X[0, i - 1] + h * X[1, i - 1];

                //przspieszenie katowe
                X[1, i] = X[1, i - 1] + h * ((-(M + m) * m * g * l * Math.Sin(X[0, i - 1]) - 0.5 * m * m * l * l
                        * Math.Sin(2 * X[0, i - 1]) * Math.Pow(X[1, i - 1], 2) + m * l * b
                        * Math.Cos(X[0, i - 1]) * X[3, i - 1] - m * l * b * Math.Cos(X[0, i - 1]) * u)
                        / (I * (M + m) + m * M * l * l + m * m * l * l * Math.Pow(Math.Sin(X[0, i - 1]), 2)));

                //położenie
                X[2, i] = X[2, i - 1] + h * X[3, i - 1];

                //prędkośc
                X[3, i] = X[3, i - 1] + h * ((b * (I + m * l * l) * X[3, i - 1] + 0.5 * m * m * g * l * l * Math.Sin(2 * X[0, i - 1])
                    + (I + m * l * l) * m * l * Math.Pow(X[1, i - 1], 2) * Math.Sin(X[0, i - 1]) + (I + m * l * l) * u)
                    / (I * (M + m) + m * M * l * l + m * m * l * l * Math.Pow(Math.Sin(X[0, i - 1]), 2)));

                this.uchybChart.Series["Series1"].Points.AddXY(x, X[0, i]);

                x = x + h;

                i++;

            }


        }

        private void uchybChart_Click(object sender, EventArgs e)
        {

        }

        private void PID_I_Click_1(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();

        }

        private void PID_II_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();

        }

        private void wsk2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
        }

        private void etap1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
