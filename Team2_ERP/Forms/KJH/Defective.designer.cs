namespace Team2_ERP
{
    partial class Defective
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
            this.searchWorker = new Team2_ERP.SearchUserControl();
            this.searchProduct = new Team2_ERP.SearchUserControl();
            this.searchFactory = new Team2_ERP.SearchUserControl();
            this.searchPeriod = new Team2_ERP.SearchPeriodControl();
            this.searchLine = new Team2_ERP.SearchUserControl();
            this.tabDefective = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDefective = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvDefectiveByLine = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvDefectiveByDefecType = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvDefectiveByDefecHandleType = new System.Windows.Forms.DataGridView();
            this.SearchArea = new System.Windows.Forms.Panel();
            this.searchPeriodForBy1 = new Team2_ERP.SearchPeriodControl();
            this.searchPeriodForBy2 = new Team2_ERP.SearchPeriodControl();
            this.searchPeriodForBy3 = new Team2_ERP.SearchPeriodControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDefective.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefective)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByLine)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByDefecType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByDefecHandleType)).BeginInit();
            this.SearchArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.tabDefective);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.tabDefective, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.SearchArea);
            this.panel5.Controls.Add(this.searchPeriodForBy3);
            this.panel5.Controls.Add(this.searchPeriodForBy2);
            this.panel5.Controls.Add(this.searchPeriodForBy1);
            // 
            // searchWorker
            // 
            this.searchWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchWorker.ControlType = Team2_ERP.SearchUserControl.Mode.DefectiveWorker;
            this.searchWorker.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchWorker.Labelname = "작업자";
            this.searchWorker.Location = new System.Drawing.Point(336, 36);
            this.searchWorker.Name = "searchWorker";
            this.searchWorker.Size = new System.Drawing.Size(312, 30);
            this.searchWorker.TabIndex = 3;
            // 
            // searchProduct
            // 
            this.searchProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchProduct.ControlType = Team2_ERP.SearchUserControl.Mode.AllProduct;
            this.searchProduct.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchProduct.Labelname = "품목";
            this.searchProduct.Location = new System.Drawing.Point(6, 36);
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
            this.searchFactory.Location = new System.Drawing.Point(6, 4);
            this.searchFactory.Name = "searchFactory";
            this.searchFactory.Size = new System.Drawing.Size(312, 30);
            this.searchFactory.TabIndex = 0;
            // 
            // searchPeriod
            // 
            this.searchPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriod.Labelname = "처리기간";
            this.searchPeriod.Location = new System.Drawing.Point(6, 67);
            this.searchPeriod.Name = "searchPeriod";
            this.searchPeriod.Size = new System.Drawing.Size(312, 30);
            this.searchPeriod.TabIndex = 4;
            // 
            // searchLine
            // 
            this.searchLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchLine.ControlType = Team2_ERP.SearchUserControl.Mode.Line;
            this.searchLine.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchLine.Labelname = "공정";
            this.searchLine.Location = new System.Drawing.Point(336, 4);
            this.searchLine.Name = "searchLine";
            this.searchLine.Size = new System.Drawing.Size(312, 30);
            this.searchLine.TabIndex = 1;
            // 
            // tabDefective
            // 
            this.tabDefective.Controls.Add(this.tabPage1);
            this.tabDefective.Controls.Add(this.tabPage2);
            this.tabDefective.Controls.Add(this.tabPage3);
            this.tabDefective.Controls.Add(this.tabPage4);
            this.tabDefective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDefective.Location = new System.Drawing.Point(0, 158);
            this.tabDefective.Name = "tabDefective";
            this.tabDefective.SelectedIndex = 0;
            this.tabDefective.Size = new System.Drawing.Size(1364, 662);
            this.tabDefective.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabDefective.TabIndex = 10;
            this.tabDefective.SelectedIndexChanged += new System.EventHandler(this.tabDefective_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgvDefective);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1356, 635);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "모두 보기";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDefective
            // 
            this.dgvDefective.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefective.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefective.Location = new System.Drawing.Point(0, 0);
            this.dgvDefective.Name = "dgvDefective";
            this.dgvDefective.Size = new System.Drawing.Size(1354, 633);
            this.dgvDefective.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.dgvDefectiveByLine);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1356, 635);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "공정별 보기";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvDefectiveByLine
            // 
            this.dgvDefectiveByLine.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefectiveByLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectiveByLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectiveByLine.Location = new System.Drawing.Point(0, 0);
            this.dgvDefectiveByLine.Name = "dgvDefectiveByLine";
            this.dgvDefectiveByLine.Size = new System.Drawing.Size(1354, 633);
            this.dgvDefectiveByLine.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.dgvDefectiveByDefecType);
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1356, 635);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "유형별 보기";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvDefectiveByDefecType
            // 
            this.dgvDefectiveByDefecType.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefectiveByDefecType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectiveByDefecType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectiveByDefecType.Location = new System.Drawing.Point(0, 0);
            this.dgvDefectiveByDefecType.Name = "dgvDefectiveByDefecType";
            this.dgvDefectiveByDefecType.Size = new System.Drawing.Size(1354, 633);
            this.dgvDefectiveByDefecType.TabIndex = 14;
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
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.dgvDefectiveByDefecHandleType);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1356, 635);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "처리유형별 보기";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvDefectiveByDefecHandleType
            // 
            this.dgvDefectiveByDefecHandleType.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefectiveByDefecHandleType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefectiveByDefecHandleType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefectiveByDefecHandleType.Location = new System.Drawing.Point(0, 0);
            this.dgvDefectiveByDefecHandleType.Name = "dgvDefectiveByDefecHandleType";
            this.dgvDefectiveByDefecHandleType.Size = new System.Drawing.Size(1354, 633);
            this.dgvDefectiveByDefecHandleType.TabIndex = 13;
            // 
            // SearchArea
            // 
            this.SearchArea.Controls.Add(this.searchFactory);
            this.SearchArea.Controls.Add(this.searchLine);
            this.SearchArea.Controls.Add(this.searchWorker);
            this.SearchArea.Controls.Add(this.searchPeriod);
            this.SearchArea.Controls.Add(this.searchProduct);
            this.SearchArea.Location = new System.Drawing.Point(12, 5);
            this.SearchArea.Name = "SearchArea";
            this.SearchArea.Size = new System.Drawing.Size(713, 100);
            this.SearchArea.TabIndex = 5;
            // 
            // searchPeriodForBy1
            // 
            this.searchPeriodForBy1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodForBy1.Labelname = "기간 선택";
            this.searchPeriodForBy1.Location = new System.Drawing.Point(17, 41);
            this.searchPeriodForBy1.Name = "searchPeriodForBy1";
            this.searchPeriodForBy1.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodForBy1.TabIndex = 6;
            // 
            // searchPeriodForBy2
            // 
            this.searchPeriodForBy2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodForBy2.Labelname = "기간 선택";
            this.searchPeriodForBy2.Location = new System.Drawing.Point(17, 41);
            this.searchPeriodForBy2.Name = "searchPeriodForBy2";
            this.searchPeriodForBy2.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodForBy2.TabIndex = 7;
            // 
            // searchPeriodForBy3
            // 
            this.searchPeriodForBy3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodForBy3.Labelname = "기간 선택";
            this.searchPeriodForBy3.Location = new System.Drawing.Point(17, 41);
            this.searchPeriodForBy3.Name = "searchPeriodForBy3";
            this.searchPeriodForBy3.Size = new System.Drawing.Size(312, 25);
            this.searchPeriodForBy3.TabIndex = 8;
            // 
            // Defective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Defective";
            this.Text = "불량 조회";
            this.Activated += new System.EventHandler(this.Defective_Activated);
            this.Deactivate += new System.EventHandler(this.Defective_Deactivate);
            this.Load += new System.EventHandler(this.Defective_Load);
            this.Shown += new System.EventHandler(this.Defective_Shown);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDefective.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefective)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByLine)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByDefecType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefectiveByDefecHandleType)).EndInit();
            this.SearchArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private SearchUserControl searchWorker;
        private SearchUserControl searchProduct;
        private SearchUserControl searchFactory;
        private SearchPeriodControl searchPeriod;
        private SearchUserControl searchLine;
        private System.Windows.Forms.TabControl tabDefective;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDefective;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvDefectiveByDefecHandleType;
        private System.Windows.Forms.DataGridView dgvDefectiveByLine;
        private System.Windows.Forms.DataGridView dgvDefectiveByDefecType;
        private SearchPeriodControl searchPeriodForBy1;
        private System.Windows.Forms.Panel SearchArea;
        private SearchPeriodControl searchPeriodForBy3;
        private SearchPeriodControl searchPeriodForBy2;
    }
}
