using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_DATABASE_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conStr = "Provider=Microsoft.Jet.OleDb.4.0;" +
            @"Data Source=D:\6505911\database\Northwind.mdb";
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();

            string query = "SELECT * FROM Customers";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet data = new DataSet();

            adapter.Fill(data, "cus");
            for (int i = 0; i < data.Tables["cus"].Rows.Count; i++)
            {
                listBox1.Items.Add(data.Tables["cus"].Rows[i]["Address"].ToString());
            }
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
