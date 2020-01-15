namespace Team2_POP
{
    partial class DowntimeRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblFairName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboDowntime = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblDowntimeName = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "공정 명";
            // 
            // lblFairName
            // 
            this.lblFairName.AutoSize = true;
            this.lblFairName.Location = new System.Drawing.Point(12, 67);
            this.lblFairName.Name = "lblFairName";
            this.lblFairName.Size = new System.Drawing.Size(147, 31);
            this.lblFairName.TabIndex = 1;
            this.lblFairName.Text = "구동부 공정";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "비가동 유형";
            // 
            // cboDowntime
            // 
            this.cboDowntime.FormattingEnabled = true;
            this.cboDowntime.Location = new System.Drawing.Point(18, 176);
            this.cboDowntime.Name = "cboDowntime";
            this.cboDowntime.Size = new System.Drawing.Size(285, 39);
            this.cboDowntime.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(327, 175);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(119, 39);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // lblDowntimeName
            // 
            this.lblDowntimeName.AutoSize = true;
            this.lblDowntimeName.Location = new System.Drawing.Point(12, 235);
            this.lblDowntimeName.Name = "lblDowntimeName";
            this.lblDowntimeName.Size = new System.Drawing.Size(172, 31);
            this.lblDowntimeName.TabIndex = 4;
            this.lblDowntimeName.Text = "비가동 유형명";
            // 
            // btnToggle
            // 
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Location = new System.Drawing.Point(19, 307);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(165, 62);
            this.btnToggle.TabIndex = 5;
            this.btnToggle.Text = "비가동 전환";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(281, 307);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 62);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DowntimeRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 404);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.lblDowntimeName);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.cboDowntime);
            this.Controls.Add(this.lblFairName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "DowntimeRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "비가동 등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFairName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboDowntime;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblDowntimeName;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Button btnClose;
    }
}