namespace Team2_ERP
{
    partial class DefectiveType
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
            this.dgvDefectiveType = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Team2_ERP.SearchUserControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDefectiveType);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtSearch);
            // 
            // dgvDefectiveType
            // 
            this.dgvDefectiveType.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefectiveType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectiveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectiveType.Location = new System.Drawing.Point(0, 0);
            this.dgvDefectiveType.Name = "dgvDefectiveType";
            this.dgvDefectiveType.Size = new System.Drawing.Size(1364, 662);
            this.dgvDefectiveType.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.txtSearch.ControlType = Team2_ERP.SearchUserControl.Mode.Defective;
            this.txtSearch.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Labelname = "불량유형명";
            this.txtSearch.Location = new System.Drawing.Point(12, 38);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(312, 25);
            this.txtSearch.TabIndex = 0;
            // 
            // DefectiveType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "DefectiveType";
            this.Activated += new System.EventHandler(this.DefectiveType_Activated);
            this.Deactivate += new System.EventHandler(this.DefectiveType_Deactivate);
            this.Load += new System.EventHandler(this.DefectiveType_Load);
            this.Shown += new System.EventHandler(this.DefectiveType_Shown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDefectiveType;
        private SearchUserControl txtSearch;
    }
}
