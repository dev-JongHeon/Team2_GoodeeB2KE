namespace Team2_ERP
{
    partial class DowntimeTypeAdd
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
            this.panel_Modi = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExplain = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel_Modi.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(277, 273);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(39, 2);
            this.btnClose.TabStop = false;
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(275, 32);
            // 
            // lblName
            // 
            this.lblName.Size = new System.Drawing.Size(179, 30);
            this.lblName.Text = "비가동유형등록";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(207, 0);
            this.panel3.Size = new System.Drawing.Size(66, 30);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel_Modi);
            this.panel5.Location = new System.Drawing.Point(0, 67);
            this.panel5.Size = new System.Drawing.Size(275, 169);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 236);
            this.panel4.Size = new System.Drawing.Size(275, 35);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(275, 35);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(170, 3);
            this.btnCancel.Size = new System.Drawing.Size(83, 28);
            this.btnCancel.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(35, 3);
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel_Modi
            // 
            this.panel_Modi.Controls.Add(this.label1);
            this.panel_Modi.Controls.Add(this.txtID);
            this.panel_Modi.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Modi.Location = new System.Drawing.Point(0, 0);
            this.panel_Modi.Name = "panel_Modi";
            this.panel_Modi.Size = new System.Drawing.Size(273, 35);
            this.panel_Modi.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "비가동유형코드";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(100, 8);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(160, 21);
            this.txtID.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.txtExplain);
            this.panel7.Controls.Add(this.txtName);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 35);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(273, 132);
            this.panel7.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 13;
            this.label2.Text = "비가동유형명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(10, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "비가동유형내용";
            // 
            // txtExplain
            // 
            this.txtExplain.Location = new System.Drawing.Point(100, 53);
            this.txtExplain.Multiline = true;
            this.txtExplain.Name = "txtExplain";
            this.txtExplain.Size = new System.Drawing.Size(160, 64);
            this.txtExplain.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(160, 21);
            this.txtName.TabIndex = 1;
            // 
            // DowntimeTypeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(277, 273);
            this.Labelname = "비가동유형등록";
            this.Name = "DowntimeTypeAdd";
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel_Modi.ResumeLayout(false);
            this.panel_Modi.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_Modi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExplain;
        private System.Windows.Forms.TextBox txtName;
    }
}
