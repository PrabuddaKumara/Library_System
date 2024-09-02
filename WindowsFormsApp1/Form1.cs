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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0T2IKS8\\SQLEXPRESS;Initial Catalog=phymacy02;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from userlogin where username='" + textBox1.Text + "' and pasword='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = comboBox1.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["usertype"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("Sucsseses you are loging!!!!!" + dt.Rows[i][2]);
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Form3 f1 = new Form3();
                            f1.Show();
                            this.Hide();

                        }
                        else
                        {
                            Form2 f2 = new Form2();
                            f2.Show();
                            this.Hide();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("error");

            }
        }
    }
}
