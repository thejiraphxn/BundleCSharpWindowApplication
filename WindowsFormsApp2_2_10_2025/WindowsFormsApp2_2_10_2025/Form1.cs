using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp2_2_10_2025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.DefaultExt = ".csv";
            saveFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (string line in textBox1.Lines)
                {
                    string[] name = line.Split(' ');
                    sw.WriteLine(name[0] + ',' + name[1]);
                }

                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.DefaultExt = ".csv";
            openFileDialog1.Filter = "CSV File (*.csv)|*.csv";
            string line = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while((line = sr.ReadLine()) != null) 
                { 
                    string[] name = line.Split(',');
                    textBox1.Text += (name[0] + ',' + name[1]) + Environment.NewLine;
                }

                //sr.Close();
            }
        }
    }
}
