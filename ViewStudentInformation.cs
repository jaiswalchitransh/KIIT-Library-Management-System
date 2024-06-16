using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Library_Management_System
{
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }
        private void txtSearchEnrollment_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchEnrollment.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewStudent where enroll LIKE '"+txtSearchEnrollment.Text+"%' ";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;

                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from NewStudent";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;

                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewStudent"; 

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd; 

            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];

        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible=true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from NewStudent where stuid = "+bid+" ";

            SqlDataAdapter DA = new SqlDataAdapter();
            DA.SelectCommand = cmd;

            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            txtSName.Text = DS.Tables[0].Rows[0][1].ToString();
            txtEnrollment.Text= DS.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text= DS.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = DS.Tables[0].Rows[0][4].ToString();
            txtContact.Text = DS.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = DS.Tables[0].Rows[0][6].ToString();



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sname = txtSName.Text;
            String enroll = txtEnrollment.Text;
            String dep = txtDepartment.Text;
            String sem = txtSemester.Text;
            Int64 contact = Int64.Parse(txtContact.Text);
            String semail = txtEmail.Text;

            if (MessageBox.Show("Are you Sure? ", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update NewStudent set sname = '" + sname + "',enroll = '" + enroll + "',dep = '" + dep + "',sem=  '" + sem + "',contact = " + contact + ",email = '" + semail + "' where stuid = " + rowid + "";

                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;

                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this,null);
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure? ", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from NewStudent where stuid = " + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter();
                DA.SelectCommand = cmd;

                DataSet DS = new DataSet();
                DA.Fill(DS);

                ViewStudentInformation_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Unsaved Data will be lost","Are you Sure?",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
            this.Close();

            }

        }
    }
}
