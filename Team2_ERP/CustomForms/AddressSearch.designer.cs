namespace Team2_ERP
{
    partial class AddressSearch
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtJibunAddr2 = new System.Windows.Forms.TextBox();
            this.txtJibunZipCode = new System.Windows.Forms.TextBox();
            this.txtJibunAddr1 = new System.Windows.Forms.TextBox();
            this.btnJibun = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtLoadAddr2 = new System.Windows.Forms.TextBox();
            this.txtLoadZipCode = new System.Windows.Forms.TextBox();
            this.txtLoadaddr1 = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSearch);
            this.panel6.Controls.Add(this.txtSearch);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(798, 70);
            this.panel6.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(443, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(170, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(256, 21);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "도로명(지번) 주소 검색";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtJibunAddr2);
            this.panel7.Controls.Add(this.txtJibunZipCode);
            this.panel7.Controls.Add(this.txtJibunAddr1);
            this.panel7.Controls.Add(this.btnJibun);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 331);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(798, 78);
            this.panel7.TabIndex = 1;
            // 
            // txtJibunAddr2
            // 
            this.txtJibunAddr2.Location = new System.Drawing.Point(222, 44);
            this.txtJibunAddr2.Name = "txtJibunAddr2";
            this.txtJibunAddr2.Size = new System.Drawing.Size(289, 21);
            this.txtJibunAddr2.TabIndex = 9;
            // 
            // txtJibunZipCode
            // 
            this.txtJibunZipCode.Location = new System.Drawing.Point(115, 44);
            this.txtJibunZipCode.Name = "txtJibunZipCode";
            this.txtJibunZipCode.Size = new System.Drawing.Size(100, 21);
            this.txtJibunZipCode.TabIndex = 10;
            // 
            // txtJibunAddr1
            // 
            this.txtJibunAddr1.Location = new System.Drawing.Point(116, 17);
            this.txtJibunAddr1.Name = "txtJibunAddr1";
            this.txtJibunAddr1.Size = new System.Drawing.Size(395, 21);
            this.txtJibunAddr1.TabIndex = 8;
            // 
            // btnJibun
            // 
            this.btnJibun.Location = new System.Drawing.Point(50, 17);
            this.btnJibun.Name = "btnJibun";
            this.btnJibun.Size = new System.Drawing.Size(59, 48);
            this.btnJibun.TabIndex = 7;
            this.btnJibun.Text = "지번주소 확인";
            this.btnJibun.UseVisualStyleBackColor = true;
            this.btnJibun.Click += new System.EventHandler(this.btnJibun_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtLoadAddr2);
            this.panel8.Controls.Add(this.txtLoadZipCode);
            this.panel8.Controls.Add(this.txtLoadaddr1);
            this.panel8.Controls.Add(this.btnLoad);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 252);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(798, 79);
            this.panel8.TabIndex = 2;
            // 
            // txtLoadAddr2
            // 
            this.txtLoadAddr2.Location = new System.Drawing.Point(233, 42);
            this.txtLoadAddr2.Name = "txtLoadAddr2";
            this.txtLoadAddr2.Size = new System.Drawing.Size(289, 21);
            this.txtLoadAddr2.TabIndex = 9;
            // 
            // txtLoadZipCode
            // 
            this.txtLoadZipCode.Location = new System.Drawing.Point(127, 43);
            this.txtLoadZipCode.Name = "txtLoadZipCode";
            this.txtLoadZipCode.Size = new System.Drawing.Size(100, 21);
            this.txtLoadZipCode.TabIndex = 10;
            // 
            // txtLoadaddr1
            // 
            this.txtLoadaddr1.Location = new System.Drawing.Point(127, 15);
            this.txtLoadaddr1.Name = "txtLoadaddr1";
            this.txtLoadaddr1.Size = new System.Drawing.Size(395, 21);
            this.txtLoadaddr1.TabIndex = 8;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(50, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(70, 49);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "도로명주소 확인";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dataGridView1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 70);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(798, 182);
            this.panel9.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(798, 182);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // AddressSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Name = "AddressSearch";
            this.Text = "AddressSearch";
            this.Load += new System.EventHandler(this.AddressSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtLoadAddr2;
        private System.Windows.Forms.TextBox txtLoadZipCode;
        private System.Windows.Forms.TextBox txtLoadaddr1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtJibunAddr2;
        private System.Windows.Forms.TextBox txtJibunZipCode;
        private System.Windows.Forms.TextBox txtJibunAddr1;
        private System.Windows.Forms.Button btnJibun;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}