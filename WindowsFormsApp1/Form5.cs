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
    public partial class Form5 : Form
    {
        public Form5()
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
            sql = "select * from sun ";
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
            sql = "select * from sun where id= '" + id + "' ";
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



        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fn = textBox1.Text;
            string ag = textBox2.Text;
            string cit = textBox3.Text;
            string ph = textBox4.Text;
            string em = textBox5.Text;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (Mode == true)
            {
                sql = "insert into sun(name,age,city,phone,email)values(@name,@age,@city,@phone,@email)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", fn);
                cmd.Parameters.AddWithValue("@age", ag);
                cmd.Parameters.AddWithValue("@city", cit);
                cmd.Parameters.AddWithValue("@phone", ph);
                cmd.Parameters.AddWithValue("@email", em);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Add To data!!!!!!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();


            }
            else
            {
                sql = "update sun set name=@name,age=@age,city=@city,phone=@phone,email=@email where id=@id";

                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", fn);
                cmd.Parameters.AddWithValue("@age", ag);
                cmd.Parameters.AddWithValue("@city", cit);
                cmd.Parameters.AddWithValue("@phone", ph);
                cmd.Parameters.AddWithValue("@email", em);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Student update!!!!!!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
            }
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

                sql = "delete from sun where id=@id";

                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Student deleted!!!!!!");

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
