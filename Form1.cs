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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_kiitlogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kiit.ac.in/");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from logintable where username = '"+txtLoginID.Text+"' and pass = '"+txtPass.Text+"'    "; 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
