using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;


namespace Payroll_System
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "select *from users where username=@user and Password=@pass";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", nametx.Text);
                    cmd.Parameters.AddWithValue("@pass", int.Parse(passtx.Text));
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Login Successful", "about login details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dashboard board = new Dashboard();
                        board.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed", "about login details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed to load employee data.",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        
    }
}
