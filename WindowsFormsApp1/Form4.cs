using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            loard();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T2IKS8\\SQLEXPRESS;Initial Catalog=phymacy02;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;
        string id;

        private void loard()
        {
            sql = "select * from book ";
            cmd = new SqlCommand(sql, con);

            con.Open();

            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);

            }
            con.Close();
        }

        public void getid(string id)
        {
            sql = "select * from book where id= '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();




            }

            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string bname = textBox1.Text;
            string auth = textBox2.Text;
            string publi = textBox3.Text;
            string pri = textBox4.Text;
            string pag = textBox5.Text;

            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "insert into book(bookname,author,publisher,price,pages)values(@bookname,@author,@publisher,@price,@pages)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bookname", bname);
                cmd.Parameters.AddWithValue("@author", auth);
                cmd.Parameters.AddWithValue("@publisher", publi);
                cmd.Parameters.AddWithValue("@price", pri);
                cmd.Parameters.AddWithValue("@pages", pag);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Created succse!!!!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();

               
            }
            else
            {
                sql = "update book set bookname=@bookname ,author=@author,publisher=@publisher,price=@price,pages=@pages where id=@id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@bookname", bname);
                cmd.Parameters.AddWithValue("@author", auth);
                cmd.Parameters.AddWithValue("@publisher", publi);
                cmd.Parameters.AddWithValue("@price", pri);
                cmd.Parameters.AddWithValue("@pages", pag);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update succse!!!!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {

                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                sql = "delete from book where id=@id";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted  succse!!!!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
                con.Close();

            }
        }
    }
}