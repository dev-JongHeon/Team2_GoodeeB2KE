namespace Team2_ERP
{ 
    partial class SalesMainForm
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
            this.Search_OrderIndexPeriod = new Team2_ERP.SearchPeriodControl();
            this.Search_ShipmentPeriod = new Team2_ERP.SearchPeriodControl();
            this.dgv_SalesStatus = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesStatus)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgv_SalesStatus);
            this.panel2.Location = new System.Drawing.Point(0, 131);
            this.panel2.Size = new System.Drawing.Size(1754, 865);
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1754, 996);
            // 
            // panel_Search
            // 
            this.panel_Search.Location = new System.Drawing.Point(0, 40);
            this.panel_Search.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Search.Size = new System.Drawing.Size(1754, 91);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 89);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(1754, 2);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_ShipmentPeriod);
            this.panel5.Controls.Add(this.Search_OrderIndexPeriod);
            this.panel5.Controls.Add(this.Search_Customer);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Size = new System.Drawing.Size(1754, 91);
            // 
            // panel_Title
            // 
            this.panel_Title.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Title.Size = new System.Drawing.Size(1754, 40);
            // 
            // panel8
            // 
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Size = new System.Drawing.Size(147, 38);
            // 
            // lblFormName
            // 
            this.lblFormName.Location = new System.Drawing.Point(36, 0);
            this.lblFormName.Size = new System.Drawing.Size(111, 38);
            this.lblFormName.Text = "매출현황";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Size = new System.Drawing.Size(36, 38);
            // 
            // linepanel1
            // 
            this.linepanel1.Location = new System.Drawing.Point(0, 38);
            this.linepanel1.Margin = new System.Windows.Forms.Padding(2);
            this.linepanel1.Size = new System.Drawing.Size(1754, 2);
            // 
            // Search_Customer
            // 
            this.Search_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Customer.ControlType = Team2_ERP.SearchUserControl.Mode.Customer;
            this.Search_Customer.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Customer.Labelname = "고객ID";
            this.Search_Customer.Location = new System.Drawing.Point(58, 14);
            this.Search_Customer.Margin = new System.Windows.Forms.Padding(4);
            this.Search_Customer.Name = "Search_Customer";
            this.Search_Customer.Size = new System.Drawing.Size(401, 30);
            this.Search_Customer.TabIndex = 0;
            // 
            // Search_OrderIndexPeriod
            // 
            this.Search_OrderIndexPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_OrderIndexPeriod.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Search_OrderIndexPeriod.Labelname = "주문일시";
            this.Search_OrderIndexPeriod.Location = new System.Drawing.Point(58, 43);
            this.Search_OrderIndexPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.Search_OrderIndexPeriod.Name = "Search_OrderIndexPeriod";
            this.Search_OrderIndexPeriod.Size = new System.Drawing.Size(401, 30);
            this.Search_OrderIndexPeriod.TabIndex = 2;
            // 
            // Search_ShipmentPeriod
            // 
            this.Search_ShipmentPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_ShipmentPeriod.Labelname = "출하처리일시";
            this.Search_ShipmentPeriod.Location = new System.Drawing.Point(405, 14);
            this.Search_ShipmentPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.Search_ShipmentPeriod.Name = "Search_ShipmentPeriod";
            this.Search_ShipmentPeriod.Size = new System.Drawing.Size(401, 30);
            this.Search_ShipmentPeriod.TabIndex = 3;
            // 
            // dgv_SalesStatus
            // 
            this.dgv_SalesStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgv_SalesStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SalesStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_SalesStatus.Location = new System.Drawing.Point(0, 0);
            this.dgv_SalesStatus.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_SalesStatus.Name = "dgv_SalesStatus";
            this.dgv_SalesStatus.RowHeadersWidth = 51;
            this.dgv_SalesStatus.RowTemplate.Height = 23;
            this.dgv_SalesStatus.Size = new System.Drawing.Size(1754, 865);
            this.dgv_SalesStatus.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 810);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1754, 55);
            this.panel3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(1574, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "0000000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1702, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "원";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1356, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "매출총액";
            // 
            // SalesMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1754, 996);
            this.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormName = "매출현황";
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SalesMainForm";
            this.Load += new System.EventHandler(this.SalesMainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesStatus)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SearchUserControl Search_Customer;
        private System.Windows.Forms.DataGridView dgv_SalesStatus;
        private SearchPeriodControl Search_ShipmentPeriod;
        private SearchPeriodControl Search_OrderIndexPeriod;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
