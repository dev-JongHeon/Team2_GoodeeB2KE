namespace Team2_ERP
{
    partial class BOM
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
            this.dgvBOM = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvBOMDetail1 = new System.Windows.Forms.DataGridView();
            this.dgvBOMDetail2 = new System.Windows.Forms.DataGridView();
            this.searchProductName = new Team2_ERP.SearchUserControl();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoSemiProduct = new System.Windows.Forms.RadioButton();
            this.rdoProduct = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1344, 729);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
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
            this.panel5.Controls.Add(this.searchProductName);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 158);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBOM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1344, 571);
            this.splitContainer1.SplitterDistance = 617;
            this.splitContainer1.TabIndex = 7;
            // 
            // dgvBOM
            // 
            this.dgvBOM.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM.Location = new System.Drawing.Point(0, 0);
            this.dgvBOM.Name = "dgvBOM";
            this.dgvBOM.RowTemplate.Height = 23;
            this.dgvBOM.Size = new System.Drawing.Size(617, 571);
            this.dgvBOM.TabIndex = 0;
            this.dgvBOM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_CellClick);
            this.dgvBOM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBOM_CellFormatting);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvBOMDetail1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvBOMDetail2);
            this.splitContainer2.Size = new System.Drawing.Size(723, 571);
            this.splitContainer2.SplitterDistance = 280;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvBOMDetail1
            // 
            this.dgvBOMDetail1.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOMDetail1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMDetail1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOMDetail1.Location = new System.Drawing.Point(0, 0);
            this.dgvBOMDetail1.Name = "dgvBOMDetail1";
            this.dgvBOMDetail1.RowTemplate.Height = 23;
            this.dgvBOMDetail1.Size = new System.Drawing.Size(723, 280);
            this.dgvBOMDetail1.TabIndex = 0;
            // 
            // dgvBOMDetail2
            // 
            this.dgvBOMDetail2.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOMDetail2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMDetail2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOMDetail2.Location = new System.Drawing.Point(0, 0);
            this.dgvBOMDetail2.Name = "dgvBOMDetail2";
            this.dgvBOMDetail2.RowTemplate.Height = 23;
            this.dgvBOMDetail2.Size = new System.Drawing.Size(723, 287);
            this.dgvBOMDetail2.TabIndex = 0;
            // 
            // searchProductName
            // 
            this.searchProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchProductName.ControlType = Team2_ERP.SearchUserControl.Mode.Product;
            this.searchProductName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchProductName.Labelname = "제품";
            this.searchProductName.Location = new System.Drawing.Point(3, 69);
            this.searchProductName.Name = "searchProductName";
            this.searchProductName.Size = new System.Drawing.Size(312, 30);
            this.searchProductName.TabIndex = 0;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(21, 24);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(47, 18);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "전체";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoSemiProduct
            // 
            this.rdoSemiProduct.AutoSize = true;
            this.rdoSemiProduct.Location = new System.Drawing.Point(93, 24);
            this.rdoSemiProduct.Name = "rdoSemiProduct";
            this.rdoSemiProduct.Size = new System.Drawing.Size(58, 18);
            this.rdoSemiProduct.TabIndex = 2;
            this.rdoSemiProduct.TabStop = true;
            this.rdoSemiProduct.Text = "반제품";
            this.rdoSemiProduct.UseVisualStyleBackColor = true;
            // 
            // rdoProduct
            // 
            this.rdoProduct.AutoSize = true;
            this.rdoProduct.Location = new System.Drawing.Point(174, 24);
            this.rdoProduct.Name = "rdoProduct";
            this.rdoProduct.Size = new System.Drawing.Size(58, 18);
            this.rdoProduct.TabIndex = 3;
            this.rdoProduct.TabStop = true;
            this.rdoProduct.Text = "완제품";
            this.rdoProduct.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Controls.Add(this.rdoProduct);
            this.groupBox1.Controls.Add(this.rdoSemiProduct);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "분류";
            // 
            // BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Name = "BOM";
            this.Text = "BOM";
            this.Activated += new System.EventHandler(this.BOM_Activated);
            this.Deactivate += new System.EventHandler(this.BOM_Deactivate);
            this.Load += new System.EventHandler(this.BOM_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private SearchUserControl searchProductName;
        private System.Windows.Forms.RadioButton rdoProduct;
        private System.Windows.Forms.RadioButton rdoSemiProduct;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBOM;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvBOMDetail1;
        private System.Windows.Forms.DataGridView dgvBOMDetail2;
    }
}