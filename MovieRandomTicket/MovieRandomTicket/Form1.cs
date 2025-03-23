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
    public partial class Form1 : Form
    {
        public static int cashVal = 0;
        public static int ticketNum = 0;
        public static int ticketChance = 0;
        public static String[] MoviesName = { "The Djinn's Curse", "A Haunting in Venice", "Talk To Me", "The Nun II", "Barbie", "Oppenheimer", "MAN SUANG", "Retribution", "Sleep", "The Queen Mary" };
        List<String> GetTickets = new List<String>();
        List<String> ChanceTickets = new List<String>();
        List<String> GetTicketsPic = new List<String>();
        List<String> ChanceTicketsPic = new List<String>();
        List<String> AllTickets = new List<String>();
        List<String> AllTicketsPic = new List<String>();

        public Form1()
        {
            InitializeComponent();
            cashpic1.Load(Application.StartupPath + "/" + "cash50.jpg");
            cashpic2.Load(Application.StartupPath + "/" + "cash100.jpg");
            cashpic3.Load(Application.StartupPath + "/" + "cash500.jpg");
            cashpic4.Load(Application.StartupPath + "/" + "cash1000.jpg");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Tutorial_Click(object sender, EventArgs e)
        {
            Form2 PopUp = new Form2();
            PopUp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random RanMovie = new Random();
            Random RanTicket = new Random();
            int RanTicketNum = 0;
            if (Cash50.Checked)
            {
                cashVal = 50;
                ticketNum = 1;
                ticketChance = 0;
            } else if (Cash100.Checked)
            {
                cashVal = 100;
                ticketNum = 2;
                ticketChance = RanTicket.Next(0, 2);
            } else if (Cash500.Checked)
            {
                cashVal = 500;
                ticketNum = 5;
                ticketChance = RanTicket.Next(1, 5);
            } else if (Cash1000.Checked)
            {
                cashVal = 1000;
                ticketNum = 7;
                ticketChance = RanTicket.Next(1, 4);
            }
            else if(Cash50.Checked == false && Cash100.Checked == false && Cash500.Checked == false && Cash1000.Checked == false)
            {
                MessageBox.Show("Please click some radiobox");
            }


            if (cashVal != 0)
            {
                // GetTicket
                for (int i = 1; i <= ticketNum; i++)
                {
                    RanTicketNum = RanMovie.Next(0, 10);
                    GetTickets.Add(MoviesName[RanTicketNum].ToString());
                    GetTicketsPic.Add(((RanTicketNum + 1) + ".png").ToString());
                    AllTickets.Add(MoviesName[RanTicketNum].ToString());
                    AllTicketsPic.Add(((RanTicketNum + 1) + ".png").ToString());
                }

                // GetChanceTicket
                if (ticketChance != 0)
                {
                    for (int j = 1; j <= ticketChance; j++)
                    {
                        RanTicketNum = RanMovie.Next(0, 10);
                        ChanceTickets.Add(MoviesName[RanTicketNum].ToString());
                        ChanceTicketsPic.Add(((RanTicketNum + 1) + ".png").ToString());
                        AllTickets.Add(MoviesName[RanTicketNum].ToString());
                        AllTicketsPic.Add(((RanTicketNum + 1) + ".png").ToString());
                    }
                }

                try
                {
                    TicketData.AllTicketNum = Convert.ToInt16(ticketNum + ticketChance);
                    TicketData.NormalTicket = GetTickets.ToArray();
                    TicketData.ChanceTicket = ChanceTickets.ToArray();
                    TicketData.AllGetTicket = AllTickets.ToArray();
                    TicketData.AllGetTicketPic = AllTicketsPic.ToArray();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }


                Form TicketShow = new Form3();
                TicketShow.ShowDialog();
            }


            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TicketData.AllTicketNum = 0;
            //TicketData.NormalTicket = new string[0];
            //TicketData.ChanceTicket = new string[0];
            //TicketData.AllGetTicket = new string[0];
            //TicketData.AllGetTicketPic= new string[0];
        }
    }
}
