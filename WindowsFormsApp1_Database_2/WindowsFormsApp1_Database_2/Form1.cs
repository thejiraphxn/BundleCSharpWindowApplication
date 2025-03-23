using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_Database_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conStr = "Provider=Microsoft.Jet.OleDb.4.0;" +
            @"Data Source=D:\6505911\database\Northwind.mdb";
        DataSet data = new DataSet();


        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();


            getProd(conn);
            getCate(conn);

            for (int i = 0; i < data.Tables["Category"].Rows.Count; i++)
            {
                listBox1.Items.Add(data.Tables["Category"].Rows[i]["CategoryName"].ToString());
            }

            textBox1.DataBindings.Add("Text", data, "Category.CategoryId");
            textBox2.DataBindings.Add("Text", data, "Category.CategoryName");
            textBox3.DataBindings.Add("Text", data, "Category.Description");
            ShowPicture(0);

            UpdateGridView(1);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            this.BindingContext[data, "Category"].Position = index;         

            ShowPicture(index);

            UpdateGridView(index + 1);



        }

        void getCate(OleDbConnection conn)
        {
            string query = "SELECT * FROM Categories";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(data, "Category");
        }

        void getProd(OleDbConnection conn)
        {
            string query = "SELECT * FROM Products";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(data, "Products");
        }

        void ShowPicture(int index)
        {
            byte[] imgByte = (byte[])data.Tables["Category"].Rows[index]["Picture"];
            MemoryStream imgStream = new MemoryStream();
            int offset = 78;
            imgStream.Write(imgByte, offset, imgByte.Length-offset);
            
            pictureBox1.Image = Image.FromStream(imgStream);
        }

        void UpdateGridView(int index)
        {
            DataView dv = new DataView(data.Tables["Products"]);
            dv.RowFilter = "CategoryID = " + index;
            dataGridView1.DataSource = dv;
        }

        private void prev_Click(object sender, EventArgs e)
        {
            int pos = this.BindingContext[data, "Category"].Position;
            if (pos == 0) { return; }
            this.BindingContext[data, "Category"].Position -= 1;
            ShowPicture(pos-1);
            UpdateGridView(pos);
        }

        private void next_Click(object sender, EventArgs e)
        {
            int pos = this.BindingContext[data, "Category"].Position;
            if (pos == data.Tables["Category"].Rows.Count-1) { return; }
            this.BindingContext[data, "Category"].Position += 1;
            ShowPicture(pos + 1);
            UpdateGridView(pos + 2);
        }
    }
}
