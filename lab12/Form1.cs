using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        string fileContent;
        string filePath;
        string result;

        public Form1()
        {
            InitializeComponent();
            fileContent = "Это простой текст для проверки программы";
            textBoxFile.Text = fileContent;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            textBoxFile.Text = fileContent;




            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            string[] array = fileContent.Split();

            char c = textBoxChar.Text.ToCharArray()[0];
            int result_i = 0;
            int max_count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                foreach (var ch in array[i].ToCharArray())
                {
                    if (c == ch)
                    {
                        count++;
                    }
                }
                if (count > max_count)
                {
                    result_i = i;
                    max_count = count;
                }
            }
            result = $"Больше всего символов '{c}' содержится с слове '{array[result_i]}'";

            textBoxResult.Text = result;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, result);
                }
            }
        }
    }
}
