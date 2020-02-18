namespace Team2_ERP
{
    partial class OrderMainForm
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
            this.Search_Customer = new Team2_ERP.SearchUserControl();
            this.dgv_Order = new System.Windows.Forms.DataGridView();
            this.dgv_OrderDetail = new System.Windows.Forms.DataGridView();
            this.Search_Period = new Team2_ERP.SearchPeriodControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Order);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_OrderDetail);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_Period);
            this.panel5.Controls.Add(this.Search_Customer);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "주문현황";
            // 
            // Search_Customer
            // 
            this.Search_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Customer.ControlType = Team2_ERP.SearchUserControl.Mode.Customer;
            this.Search_Customer.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Customer.Labelname = "고객";
            this.Search_Customer.Location = new System.Drawing.Point(19, 57);
            this.Search_Customer.Name = "Search_Customer";
            this.Search_Customer.Size = new System.Drawing.Size(312, 25);
            this.Search_Customer.TabIndex = 0;
            // 
            // dgv_Order
            // 
            this.dgv_Order.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Order.Location = new System.Drawing.Point(0, 0);
            this.dgv_Order.Name = "dgv_Order";
            this.dgv_Order.RowTemplate.Height = 23;
            this.dgv_Order.Size = new System.Drawing.Size(1364, 368);
            this.dgv_Order.TabIndex = 0;
            this.dgv_Order.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Order_CellContentClick);
            this.dgv_Order.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Order_CellDoubleClick);
            // 
            // dgv_OrderDetail
            // 
            this.dgv_OrderDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_OrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_OrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_OrderDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_OrderDetail.Name = "dgv_OrderDetail";
            this.dgv_OrderDetail.RowTemplate.Height = 23;
            this.dgv_OrderDetail.Size = new System.Drawing.Size(1364, 290);
            this.dgv_OrderDetail.TabIndex = 0;
            // 
            // Search_Period
            // 
            this.Search_Period.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Period.Labelname = "주문일자";
            this.Search_Period.Location = new System.Drawing.Point(19, 26);
            this.Search_Period.Name = "Search_Period";
            this.Search_Period.Size = new System.Drawing.Size(312, 25);
            this.Search_Period.TabIndex = 2;
            // 
            // OrderMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "주문현황";
            this.Name = "OrderMainForm";
            this.Activated += new System.EventHandler(this.OrderMainForm_Activated);
            this.Deactivate += new System.EventHandler(this.OrderMainForm_Deactivate);
            this.Load += new System.EventHandler(this.OrderMainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_OrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Order;
        private System.Windows.Forms.DataGridView dgv_OrderDetail;
        private SearchPeriodControl Search_Period;
        private SearchUserControl Search_Customer;
    }
}
