namespace Team2_ERP
{
    partial class Factory
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
            this.dgvFactory = new System.Windows.Forms.DataGridView();
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.searchUserControl1 = new Team2_ERP.SearchUserControl();
            this.searchUserControl2 = new Team2_ERP.SearchUserControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvFactory);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvLine);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchUserControl2);
            this.panel5.Controls.Add(this.searchUserControl1);
            // 
            // dgvFactory
            // 
            this.dgvFactory.BackgroundColor = System.Drawing.Color.White;
            this.dgvFactory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFactory.Location = new System.Drawing.Point(0, 0);
            this.dgvFactory.Name = "dgvFactory";
            this.dgvFactory.RowTemplate.Height = 23;
            this.dgvFactory.Size = new System.Drawing.Size(1364, 368);
            this.dgvFactory.TabIndex = 8;
            this.dgvFactory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFactory_CellClick);
            // 
            // dgvLine
            // 
            this.dgvLine.BackgroundColor = System.Drawing.Color.White;
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLine.Location = new System.Drawing.Point(0, 0);
            this.dgvLine.Name = "dgvLine";
            this.dgvLine.RowTemplate.Height = 23;
            this.dgvLine.Size = new System.Drawing.Size(1364, 290);
            this.dgvLine.TabIndex = 0;
            this.dgvLine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLine_CellClick);
            // 
            // searchUserControl1
            // 
            this.searchUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl1.ControlType = Team2_ERP.SearchUserControl.Mode.Factory;
            this.searchUserControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl1.Labelname = "공장";
            this.searchUserControl1.Location = new System.Drawing.Point(3, 6);
            this.searchUserControl1.Name = "searchUserControl1";
            this.searchUserControl1.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl1.TabIndex = 0;
            // 
            // searchUserControl2
            // 
            this.searchUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl2.ControlType = Team2_ERP.SearchUserControl.Mode.Line;
            this.searchUserControl2.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl2.Labelname = "공정";
            this.searchUserControl2.Location = new System.Drawing.Point(3, 37);
            this.searchUserControl2.Name = "searchUserControl2";
            this.searchUserControl2.Size = new System.Drawing.Size(312, 25);
            this.searchUserControl2.TabIndex = 1;
            // 
            // Factory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Factory";
            this.Text = "Factory";
            this.Activated += new System.EventHandler(this.Factory_Activated);
            this.Deactivate += new System.EventHandler(this.Factory_Deactivate);
            this.Load += new System.EventHandler(this.Factory_Load);
            this.Shown += new System.EventHandler(this.Factory_Shown);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFactory;
        private System.Windows.Forms.DataGridView dgvLine;
        private SearchUserControl searchUserControl2;
        private SearchUserControl searchUserControl1;
    }
}