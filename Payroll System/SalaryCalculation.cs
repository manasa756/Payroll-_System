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

namespace Payroll_System
{
    public partial class SalaryCalculation : Form
    {
        public SalaryCalculation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal basic = Convert.ToDecimal(txtsal.Text);
            decimal Hra = Convert.ToDecimal(txtHra.Text);
            decimal Da = Convert.ToDecimal(txtDa.Text);
            decimal Pf = Convert.ToDecimal(txtPf.Text);
            decimal netsalary = basic + Hra + Da - Pf;

            txtNet.Text = netsalary.ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "select BasicSalary,HRA,DA,PF from employees where employeeid=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtsal.Text = reader["Basicsalary"].ToString();
                        txtHra.Text = reader["HRA"].ToString();
                        txtDa.Text = reader["DA"].ToString();
                        txtPf.Text = reader["PF"].ToString();


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

        private void SalaryCalculation_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "select employeeid,Name from employees";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "employeeid";
                    comboBox1.DataSource = dt;

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
