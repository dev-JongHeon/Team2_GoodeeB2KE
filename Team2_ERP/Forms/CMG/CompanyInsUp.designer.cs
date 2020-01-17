namespace Team2_ERP
{
    partial class CompanyInsUp
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyNumber = new System.Windows.Forms.TextBox();
            this.txtCompanyFaxNumber = new System.Windows.Forms.TextBox();
            this.addressControl1 = new Team2_ERP.AddressControl();
            this.cboCompanyDivision = new System.Windows.Forms.ComboBox();
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
            this.panel5.Controls.Add(this.cboCompanyDivision);
            this.panel5.Controls.Add(this.addressControl1);
            this.panel5.Controls.Add(this.txtCompanyFaxNumber);
            this.panel5.Controls.Add(this.txtCompanyNumber);
            this.panel5.Controls.Add(this.txtCompanyName);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label2);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(49, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "거래처 이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(49, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "전화번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(49, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fax 번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(49, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 14);
            this.label6.TabIndex = 1;
            this.label6.Text = "업종";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(126, 34);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(133, 21);
            this.txtCompanyName.TabIndex = 2;
            // 
            // txtCompanyNumber
            // 
            this.txtCompanyNumber.Location = new System.Drawing.Point(126, 96);
            this.txtCompanyNumber.Name = "txtCompanyNumber";
            this.txtCompanyNumber.Size = new System.Drawing.Size(133, 21);
            this.txtCompanyNumber.TabIndex = 2;
            // 
            // txtCompanyFaxNumber
            // 
            this.txtCompanyFaxNumber.Location = new System.Drawing.Point(126, 159);
            this.txtCompanyFaxNumber.Name = "txtCompanyFaxNumber";
            this.txtCompanyFaxNumber.Size = new System.Drawing.Size(133, 21);
            this.txtCompanyFaxNumber.TabIndex = 2;
            // 
            // addressControl1
            // 
            this.addressControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addressControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addressControl1.Location = new System.Drawing.Point(52, 279);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.Size = new System.Drawing.Size(505, 106);
            this.addressControl1.TabIndex = 3;
            // 
            // cboCompanyDivision
            // 
            this.cboCompanyDivision.FormattingEnabled = true;
            this.cboCompanyDivision.Location = new System.Drawing.Point(126, 220);
            this.cboCompanyDivision.Name = "cboCompanyDivision";
            this.cboCompanyDivision.Size = new System.Drawing.Size(133, 22);
            this.cboCompanyDivision.TabIndex = 4;
            // 
            // CompanyInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Name = "CompanyInsUp";
            this.Text = "CompanyInsUp";
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
        private System.Windows.Forms.TextBox txtCompanyFaxNumber;
        private System.Windows.Forms.TextBox txtCompanyNumber;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private AddressControl addressControl1;
        private System.Windows.Forms.ComboBox cboCompanyDivision;
    }
}