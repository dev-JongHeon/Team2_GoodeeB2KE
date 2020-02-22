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
            this.tabDowntime = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDowntime = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDowntimeByLine = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvDowntimeByType = new System.Windows.Forms.DataGridView();
            this.searchPeriodForBy = new Team2_ERP.SearchPeriodControl();
            this.SearchArea = new System.Windows.Forms.Panel();
            this.searchPeriod = new Team2_ERP.SearchPeriodControl();
            this.searchLine = new Team2_ERP.SearchUserControl();
            this.searchDowntime = new Team2_ERP.SearchUserControl();
            this.searchWorker = new Team2_ERP.SearchUserControl();
            this.searchFactory = new Team2_ERP.SearchUserControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDowntime.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntimeByLine)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntimeByType)).BeginInit();
            this.SearchArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabDowntime);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.tabDowntime, 0);
            // 
            // panel_Search
            // 
            this.panel_Search.Size = new System.Drawing.Size(1362, 110);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(1362, 2);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.SearchArea);
            this.panel5.Controls.Add(this.searchPeriodForBy);
            this.panel5.Size = new System.Drawing.Size(1362, 110);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(1362, 48);
            // 
            // linepanel1
            // 
            this.linepanel1.Size = new System.Drawing.Size(1362, 2);
            // 
            // tabDowntime
            // 
            this.tabDowntime.Controls.Add(this.tabPage1);
            this.tabDowntime.Controls.Add(this.tabPage2);
            this.tabDowntime.Controls.Add(this.tabPage3);
            this.tabDowntime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDowntime.Location = new System.Drawing.Point(0, 158);
            this.tabDowntime.Name = "tabDowntime";
            this.tabDowntime.SelectedIndex = 0;
            this.tabDowntime.Size = new System.Drawing.Size(1362, 660);
            this.tabDowntime.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabDowntime.TabIndex = 8;
            this.tabDowntime.SelectedIndexChanged += new System.EventHandler(this.tabDowntime_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgvDowntime);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1354, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "모두 보기";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDowntime
            // 
            this.dgvDowntime.BackgroundColor = System.Drawing.Color.White;
            this.dgvDowntime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDowntime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDowntime.Location = new System.Drawing.Point(0, 0);
            this.dgvDowntime.Name = "dgvDowntime";
            this.dgvDowntime.RowTemplate.Height = 23;
            this.dgvDowntime.Size = new System.Drawing.Size(1352, 631);
            this.dgvDowntime.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.dgvDowntimeByLine);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1354, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "공정별 보기";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDowntimeByLine
            // 
            this.dgvDowntimeByLine.BackgroundColor = System.Drawing.Color.White;
            this.dgvDowntimeByLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDowntimeByLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDowntimeByLine.Location = new System.Drawing.Point(0, 0);
            this.dgvDowntimeByLine.Name = "dgvDowntimeByLine";
            this.dgvDowntimeByLine.RowTemplate.Height = 23;
            this.dgvDowntimeByLine.Size = new System.Drawing.Size(1352, 631);
            this.dgvDowntimeByLine.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.dgvDowntimeByType);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1354, 633);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "유형별 보기";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvDowntimeByType
            // 
            this.dgvDowntimeByType.BackgroundColor = System.Drawing.Color.White;
            this.dgvDowntimeByType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDowntimeByType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDowntimeByType.Location = new System.Drawing.Point(0, 0);
            this.dgvDowntimeByType.Name = "dgvDowntimeByType";
            this.dgvDowntimeByType.RowTemplate.Height = 23;
            this.dgvDowntimeByType.Size = new System.Drawing.Size(1352, 631);
            this.dgvDowntimeByType.TabIndex = 14;
            // 
            // searchPeriodForBy
            // 
            this.searchPeriodForBy.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodForBy.Labelname = "기간 선택";
            this.searchPeriodForBy.Location = new System.Drawing.Point(11, 40);
            this.searchPeriodForBy.Name = "searchPeriodForBy";
            this.searchPeriodForBy.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodForBy.TabIndex = 7;
            // 
            // SearchArea
            // 
            this.SearchArea.Controls.Add(this.searchPeriod);
            this.SearchArea.Controls.Add(this.searchLine);
            this.SearchArea.Controls.Add(this.searchDowntime);
            this.SearchArea.Controls.Add(this.searchWorker);
            this.SearchArea.Controls.Add(this.searchFactory);
            this.SearchArea.Location = new System.Drawing.Point(11, 4);
            this.SearchArea.Name = "SearchArea";
            this.SearchArea.Size = new System.Drawing.Size(741, 100);
            this.SearchArea.TabIndex = 9;
            // 
            // searchPeriod
            // 
            this.searchPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriod.Labelname = "비가동일자";
            this.searchPeriod.Location = new System.Drawing.Point(334, 38);
            this.searchPeriod.Name = "searchPeriod";
            this.searchPeriod.Size = new System.Drawing.Size(312, 31);
            this.searchPeriod.TabIndex = 6;
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchLine.ControlType = Team2_ERP.SearchUserControl.Mode.Line;
            this.searchLine.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLine.Labelname = "공정";
            this.searchLine.Location = new System.Drawing.Point(4, 38);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(312, 25);
            this.searchLine.TabIndex = 4;
            // 
            // searchDowntime
            // 
            this.searchDowntime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchDowntime.ControlType = Team2_ERP.SearchUserControl.Mode.Downtime;
            this.searchDowntime.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchDowntime.Labelname = "비가동유형";
            this.searchDowntime.Location = new System.Drawing.Point(4, 69);
            this.searchDowntime.Name = "searchDowntime";
            this.searchDowntime.Size = new System.Drawing.Size(312, 25);
            this.searchDowntime.TabIndex = 2;
            // 
            // searchWorker
            // 
            this.searchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchWorker.ControlType = Team2_ERP.SearchUserControl.Mode.DowntimeWorker;
            this.searchWorker.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchWorker.Labelname = "작업자";
            this.searchWorker.Location = new System.Drawing.Point(334, 6);
            this.searchWorker.Name = "searchWorker";
            this.searchWorker.Size = new System.Drawing.Size(312, 25);
            this.searchWorker.TabIndex = 3;
            // 
            // searchFactory
            // 
            this.searchFactory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchFactory.ControlType = Team2_ERP.SearchUserControl.Mode.Factory;
            this.searchFactory.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchFactory.Labelname = "공장";
            this.searchFactory.Location = new System.Drawing.Point(4, 7);
            this.searchFactory.Name = "searchFactory";
            this.searchFactory.Size = new System.Drawing.Size(312, 25);
            this.searchFactory.TabIndex = 5;
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
            this.tabDowntime.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntimeByLine)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntimeByType)).EndInit();
            this.SearchArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabDowntime;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private SearchPeriodControl searchPeriodForBy;
        private System.Windows.Forms.Panel SearchArea;
        private SearchPeriodControl searchPeriod;
        private SearchUserControl searchDowntime;
        private SearchUserControl searchWorker;
        private SearchUserControl searchLine;
        private SearchUserControl searchFactory;
        private System.Windows.Forms.DataGridView dgvDowntime;
        private System.Windows.Forms.DataGridView dgvDowntimeByLine;
        private System.Windows.Forms.DataGridView dgvDowntimeByType;
    }
}
