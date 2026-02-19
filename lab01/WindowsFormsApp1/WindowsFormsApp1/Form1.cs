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
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 20;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 20;
            chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0;
        }

        decimal t, x, y, v0, cosa, sina, S, m, k, vx, vy;

        private void Cancle_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        const decimal g = 9.81M, C = 0.15M, rho = 1.29M;

        private void edStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                chart.Series[0].Points.Clear();
                t = 0;
                x = 0;
                y = edHieght.Value;
                v0 = edSpeed.Value;
                double a = (double)edAngle.Value * Math.PI / 180;
                cosa = (decimal)Math.Cos(a);
                sina = (decimal)Math.Sin(a);
                S = edSize.Value;
                m = edWeight.Value;
                k = 0.5M * C * rho * S / m;
                vx = v0 * cosa;
                vy = v0 * sina;
                chart.Series[0].Points.AddXY(x, y);
                chart.Invalidate();
                timer1.Start();
            }
        }

        const decimal dt = 0.000001M;

        private void timer1_Tick(object sender, EventArgs e)
        {
            t += dt;
            decimal v = (decimal)Math.Sqrt((double)(vx * vx + vy * vy));
            vx = vx - k * vx * v * dt;
            vy = vy - (g + k * vy * v) * dt;
            x = x + vx * dt;
            y = y + vy * dt;
            chart.Series[0].Points.AddXY(x, y);
            chart.Invalidate();
            if (y <= 0) timer1.Stop();
        }

    }
}
