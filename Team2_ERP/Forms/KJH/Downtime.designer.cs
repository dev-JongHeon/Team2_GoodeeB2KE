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
            this.searchFactory = new Team2_ERP.SearchUserControl();
            this.searchLine = new Team2_ERP.SearchUserControl();
            this.searchDowntime = new Team2_ERP.SearchUserControl();
            this.searchWorker = new Team2_ERP.SearchUserControl();
            this.searchPeriod = new Team2_ERP.SearchPeriodControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDowntime = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.tabControl1, 0);
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
            this.panel5.Controls.Add(this.searchPeriod);
            this.panel5.Controls.Add(this.searchDowntime);
            this.panel5.Controls.Add(this.searchWorker);
            this.panel5.Controls.Add(this.searchLine);
            this.panel5.Controls.Add(this.searchFactory);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 158);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1362, 660);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgvDowntime);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1354, 633);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "전체보기";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDowntime
            // 
            this.dgvDowntime.BackgroundColor = System.Drawing.Color.White;
            this.dgvDowntime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDowntime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDowntime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDowntime.Location = new System.Drawing.Point(3, 3);
            this.dgvDowntime.Name = "dgvDowntime";
            this.dgvDowntime.RowTemplate.Height = 23;
            this.dgvDowntime.Size = new System.Drawing.Size(1346, 625);
            this.dgvDowntime.TabIndex = 10;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1354, 633);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "공정별 보기";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1354, 633);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "유형별 보기";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1348, 627);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1354, 633);
            this.dataGridView2.TabIndex = 11;
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDowntime)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SearchPeriodControl searchPeriod;
        private SearchUserControl searchDowntime;
        private SearchUserControl searchWorker;
        private SearchUserControl searchLine;
        private SearchUserControl searchFactory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDowntime;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}
