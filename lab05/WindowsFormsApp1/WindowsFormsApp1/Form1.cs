using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static BigInteger lastSeed = 1;

        private static BigInteger a = 1664525;

        private static BigInteger c = 1013904223;

        private static BigInteger M = BigInteger.Pow(2, 32);
        public static double LKG()
        {
            lastSeed = (a*lastSeed + c) % M;

            double x = (double)lastSeed / (double)M;

            return x;
        }

        private void Answer_Click(object sender, EventArgs e)
        {
            double probability = 0.5;

            double x = LKG();

            if (x < probability)
            {
                request.Text = $"Результат: Нет {x}";
            }
            else
            {
                request.Text = $"Результат: Да {x}";
            }
        }

        private void request_Enter(object sender, EventArgs e)
        {
            if (request.Text == "Введите свой запрос" || request.Text == "Результат: Да" || request.Text == "Результат: Нет")
            {
                request.Text = "";
            }
        }
    }
}
