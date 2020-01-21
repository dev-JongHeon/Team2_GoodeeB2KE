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
            this.searchUserControl1 = new Team2_ERP.SearchUserControl();
            this.searchUserControl3 = new Team2_ERP.SearchUserControl();
            this.searchUserControl2 = new Team2_ERP.SearchUserControl();
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
            this.panel5.Controls.Add(this.searchUserControl2);
            this.panel5.Controls.Add(this.searchUserControl3);
            this.panel5.Controls.Add(this.searchUserControl1);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "재고현황";
            // 
            // dgv_StockStatus
            // 
            this.dgv_StockStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StockStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_StockStatus.Location = new System.Drawing.Point(0, 0);
            this.dgv_StockStatus.Name = "dgv_StockStatus";
            this.dgv_StockStatus.RowTemplate.Height = 23;
            this.dgv_StockStatus.Size = new System.Drawing.Size(1364, 662);
            this.dgv_StockStatus.TabIndex = 1;
            // 
            // searchUserControl1
            // 
            this.searchUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl1.ControlType = Team2_ERP.SearchUserControl.Mode.SemiProduct;
            this.searchUserControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl1.Labelname = "반제품";
            this.searchUserControl1.Location = new System.Drawing.Point(50, 26);
            this.searchUserControl1.Name = "searchUserControl1";
            this.searchUserControl1.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl1.TabIndex = 33;
            // 
            // searchUserControl3
            // 
            this.searchUserControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl3.ControlType = Team2_ERP.SearchUserControl.Mode.Warehouse;
            this.searchUserControl3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl3.Labelname = "창고";
            this.searchUserControl3.Location = new System.Drawing.Point(50, 53);
            this.searchUserControl3.Name = "searchUserControl3";
            this.searchUserControl3.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl3.TabIndex = 35;
            // 
            // searchUserControl2
            // 
            this.searchUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl2.ControlType = Team2_ERP.SearchUserControl.Mode.ProductCategory;
            this.searchUserControl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl2.Labelname = "제품카테고리";
            this.searchUserControl2.Location = new System.Drawing.Point(388, 26);
            this.searchUserControl2.Name = "searchUserControl2";
            this.searchUserControl2.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl2.TabIndex = 36;
            // 
            // StockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "재고현황";
            this.Name = "StockStatus";
            this.Text = "재고현황";
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
        private SearchUserControl searchUserControl3;
        private SearchUserControl searchUserControl1;
        private SearchUserControl searchUserControl2;
    }
}
