using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisX.Title = "Длина, м";
            chart1.ChartAreas[0].AxisY.Title = "Температура, °C";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "F3";
        }

        decimal rho, c, lambda, L, h, tau, T0, T_left, T_right, T_total, M;
        decimal[] T, A, B, C, F;
        int N;



        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                chart1.Series[0].Points.Clear();
                dataGridView1.Rows.Clear();
                // Физические параметры
                rho = edRho.Value;
                c = edC.Value;
                lambda = edLambda.Value;

                // Параметры сетки
                L = edL.Value;
                h = Convert.ToDecimal(edDx.SelectedItem.ToString());
                N = (int)(L / h) + 1;

                // Параметры времени
                T_total = edT_total.Value;
                tau = Convert.ToDecimal(edTau.SelectedItem.ToString());
                M = (int)(T_total / tau);

                // Начальные и граничные усл-ия
                T0 = edT0.Value;
                T_left = edT_left.Value;
                T_right = edT_right.Value;

                T = new decimal[N];
                for (int i = 0; i < N; i++)
                {
                    T[i] = T0;
                }

                A = new decimal[N];

                for (int i = 0; i < N; i++)
                {
                    A[i] = lambda / (h * h);
                }

                B = new decimal[N];

                for (int i = 0; i < N; i++)
                {
                    B[i] = (2 * lambda / (h * h)) + (rho * c / tau);
                }

                C = new decimal[N];

                for (int i = 0; i < N; i++)
                {
                    C[i] = lambda / (h * h);
                }

                F = new decimal[N];

                timer1.Start();
            }
        }

        public void Aproatch()
        {
            decimal[] alpha = new decimal[N];
            decimal[] beta = new decimal[N];

            alpha[0] = A[0] / B[0];
            beta[0] = -1 * F[0] / B[0];

            for (int i = 1; i < N; i++)
            {
                alpha[i] = A[i] / (B[i] - C[i] * alpha[i - 1]);
                beta[i] = (C[i] * beta[i - 1] - F[i]) / (B[i] - C[i] * alpha[i - 1]);
            }

            T[T.Length - 1] = beta[beta.Length - 1];

            for (int i = T.Length - 2; i >= 0; i--)
            {
                T[i] = alpha[i] * T[i + 1] + beta[i];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < M; j++)
            { 
                T[0] = T_left;
                T[T.Length - 1] = T_right;
                for (int i = 0; i < N; i++)
                {
                    F[i] = -1 * (rho * c / tau) * T[i];
                }

                Aproatch();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < N; i++)
                {
                    sb.Append($"\t{Math.Round(T[i], 3)}\t/");
                }

                string result = sb.ToString();
                int number = dataGridView1.Rows.Count;

                if (N % 2 == 1)
                {
                   // chart1.Series[0].Points.AddY((double)T[N / 2]);
                    dataGridView1.Rows.Add(number, Math.Round((double)T[N / 2],5), result);
                }
                else
                {
                   // chart1.Series[0].Points.AddY((double)T[N / 2 - 1]);
                    dataGridView1.Rows.Add(number, Math.Round((double)T[N / 2 - 1],5), result);
                }

            }

            

            for (int i = 0; i < N; i++)
            {
                chart1.Series[0].Points.AddXY((double)h * i, (double)T[i]);
            }

            timer1.Stop();
        }

    }


}
