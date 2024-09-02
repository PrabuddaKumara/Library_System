using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            book();
            loard();
            
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T2IKS8\\SQLEXPRESS;Initial Catalog=phymacy02;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;
        string id;
        SqlDataAdapter da;
        

        public void book()
        {
            string query = "select * from book";
            cmd = new SqlCommand(query,con);
            con.Open();
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "bookname";
            comboBox1.ValueMember = "id";
            con.Close();
            
        }
        
        private void loard()
        {
            sql = "select * from sissebook ";
            cmd = new SqlCommand(sql, con);

            con.Open();

            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);

            }
            con.Close();
        }
        public void getid(string id)
        {
            sql = "select * from sissebook where id= '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                comboBox1.Text = dr[2].ToString();
                dateTimePicker1.Text = dr[3].ToString();
                dateTimePicker2. Text = dr[4].ToString();




            }

            con.Close();
        }

        





        private void button1_Click(object sender, EventArgs e)
        {
            string sid = textBox1.Text;
            string sname = textBox2.Text;
            string book = comboBox1.Text;
            string issuedate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string returndate = dateTimePicker2.Value.ToString("yyyy-MM-dd");


            if (Mode == true)
            {


                sql = "insert into sissebook(stuid,book,issuebook,returnbook)values(@stuid,@book,@issuebook,@returnbook)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@stuid", sid);
                //cmd.Parameters.AddWithValue("@stuid", sid);
                cmd.Parameters.AddWithValue("@book", book);

                cmd.Parameters.AddWithValue("@issuebook", issuedate);
                cmd.Parameters.AddWithValue("@returnbook", returndate);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Issued!!!!!!!");
                con.Close();

            }
            else
            {
                /*
                string updateQuery = "UPDATE sissebook SET issuedate = @issuebook WHERE returnbook = @returnbook";
                SqlCommand command = new SqlCommand(updateQuery);
                command.Parameters.AddWithValue("@issuebook", issuedate);
                command.Parameters.AddWithValue("@returnbook",returndate);
                command.ExecuteNonQuery();
                */
            }


        }

        
        
        


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                cmd = new SqlCommand("select * from sun where id= '" + textBox1.Text + "'   ",con);
                con.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    textBox2.Text = dr["name"].ToString();

                }
                else
                {
                    MessageBox.Show("Member Id Not Found");
                }
                con.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 f45 = new Form3();
            f45.Show();
        }
    }
}
