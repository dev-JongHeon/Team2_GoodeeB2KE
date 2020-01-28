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
            this.txtFactoryNumber = new System.Windows.Forms.TextBox();
            this.txtFactoryFaxNumber = new System.Windows.Forms.TextBox();
            this.addressControl1 = new Team2_ERP.AddressControl();
            this.cboFactoryDivision = new System.Windows.Forms.ComboBox();
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
            this.panel5.Controls.Add(this.cboFactoryDivision);
            this.panel5.Controls.Add(this.addressControl1);
            this.panel5.Controls.Add(this.txtFactoryFaxNumber);
            this.panel5.Controls.Add(this.txtFactoryNumber);
            this.panel5.Controls.Add(this.txtFactoryName);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
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
            // txtFactoryNumber
            // 
            this.txtFactoryNumber.Location = new System.Drawing.Point(110, 147);
            this.txtFactoryNumber.Name = "txtFactoryNumber";
            this.txtFactoryNumber.Size = new System.Drawing.Size(133, 21);
            this.txtFactoryNumber.TabIndex = 2;
            // 
            // txtFactoryFaxNumber
            // 
            this.txtFactoryFaxNumber.Location = new System.Drawing.Point(110, 205);
            this.txtFactoryFaxNumber.Name = "txtFactoryFaxNumber";
            this.txtFactoryFaxNumber.Size = new System.Drawing.Size(133, 21);
            this.txtFactoryFaxNumber.TabIndex = 3;
            // 
            // addressControl1
            // 
            this.addressControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addressControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addressControl1.Location = new System.Drawing.Point(36, 260);
            this.addressControl1.Name = "addressControl1";
            this.addressControl1.Size = new System.Drawing.Size(505, 106);
            this.addressControl1.TabIndex = 4;
            // 
            // cboFactoryDivision
            // 
            this.cboFactoryDivision.FormattingEnabled = true;
            this.cboFactoryDivision.Location = new System.Drawing.Point(110, 92);
            this.cboFactoryDivision.Name = "cboFactoryDivision";
            this.cboFactoryDivision.Size = new System.Drawing.Size(133, 22);
            this.cboFactoryDivision.TabIndex = 1;
            // 
            // FactoryInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
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
        private System.Windows.Forms.TextBox txtFactoryFaxNumber;
        private System.Windows.Forms.TextBox txtFactoryNumber;
        private AddressControl addressControl1;
        private System.Windows.Forms.ComboBox cboFactoryDivision;
    }
}