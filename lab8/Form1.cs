using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxX.Text = 3.5.ToString();
            textBoxEps.Text = 0.001.ToString();
            labelResult.Text = "Здесь будет результат";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x = 0;

            if (!double.TryParse(textBoxX.Text, out x))
            {
                textBoxX.Text = 0.ToString();
            }

            double eps = double.Parse(textBoxEps.Text);
            if (!double.TryParse(textBoxEps.Text, out eps))
            {
                textBoxEps.Text = (0.1).ToString();
            }
            double result = 0;

            double delta_zero = 1;

            // эффективно считаем следующее слагаемо, используя предыдущее
            int k = 1;
            double delta_next = delta_zero * x * x / 2 / 1;

            while (delta_next >= eps)
            {
                result += delta_next;
                k++;
                delta_next = delta_next * x * x / 2 / k;
            }


            labelResult.Text = "Результат:\n"+result.ToString();
        }
    }
}
