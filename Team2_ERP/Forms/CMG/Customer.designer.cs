namespace Team2_ERP
{
    partial class Customer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.searchCustomerName = new Team2_ERP.SearchUserControl();
            this.searchCustomerBirth = new Team2_ERP.SearchPeriodControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCustomer);
            this.panel1.Size = new System.Drawing.Size(1344, 729);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.dgvCustomer, 0);
            // 
            // panel_Search
            // 
            this.panel_Search.Size = new System.Drawing.Size(1344, 110);
            // 
            // panel4
            // 
            this.panel4.Size = new System.Drawing.Size(1344, 2);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchCustomerBirth);
            this.panel5.Controls.Add(this.searchCustomerName);
            this.panel5.Size = new System.Drawing.Size(1344, 110);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(1344, 48);
            // 
            // linepanel1
            // 
            this.linepanel1.Size = new System.Drawing.Size(1344, 2);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomer.Location = new System.Drawing.Point(0, 158);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowTemplate.Height = 23;
            this.dgvCustomer.Size = new System.Drawing.Size(1344, 571);
            this.dgvCustomer.TabIndex = 7;
            // 
            // searchCustomerName
            // 
            this.searchCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchCustomerName.ControlType = Team2_ERP.SearchUserControl.Mode.Customer;
            this.searchCustomerName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchCustomerName.Labelname = "고객";
            this.searchCustomerName.Location = new System.Drawing.Point(3, 39);
            this.searchCustomerName.Name = "searchCustomerName";
            this.searchCustomerName.Size = new System.Drawing.Size(312, 30);
            this.searchCustomerName.TabIndex = 0;
            // 
            // searchCustomerBirth
            // 
            this.searchCustomerBirth.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchCustomerBirth.Labelname = "생년 월일";
            this.searchCustomerBirth.Location = new System.Drawing.Point(333, 39);
            this.searchCustomerBirth.Name = "searchCustomerBirth";
            this.searchCustomerBirth.Size = new System.Drawing.Size(312, 25);
            this.searchCustomerBirth.TabIndex = 1;
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Name = "Customer";
            this.Text = "Customer";
            this.Activated += new System.EventHandler(this.Customer_Activated);
            this.Deactivate += new System.EventHandler(this.Customer_Deactivate);
            this.Load += new System.EventHandler(this.Customer_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private SearchUserControl searchCustomerName;
        private SearchPeriodControl searchCustomerBirth;
    }
}