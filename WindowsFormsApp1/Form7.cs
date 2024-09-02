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

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T2IKS8\\SQLEXPRESS;Initial Catalog=phymacy02;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;
        string id;
        SqlDataAdapter da;




        private void button1_Click(object sender, EventArgs e)
        {
            string sid = textBox1.Text;
            string book = textBox2.Text;
            string rdate = textBox3.Text;
            string elap = textBox4.Text;
            string fine = textBox5.Text;






            sql = "insert into returnbook(studentId,returndate,elap,fine)values(@studentId,@returndate,@elap,@fine)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@studentId", sid);
                cmd.Parameters.AddWithValue("@returndate", book);
                cmd.Parameters.AddWithValue("@returndate", rdate);
                cmd.Parameters.AddWithValue("@elap", elap);
                cmd.Parameters.AddWithValue("@fine", fine);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Book Returned Sucsses!!!!!!!");
                con.Close();

            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                cmd = new SqlCommand("select book,issuebook,returnbook,DATEDIFF(dd,returnbook,GETDATE()) as elap from sissebook where stuid= '" +textBox1.Text+"'",con);

                con.Open();
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    textBox2.Text = dr["book"].ToString();
                    textBox3.Text = dr["returnbook"].ToString();
                    string elap = dr["elap"].ToString();

                    int elapp = int.Parse(elap);
                    

                    if(elapp>0)
                    {
                        textBox4.Text = elap;
                        int fine = elapp * 100;
                        textBox5.Text = fine.ToString();
                    }
                    else
                    {
                        textBox4.Text = "0";
                        textBox5.Text = "0";
                    }

                }
                con.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form3 f44 = new Form3();
            f44.Show();
        }
    }
}
