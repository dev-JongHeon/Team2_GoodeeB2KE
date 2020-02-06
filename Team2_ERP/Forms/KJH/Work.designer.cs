namespace Team2_ERP
{
    partial class Work
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
            this.dgvWorkList = new System.Windows.Forms.DataGridView();
            this.dgvProduce = new System.Windows.Forms.DataGridView();
            this.searchSales = new Team2_ERP.SearchUserControl();
            this.searchPeriodwork = new Team2_ERP.SearchPeriodControl();
            this.searchPeriodRequire = new Team2_ERP.SearchPeriodControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbx2 = new System.Windows.Forms.RadioButton();
            this.rbx0 = new System.Windows.Forms.RadioButton();
            this.rbx1 = new System.Windows.Forms.RadioButton();
            this.rbxAll = new System.Windows.Forms.RadioButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvWorkList);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvProduce);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.searchPeriodRequire);
            this.panel5.Controls.Add(this.searchPeriodwork);
            this.panel5.Controls.Add(this.searchSales);
            // 
            // dgvWorkList
            // 
            this.dgvWorkList.BackgroundColor = System.Drawing.Color.White;
            this.dgvWorkList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkList.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkList.Name = "dgvWorkList";
            this.dgvWorkList.RowTemplate.Height = 23;
            this.dgvWorkList.Size = new System.Drawing.Size(1364, 368);
            this.dgvWorkList.TabIndex = 8;
            this.dgvWorkList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkList_CellClick);
            // 
            // dgvProduce
            // 
            this.dgvProduce.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduce.Location = new System.Drawing.Point(0, 0);
            this.dgvProduce.Name = "dgvProduce";
            this.dgvProduce.RowTemplate.Height = 23;
            this.dgvProduce.Size = new System.Drawing.Size(1364, 290);
            this.dgvProduce.TabIndex = 1;
            // 
            // searchSales
            // 
            this.searchSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchSales.ControlType = Team2_ERP.SearchUserControl.Mode.DepSales;
            this.searchSales.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchSales.Labelname = "작업지시자";
            this.searchSales.Location = new System.Drawing.Point(153, 14);
            this.searchSales.Name = "searchSales";
            this.searchSales.Size = new System.Drawing.Size(312, 25);
            this.searchSales.TabIndex = 0;
            // 
            // searchPeriodwork
            // 
            this.searchPeriodwork.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodwork.Labelname = "작업지시일";
            this.searchPeriodwork.Location = new System.Drawing.Point(153, 45);
            this.searchPeriodwork.Name = "searchPeriodwork";
            this.searchPeriodwork.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodwork.TabIndex = 1;
            // 
            // searchPeriodRequire
            // 
            this.searchPeriodRequire.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodRequire.Labelname = "납기일";
            this.searchPeriodRequire.Location = new System.Drawing.Point(153, 76);
            this.searchPeriodRequire.Name = "searchPeriodRequire";
            this.searchPeriodRequire.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodRequire.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbx2);
            this.groupBox1.Controls.Add(this.rbx0);
            this.groupBox1.Controls.Add(this.rbx1);
            this.groupBox1.Controls.Add(this.rbxAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 100);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "작업상태";
            // 
            // rbx2
            // 
            this.rbx2.AutoSize = true;
            this.rbx2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbx2.Location = new System.Drawing.Point(6, 68);
            this.rbx2.Name = "rbx2";
            this.rbx2.Size = new System.Drawing.Size(69, 18);
            this.rbx2.TabIndex = 4;
            this.rbx2.Text = "작업완료";
            this.rbx2.UseVisualStyleBackColor = true;
            this.rbx2.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // rbx0
            // 
            this.rbx0.AutoSize = true;
            this.rbx0.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbx0.Location = new System.Drawing.Point(6, 20);
            this.rbx0.Name = "rbx0";
            this.rbx0.Size = new System.Drawing.Size(69, 18);
            this.rbx0.TabIndex = 2;
            this.rbx0.Text = "작업대기";
            this.rbx0.UseVisualStyleBackColor = true;
            this.rbx0.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // rbx1
            // 
            this.rbx1.AutoSize = true;
            this.rbx1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbx1.Location = new System.Drawing.Point(6, 44);
            this.rbx1.Name = "rbx1";
            this.rbx1.Size = new System.Drawing.Size(58, 18);
            this.rbx1.TabIndex = 3;
            this.rbx1.Text = "작업중";
            this.rbx1.UseVisualStyleBackColor = true;
            this.rbx1.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // rbxAll
            // 
            this.rbxAll.AutoSize = true;
            this.rbxAll.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbxAll.Location = new System.Drawing.Point(81, 20);
            this.rbxAll.Name = "rbxAll";
            this.rbxAll.Size = new System.Drawing.Size(47, 18);
            this.rbxAll.TabIndex = 1;
            this.rbxAll.Text = "전체";
            this.rbxAll.UseVisualStyleBackColor = true;
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbxAll_CheckedChanged);
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Work";
            this.Activated += new System.EventHandler(this.Work_Activated);
            this.Deactivate += new System.EventHandler(this.Work_Deactivate);
            this.Load += new System.EventHandler(this.Work_Load);
            this.Shown += new System.EventHandler(this.Work_Shown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvWorkList;
        private System.Windows.Forms.DataGridView dgvProduce;
        private SearchPeriodControl searchPeriodwork;
        private SearchUserControl searchSales;
        private SearchPeriodControl searchPeriodRequire;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbx2;
        private System.Windows.Forms.RadioButton rbx0;
        private System.Windows.Forms.RadioButton rbx1;
        private System.Windows.Forms.RadioButton rbxAll;
    }
}
