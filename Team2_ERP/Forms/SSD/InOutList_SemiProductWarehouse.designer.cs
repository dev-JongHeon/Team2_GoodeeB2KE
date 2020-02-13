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
            this.Search_SemiProduct = new Team2_ERP.SearchUserControl();
            this.Search_Warehouse = new Team2_ERP.SearchUserControl();
            this.Search_Period = new Team2_ERP.SearchPeriodControl();
            this.Group_Rdo = new System.Windows.Forms.GroupBox();
            this.rdo_In = new System.Windows.Forms.RadioButton();
            this.rdo_Out = new System.Windows.Forms.RadioButton();
            this.rdo_All = new System.Windows.Forms.RadioButton();
            this.Search_Employees = new Team2_ERP.SearchUserControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).BeginInit();
            this.Group_Rdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Stock);
            this.panel2.Location = new System.Drawing.Point(0, 192);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(1364, 628);
            // 
            // panel_Search
            // 
            this.panel_Search.Location = new System.Drawing.Point(0, 58);
            this.panel_Search.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Search.Size = new System.Drawing.Size(1364, 134);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 132);
            this.panel4.Margin = new System.Windows.Forms.Padding(5);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_Employees);
            this.panel5.Controls.Add(this.Group_Rdo);
            this.panel5.Controls.Add(this.Search_SemiProduct);
            this.panel5.Controls.Add(this.Search_Warehouse);
            this.panel5.Controls.Add(this.Search_Period);
            this.panel5.Size = new System.Drawing.Size(1364, 134);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(1364, 58);
            // 
            // panel8
            // 
            this.panel8.Size = new System.Drawing.Size(243, 56);
            // 
            // lblFormName
            // 
            this.lblFormName.Location = new System.Drawing.Point(59, 0);
            this.lblFormName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormName.Size = new System.Drawing.Size(184, 56);
            this.lblFormName.Text = "수불내역(반제품)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Size = new System.Drawing.Size(59, 56);
            // 
            // linepanel1
            // 
            this.linepanel1.Location = new System.Drawing.Point(0, 56);
            this.linepanel1.Margin = new System.Windows.Forms.Padding(5);
            // 
            // dgv_Stock
            // 
            this.dgv_Stock.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Stock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Stock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Stock.Location = new System.Drawing.Point(0, 0);
            this.dgv_Stock.Name = "dgv_Stock";
            this.dgv_Stock.RowHeadersWidth = 51;
            this.dgv_Stock.RowTemplate.Height = 23;
            this.dgv_Stock.Size = new System.Drawing.Size(1364, 628);
            this.dgv_Stock.TabIndex = 2;
            // 
            // Search_SemiProduct
            // 
            this.Search_SemiProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_SemiProduct.ControlType = Team2_ERP.SearchUserControl.Mode.SemiProduct;
            this.Search_SemiProduct.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_SemiProduct.Labelname = "반제품";
            this.Search_SemiProduct.Location = new System.Drawing.Point(186, 81);
            this.Search_SemiProduct.Name = "Search_SemiProduct";
            this.Search_SemiProduct.Size = new System.Drawing.Size(312, 25);
            this.Search_SemiProduct.TabIndex = 69;
            // 
            // Search_Warehouse
            // 
            this.Search_Warehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Warehouse.ControlType = Team2_ERP.SearchUserControl.Mode.Warehouse;
            this.Search_Warehouse.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Warehouse.Labelname = "창고";
            this.Search_Warehouse.Location = new System.Drawing.Point(186, 49);
            this.Search_Warehouse.Name = "Search_Warehouse";
            this.Search_Warehouse.Size = new System.Drawing.Size(312, 25);
            this.Search_Warehouse.TabIndex = 68;
            // 
            // Search_Period
            // 
            this.Search_Period.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Period.Labelname = "처리일자";
            this.Search_Period.Location = new System.Drawing.Point(186, 19);
            this.Search_Period.Name = "Search_Period";
            this.Search_Period.Size = new System.Drawing.Size(312, 35);
            this.Search_Period.TabIndex = 67;
            // 
            // Group_Rdo
            // 
            this.Group_Rdo.Controls.Add(this.rdo_In);
            this.Group_Rdo.Controls.Add(this.rdo_Out);
            this.Group_Rdo.Controls.Add(this.rdo_All);
            this.Group_Rdo.Location = new System.Drawing.Point(33, 17);
            this.Group_Rdo.Name = "Group_Rdo";
            this.Group_Rdo.Size = new System.Drawing.Size(130, 86);
            this.Group_Rdo.TabIndex = 70;
            this.Group_Rdo.TabStop = false;
            this.Group_Rdo.Text = "구분";
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
            // Search_Employees
            // 
            this.Search_Employees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Employees.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.Search_Employees.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Employees.Labelname = "작업자";
            this.Search_Employees.Location = new System.Drawing.Point(537, 19);
            this.Search_Employees.Name = "Search_Employees";
            this.Search_Employees.Size = new System.Drawing.Size(312, 25);
            this.Search_Employees.TabIndex = 71;
            // 
            // InOutList_SemiProductWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormName = "수불내역(반제품)";
            this.Name = "InOutList_SemiProductWarehouse";
            this.Activated += new System.EventHandler(this.InOutList_SemiProductWarehouse_Activated);
            this.Deactivate += new System.EventHandler(this.InOutList_SemiProductWarehouse_Deactivate);
            this.Load += new System.EventHandler(this.InOutList_SemiProductWarehouse_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Stock)).EndInit();
            this.Group_Rdo.ResumeLayout(false);
            this.Group_Rdo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Stock;
        private SearchUserControl Search_SemiProduct;
        private SearchUserControl Search_Warehouse;
        private SearchPeriodControl Search_Period;
        private System.Windows.Forms.GroupBox Group_Rdo;
        private System.Windows.Forms.RadioButton rdo_In;
        private System.Windows.Forms.RadioButton rdo_Out;
        private System.Windows.Forms.RadioButton rdo_All;
        private SearchUserControl Search_Employees;
    }
}
