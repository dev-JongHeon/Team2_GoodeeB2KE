namespace Team2_ERP
{
    partial class StockStatus
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_StockStatus = new System.Windows.Forms.DataGridView();
            this.Search_Product = new Team2_ERP.SearchUserControl();
            this.Search_Warehouse = new Team2_ERP.SearchUserControl();
            this.Search_Category = new Team2_ERP.SearchUserControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_StockStatus);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_Category);
            this.panel5.Controls.Add(this.Search_Warehouse);
            this.panel5.Controls.Add(this.Search_Product);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "재고현황";
            // 
            // dgv_StockStatus
            // 
            this.dgv_StockStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgv_StockStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StockStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StockStatus.Location = new System.Drawing.Point(0, 0);
            this.dgv_StockStatus.Name = "dgv_StockStatus";
            this.dgv_StockStatus.RowTemplate.Height = 23;
            this.dgv_StockStatus.Size = new System.Drawing.Size(1364, 662);
            this.dgv_StockStatus.TabIndex = 1;
            // 
            // Search_Product
            // 
            this.Search_Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Product.ControlType = Team2_ERP.SearchUserControl.Mode.Product;
            this.Search_Product.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Product.Labelname = "제품";
            this.Search_Product.Location = new System.Drawing.Point(50, 26);
            this.Search_Product.Name = "Search_Product";
            this.Search_Product.Size = new System.Drawing.Size(312, 25);
            this.Search_Product.TabIndex = 33;
            // 
            // Search_Warehouse
            // 
            this.Search_Warehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Warehouse.ControlType = Team2_ERP.SearchUserControl.Mode.Warehouse;
            this.Search_Warehouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Warehouse.Labelname = "창고";
            this.Search_Warehouse.Location = new System.Drawing.Point(50, 53);
            this.Search_Warehouse.Name = "Search_Warehouse";
            this.Search_Warehouse.Size = new System.Drawing.Size(312, 25);
            this.Search_Warehouse.TabIndex = 35;
            // 
            // Search_Category
            // 
            this.Search_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Category.ControlType = Team2_ERP.SearchUserControl.Mode.ProductCategory;
            this.Search_Category.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Category.Labelname = "카테고리";
            this.Search_Category.Location = new System.Drawing.Point(388, 26);
            this.Search_Category.Name = "Search_Category";
            this.Search_Category.Size = new System.Drawing.Size(312, 25);
            this.Search_Category.TabIndex = 36;
            // 
            // StockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "재고현황";
            this.Name = "StockStatus";
            this.Text = "재고현황";
            this.Activated += new System.EventHandler(this.StockStatus_Activated);
            this.Deactivate += new System.EventHandler(this.StockStatus_Deactivate);
            this.Load += new System.EventHandler(this.StockStatus_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StockStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_StockStatus;
        private SearchUserControl Search_Warehouse;
        private SearchUserControl Search_Product;
        private SearchUserControl Search_Category;
    }
}
