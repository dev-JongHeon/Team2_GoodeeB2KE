﻿namespace Team2_ERP
{
    partial class ShipmentCompleteForm
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
            this.Search_Employees = new Team2_ERP.SearchUserControl();
            this.Search_OrderPeriod = new Team2_ERP.SearchPeriodControl();
            this.Search_Customer = new Team2_ERP.SearchUserControl();
            this.dgv_Shipment = new System.Windows.Forms.DataGridView();
            this.dgv_ShipmentDetail = new System.Windows.Forms.DataGridView();
            this.Search_OrderCompletedPeriod = new Team2_ERP.SearchPeriodControl();
            this.Search_ShipmentRequiredPeriod = new Team2_ERP.SearchPeriodControl();
            this.Search_ShipmentDonePeriod = new Team2_ERP.SearchPeriodControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShipmentDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Shipment);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_ShipmentDetail);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Search_ShipmentDonePeriod);
            this.panel5.Controls.Add(this.Search_ShipmentRequiredPeriod);
            this.panel5.Controls.Add(this.Search_OrderCompletedPeriod);
            this.panel5.Controls.Add(this.Search_Employees);
            this.panel5.Controls.Add(this.Search_OrderPeriod);
            this.panel5.Controls.Add(this.Search_Customer);
            // 
            // lblFormName
            // 
            this.lblFormName.Text = "출하완료현황";
            // 
            // Search_Employees
            // 
            this.Search_Employees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Employees.ControlType = Team2_ERP.SearchUserControl.Mode.Employee;
            this.Search_Employees.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Employees.Labelname = "출하지시자";
            this.Search_Employees.Location = new System.Drawing.Point(348, 72);
            this.Search_Employees.Name = "Search_Employees";
            this.Search_Employees.Size = new System.Drawing.Size(312, 25);
            this.Search_Employees.TabIndex = 6;
            // 
            // Search_OrderPeriod
            // 
            this.Search_OrderPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_OrderPeriod.Labelname = "주문일자";
            this.Search_OrderPeriod.Location = new System.Drawing.Point(14, 41);
            this.Search_OrderPeriod.Name = "Search_OrderPeriod";
            this.Search_OrderPeriod.Size = new System.Drawing.Size(312, 25);
            this.Search_OrderPeriod.TabIndex = 4;
            // 
            // Search_Customer
            // 
            this.Search_Customer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.Search_Customer.ControlType = Team2_ERP.SearchUserControl.Mode.Customer;
            this.Search_Customer.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Customer.Labelname = "고객성명";
            this.Search_Customer.Location = new System.Drawing.Point(348, 41);
            this.Search_Customer.Name = "Search_Customer";
            this.Search_Customer.Size = new System.Drawing.Size(312, 25);
            this.Search_Customer.TabIndex = 3;
            // 
            // dgv_Shipment
            // 
            this.dgv_Shipment.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Shipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Shipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Shipment.Location = new System.Drawing.Point(0, 0);
            this.dgv_Shipment.Name = "dgv_Shipment";
            this.dgv_Shipment.RowTemplate.Height = 23;
            this.dgv_Shipment.Size = new System.Drawing.Size(1364, 368);
            this.dgv_Shipment.TabIndex = 37;
            this.dgv_Shipment.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Shipment_CellDoubleClick);
            // 
            // dgv_ShipmentDetail
            // 
            this.dgv_ShipmentDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ShipmentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShipmentDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShipmentDetail.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShipmentDetail.Name = "dgv_ShipmentDetail";
            this.dgv_ShipmentDetail.RowTemplate.Height = 23;
            this.dgv_ShipmentDetail.Size = new System.Drawing.Size(1364, 290);
            this.dgv_ShipmentDetail.TabIndex = 38;
            // 
            // Search_OrderCompletedPeriod
            // 
            this.Search_OrderCompletedPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_OrderCompletedPeriod.Labelname = "주문처리일자";
            this.Search_OrderCompletedPeriod.Location = new System.Drawing.Point(14, 10);
            this.Search_OrderCompletedPeriod.Name = "Search_OrderCompletedPeriod";
            this.Search_OrderCompletedPeriod.Size = new System.Drawing.Size(312, 25);
            this.Search_OrderCompletedPeriod.TabIndex = 7;
            // 
            // Search_ShipmentRequiredPeriod
            // 
            this.Search_ShipmentRequiredPeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_ShipmentRequiredPeriod.Labelname = "출하요청일자";
            this.Search_ShipmentRequiredPeriod.Location = new System.Drawing.Point(14, 72);
            this.Search_ShipmentRequiredPeriod.Name = "Search_ShipmentRequiredPeriod";
            this.Search_ShipmentRequiredPeriod.Size = new System.Drawing.Size(312, 25);
            this.Search_ShipmentRequiredPeriod.TabIndex = 8;
            // 
            // Search_ShipmentDonePeriod
            // 
            this.Search_ShipmentDonePeriod.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_ShipmentDonePeriod.Labelname = "출하처리일자";
            this.Search_ShipmentDonePeriod.Location = new System.Drawing.Point(348, 10);
            this.Search_ShipmentDonePeriod.Name = "Search_ShipmentDonePeriod";
            this.Search_ShipmentDonePeriod.Size = new System.Drawing.Size(312, 25);
            this.Search_ShipmentDonePeriod.TabIndex = 9;
            // 
            // ShipmentCompleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.FormName = "출하완료현황";
            this.Name = "ShipmentCompleteForm";
            this.Activated += new System.EventHandler(this.ShipmentCompleteForm_Activated);
            this.Deactivate += new System.EventHandler(this.ShipmentCompleteForm_Deactivate);
            this.Load += new System.EventHandler(this.ShipmentCompleteForm_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Shipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShipmentDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SearchUserControl Search_Employees;
        private SearchPeriodControl Search_OrderPeriod;
        private SearchUserControl Search_Customer;
        private System.Windows.Forms.DataGridView dgv_Shipment;
        private System.Windows.Forms.DataGridView dgv_ShipmentDetail;
        private SearchPeriodControl Search_OrderCompletedPeriod;
        private SearchPeriodControl Search_ShipmentRequiredPeriod;
        private SearchPeriodControl Search_ShipmentDonePeriod;
    }
}
