namespace Team2_ERP
{
    partial class Resource
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
            this.dgvResource = new System.Windows.Forms.DataGridView();
            this.searchResourceName = new Team2_ERP.SearchUserControl();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvResource);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.dgvResource, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.searchResourceName);
            // 
            // dgvResource
            // 
            this.dgvResource.BackgroundColor = System.Drawing.Color.White;
            this.dgvResource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResource.Location = new System.Drawing.Point(0, 158);
            this.dgvResource.Name = "dgvResource";
            this.dgvResource.RowTemplate.Height = 23;
            this.dgvResource.Size = new System.Drawing.Size(1364, 662);
            this.dgvResource.TabIndex = 7;
            this.dgvResource.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // searchResourceName
            // 
            this.searchResourceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchResourceName.ControlType = Team2_ERP.SearchUserControl.Mode.Meterial;
            this.searchResourceName.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchResourceName.Labelname = "원자재";
            this.searchResourceName.Location = new System.Drawing.Point(3, 40);
            this.searchResourceName.Name = "searchResourceName";
            this.searchResourceName.Size = new System.Drawing.Size(312, 25);
            this.searchResourceName.TabIndex = 0;
            // 
            // Resource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 820);
            this.Name = "Resource";
            this.Text = "Resource";
            this.Activated += new System.EventHandler(this.Resource_Activated);
            this.Deactivate += new System.EventHandler(this.Resource_Deactivate);
            this.Load += new System.EventHandler(this.Resource_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResource;
        private SearchUserControl searchResourceName;
    }
}