using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRandomTicket
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cashpic1.Load(Application.StartupPath + "/" + "cash50.jpg");
            cashpic2.Load(Application.StartupPath + "/" + "cash100.jpg");
            cashpic3.Load(Application.StartupPath + "/" + "cash500.jpg");
            cashpic4.Load(Application.StartupPath + "/" + "cash1000.jpg");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
