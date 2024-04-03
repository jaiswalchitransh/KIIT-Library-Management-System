using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername(object sender, EventArgs e)
        {
            
        }

        private void txtPassword(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }
        private void txtLoginID_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtLoginID.Text == "Login ID")
            {
                txtLoginID.Clear();
            }

        }

        private void txtPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Clear();
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
