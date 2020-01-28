namespace Team2_ERP
{
    partial class BaljuList_Completed
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
            this.dgv_BaljuCompleted = new System.Windows.Forms.DataGridView();
            this.dgv_BaljuDetail = new System.Windows.Forms.DataGridView();
            this.dtp_ReceiptDate = new System.Windows.Forms.DateTimePicker();
            this.Search_Company = new Team2_ERP.SearchUserControl();
            this.Search_Employee = new Team2_ERP.SearchUserControl();
            this.Search_Period = new Team2_ERP.SearchPeriodControl();
            this.chk_ReceiptDate = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuCompleted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_BaljuCompleted);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_BaljuDetail);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chk_ReceiptDate);
            this.panel5.Controls.Add(this.Search_Company);
            this.panel5.Controls.Add(this.Search_Employee);
            this.panel5.Controls.Add(this.Search_Period);
            this.panel5.Controls.Add(this.dtp_ReceiptDate);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "발주완료현황";
            // 
            // dgv_BaljuCompleted
            // 
            this.dgv_BaljuCompleted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BaljuCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_BaljuCompleted.Location = new System.Drawing.Point(0, 0);
            this.dgv_BaljuCompleted.Name = "dgv_BaljuCompleted";
            this.dgv_BaljuCompleted.RowTemplate.Height = 23;
            this.dgv_BaljuCompleted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_BaljuCompleted.Size = new System.Drawing.Size(1364, 368);
            this.dgv_BaljuCompleted.TabIndex = 3;
            this.dgv_BaljuCompleted.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_BaljuCompleted_CellDoubleClick);
            // 
            // dgv_BaljuDetail
            // 
            this.dgv_BaljuDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_BaljuDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_BaljuDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_BaljuDetail.Name = "dgv_BaljuDetail";
            this.dgv_BaljuDetail.RowTemplate.Height = 23;
            this.dgv_BaljuDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_BaljuDetail.Size = new System.Drawing.Size(1364, 290);
            this.dgv_BaljuDetail.TabIndex = 3;
            // 
            // dtp_ReceiptDate
            // 
            this.dtp_ReceiptDate.Enabled = false;
            this.dtp_ReceiptDate.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtp_ReceiptDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ReceiptDate.Location = new System.Drawing.Point(552, 9);
            this.dtp_ReceiptDate.Name = "dtp_ReceiptDate";
            this.dtp_ReceiptDate.Size = new System.Drawing.Size(111, 22);
            this.dtp_ReceiptDate.TabIndex = 75;
            // 
            // Search_Company
            // 
            this.Search_Company.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Company.ControlType = Team2_ERP.SearchUserControl.Mode.Company;
            this.Search_Company.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Company.Labelname = "회사";
            this.Search_Company.Location = new System.Drawing.Point(89, 38);
            this.Search_Company.Name = "Search_Company";
            this.Search_Company.Size = new System.Drawing.Size(312, 25);
            this.Search_Company.TabIndex = 84;
            // 
            // Search_Employee
            // 
            this.Search_Employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Employee.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.Search_Employee.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Employee.Labelname = "사원";
            this.Search_Employee.Location = new System.Drawing.Point(89, 6);
            this.Search_Employee.Name = "Search_Employee";
            this.Search_Employee.Size = new System.Drawing.Size(312, 25);
            this.Search_Employee.TabIndex = 83;
            // 
            // Search_Period
            // 
            this.Search_Period.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Period.Labelname = "기간 선택";
            this.Search_Period.Location = new System.Drawing.Point(89, 69);
            this.Search_Period.Name = "Search_Period";
            this.Search_Period.Size = new System.Drawing.Size(312, 26);
            this.Search_Period.TabIndex = 81;
            // 
            // chk_ReceiptDate
            // 
            this.chk_ReceiptDate.AutoSize = true;
            this.chk_ReceiptDate.Location = new System.Drawing.Point(475, 11);
            this.chk_ReceiptDate.Name = "chk_ReceiptDate";
            this.chk_ReceiptDate.Size = new System.Drawing.Size(59, 18);
            this.chk_ReceiptDate.TabIndex = 86;
            this.chk_ReceiptDate.Text = "수령일";
            this.chk_ReceiptDate.UseVisualStyleBackColor = true;
            this.chk_ReceiptDate.CheckedChanged += new System.EventHandler(this.chk_ReceiptDate_CheckedChanged);
            // 
            // BaljuList_Completed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "발주완료현황";
            this.Name = "BaljuList_Completed";
            this.Activated += new System.EventHandler(this.BaljuList_Completed_Activated);
            this.Deactivate += new System.EventHandler(this.BaljuList_Completed_Deactivate);
            this.Load += new System.EventHandler(this.BaljuList_Completed_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuCompleted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_BaljuCompleted;
        private System.Windows.Forms.DataGridView dgv_BaljuDetail;
        private System.Windows.Forms.DateTimePicker dtp_ReceiptDate;
        private SearchUserControl Search_Company;
        private SearchUserControl Search_Employee;
        private SearchPeriodControl Search_Period;
        private System.Windows.Forms.CheckBox chk_ReceiptDate;
    }
}
