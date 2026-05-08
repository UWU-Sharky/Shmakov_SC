using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private double[,] Q;

        public Form1()
        {
            InitializeComponent();
            Q = new double[3, 3];
        }

        private TextBox[,] _matrixFields;

        private void InitializeFields()
        {
            _matrixFields = new TextBox[,] {
        { Clear_Clear,  Clear_Cloudy,  Clear_Glomy  },
        { Cloudy_Clear, Cloudy_Cloudy, Cloudy_Glomy },
        { Glomy_Clear,  Glomy_Cloudy,  Glomy_Glomy  }
            };
        }

        public void Parse_Intensity()
        {
            if (_matrixFields == null) InitializeFields();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Q[i, j] = StringExtensions.ToDecimal(_matrixFields[i, j].Text);
                }
            }
        }

        public void Input_Intensity()
        {
            if (_matrixFields == null) InitializeFields();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _matrixFields[i, j].Text = Q[i, j].ToString();
                }
            }
        }

        public bool Norm_Condition()
        {
            for (int i = 0; i < Q.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < Q.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        sum += Q[i, j];
                    }
                    else
                    {
                        continue;
                    }
                }
                if (sum + Q[i, i] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void Norm_Click(object sender, EventArgs e)
        {
            Parse_Intensity();
            if (!Norm_Condition())
            {
                for (int i = 0; i < Q.GetLength(0); i++)
                {
                    double sum = 0;
                    for (int j = 0; j < Q.GetLength(1); j++)
                    {
                        if (i != j)
                        {
                            sum += Q[i, j];
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (Q[i, i] != -sum)
                    {
                        Q[i, i] = -sum;
                    }
                    for (int j = 0; j < Q.GetLength(1); j++)
                    {
                        Q[i, j] /= sum;
                    }
                }
                Input_Intensity();
                MessageBox.Show("Матрица  отнормирована.");
            }

        }

        public void Start_Click(object sender, EventArgs e)
        {
            Parse_Intensity();
            if (Norm_Condition())
            {
                listBox1.Items.Clear();

                double[] theoreticalProbabilities = Calculate_Theoretical_Probabilities();
                double[] empiricalProbabilities = Calculate_Empirical_Probabilities(theoreticalProbabilities);

                double[] error = new double[3];
                for (int i = 0; i < 3; i++)
                    error[i] = Math.Abs(empiricalProbabilities[i] - theoreticalProbabilities[i]);

                string[] weathers = new string[3] { "Ясно", "Облачно", "Пасмурно" };

                listBox1.Items.Add("Статистика сравнения вероятностей");
                listBox1.Items.Add("\n");
                for (int i = 0; i < 3; i++)
                {
                    listBox1.Items.Add($"Состояние {weathers[i]}:");
                    listBox1.Items.Add($"   Теоретическая вероятность = {theoreticalProbabilities[i]:F6}");
                    listBox1.Items.Add($"   Эмпирическая вероятность = {empiricalProbabilities[i]:F6}");
                    listBox1.Items.Add($"   Ошибка = {error[i]:F6}");
                    listBox1.Items.Add("\n");

                }
                listBox1.Items.Add($"Количество переходов = {steps}");

                string fileName = "weather_statistics.csv";

                string folder = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(folder, fileName);

                using (StreamWriter sw = new StreamWriter(fullPath, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("Состояние;Время (дни);Эмпирическая вероятность;Теоретическая вероятность;Абсолютная ошибка");
                    for (int i = 0; i < 3; i++)
                    {
                        sw.WriteLine($"{weathers[i]};{Durations[i]:F4};{empiricalProbabilities[i]:F6};{theoreticalProbabilities[i]:F6};{error[i]:F6}");
                    }
                    sw.WriteLine();
                    sw.WriteLine("Переходы (из -> в):");
                    sw.WriteLine("Из\\В;Ясно;Облачно;Пасмурно");
                    for (int i = 0; i < 3; i++)
                    {
                        sw.Write($"{weathers[i]};");
                        for (int j = 0; j < 3; j++)
                            sw.Write($"{transition[i, j]};");
                        sw.WriteLine();
                    }
                    sw.WriteLine();
                    sw.WriteLine($"Количество переходов: {steps}");
                }

                listBox1.Items.Add($"Статистика сохранена в файл: {fileName}");
            }
            else
            {
                MessageBox.Show("Матрица не нормирована.");
            }
        }

        public double[] Calculate_Theoretical_Probabilities()
        {
            var A = Matrix<double>.Build.DenseOfArray(Q);
            var AT = A.Transpose();

            for (int j = 0; j < AT.ColumnCount; j++)
                AT[AT.RowCount - 1, j] = 1;

            var b = Vector<double>.Build.Dense(AT.RowCount);
            b[b.Count - 1] = 1;

            var pi = AT.Solve(b);

            double[] Arr = pi.ToArray();

            return Arr;
        }

        private static BigInteger lastSeed = 1;

        private static BigInteger a = 1664525;

        private static BigInteger c = 1013904223;

        private static BigInteger M = BigInteger.Pow(2, 32);

        public static double LKG()
        {
            lastSeed = (a * lastSeed + c) % M;

            double x = (double)lastSeed / (double)M;

            return x;
        }

        public static double GetExpRV(double q)
        {
            double u = LKG();
            return -Math.Log(1 - u) / q;
        }

        private double[,] _IntensityIJ;
        private void InitializeIntensity()
        {
            _IntensityIJ = new double[3, 3];
            for (int i = 0; i < Q.GetLength(0); i++)
            {
                double lambdaI = Math.Abs(Q[i, i]);

                for (int j = 0; j < Q.GetLength(1); j++)
                {
                    if (i != j && lambdaI > 0)
                        _IntensityIJ[i, j] = Q[i, j] / lambdaI;
                    else
                        _IntensityIJ[i, j] = 0;
                }
            }
        }

        public double GetNextState(int stage)
        {
            if (_IntensityIJ == null) InitializeIntensity();
            double a = LKG();

            for(int i = 0; i < _IntensityIJ.GetLength(1); i++)
            {
                a -= _IntensityIJ[stage, i];
                if (a <= 0)
                {
                    return i;
                }
            }
            return -1; 
        }

        private int steps;

        private double[] Durations;

        private int[,] transition;
        public double[] Calculate_Empirical_Probabilities(double[] Arr)
        {
            steps = 0;

            double maxValue = Arr.Max();

            int Current_State = Array.IndexOf(Arr, maxValue);

            chart1.Series[0].Points.Clear();

            chart1.Series[0].Points.AddXY(0, Current_State);

            double totalDays = (double)TotalDays.Value;

            transition = new int[3, 3];

            double t = 0;

            Durations = new double[3];

            while (t < totalDays)
            {
                double dt = GetExpRV(Math.Abs(Q[Current_State, Current_State]));

                if (t + dt < totalDays)
                {
                   Durations[Current_State] += dt;

                    t += dt;

                    steps++;

                    chart1.Series[0].Points.AddXY(t, Current_State);

                    int previousState = Current_State;

                    Current_State = (int)GetNextState(Current_State);

                    transition[previousState, Current_State]++;

                    chart1.Series[0].Points.AddXY(t, Current_State);
                }
                else
                {
                    double diff = totalDays - t;

                    Durations[Current_State] += diff;

                    t = totalDays;

                    chart1.Series[0].Points.AddXY(totalDays, Current_State);
                }
            }

            double[] empirical = new double[3];
            for (int i = 0; i < 3; i++)
                empirical[i] = Durations[i] / totalDays;

            return empirical;

        }


    }

    public static class StringExtensions
    {
        public static double ToDecimal(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;

            string normalized = input.Replace(',', '.');

            if (double.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            return 0;
        }
    }

}
