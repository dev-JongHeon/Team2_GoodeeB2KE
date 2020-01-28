namespace Team2_ERP
{
    partial class BaljuList
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
            this.dgv_Balju = new System.Windows.Forms.DataGridView();
            this.Search_Period = new Team2_ERP.SearchPeriodControl();
            this.Search_Company = new Team2_ERP.SearchUserControl();
            this.dgv_BaljuDetail = new System.Windows.Forms.DataGridView();
            this.Search_Employee = new Team2_ERP.SearchUserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Balju)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Balju);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_BaljuDetail);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_Employee);
            this.panel5.Controls.Add(this.Search_Company);
            this.panel5.Controls.Add(this.Search_Period);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "발주현황";
            // 
            // dgv_Balju
            // 
            this.dgv_Balju.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Balju.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Balju.Location = new System.Drawing.Point(0, 0);
            this.dgv_Balju.Name = "dgv_Balju";
            this.dgv_Balju.RowTemplate.Height = 23;
            this.dgv_Balju.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Balju.Size = new System.Drawing.Size(1364, 368);
            this.dgv_Balju.TabIndex = 2;
            this.dgv_Balju.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Balju_CellDoubleClick);
            // 
            // Search_Period
            // 
            this.Search_Period.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Period.Labelname = "기간 선택";
            this.Search_Period.Location = new System.Drawing.Point(92, 70);
            this.Search_Period.Name = "Search_Period";
            this.Search_Period.Size = new System.Drawing.Size(312, 26);
            this.Search_Period.TabIndex = 76;
            this.Search_Period.UseWaitCursor = true;
            // 
            // Search_Company
            // 
            this.Search_Company.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Company.ControlType = Team2_ERP.SearchUserControl.Mode.Company;
            this.Search_Company.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Company.Labelname = "회사";
            this.Search_Company.Location = new System.Drawing.Point(92, 8);
            this.Search_Company.Name = "Search_Company";
            this.Search_Company.Size = new System.Drawing.Size(312, 25);
            this.Search_Company.TabIndex = 80;
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
            this.dgv_BaljuDetail.TabIndex = 1;
            // 
            // Search_Employee
            // 
            this.Search_Employee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Employee.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.Search_Employee.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Employee.Labelname = "사원";
            this.Search_Employee.Location = new System.Drawing.Point(92, 39);
            this.Search_Employee.Name = "Search_Employee";
            this.Search_Employee.Size = new System.Drawing.Size(312, 25);
            this.Search_Employee.TabIndex = 81;
            // 
            // BaljuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "발주현황";
            this.Name = "BaljuList";
            this.Text = "발주현황";
            this.Activated += new System.EventHandler(this.BaljuList_Activated);
            this.Deactivate += new System.EventHandler(this.BaljuList_Deactivate);
            this.Load += new System.EventHandler(this.BaljuList_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Balju)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BaljuDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Balju;
        private SearchPeriodControl Search_Period;
        private SearchUserControl Search_Company;
        private System.Windows.Forms.DataGridView dgv_BaljuDetail;
        private SearchUserControl Search_Employee;
    }
}
