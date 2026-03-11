using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void esStart_Click(object sender, EventArgs e)
        {
            int num = (int)numericUpDown1.Value;
            Form1 newForm = new Form1(num);
            newForm.Show();
            this.Hide();
        }
    }
}
