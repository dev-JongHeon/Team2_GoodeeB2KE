namespace Team2_ERP
{
    partial class ShipmentMainForm
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
            this.dgv_Shipment = new System.Windows.Forms.DataGridView();
            this.dgv_ShipmentDetail = new System.Windows.Forms.DataGridView();
            this.searchPeriodControl1 = new Team2_ERP.SearchPeriodControl();
            this.searchPeriodControl2 = new Team2_ERP.SearchPeriodControl();
            this.searchUserControl2 = new Team2_ERP.SearchUserControl();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShipmentDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 280;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Shipment);
            this.panel2.Size = new System.Drawing.Size(1364, 280);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_ShipmentDetail);
            this.panel3.Size = new System.Drawing.Size(1364, 378);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchUserControl2);
            this.panel5.Controls.Add(this.searchPeriodControl2);
            this.panel5.Controls.Add(this.searchPeriodControl1);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "출하관리";
            // 
            // dgv_Shipment
            // 
            this.dgv_Shipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Shipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column9,
            this.Column4,
            this.Column3,
            this.Column2});
            this.dgv_Shipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Shipment.Location = new System.Drawing.Point(0, 0);
            this.dgv_Shipment.Name = "dgv_Shipment";
            this.dgv_Shipment.RowTemplate.Height = 23;
            this.dgv_Shipment.Size = new System.Drawing.Size(1364, 280);
            this.dgv_Shipment.TabIndex = 36;
            // 
            // dgv_ShipmentDetail
            // 
            this.dgv_ShipmentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShipmentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column12,
            this.Column10,
            this.Column11});
            this.dgv_ShipmentDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShipmentDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShipmentDetail.Name = "dgv_ShipmentDetail";
            this.dgv_ShipmentDetail.RowTemplate.Height = 23;
            this.dgv_ShipmentDetail.Size = new System.Drawing.Size(1364, 378);
            this.dgv_ShipmentDetail.TabIndex = 37;
            // 
            // searchPeriodControl1
            // 
            this.searchPeriodControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodControl1.Labelname = "출하예정일";
            this.searchPeriodControl1.Location = new System.Drawing.Point(12, 16);
            this.searchPeriodControl1.Name = "searchPeriodControl1";
            this.searchPeriodControl1.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodControl1.TabIndex = 1;
            // 
            // searchPeriodControl2
            // 
            this.searchPeriodControl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodControl2.Labelname = "출하일자";
            this.searchPeriodControl2.Location = new System.Drawing.Point(12, 47);
            this.searchPeriodControl2.Name = "searchPeriodControl2";
            this.searchPeriodControl2.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodControl2.TabIndex = 1;
            // 
            // searchUserControl2
            // 
            this.searchUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl2.ControlType = Team2_ERP.SearchUserControl.Mode.Company;
            this.searchUserControl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl2.Labelname = "출하지시자";
            this.searchUserControl2.Location = new System.Drawing.Point(330, 16);
            this.searchUserControl2.Name = "searchUserControl2";
            this.searchUserControl2.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl2.TabIndex = 2;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "출하번호";
            this.Column6.Name = "Column6";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "제품ID";
            this.Column12.Name = "Column12";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "제품명";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "수량";
            this.Column11.Name = "Column11";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "출하번호";
            this.Column1.Name = "Column1";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "주문일시";
            this.Column5.Name = "Column5";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "주문번호";
            this.Column9.Name = "Column9";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "주문자ID";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "출하지시일";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "출하지시자";
            this.Column2.Name = "Column2";
            // 
            // ShipmentMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "출하관리";
            this.Name = "ShipmentMainForm";
            this.Load += new System.EventHandler(this.ShipmentMainForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShipmentDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Shipment;
        private System.Windows.Forms.DataGridView dgv_ShipmentDetail;
        private SearchPeriodControl searchPeriodControl2;
        private SearchPeriodControl searchPeriodControl1;
        private SearchUserControl searchUserControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
