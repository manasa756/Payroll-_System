using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewForm view = new ViewForm();
            view.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeForm emp = new EmployeeForm();
            emp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalaryCalculation sal = new SalaryCalculation();
            sal.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          DialogResult dr= MessageBox.Show("Are you sure you want to exit ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Form1 logout = new Form1();
                logout.Show();
                this.Hide();
            }
            
        }
    }
}
