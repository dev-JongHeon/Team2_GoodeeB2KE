namespace Team2_ERP
{
    partial class Category
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
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.searchCategory = new Team2_ERP.SearchUserControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCategory);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.dgvCategory, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchCategory);
            // 
            // dgvCategory
            // 
            this.dgvCategory.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategory.Location = new System.Drawing.Point(0, 158);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowTemplate.Height = 23;
            this.dgvCategory.Size = new System.Drawing.Size(1364, 662);
            this.dgvCategory.TabIndex = 7;
            this.dgvCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // searchCategory
            // 
            this.searchCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchCategory.ControlType = Team2_ERP.SearchUserControl.Mode.ProductCategory;
            this.searchCategory.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchCategory.Labelname = "제품카테고리";
            this.searchCategory.Location = new System.Drawing.Point(3, 36);
            this.searchCategory.Name = "searchCategory";
            this.searchCategory.Size = new System.Drawing.Size(312, 25);
            this.searchCategory.TabIndex = 0;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Category";
            this.Text = "Category";
            this.Activated += new System.EventHandler(this.Category_Activated);
            this.Deactivate += new System.EventHandler(this.Category_Deactivate);
            this.Load += new System.EventHandler(this.Category_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategory;
        private SearchUserControl searchCategory;
    }
}