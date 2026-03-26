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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Dictionary<String, double> answers = new Dictionary<String, double>()
        {
            {"Да", 0.125},
            {"Возможно", 0.125},
            {"Скорее да, чем нет", 0.125},
            {"Наверное", 0.125},
            {"Скорее нет, чем да", 0.125},
            {"Мало вероятно", 0.125},
            {"Нет", 0.125},
            {"Спросите позже", 0.125},

        };


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
        public static string Answer()
        {
            double x = LKG();
            foreach(var ans in answers)
            {
                x = x - (double)(ans.Value);
                if (x <= 0)
                {
                    return(ans.Key);
                }
            }
            return "Error";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            answer.Text = Answer();
        }
    }
}
