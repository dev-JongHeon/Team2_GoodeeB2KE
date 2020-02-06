namespace Team2_ERP
{
    partial class Employees
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
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.searchEmployeeName = new Team2_ERP.SearchUserControl();
            this.searchDepartmentName = new Team2_ERP.SearchUserControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEmployee);
            this.panel1.Size = new System.Drawing.Size(1344, 729);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.dgvEmployee, 0);
            // 
            // panel_Search
            // 
            this.panel_Search.Size = new System.Drawing.Size(1344, 110);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(1344, 2);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchDepartmentName);
            this.panel5.Controls.Add(this.searchEmployeeName);
            this.panel5.Size = new System.Drawing.Size(1344, 110);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(1344, 48);
            // 
            // linepanel1
            // 
            this.linepanel1.Size = new System.Drawing.Size(1344, 2);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployee.Location = new System.Drawing.Point(0, 158);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 23;
            this.dgvEmployee.Size = new System.Drawing.Size(1344, 571);
            this.dgvEmployee.TabIndex = 7;
            this.dgvEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            // 
            // searchEmployeeName
            // 
            this.searchEmployeeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchEmployeeName.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.searchEmployeeName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchEmployeeName.Labelname = "사원";
            this.searchEmployeeName.Location = new System.Drawing.Point(3, 4);
            this.searchEmployeeName.Name = "searchEmployeeName";
            this.searchEmployeeName.Size = new System.Drawing.Size(312, 30);
            this.searchEmployeeName.TabIndex = 0;
            // 
            // searchDepartmentName
            // 
            this.searchDepartmentName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchDepartmentName.ControlType = Team2_ERP.SearchUserControl.Mode.Department;
            this.searchDepartmentName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchDepartmentName.Labelname = "부서";
            this.searchDepartmentName.Location = new System.Drawing.Point(3, 40);
            this.searchDepartmentName.Name = "searchDepartmentName";
            this.searchDepartmentName.Size = new System.Drawing.Size(312, 30);
            this.searchDepartmentName.TabIndex = 1;
            // 
            // Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Name = "Employees";
            this.Text = "Employees";
            this.Activated += new System.EventHandler(this.Employees_Activated);
            this.Deactivate += new System.EventHandler(this.Employees_Deactivate);
            this.Load += new System.EventHandler(this.Employees_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private SearchUserControl searchDepartmentName;
        private SearchUserControl searchEmployeeName;
    }
}