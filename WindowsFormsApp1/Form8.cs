using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String us, paw;
            us = textBox1.Text;
            paw = textBox2.Text;

            if(us== "add" && paw == "123")
            {
                MessageBox.Show("Succes!!!!!!!!");
                Form3 f178 = new Form3();
                f178.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("error");
            }

        }
    }
}
