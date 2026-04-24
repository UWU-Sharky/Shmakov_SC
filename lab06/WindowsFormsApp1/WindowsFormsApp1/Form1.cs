using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<NumericUpDown> pInputs;

        public Form1()
        {
            InitializeComponent();
            pInputs = new List<NumericUpDown> { Prob1, Prob2, Prob3, Prob4, Prob5 };
        }

        public void Normalize_Click(object sender, EventArgs e)
        {
            Normalizer.NormalizeProportionally(pInputs);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Normalizer.Check(pInputs))
            {
                double[] pValues = pInputs.Select(x => (double)x.Value).ToArray();
                double[] xValues = new double[] { 1, 2, 3, 4, 5 };
                int sampleSize = (int)SampleSize.Value;
                List<double> sample = new Probability().GenerateSample(xValues, pValues, sampleSize);

                UpdateChart(xValues, pValues, sample);
                lblResults.Text = new Probability().CalculateStatistics(xValues, pValues, sample);
                lblChi.Text = new Probability().CheckChiSquared(pValues, sample, xValues);
            }
            else
            {
                MessageBox.Show("Сумма вероятностей должна быть равна 1. Пожалуйста, отредактируйте значения.");
            }

        }

        private void UpdateChart(double[] xValues, double[] pValues, List<double> results)
        {
            // 1. Очищаем старые данные
            chart1.Series["Теория"].Points.Clear();
            chart1.Series["Практика"].Points.Clear();

            int n = results.Count;

            for (int i = 0; i < xValues.Length; i++)
            {
                double x = xValues[i];

                // Считаем, сколько раз значение x встретилось в выборке
                int count = results.Count(r => r == x);
                double empiricalFreq = (double)count / n; // Эмпирическая частота

                // 2. Добавляем точки на график
                // Аргумент 1: подпись по оси X, Аргумент 2: значение по оси Y
                chart1.Series["Теория"].Points.AddXY(x, pValues[i]);
                chart1.Series["Практика"].Points.AddXY(x, empiricalFreq);
            }
        }
    }

    public class Probability
    {
        public List<double> GenerateSample(double[] xValues, double[] pValues, int sampleSize)
        {
            Random rnd = new Random();
            List<double> sample = new List<double>();

            // 1. Предварительно вычисляем кумулятивные вероятности (границы интервалов)
            double[] cumulativeP = new double[pValues.Length];
            double sum = 0;
            for (int i = 0; i < pValues.Length; i++)
            {
                sum += pValues[i];
                cumulativeP[i] = sum;
            }

            // 2. Цикл генерации выборки
            for (int s = 0; s < sampleSize; s++)
            {
                double u = rnd.NextDouble(); // Число от 0.0 до 1.0

                // 3. Поиск интервала
                for (int i = 0; i < cumulativeP.Length; i++)
                {
                    if (u < cumulativeP[i])
                    {
                        sample.Add(xValues[i]);
                        break;
                    }
                }
            }
            return sample;
        }

        public string CalculateStatistics(double[] xValues, double[] pValues, List<double> sample)
        {
            // --- Теоретические расчеты ---
            double mTeor = 0;
            double mSqTeor = 0;
            for (int i = 0; i < xValues.Length; i++)
            {
                mTeor += xValues[i] * pValues[i];
                mSqTeor += Math.Pow(xValues[i], 2) * pValues[i];
            }
            double dTeor = mSqTeor - Math.Pow(mTeor, 2);

            // --- Эмпирические расчеты (по выборке) ---
            double mEmp = sample.Average();
            double dEmp = sample.Select(val => Math.Pow(val - mEmp, 2)).Average();

            // --- Погрешности (%) ---
            // Добавляем проверку на 0, чтобы избежать деления на ноль
            double errorM = mTeor != 0 ? Math.Abs((mTeor - mEmp) / mTeor) * 100 : 0;
            double errorD = dTeor != 0 ? Math.Abs((dTeor - dEmp) / dTeor) * 100 : 0;

            // --- Вывод результатов (например, в Label или RichTextBox) ---
            return $"Мат. ожидание: теор = {mTeor:F3}, эмп = {mEmp:F3} (погр: {errorM:F2}%)\n" +
            $"Дисперсия: теор = {dTeor:F3}, эмп = {dEmp:F3} (погр: {errorD:F2}%)";
        }
        public string CheckChiSquared(double[] pValues, List<double> sample, double[] xValues)
        {
            int n = sample.Count;
            int k = pValues.Length;
            double chiObserved = 0;

            // 1. Считаем частоты выпадения каждого X
            for (int i = 0; i < k; i++)
            {
                double x = xValues[i];
                int ni = sample.Count(val => val == x); // Сколько раз выпало x
                double expected = n * pValues[i];      // Сколько должно было выпасть

                if (expected > 0)
                {
                    chiObserved += Math.Pow(ni - expected, 2) / expected;
                }
            }

            // 2. Сравниваем с критическим значением (для df = 4, alpha = 0.05)
            double chiCritical = 9.488;
            bool isHypothesisAccepted = chiObserved <= chiCritical;

            // 3. Вывод
            return $"Chi-Square: {chiObserved:F3} (Крит: {chiCritical})\n" +
            $"Результат: {(isHypothesisAccepted ? "Гипотеза принята ✅" : "Гипотеза отвергнута ❌")}";
        }
    }
    public class Normalizer
    {
        public static bool Check(List<NumericUpDown> inputs)
        {
            
            decimal sum = 0;
            foreach (var nud in inputs) sum += nud.Value;
            if (sum == 1) return true;
            else return false;
        }
        public static void NormalizeProportionally(List<NumericUpDown> inputs)
        {
            decimal currentSum = 0;
            foreach (var nud in inputs) currentSum += nud.Value;

            if (currentSum == 0)
            {
                DistributeUniformly(inputs);
                return;
            }

            decimal runningSum = 0;
            for (int i = 0; i < inputs.Count; i++)
            {

                if (i == inputs.Count - 1)
                {
                    inputs[i].Value = Math.Max(0, 1.0m - runningSum);
                }
                else
                {
                    decimal newValue = Math.Round(inputs[i].Value / currentSum, 3);
                    inputs[i].Value = newValue;
                    runningSum += newValue;
                }
            }

            
        }

        private static void DistributeUniformly(List<NumericUpDown> inputs)
        {
            if (inputs.Count == 0) return;

            decimal share = Math.Round(1.0m / inputs.Count, 3);
            decimal runningSum = 0;

            for (int i = 0; i < inputs.Count; i++)
            {
                if (i == inputs.Count - 1)
                {
                    inputs[i].Value = 1.0m - runningSum; // Добираем остаток
                }
                else
                {
                    inputs[i].Value = share;
                    runningSum += share;
                }
            }


        }
        
    }
}