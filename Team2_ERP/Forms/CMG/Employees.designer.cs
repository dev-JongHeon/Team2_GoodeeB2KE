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
            this.searchHiredate = new Team2_ERP.SearchPeriodControl();
            this.searchResigndate = new Team2_ERP.SearchPeriodControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoResign = new System.Windows.Forms.RadioButton();
            this.rdoWork = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.searchResigndate);
            this.panel5.Controls.Add(this.searchHiredate);
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
            this.searchEmployeeName.Location = new System.Drawing.Point(104, 59);
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
            this.searchDepartmentName.Location = new System.Drawing.Point(104, 23);
            this.searchDepartmentName.Name = "searchDepartmentName";
            this.searchDepartmentName.Size = new System.Drawing.Size(312, 30);
            this.searchDepartmentName.TabIndex = 1;
            // 
            // searchHiredate
            // 
            this.searchHiredate.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchHiredate.Labelname = "입사일";
            this.searchHiredate.Location = new System.Drawing.Point(437, 25);
            this.searchHiredate.Name = "searchHiredate";
            this.searchHiredate.Size = new System.Drawing.Size(312, 25);
            this.searchHiredate.TabIndex = 2;
            // 
            // searchResigndate
            // 
            this.searchResigndate.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchResigndate.Labelname = "퇴사일";
            this.searchResigndate.Location = new System.Drawing.Point(437, 26);
            this.searchResigndate.Name = "searchResigndate";
            this.searchResigndate.Size = new System.Drawing.Size(312, 25);
            this.searchResigndate.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoResign);
            this.groupBox1.Controls.Add(this.rdoWork);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(71, 79);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "재직여부";
            // 
            // rdoResign
            // 
            this.rdoResign.AutoSize = true;
            this.rdoResign.Location = new System.Drawing.Point(6, 50);
            this.rdoResign.Name = "rdoResign";
            this.rdoResign.Size = new System.Drawing.Size(47, 18);
            this.rdoResign.TabIndex = 1;
            this.rdoResign.TabStop = true;
            this.rdoResign.Text = "퇴사";
            this.rdoResign.UseVisualStyleBackColor = true;
            this.rdoResign.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoWork
            // 
            this.rdoWork.AutoSize = true;
            this.rdoWork.Location = new System.Drawing.Point(6, 23);
            this.rdoWork.Name = "rdoWork";
            this.rdoWork.Size = new System.Drawing.Size(47, 18);
            this.rdoWork.TabIndex = 0;
            this.rdoWork.TabStop = true;
            this.rdoWork.Text = "재직";
            this.rdoWork.UseVisualStyleBackColor = true;
            this.rdoWork.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private SearchUserControl searchDepartmentName;
        private SearchUserControl searchEmployeeName;
        private SearchPeriodControl searchResigndate;
        private SearchPeriodControl searchHiredate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoResign;
        private System.Windows.Forms.RadioButton rdoWork;
    }
}