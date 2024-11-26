using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_CRUD_using_ADO.Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Sno;
            string Sname;
            int Fee;

            conn.Open();
            cmd.Connection=conn;
            Sno=int.Parse(textBox1.Text);
            Sname=textBox2.Text;
            Fee=int.Parse(textBox3.Text);
            cmd.CommandText = "insert into studentinfo values(" + Sno + "," + Sname + "," + Fee +")";
            cmd.ExecuteNonQuery();
            conn.Close();   
        }

      

        private System.Data.SqlClient.SqlConnection conn = null;
        private System.Data.SqlClient.SqlCommand cmd = null;
        public System.Data.SqlClient.SqlDataReader reader = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new System.Data.SqlClient.SqlConnection("data source=Lakshmi\\SQLEXPRESS; integrated security=true; database=CRUDDB;");
            cmd = new System.Data.SqlClient.SqlCommand();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            conn.Open();
            cmd.Connection= conn;
            cmd.CommandText = "select * from studentinfo";
            reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                MessageBox.Show(string.Format("{0}{1}{2}", reader.GetValue(0), reader.GetValue(1), reader.GetValue(2)));
            }
           
            reader.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from studentinfo";
            reader = cmd.ExecuteReader();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
            reader.Close();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Sno = textBox1.Text;
            var Sname = textBox2.Text;
            var Fee= textBox3.Text;
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "update studentinfo SET Sname=" + Sname + ", Fee=" + Fee + "where Sno=" + Sno;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int Sno = int.Parse(textBox1.Text);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from studentinfo where Sno=" + Sno;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                textBox2.Text = reader.GetValue(1).ToString();
                textBox3.Text = reader.GetValue(2).ToString();
            }
          
            reader.Close();
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Sno = int.Parse(textBox1.Text);
            conn.Open();
            cmd.Connection=conn;
            cmd.CommandText = "delete from studentinfo where Sno=" + Sno;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
