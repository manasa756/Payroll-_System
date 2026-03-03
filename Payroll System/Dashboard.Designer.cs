namespace Payroll_System
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnadd = new System.Windows.Forms.Button();
            this.btncal = new System.Windows.Forms.Button();
            this.btnlog = new System.Windows.Forms.Button();
            this.btnview = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(34, 42);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(402, 88);
            this.btnadd.TabIndex = 0;
            this.btnadd.Text = "Add Employee";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btncal
            // 
            this.btncal.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncal.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncal.ForeColor = System.Drawing.Color.White;
            this.btncal.Location = new System.Drawing.Point(34, 179);
            this.btncal.Name = "btncal";
            this.btncal.Size = new System.Drawing.Size(402, 88);
            this.btncal.TabIndex = 2;
            this.btncal.Text = "Calculate Salary";
            this.btncal.UseVisualStyleBackColor = false;
            this.btncal.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnlog
            // 
            this.btnlog.BackColor = System.Drawing.Color.Red;
            this.btnlog.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlog.ForeColor = System.Drawing.Color.White;
            this.btnlog.Location = new System.Drawing.Point(545, 179);
            this.btnlog.Name = "btnlog";
            this.btnlog.Size = new System.Drawing.Size(402, 88);
            this.btnlog.TabIndex = 3;
            this.btnlog.Text = "Log Out";
            this.btnlog.UseVisualStyleBackColor = false;
            this.btnlog.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnview
            // 
            this.btnview.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnview.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.ForeColor = System.Drawing.Color.White;
            this.btnview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnview.Location = new System.Drawing.Point(545, 42);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(402, 88);
            this.btnview.TabIndex = 1;
            this.btnview.Text = "View Employees";
            this.btnview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnview.UseVisualStyleBackColor = false;
            this.btnview.Click += new System.EventHandler(this.button2_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1008, 381);
            this.Controls.Add(this.btnlog);
            this.Controls.Add(this.btncal);
            this.Controls.Add(this.btnview);
            this.Controls.Add(this.btnadd);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Details";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.Button btncal;
        private System.Windows.Forms.Button btnlog;
    }
}