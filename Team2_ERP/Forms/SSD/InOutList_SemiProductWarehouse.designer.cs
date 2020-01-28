namespace Team2_ERP
{
    partial class InOutList_SemiProductWarehouse
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
            this.dgv_Stock = new System.Windows.Forms.DataGridView();
            this.searchUserControl1 = new Team2_ERP.SearchUserControl();
            this.searchUserControl2 = new Team2_ERP.SearchUserControl();
            this.searchPeriodControl1 = new Team2_ERP.SearchPeriodControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_In = new System.Windows.Forms.RadioButton();
            this.rdo_Out = new System.Windows.Forms.RadioButton();
            this.rdo_All = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Stock);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.searchUserControl1);
            this.panel5.Controls.Add(this.searchUserControl2);
            this.panel5.Controls.Add(this.searchPeriodControl1);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "수불내역(반제품)";
            // 
            // dgv_Stock
            // 
            this.dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Stock.Location = new System.Drawing.Point(0, 0);
            this.dgv_Stock.Name = "dgv_Stock";
            this.dgv_Stock.RowTemplate.Height = 23;
            this.dgv_Stock.Size = new System.Drawing.Size(1364, 662);
            this.dgv_Stock.TabIndex = 2;
            // 
            // searchUserControl1
            // 
            this.searchUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl1.ControlType = Team2_ERP.SearchUserControl.Mode.SemiProduct;
            this.searchUserControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl1.Labelname = "반제품";
            this.searchUserControl1.Location = new System.Drawing.Point(186, 73);
            this.searchUserControl1.Name = "searchUserControl1";
            this.searchUserControl1.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl1.TabIndex = 69;
            // 
            // searchUserControl2
            // 
            this.searchUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl2.ControlType = Team2_ERP.SearchUserControl.Mode.Warehouse;
            this.searchUserControl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl2.Labelname = "창고";
            this.searchUserControl2.Location = new System.Drawing.Point(186, 41);
            this.searchUserControl2.Name = "searchUserControl2";
            this.searchUserControl2.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl2.TabIndex = 68;
            // 
            // searchPeriodControl1
            // 
            this.searchPeriodControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchPeriodControl1.Labelname = "기간 선택";
            this.searchPeriodControl1.Location = new System.Drawing.Point(186, 11);
            this.searchPeriodControl1.Name = "searchPeriodControl1";
            this.searchPeriodControl1.Size = new System.Drawing.Size(312, 35);
            this.searchPeriodControl1.TabIndex = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_In);
            this.groupBox1.Controls.Add(this.rdo_Out);
            this.groupBox1.Controls.Add(this.rdo_All);
            this.groupBox1.Location = new System.Drawing.Point(33, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 86);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "구분";
            // 
            // rdo_In
            // 
            this.rdo_In.AutoSize = true;
            this.rdo_In.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdo_In.Location = new System.Drawing.Point(42, 38);
            this.rdo_In.Name = "rdo_In";
            this.rdo_In.Size = new System.Drawing.Size(47, 18);
            this.rdo_In.TabIndex = 59;
            this.rdo_In.Text = "입고";
            this.rdo_In.UseVisualStyleBackColor = true;
            this.rdo_In.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdo_Out
            // 
            this.rdo_Out.AutoSize = true;
            this.rdo_Out.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdo_Out.Location = new System.Drawing.Point(42, 62);
            this.rdo_Out.Name = "rdo_Out";
            this.rdo_Out.Size = new System.Drawing.Size(47, 18);
            this.rdo_Out.TabIndex = 60;
            this.rdo_Out.Text = "출고";
            this.rdo_Out.UseVisualStyleBackColor = true;
            this.rdo_Out.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdo_All
            // 
            this.rdo_All.AutoSize = true;
            this.rdo_All.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdo_All.Location = new System.Drawing.Point(42, 14);
            this.rdo_All.Name = "rdo_All";
            this.rdo_All.Size = new System.Drawing.Size(47, 18);
            this.rdo_All.TabIndex = 58;
            this.rdo_All.Text = "전체";
            this.rdo_All.UseVisualStyleBackColor = true;
            this.rdo_All.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // InOutList_SemiProductWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormName = "수불내역(반제품)";
            this.Name = "InOutList_SemiProductWarehouse";
            this.Load += new System.EventHandler(this.InOutList_SemiProductWarehouse_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Stock;
        private SearchUserControl searchUserControl1;
        private SearchUserControl searchUserControl2;
        private SearchPeriodControl searchPeriodControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_In;
        private System.Windows.Forms.RadioButton rdo_Out;
        private System.Windows.Forms.RadioButton rdo_All;
    }
}
