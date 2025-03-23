using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MovieRandomTicket.TicketData;

namespace MovieRandomTicket
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            PictureBox[] PictureTicket = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10};

            //MessageBox.Show(TicketData.AllGetTicketPic[0].ToString());
            for (int i = 0; i < TicketData.AllTicketNum; i++)
            {
                //MessageBox.Show(TicketData.AllGetTicketPic[i].ToString());
                PictureTicket[i].Load(Application.StartupPath + "/" + TicketData.AllGetTicketPic[i]);
            }
            MessageBox.Show($"You got all ticket(s) : {TicketData.AllTicketNum} \r\n" +
                            $"Random Ticket(s) : {TicketData.NormalTicket.Count()} \r\n" +
                            $"Chance Ticket(s) : {TicketData.ChanceTicket.Count()}");
        }
    }
}
