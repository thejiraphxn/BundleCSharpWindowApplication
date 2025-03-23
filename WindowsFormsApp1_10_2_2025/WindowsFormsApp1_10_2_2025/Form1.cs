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

namespace WindowsFormsApp1_10_2_2025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string drv in Directory.GetLogicalDrives())
            {
                comboBox1.Items.Add(drv);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] dir = Directory.GetDirectories(comboBox1.SelectedItem.ToString());
            foreach (string drv in dir)
            {
                
                listBox1.Items.Add(drv);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string item = listBox1.SelectedItem.ToString();
            foreach (string f in Directory.GetFiles(item))
            {
                listBox2.Items.Add(f);
            }
        }
    }
}
