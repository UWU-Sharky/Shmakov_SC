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
using MathNet.Numerics.Distributions;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            double mu = (double)Mean.Value;
            double variance = (double)Variance.Value;
            double sigma = Math.Sqrt(variance);
            int n = (int)SampleSize.Value;
            int bins = (int)Bins.Value;
            List<double> sample = new Probability().GenerateNormalSample(mu, sigma, n);
            DrawNormalDistribution(sample, mu, variance, bins);
            lblResults.Text = DisplayStatistics(sample, mu, sigma);
            lblChi.Text = CheckChiSquaredNormal(sample, mu, variance, bins);
        }

        private void DrawNormalDistribution(List<double> sample, double mu, double variance, int binCount)
        {
            double sigma = Math.Sqrt(variance);

            chart1.Series["Теория"].Points.Clear();
            chart1.Series["Практика"].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = mu - 4 * sigma; // Запас для краев
            chart1.ChartAreas[0].AxisX.Maximum = mu + 4 * sigma;
            chart1.Series["Практика"]["PointWidth"] = "1";

            double minX = mu - 3 * sigma;
            double maxX = mu + 3 * sigma;
            double binWidth = (maxX - minX) / binCount;
            int[] bins = new int[binCount];

            foreach (var val in sample)
            {
                int index = (int)((val - minX) / binWidth);
                if (index >= 0 && index < binCount) bins[index]++;
            }

            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            for (int i = 0; i < binCount; i++)
            {
                double binStart = minX + i * binWidth;
                double binEnd = binStart + binWidth;
                double binCenter = binStart + binWidth / 2;

                double height = (double)bins[i] / (sample.Count * binWidth);
                chart1.Series["Практика"].Points.AddXY(binCenter, height);

    
                var label = new CustomLabel(binStart, binEnd, $"({binStart:F2}; {binEnd:F2}]", 0, LabelMarkStyle.LineSideMark);
                chart1.ChartAreas[0].AxisX.CustomLabels.Add(label);
            }

            int pointsCount = 100;
            double step = (8 * sigma) / pointsCount;
            for (int i = 0; i < pointsCount; i++)
            {
                double x = (mu - 4 * sigma) + i * step;
                // Формула плотности вероятности нормального распределения
                double y = (1.0 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow(x - mu, 2) / (2 * variance));
                chart1.Series["Теория"].Points.AddXY(x, y);
            }
        }

        public string DisplayStatistics(List<double> sample, double mu, double varTeor)
        {
            int n = sample.Count;

            double mEmp = sample.Average();

            double dEmp = sample.Select(x => Math.Pow(x - mEmp, 2)).Sum() / n;


            // Погрешность мат. ожидания
            double errorM = (mu != 0)
                ? Math.Abs(mu - mEmp) / Math.Abs(mu) * 100
                : Math.Abs(mEmp) * 100; // Если mu = 0, считаем абсолютное отклонение

            // Погрешность дисперсии
            double errorD = (varTeor != 0)
                ? Math.Abs(varTeor - dEmp) / varTeor * 100
                : Math.Abs(dEmp) * 100;

            return $"Мат. ожидание: теор = {mu:F3}, эмп = {mEmp:F3} (погр: {errorM:F2}%)\n" +
            $"Дисперсия: теор = {varTeor:F3}, эмп = {dEmp:F3} (погр: {errorD:F2}%)";
        }

        public string CheckChiSquaredNormal(List<double> sample, double mu, double varTeor, int k)
        {
            int n = sample.Count;
            double sigma = Math.Sqrt(varTeor);
            int df = k - 1;
            double alpha = 0.05;

            double minX = mu - 3 * sigma;
            double maxX = mu + 3 * sigma;
            double step = (maxX - minX) / k;

            int[] observed = new int[k];
            double chiObserved = 0;

            // Считаем частоты 
            foreach (var val in sample)
            {
                int idx = (int)((val - minX) / step);
                if (idx >= 0 && idx < k) observed[idx]++;
            }

            // Считаем статистику
            for (int i = 0; i < k; i++)
            {
                double a = minX + i * step;
                double b = a + step;
                double mid = (a + b) / 2.0;

                // Теоретическая вероятность p_i через плотность в центре интервала
                double p_i = (1.0 / (sigma * Math.Sqrt(2 * Math.PI))) * Math.Exp(-Math.Pow(mid - mu, 2) / (2 * varTeor)) * step;

                double expected = n * p_i;

                if (expected > 0)
                {
                    chiObserved += Math.Pow(observed[i] - expected, 2) / expected;
                }
            }


            double chiCritical = ChiSquared.InvCDF(df, 1 - alpha);
            bool isAccepted = chiObserved <= chiCritical;

            return $"Хи-квадрат: Набл = {chiObserved:F3}, Крит = {chiCritical}\n" +
            $"Результат: {(isAccepted ? "Гипотеза принята ✅" : "Гипотеза отвергнута ❌")}\n\n";
        }

        public class Probability
        {
            public List<double> GenerateNormalSample(double mu, double sigma, int n)
            {
                Random rnd = new Random();
                List<double> sample = new List<double>();

                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < 12; j++) sum += rnd.NextDouble();

                    double val = mu + sigma * (sum - 6);
                    sample.Add(val);
                }
                return sample;
            }
        }
    }
}

