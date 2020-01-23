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
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.searchUserControl4 = new Team2_ERP.SearchUserControl();
            this.searchUserControl3 = new Team2_ERP.SearchUserControl();
            this.searchUserControl1 = new Team2_ERP.SearchUserControl();
            this.searchPeriodControl1 = new Team2_ERP.SearchPeriodControl();
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
            this.panel5.Controls.Add(this.searchUserControl4);
            this.panel5.Controls.Add(this.searchUserControl3);
            this.panel5.Controls.Add(this.searchUserControl1);
            this.panel5.Controls.Add(this.searchPeriodControl1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.dateTimePicker3);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(454, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 73;
            this.label3.Text = "수령일";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker3.Location = new System.Drawing.Point(524, 35);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(111, 22);
            this.dateTimePicker3.TabIndex = 75;
            // 
            // searchUserControl4
            // 
            this.searchUserControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl4.ControlType = Team2_ERP.SearchUserControl.Mode.Company;
            this.searchUserControl4.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl4.Labelname = "회사";
            this.searchUserControl4.Location = new System.Drawing.Point(89, 38);
            this.searchUserControl4.Name = "searchUserControl4";
            this.searchUserControl4.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl4.TabIndex = 84;
            // 
            // searchUserControl3
            // 
            this.searchUserControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl3.ControlType = Team2_ERP.SearchUserControl.Mode.Company;
            this.searchUserControl3.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl3.Labelname = "작업자";
            this.searchUserControl3.Location = new System.Drawing.Point(89, 6);
            this.searchUserControl3.Name = "searchUserControl3";
            this.searchUserControl3.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl3.TabIndex = 83;
            // 
            // searchUserControl1
            // 
            this.searchUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl1.ControlType = Team2_ERP.SearchUserControl.Mode.Meterial;
            this.searchUserControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl1.Labelname = "원자재";
            this.searchUserControl1.Location = new System.Drawing.Point(89, 69);
            this.searchUserControl1.Name = "searchUserControl1";
            this.searchUserControl1.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl1.TabIndex = 82;
            // 
            // searchPeriodControl1
            // 
            this.searchPeriodControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodControl1.Labelname = "기간 선택";
            this.searchPeriodControl1.Location = new System.Drawing.Point(441, 6);
            this.searchPeriodControl1.Name = "searchPeriodControl1";
            this.searchPeriodControl1.Size = new System.Drawing.Size(312, 26);
            this.searchPeriodControl1.TabIndex = 81;
            // 
            // BaljuList_Completed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "발주완료현황";
            this.Name = "BaljuList_Completed";
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private SearchUserControl searchUserControl4;
        private SearchUserControl searchUserControl3;
        private SearchUserControl searchUserControl1;
        private SearchPeriodControl searchPeriodControl1;
    }
}
