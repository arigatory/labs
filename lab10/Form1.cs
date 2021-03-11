using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDownN.Value = 4;
        }

        void Print(int[,] A)
        {
            textBoxMatrix.Text = "";
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    textBoxMatrix.Text += string.Format("{0,5}", A[i, j]);
                }
                textBoxMatrix.Text += "\r\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int N = (int) numericUpDownN.Value;
            int[,] A = new int[N, N];

            int maximum_i = 0;
            int maximum_j = N - 1;
            int maximum = A[0, N - 1];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = random.Next(100);
                    if (i + j == N - 1 && A[i, j] > maximum)
                    {
                        maximum = A[i, j];
                        maximum_i = i;
                        maximum_j = j;
                    }

                }
            }
            Print(A);

            textBoxResult.Text = "";
            for (int i = 0; i < N; i++)
            {
                textBoxResult.Text += string.Format("{0,5}", A[maximum_i, i]);
            }
        }

            
     }

 }
