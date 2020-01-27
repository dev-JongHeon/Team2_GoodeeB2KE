namespace Team2_ERP
{
    partial class UserAuth
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
            this.dgvEmpList = new System.Windows.Forms.DataGridView();
            this.dgvAuthList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Team2_ERP.SearchUserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvEmpList);
            this.panel2.Size = new System.Drawing.Size(368, 662);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvAuthList);
            this.panel3.Size = new System.Drawing.Size(992, 662);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtSearch);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "사용자권한설정";
            // 
            // dgvEmpList
            // 
            this.dgvEmpList.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpList.Location = new System.Drawing.Point(0, 0);
            this.dgvEmpList.Name = "dgvEmpList";
            this.dgvEmpList.RowTemplate.Height = 23;
            this.dgvEmpList.Size = new System.Drawing.Size(368, 662);
            this.dgvEmpList.TabIndex = 0;
            this.dgvEmpList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpList_CellDoubleClick);
            // 
            // dgvAuthList
            // 
            this.dgvAuthList.BackgroundColor = System.Drawing.Color.White;
            this.dgvAuthList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuthList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuthList.Location = new System.Drawing.Point(0, 0);
            this.dgvAuthList.Name = "dgvAuthList";
            this.dgvAuthList.RowTemplate.Height = 23;
            this.dgvAuthList.Size = new System.Drawing.Size(992, 662);
            this.dgvAuthList.TabIndex = 1;
            this.dgvAuthList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuthList_CellContentClick);
            this.dgvAuthList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAuthList_DataBindingComplete);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtSearch.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Labelname = "사원";
            this.txtSearch.Location = new System.Drawing.Point(12, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(312, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // UserAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.DoubleBuffered = true;
            this.FormName = "사용자권한설정";
            this.Name = "UserAuth";
            this.Activated += new System.EventHandler(this.UserAuth_Activated);
            this.Deactivate += new System.EventHandler(this.UserAuth_Deactivate);
            this.Load += new System.EventHandler(this.UserAuth_Load);
            this.Shown += new System.EventHandler(this.UserAuth_Shown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuthList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpList;
        private System.Windows.Forms.DataGridView dgvAuthList;
        private SearchUserControl txtSearch;
    }
}
