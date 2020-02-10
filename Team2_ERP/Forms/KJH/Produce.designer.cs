namespace Team2_ERP
{
    partial class Produce
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
            this.dgvPerformance = new System.Windows.Forms.DataGridView();
            this.searchProduct = new Team2_ERP.SearchUserControl();
            this.searchFactory = new Team2_ERP.SearchUserControl();
            this.searchLine = new Team2_ERP.SearchUserControl();
            this.dgvProduce = new System.Windows.Forms.DataGridView();
            this.searchPeriodStart = new Team2_ERP.SearchPeriodControl();
            this.searchPeriodEnd = new Team2_ERP.SearchPeriodControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvProduce);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvPerformance);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchPeriodEnd);
            this.panel5.Controls.Add(this.searchPeriodStart);
            this.panel5.Controls.Add(this.searchLine);
            this.panel5.Controls.Add(this.searchFactory);
            this.panel5.Controls.Add(this.searchProduct);
            // 
            // dgvPerformance
            // 
            this.dgvPerformance.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerformance.Location = new System.Drawing.Point(0, 0);
            this.dgvPerformance.Name = "dgvPerformance";
            this.dgvPerformance.RowTemplate.Height = 23;
            this.dgvPerformance.Size = new System.Drawing.Size(1364, 290);
            this.dgvPerformance.TabIndex = 0;
            // 
            // searchProduct
            // 
            this.searchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchProduct.ControlType = Team2_ERP.SearchUserControl.Mode.AllProduct;
            this.searchProduct.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchProduct.Labelname = "품목";
            this.searchProduct.Location = new System.Drawing.Point(12, 74);
            this.searchProduct.Name = "searchProduct";
            this.searchProduct.Size = new System.Drawing.Size(312, 30);
            this.searchProduct.TabIndex = 2;
            // 
            // searchFactory
            // 
            this.searchFactory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchFactory.ControlType = Team2_ERP.SearchUserControl.Mode.Factory;
            this.searchFactory.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchFactory.Labelname = "공장";
            this.searchFactory.Location = new System.Drawing.Point(12, 12);
            this.searchFactory.Name = "searchFactory";
            this.searchFactory.Size = new System.Drawing.Size(312, 30);
            this.searchFactory.TabIndex = 2;
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchLine.ControlType = Team2_ERP.SearchUserControl.Mode.Line;
            this.searchLine.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLine.Labelname = "공정";
            this.searchLine.Location = new System.Drawing.Point(12, 43);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(312, 30);
            this.searchLine.TabIndex = 2;
            // 
            // dgvProduce
            // 
            this.dgvProduce.BackgroundColor = System.Drawing.Color.White;
            this.dgvProduce.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduce.Location = new System.Drawing.Point(0, 0);
            this.dgvProduce.Name = "dgvProduce";
            this.dgvProduce.RowTemplate.Height = 23;
            this.dgvProduce.Size = new System.Drawing.Size(1364, 368);
            this.dgvProduce.TabIndex = 2;
            this.dgvProduce.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduce_CellDoubleClick);
            // 
            // searchPeriodStart
            // 
            this.searchPeriodStart.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodStart.Labelname = "생산시작일";
            this.searchPeriodStart.Location = new System.Drawing.Point(349, 12);
            this.searchPeriodStart.Name = "searchPeriodStart";
            this.searchPeriodStart.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodStart.TabIndex = 3;
            // 
            // searchPeriodEnd
            // 
            this.searchPeriodEnd.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodEnd.Labelname = "생산종료일";
            this.searchPeriodEnd.Location = new System.Drawing.Point(349, 43);
            this.searchPeriodEnd.Name = "searchPeriodEnd";
            this.searchPeriodEnd.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodEnd.TabIndex = 4;
            // 
            // Produce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Produce";
            this.Activated += new System.EventHandler(this.Produce_Activated);
            this.Deactivate += new System.EventHandler(this.Produce_Deactivate);
            this.Load += new System.EventHandler(this.Produce_Load);
            this.Shown += new System.EventHandler(this.Produce_Shown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvPerformance;
        private SearchUserControl searchFactory;
        private SearchUserControl searchProduct;
        private SearchUserControl searchLine;
        private System.Windows.Forms.DataGridView dgvProduce;
        private SearchPeriodControl searchPeriodEnd;
        private SearchPeriodControl searchPeriodStart;
    }
}
