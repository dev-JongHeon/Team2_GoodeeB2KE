namespace Team2_ERP
{
    partial class WarehouseInsUp
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
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.txtWarehouseNumber = new System.Windows.Forms.TextBox();
            this.txtWarehouseFaxNumber = new System.Windows.Forms.TextBox();
            this.addrWarehouse = new Team2_ERP.AddressControl();
            this.cboWarehouseDivision = new System.Windows.Forms.ComboBox();
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
            this.panel5.Controls.Add(this.cboWarehouseDivision);
            this.panel5.Controls.Add(this.addrWarehouse);
            this.panel5.Controls.Add(this.txtWarehouseFaxNumber);
            this.panel5.Controls.Add(this.txtWarehouseNumber);
            this.panel5.Controls.Add(this.txtWarehouseName);
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
            this.label2.Location = new System.Drawing.Point(48, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "창고이름";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(48, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "구분";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "전화번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Fax 번호";
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(125, 27);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(143, 21);
            this.txtWarehouseName.TabIndex = 0;
            // 
            // txtWarehouseNumber
            // 
            this.txtWarehouseNumber.Location = new System.Drawing.Point(125, 139);
            this.txtWarehouseNumber.Name = "txtWarehouseNumber";
            this.txtWarehouseNumber.Size = new System.Drawing.Size(143, 21);
            this.txtWarehouseNumber.TabIndex = 2;
            // 
            // txtWarehouseFaxNumber
            // 
            this.txtWarehouseFaxNumber.Location = new System.Drawing.Point(125, 197);
            this.txtWarehouseFaxNumber.Name = "txtWarehouseFaxNumber";
            this.txtWarehouseFaxNumber.Size = new System.Drawing.Size(143, 21);
            this.txtWarehouseFaxNumber.TabIndex = 3;
            // 
            // addrWarehouse
            // 
            this.addrWarehouse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addrWarehouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addrWarehouse.Location = new System.Drawing.Point(51, 250);
            this.addrWarehouse.Name = "addrWarehouse";
            this.addrWarehouse.Size = new System.Drawing.Size(505, 106);
            this.addrWarehouse.TabIndex = 4;
            // 
            // cboWarehouseDivision
            // 
            this.cboWarehouseDivision.FormattingEnabled = true;
            this.cboWarehouseDivision.Location = new System.Drawing.Point(125, 81);
            this.cboWarehouseDivision.Name = "cboWarehouseDivision";
            this.cboWarehouseDivision.Size = new System.Drawing.Size(143, 22);
            this.cboWarehouseDivision.TabIndex = 1;
            // 
            // WarehouseInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Name = "WarehouseInsUp";
            this.Text = "WarehouseInsUp";
            this.Load += new System.EventHandler(this.WarehouseInsUp_Load);
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
        private System.Windows.Forms.TextBox txtWarehouseFaxNumber;
        private System.Windows.Forms.TextBox txtWarehouseNumber;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private AddressControl addrWarehouse;
        private System.Windows.Forms.ComboBox cboWarehouseDivision;
    }
}