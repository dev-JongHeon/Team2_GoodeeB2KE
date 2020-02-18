namespace Team2_ERP
{
    partial class FactoryInsUp
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
            this.txtFactoryName = new System.Windows.Forms.TextBox();
            this.addrFactory = new Team2_ERP.AddressControl();
            this.cboFactoryDivision = new System.Windows.Forms.ComboBox();
            this.maskedFactoryNumber = new System.Windows.Forms.MaskedTextBox();
            this.maskedFactoryFaxNumber = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(605, 525);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(603, 32);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(401, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.maskedFactoryFaxNumber);
            this.panel5.Controls.Add(this.maskedFactoryNumber);
            this.panel5.Controls.Add(this.cboFactoryDivision);
            this.panel5.Controls.Add(this.addrFactory);
            this.panel5.Controls.Add(this.txtFactoryName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Size = new System.Drawing.Size(603, 409);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(603, 50);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(603, 32);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(369, 3);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(172, 3);
            this.btnOK.TabIndex = 5;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(33, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "공장이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(33, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "구분";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(33, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "전화번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fax 번호";
            // 
            // txtFactoryName
            // 
            this.txtFactoryName.Location = new System.Drawing.Point(110, 35);
            this.txtFactoryName.Name = "txtFactoryName";
            this.txtFactoryName.Size = new System.Drawing.Size(133, 21);
            this.txtFactoryName.TabIndex = 0;
            // 
            // addrFactory
            // 
            this.addrFactory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addrFactory.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addrFactory.Location = new System.Drawing.Point(36, 260);
            this.addrFactory.Name = "addrFactory";
            this.addrFactory.Size = new System.Drawing.Size(505, 106);
            this.addrFactory.TabIndex = 4;
            // 
            // cboFactoryDivision
            // 
            this.cboFactoryDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFactoryDivision.FormattingEnabled = true;
            this.cboFactoryDivision.Location = new System.Drawing.Point(110, 92);
            this.cboFactoryDivision.Name = "cboFactoryDivision";
            this.cboFactoryDivision.Size = new System.Drawing.Size(133, 22);
            this.cboFactoryDivision.TabIndex = 1;
            // 
            // maskedFactoryNumber
            // 
            this.maskedFactoryNumber.Location = new System.Drawing.Point(110, 147);
            this.maskedFactoryNumber.Mask = "000-9000-0000";
            this.maskedFactoryNumber.Name = "maskedFactoryNumber";
            this.maskedFactoryNumber.Size = new System.Drawing.Size(133, 21);
            this.maskedFactoryNumber.TabIndex = 2;
            // 
            // maskedFactoryFaxNumber
            // 
            this.maskedFactoryFaxNumber.Location = new System.Drawing.Point(110, 205);
            this.maskedFactoryFaxNumber.Mask = "000-9000-0000";
            this.maskedFactoryFaxNumber.Name = "maskedFactoryFaxNumber";
            this.maskedFactoryFaxNumber.Size = new System.Drawing.Size(133, 21);
            this.maskedFactoryFaxNumber.TabIndex = 3;
            // 
            // FactoryInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 525);
            this.Name = "FactoryInsUp";
            this.Text = "FactoryInsUp";
            this.Load += new System.EventHandler(this.FactoryInsUp_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFactoryName;
        private AddressControl addrFactory;
        private System.Windows.Forms.ComboBox cboFactoryDivision;
        private System.Windows.Forms.MaskedTextBox maskedFactoryFaxNumber;
        private System.Windows.Forms.MaskedTextBox maskedFactoryNumber;
    }
}