namespace Team2_ERP
{
    partial class Downtime
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
            this.dgvDowntime = new System.Windows.Forms.DataGridView();
            this.searchFactory = new Team2_ERP.SearchUserControl();
            this.searchLine = new Team2_ERP.SearchUserControl();
            this.searchDowntime = new Team2_ERP.SearchUserControl();
            this.searchWorker = new Team2_ERP.SearchUserControl();
            this.searchPeriod = new Team2_ERP.SearchPeriodControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDowntime);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.dgvDowntime, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchPeriod);
            this.panel5.Controls.Add(this.searchDowntime);
            this.panel5.Controls.Add(this.searchWorker);
            this.panel5.Controls.Add(this.searchLine);
            this.panel5.Controls.Add(this.searchFactory);
            // 
            // dgvDowntime
            // 
            this.dgvDowntime.BackgroundColor = System.Drawing.Color.White;
            this.dgvDowntime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDowntime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDowntime.Location = new System.Drawing.Point(0, 158);
            this.dgvDowntime.Name = "dgvDowntime";
            this.dgvDowntime.RowTemplate.Height = 23;
            this.dgvDowntime.Size = new System.Drawing.Size(1364, 662);
            this.dgvDowntime.TabIndex = 7;
            // 
            // searchFactory
            // 
            this.searchFactory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchFactory.ControlType = Team2_ERP.SearchUserControl.Mode.Factory;
            this.searchFactory.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchFactory.Labelname = "공장";
            this.searchFactory.Location = new System.Drawing.Point(23, 11);
            this.searchFactory.Name = "searchFactory";
            this.searchFactory.Size = new System.Drawing.Size(312, 25);
            this.searchFactory.TabIndex = 0;
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchLine.ControlType = Team2_ERP.SearchUserControl.Mode.Line;
            this.searchLine.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLine.Labelname = "공정";
            this.searchLine.Location = new System.Drawing.Point(23, 42);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(312, 25);
            this.searchLine.TabIndex = 0;
            // 
            // searchDowntime
            // 
            this.searchDowntime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchDowntime.ControlType = Team2_ERP.SearchUserControl.Mode.Downtime;
            this.searchDowntime.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchDowntime.Labelname = "비가동유형";
            this.searchDowntime.Location = new System.Drawing.Point(23, 73);
            this.searchDowntime.Name = "searchDowntime";
            this.searchDowntime.Size = new System.Drawing.Size(312, 25);
            this.searchDowntime.TabIndex = 0;
            // 
            // searchWorker
            // 
            this.searchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchWorker.ControlType = Team2_ERP.SearchUserControl.Mode.Worker;
            this.searchWorker.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchWorker.Labelname = "작업자";
            this.searchWorker.Location = new System.Drawing.Point(353, 10);
            this.searchWorker.Name = "searchWorker";
            this.searchWorker.Size = new System.Drawing.Size(312, 25);
            this.searchWorker.TabIndex = 0;
            // 
            // searchPeriod
            // 
            this.searchPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriod.Labelname = "비가동일자";
            this.searchPeriod.Location = new System.Drawing.Point(353, 42);
            this.searchPeriod.Name = "searchPeriod";
            this.searchPeriod.Size = new System.Drawing.Size(312, 31);
            this.searchPeriod.TabIndex = 1;
            // 
            // Downtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Downtime";
            this.Text = "비가동 조회";
            this.Activated += new System.EventHandler(this.Downtime_Activated);
            this.Deactivate += new System.EventHandler(this.Downtime_Deactivate);
            this.Load += new System.EventHandler(this.Downtime_Load);
            this.Shown += new System.EventHandler(this.Downtime_Shown);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDowntime;
        private SearchPeriodControl searchPeriod;
        private SearchUserControl searchDowntime;
        private SearchUserControl searchWorker;
        private SearchUserControl searchLine;
        private SearchUserControl searchFactory;
    }
}
