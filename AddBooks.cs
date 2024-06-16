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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                // Validation code starts here

                try
                {
                    Int64 quan = Int64.Parse(txtQuantity.Text);
                    Int64 price = Int64.Parse(txtPrice.Text);
                    
                    String bname = txtBookName.Text;
                    String bauthor = txtAuthor.Text;
                    String publication = txtPublication.Text;
                    String pdate = dateTimePicker1.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Data Source=BT-2105617\\SQLEXPRESS;Initial Catalog=library;Integrated Security=True;";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuant) values ('" + bname + "','" + bauthor + "','" + publication + "','" + pdate + "'," + price + "," + quan + ")";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBookName.Clear();
                    txtAuthor.Clear();
                    txtPublication.Clear();
                    txtQuantity.Clear();
                    txtPrice.Clear();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter valid integer values for price and quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty field not allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Delete your unsaved Data.", "Are you Sure? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
    

}
