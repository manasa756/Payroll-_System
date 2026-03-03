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


namespace Payroll_System
{

    public partial class ViewForm : Form
    {
        
        public ViewForm()
        {
            InitializeComponent();
        }
        
        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            viewgrid.DataSource = EmployeeForm.Get_employee();

            if (viewgrid.Columns.Contains("employeeid"))
            {
                viewgrid.Columns["employeeid"].Visible = false;
            }
        }
    }
}
