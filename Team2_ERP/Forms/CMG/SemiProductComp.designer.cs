namespace Team2_ERP
{
    partial class SemiProductComp
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.cboCategoryDetail = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvSemiProduct = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.numSafety = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSemiproductName = new System.Windows.Forms.TextBox();
            this.txtSemiproductMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemiProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSafety)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.splitContainer1);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(796, 407);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.cboCategoryDetail);
            this.splitContainer3.Panel1.Controls.Add(this.cboCategory);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvSemiProduct);
            this.splitContainer3.Size = new System.Drawing.Size(289, 407);
            this.splitContainer3.SplitterDistance = 90;
            this.splitContainer3.TabIndex = 0;
            // 
            // cboCategoryDetail
            // 
            this.cboCategoryDetail.FormattingEnabled = true;
            this.cboCategoryDetail.Location = new System.Drawing.Point(151, 49);
            this.cboCategoryDetail.Name = "cboCategoryDetail";
            this.cboCategoryDetail.Size = new System.Drawing.Size(121, 22);
            this.cboCategoryDetail.TabIndex = 4;
            this.cboCategoryDetail.SelectedIndexChanged += new System.EventHandler(this.cboCategoryDetail_SelectedIndexChanged);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(11, 49);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 22);
            this.cboCategory.TabIndex = 3;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "카테고리";
            // 
            // dgvSemiProduct
            // 
            this.dgvSemiProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvSemiProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSemiProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSemiProduct.Location = new System.Drawing.Point(0, 0);
            this.dgvSemiProduct.Name = "dgvSemiProduct";
            this.dgvSemiProduct.RowTemplate.Height = 23;
            this.dgvSemiProduct.Size = new System.Drawing.Size(289, 313);
            this.dgvSemiProduct.TabIndex = 0;
            this.dgvSemiProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSemiProduct_CellDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.numSafety);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.cboWarehouse);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.numQty);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.txtSemiproductName);
            this.splitContainer2.Panel2.Controls.Add(this.txtSemiproductMoney);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Size = new System.Drawing.Size(503, 407);
            this.splitContainer2.SplitterDistance = 227;
            this.splitContainer2.TabIndex = 0;
            // 
            // numSafety
            // 
            this.numSafety.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSafety.Location = new System.Drawing.Point(307, 79);
            this.numSafety.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSafety.Name = "numSafety";
            this.numSafety.Size = new System.Drawing.Size(98, 21);
            this.numSafety.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(237, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "안전재고량";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(307, 9);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(121, 22);
            this.cboWarehouse.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(237, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 14);
            this.label5.TabIndex = 5;
            this.label5.Text = "보관창고";
            // 
            // numQty
            // 
            this.numQty.Location = new System.Drawing.Point(307, 113);
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(42, 21);
            this.numQty.TabIndex = 4;
            this.numQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQty.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(237, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "개수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(237, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "반제품명";
            // 
            // txtSemiproductName
            // 
            this.txtSemiproductName.Location = new System.Drawing.Point(307, 44);
            this.txtSemiproductName.Name = "txtSemiproductName";
            this.txtSemiproductName.Size = new System.Drawing.Size(186, 21);
            this.txtSemiproductName.TabIndex = 1;
            // 
            // txtSemiproductMoney
            // 
            this.txtSemiproductMoney.Location = new System.Drawing.Point(307, 146);
            this.txtSemiproductMoney.Name = "txtSemiproductMoney";
            this.txtSemiproductMoney.Size = new System.Drawing.Size(186, 21);
            this.txtSemiproductMoney.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(237, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "단가";
            // 
            // SemiProductComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Name = "SemiProductComp";
            this.Text = "SemiProductComp";
            this.Load += new System.EventHandler(this.SemiProductComp_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSemiProduct)).EndInit();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSafety)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSemiproductMoney;
        private System.Windows.Forms.TextBox txtSemiproductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSemiProduct;
        private System.Windows.Forms.ComboBox cboCategoryDetail;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSafety;
        private System.Windows.Forms.Label label6;
    }
}