namespace Team2_ERP
{
    partial class BOM
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvBOM = new System.Windows.Forms.DataGridView();
            this.dgvBOMDetail = new System.Windows.Forms.DataGridView();
            this.searchUserControl1 = new Team2_ERP.SearchUserControl();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.panel_Search.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel_Title.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Size = new System.Drawing.Size(1344, 729);
            this.panel1.Controls.SetChildIndex(this.panel_Title, 0);
            this.panel1.Controls.SetChildIndex(this.panel_Search, 0);
            this.panel1.Controls.SetChildIndex(this.splitContainer1, 0);
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
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.searchUserControl1);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 158);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvBOM);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvBOMDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1344, 571);
            this.splitContainer1.SplitterDistance = 617;
            this.splitContainer1.TabIndex = 7;
            // 
            // dgvBOM
            // 
            this.dgvBOM.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM.Location = new System.Drawing.Point(0, 0);
            this.dgvBOM.Name = "dgvBOM";
            this.dgvBOM.RowTemplate.Height = 23;
            this.dgvBOM.Size = new System.Drawing.Size(617, 571);
            this.dgvBOM.TabIndex = 0;
            this.dgvBOM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBOM_CellClick);
            this.dgvBOM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBOM_CellFormatting);
            // 
            // dgvBOMDetail
            // 
            this.dgvBOMDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOMDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBOMDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOMDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvBOMDetail.Name = "dgvBOMDetail";
            this.dgvBOMDetail.RowTemplate.Height = 23;
            this.dgvBOMDetail.Size = new System.Drawing.Size(723, 571);
            this.dgvBOMDetail.TabIndex = 0;
            // 
            // searchUserControl1
            // 
            this.searchUserControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.searchUserControl1.ControlType = Team2_ERP.SearchUserControl.Mode.Product;
            this.searchUserControl1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.searchUserControl1.Labelname = "제품";
            this.searchUserControl1.Location = new System.Drawing.Point(3, 69);
            this.searchUserControl1.Name = "searchUserControl1";
            this.searchUserControl1.Size = new System.Drawing.Size(312, 30);
            this.searchUserControl1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 18);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "전체";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(93, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 18);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "반제품";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(174, 24);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 18);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "완제품";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "분류";
            // 
            // BOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 729);
            this.Name = "BOM";
            this.Text = "BOM";
            this.Activated += new System.EventHandler(this.BOM_Activated);
            this.Deactivate += new System.EventHandler(this.BOM_Deactivate);
            this.Load += new System.EventHandler(this.BOM_Load);
            this.Shown += new System.EventHandler(this.BOM_Shown);
            this.panel1.ResumeLayout(false);
            this.panel_Search.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOMDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvBOMDetail;
        private SearchUserControl searchUserControl1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBOM;
    }
}