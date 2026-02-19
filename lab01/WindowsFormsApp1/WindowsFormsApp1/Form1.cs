using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 20;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 20;
            */
            ShowResults();

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:F2}";

            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:F2}";

        }

        private Series AddNewSeries()
        {
            string name = "Полет" + (chart.Series.Count + 1);
            Series newSeries = new Series(name);

            newSeries.ChartType = SeriesChartType.Line;
            newSeries.BorderWidth = 3;
            return newSeries;
        }
            decimal t, x, y, v0, cosa, sina, S, m, k, vx, vy, L, maxHieght;

        private void Cancle_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            chart.Series.Clear();
        }


        DataTable table = new DataTable();
        private void ShowResults()
        {
            table.Columns.Add("Дальность полёта, м", typeof(decimal));
            table.Columns.Add("Максимальная высота, м", typeof(decimal));
            table.Columns.Add("Скорость в конечной точке, м/с", typeof(decimal));

            dataGridView1.DataSource = table;
        }

        const decimal g = 9.81M, C = 0.15M, rho = 1.29M;
        double a;
        Series nowSeries;
        private void edStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                nowSeries = AddNewSeries();
                t = 0;
                x = 0;
                y = edHieght.Value;
                v0 = edSpeed.Value;
                a = (double)edAngle.Value * Math.PI / 180;
                cosa = (decimal)Math.Cos(a);
                sina = (decimal)Math.Sin(a);
                S = edSize.Value;
                m = edWeight.Value;
                k = 0.5M * C * rho * S / m;
                vx = v0 * cosa;
                vy = v0 * sina;
                nowSeries.Points.AddXY(x, y);
                maxHieght = Math.Max(maxHieght, y);
                chart.Invalidate();
                timer1.Start();
            }
        }



        decimal dt;

        private void timer1_Tick(object sender, EventArgs e)
        {
            dt = edDt.Value;
            t += dt;
            decimal v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            vx = vx - k * vx * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x = x + vx * dt;
            y = y + vy * dt;
            nowSeries.Points.AddXY(x, y);
            maxHieght = Math.Max(maxHieght, y);
            chart.Invalidate();
            if (y <= 0)
            {
                timer1.Stop();
                chart.Series.Add(nowSeries);
                maxHieght = Math.Max(maxHieght, y);
                L = ((v0 * v0) * (decimal)Math.Sin(2 * a)) / g;
                double endV = Math.Sqrt(Math.Pow(Convert.ToDouble(vx), 2) + Math.Pow(Convert.ToDouble(vy), 2));
                
                table.Rows.Add(Math.Round(L, 4), Math.Round(maxHieght, 4), Math.Round(endV, 4));

            }
        }

    }
}
