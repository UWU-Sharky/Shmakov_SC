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
            answers.Add("Да");
            answers.Add("Возможно");
            answers.Add("Скорее да, чем нет");
            answers.Add("Наверное");
            answers.Add("Скорее нет, чем да");
            answers.Add("Мало вероятно");
            answers.Add("Нет");
            answers.Add("Спросите позже");
        }

        public static List<String> answers = new List<String>();

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
            for(int i = 0; i < answers.Count(); i++)
            {
                x = x - (double)(1.0 / answers.Count());
                if (x <= 0)
                {
                    return(answers[i]);
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
