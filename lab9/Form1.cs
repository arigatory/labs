using System;
using System.Windows.Forms;

namespace lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            labelArray.Text = "";

            double[] numbers = new double[20];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.NextDouble() * (9 + 3) - 3;
                labelArray.Text += string.Format("{0,10:0.0}", numbers[i]);
                if (i == 9)
                {
                    labelArray.Text += "\n\n";
                }
            }
            int first_negative_i = 0;
            int second_negative_i = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    first_negative_i = i;
                    break;
                }
            }
            for (int j = first_negative_i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < 0)
                {
                    second_negative_i = j;
                    break;
                }
            }
            labelNewArray.Text = "";
            double sum = 0;
            if (second_negative_i - first_negative_i > 1)
            {
                for (int i = first_negative_i + 1; i < second_negative_i; i++)
                {
                    sum += numbers[i];
                    labelNewArray.Text += string.Format("{0,10:0.0}", numbers[i]);
                }
                labelSum.Text = string.Format("{0,10:0.0}", sum);
            }
            else
            {
                labelNewArray.Text += "Между первым и вторым отрицательными элементами нет положительных чисел";
            }
            labelSum.Text = string.Format("{0,10:0.0}", sum);
        }
    }
}
