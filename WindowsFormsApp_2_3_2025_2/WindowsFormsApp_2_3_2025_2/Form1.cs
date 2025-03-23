using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_2_3_2025_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.DefaultExt = ".rtf";
                try
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try 
                { 
                    richTextBox1.LoadFile(openFileDialog1.FileName);
                } catch( Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
