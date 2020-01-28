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
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(285, 273);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(39, 2);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(283, 32);
            // 
            // lblName
            // 
            this.lblName.Size = new System.Drawing.Size(179, 32);
            this.lblName.Text = "비가동유형등록";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(217, 0);
            this.panel3.Size = new System.Drawing.Size(66, 32);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Size = new System.Drawing.Size(283, 157);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 221);
            this.panel4.Size = new System.Drawing.Size(283, 50);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(283, 32);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(170, 3);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(35, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "비가동유형명";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtCustomerID);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(281, 35);
            this.panel6.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "비가동유형코드";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(112, 9);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(160, 21);
            this.txtCustomerID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "비가동유형내용";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 87);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 64);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 21);
            this.textBox1.TabIndex = 10;
            // 
            // DowntimeTypeAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(285, 273);
            this.Labelname = "비가동유형등록";
            this.Name = "DowntimeTypeAdd";
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
