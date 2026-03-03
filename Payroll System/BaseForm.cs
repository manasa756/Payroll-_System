using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Payroll_System
{
    public class BaseForm : Form
    {
        protected void ExecuteWithTryCatch(Action action)
        {
            try
            {
                action();
            }
            catch (SqlException)
            {
                MessageBox.Show("Database operation failed. Please try again.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong. Please contact support.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}