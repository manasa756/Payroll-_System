using Microsoft.Identity.Client;
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
    public partial class EmployeeForm : Form
    {
        ViewForm v = new ViewForm();
        public EmployeeForm()
        {
            InitializeComponent();
        }
        public void ExecuteDbOperation(Action action)
        {
            try
            {
                action();
            }
            catch (SqlException)
            {
                MessageBox.Show("Database operation failed.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        public bool validations()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Employee Name is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (!txtName.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Employee Name should contain letters only",
        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDept.Text))
            {
                MessageBox.Show("Department is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDept.Focus();
                return false;
            }
            if (!txtDept.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Department Name should contain letters only",
        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDept.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDesi.Text))
            {
                MessageBox.Show("Designation is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesi.Focus();
                return false;
            }
            if (!txtDesi.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Designation should contain letters only",
        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSal.Text))
            {
                MessageBox.Show("Basic Salary is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSal.Focus();
                return false;
            }
            if (!decimal.TryParse(txtSal.Text, out decimal basic) || basic <= 0)
            {
                MessageBox.Show("Enter valid Basic Salary", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSal.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtHra.Text))
            {
                MessageBox.Show("HRA is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHra.Focus();
                return false;
            }
            if (!decimal.TryParse(txtHra.Text, out decimal HRA) || HRA <= 0)
            {
                MessageBox.Show("Enter valid HRA Salary", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHra.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDa.Text))
            {
                MessageBox.Show("DA is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDa.Focus();
                return false;
            }
            if (!decimal.TryParse(txtDa.Text, out decimal DA) || DA <= 0)
            {
                MessageBox.Show("Enter valid HRA Salary", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDa.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPf.Text))
            {
                MessageBox.Show("Pf is required", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPf.Focus();
                return false;
            }
            if (!decimal.TryParse(txtPf.Text, out decimal Pf) || Pf <= 0)
            {
                MessageBox.Show("Enter valid HRA Salary", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPf.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!validations())
                return;

            ExecuteDbOperation(() =>
            {

                using (SqlConnection con = DB.GetConnection())
                {

                    string query = "insert into employees values(@Name,@dept,@desi,@Basic,@Hra,@Da,@Pf)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    // cmd.Parameters.AddWithValue("@id", txtId.Text);

                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                    cmd.Parameters.AddWithValue("@desi", txtDesi.Text);
                    cmd.Parameters.AddWithValue("@Basic", decimal.Parse(txtSal.Text));
                    cmd.Parameters.AddWithValue("@Hra", decimal.Parse(txtHra.Text));
                    cmd.Parameters.AddWithValue("@Da", decimal.Parse(txtDa.Text));
                    cmd.Parameters.AddWithValue("@Pf", decimal.Parse(txtPf.Text));
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed");
                    }
                }


                Get_details();
                clear_details();


            });
        }
        public static DataTable Get_employee()
        {
            
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "select*from employees";
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;

                }
            
            


        }
        public void Get_details()
        {
            try
            {
                Employee_Datagrid.DataSource = Get_employee();
                if (Employee_Datagrid.Columns.Contains("employeeid"))
                {
                    Employee_Datagrid.Columns["employeeid"].Visible = false;
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

        private void Employee_Datagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void clear_details()
        {
            txtName.Text = "";
            txtDept.Text = "";
            txtDesi.Text = "";
            txtSal.Text = "";
            txtHra.Text = "";
            txtDa.Text = "";
            txtPf.Text = "";
        }


        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            Get_details();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validations())
                return;
            ExecuteDbOperation(() =>
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "update employees set Name=@name,Department=@dept,Designation=@desi,BasicSalary =@sal,HRA=@Hra,DA=@Da,PF=@Pf where employeeid=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", txtId.Text);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                    cmd.Parameters.AddWithValue("@desi", txtDesi.Text);
                    cmd.Parameters.AddWithValue("@sal", Convert.ToDecimal(txtSal.Text));
                    cmd.Parameters.AddWithValue("@Hra", Convert.ToDecimal(txtHra.Text));
                    cmd.Parameters.AddWithValue("@Da", Convert.ToDecimal(txtDa.Text));
                    cmd.Parameters.AddWithValue("@Pf", Convert.ToDecimal(txtPf.Text));
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Updated Details Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Not Updated Details");
                    }

                }
                Get_details();


            });
        }


        private void Employee_Datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Employee_Datagrid.Rows[e.RowIndex];
                txtId.Text = row.Cells["employeeid"].Value.ToString();

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtDept.Text = row.Cells["Department"].Value.ToString();
                txtDesi.Text = row.Cells["Designation"].Value.ToString();
                txtSal.Text = row.Cells["BasicSalary"].Value.ToString();
                txtHra.Text = row.Cells["HRA"].Value.ToString();
                txtDa.Text = row.Cells["DA"].Value.ToString();
                txtPf.Text = row.Cells["PF"].Value.ToString();



            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!validations())
                return;
            ExecuteDbOperation(() =>
            {
                using (SqlConnection con = DB.GetConnection())
                {
                    string query = "delete from employees where employeeid=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deleted Details Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Not Deleted Details");
                    }


                }
                Get_details();
                clear_details();
            });
        }
        

        private void btnclr_Click(object sender, EventArgs e)
        {
            clear_details();
        } 
    }
}
