namespace Team2_ERP
{
    partial class EmployeesInsUp
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmployeesName = new System.Windows.Forms.TextBox();
            this.txtEmployeesPassword = new System.Windows.Forms.TextBox();
            this.txtEmployeesPhoneNumber = new System.Windows.Forms.TextBox();
            this.dtpEmployeesHireDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEmployeesResignDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEmployeesBirthDay = new System.Windows.Forms.DateTimePicker();
            this.cboEmployeesCategory = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboEmployeesCategory);
            this.panel5.Controls.Add(this.dtpEmployeesBirthDay);
            this.panel5.Controls.Add(this.dtpEmployeesResignDate);
            this.panel5.Controls.Add(this.dtpEmployeesHireDate);
            this.panel5.Controls.Add(this.txtEmployeesPhoneNumber);
            this.panel5.Controls.Add(this.txtEmployeesPassword);
            this.panel5.Controls.Add(this.txtEmployeesName);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(33, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "사원명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(33, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "부서명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(33, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "입사일";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "퇴사일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(33, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "비밀번호";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(33, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "전화번호";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(33, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "생년월일";
            // 
            // txtEmployeesName
            // 
            this.txtEmployeesName.Location = new System.Drawing.Point(100, 25);
            this.txtEmployeesName.Name = "txtEmployeesName";
            this.txtEmployeesName.Size = new System.Drawing.Size(132, 21);
            this.txtEmployeesName.TabIndex = 1;
            // 
            // txtEmployeesPassword
            // 
            this.txtEmployeesPassword.Location = new System.Drawing.Point(100, 242);
            this.txtEmployeesPassword.Name = "txtEmployeesPassword";
            this.txtEmployeesPassword.Size = new System.Drawing.Size(132, 21);
            this.txtEmployeesPassword.TabIndex = 1;
            // 
            // txtEmployeesPhoneNumber
            // 
            this.txtEmployeesPhoneNumber.Location = new System.Drawing.Point(100, 298);
            this.txtEmployeesPhoneNumber.Name = "txtEmployeesPhoneNumber";
            this.txtEmployeesPhoneNumber.Size = new System.Drawing.Size(132, 21);
            this.txtEmployeesPhoneNumber.TabIndex = 1;
            // 
            // dtpEmployeesHireDate
            // 
            this.dtpEmployeesHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmployeesHireDate.Location = new System.Drawing.Point(100, 130);
            this.dtpEmployeesHireDate.Name = "dtpEmployeesHireDate";
            this.dtpEmployeesHireDate.Size = new System.Drawing.Size(132, 21);
            this.dtpEmployeesHireDate.TabIndex = 2;
            // 
            // dtpEmployeesResignDate
            // 
            this.dtpEmployeesResignDate.Enabled = false;
            this.dtpEmployeesResignDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmployeesResignDate.Location = new System.Drawing.Point(100, 184);
            this.dtpEmployeesResignDate.Name = "dtpEmployeesResignDate";
            this.dtpEmployeesResignDate.Size = new System.Drawing.Size(132, 21);
            this.dtpEmployeesResignDate.TabIndex = 2;
            // 
            // dtpEmployeesBirthDay
            // 
            this.dtpEmployeesBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmployeesBirthDay.Location = new System.Drawing.Point(100, 355);
            this.dtpEmployeesBirthDay.Name = "dtpEmployeesBirthDay";
            this.dtpEmployeesBirthDay.Size = new System.Drawing.Size(132, 21);
            this.dtpEmployeesBirthDay.TabIndex = 2;
            // 
            // cboEmployeesCategory
            // 
            this.cboEmployeesCategory.FormattingEnabled = true;
            this.cboEmployeesCategory.Location = new System.Drawing.Point(100, 76);
            this.cboEmployeesCategory.Name = "cboEmployeesCategory";
            this.cboEmployeesCategory.Size = new System.Drawing.Size(132, 22);
            this.cboEmployeesCategory.TabIndex = 3;
            // 
            // EmployeesInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Name = "EmployeesInsUp";
            this.Text = "EmployeesInsUp";
            this.Load += new System.EventHandler(this.EmployeesInsUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboEmployeesCategory;
        private System.Windows.Forms.DateTimePicker dtpEmployeesBirthDay;
        private System.Windows.Forms.DateTimePicker dtpEmployeesResignDate;
        private System.Windows.Forms.DateTimePicker dtpEmployeesHireDate;
        private System.Windows.Forms.TextBox txtEmployeesPhoneNumber;
        private System.Windows.Forms.TextBox txtEmployeesPassword;
        private System.Windows.Forms.TextBox txtEmployeesName;
        private System.Windows.Forms.Label label8;
    }
}