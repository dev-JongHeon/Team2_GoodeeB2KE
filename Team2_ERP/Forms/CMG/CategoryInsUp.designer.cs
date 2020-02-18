namespace Team2_ERP
{
    partial class CategoryInsUp
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
            this.txtContext = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSemiProduct = new System.Windows.Forms.RadioButton();
            this.rdoResource = new System.Windows.Forms.RadioButton();
            this.cboContext = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(378, 362);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(376, 32);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(174, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboContext);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.txtContext);
            this.panel5.Controls.Add(this.txtName);
            this.panel5.Size = new System.Drawing.Size(376, 246);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 310);
            this.panel4.Size = new System.Drawing.Size(376, 50);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(376, 32);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(216, 3);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(91, 3);
            this.btnOK.TabIndex = 2;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtContext
            // 
            this.txtContext.Location = new System.Drawing.Point(156, 181);
            this.txtContext.Name = "txtContext";
            this.txtContext.Size = new System.Drawing.Size(143, 21);
            this.txtContext.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(156, 122);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 21);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(38, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(38, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSemiProduct);
            this.groupBox1.Controls.Add(this.rdoResource);
            this.groupBox1.Location = new System.Drawing.Point(82, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // rdoSemiProduct
            // 
            this.rdoSemiProduct.AutoSize = true;
            this.rdoSemiProduct.Location = new System.Drawing.Point(103, 29);
            this.rdoSemiProduct.Name = "rdoSemiProduct";
            this.rdoSemiProduct.Size = new System.Drawing.Size(58, 18);
            this.rdoSemiProduct.TabIndex = 0;
            this.rdoSemiProduct.TabStop = true;
            this.rdoSemiProduct.Text = "반제품";
            this.rdoSemiProduct.UseVisualStyleBackColor = true;
            this.rdoSemiProduct.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoResource
            // 
            this.rdoResource.AutoSize = true;
            this.rdoResource.Location = new System.Drawing.Point(24, 29);
            this.rdoResource.Name = "rdoResource";
            this.rdoResource.Size = new System.Drawing.Size(58, 18);
            this.rdoResource.TabIndex = 0;
            this.rdoResource.TabStop = true;
            this.rdoResource.Text = "원자재";
            this.rdoResource.UseVisualStyleBackColor = true;
            this.rdoResource.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // cboContext
            // 
            this.cboContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContext.FormattingEnabled = true;
            this.cboContext.Location = new System.Drawing.Point(156, 181);
            this.cboContext.Name = "cboContext";
            this.cboContext.Size = new System.Drawing.Size(143, 22);
            this.cboContext.TabIndex = 9;
            // 
            // CategoryInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 362);
            this.Name = "CategoryInsUp";
            this.Text = "CategoryInsUp";
            this.Load += new System.EventHandler(this.CategoryInsUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtContext;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboContext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoSemiProduct;
        private System.Windows.Forms.RadioButton rdoResource;
    }
}