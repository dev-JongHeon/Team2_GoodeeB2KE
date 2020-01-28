namespace Team2_ERP
{
    partial class LineInsUp
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
            this.cboFactoryName = new System.Windows.Forms.ComboBox();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDownTime = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel_Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(332, 290);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(330, 32);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(130, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cboDownTime);
            this.panel5.Controls.Add(this.cboFactoryName);
            this.panel5.Controls.Add(this.txtLineName);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Size = new System.Drawing.Size(330, 174);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 238);
            this.panel4.Size = new System.Drawing.Size(330, 50);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(330, 32);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(204, 3);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(52, 3);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboFactoryName
            // 
            this.cboFactoryName.FormattingEnabled = true;
            this.cboFactoryName.Location = new System.Drawing.Point(123, 72);
            this.cboFactoryName.Name = "cboFactoryName";
            this.cboFactoryName.Size = new System.Drawing.Size(132, 22);
            this.cboFactoryName.TabIndex = 9;
            // 
            // txtLineName
            // 
            this.txtLineName.Location = new System.Drawing.Point(123, 20);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(132, 21);
            this.txtLineName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(50, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "공장이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(50, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "공정이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(50, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "비가동여부";
            // 
            // cboDownTime
            // 
            this.cboDownTime.FormattingEnabled = true;
            this.cboDownTime.Location = new System.Drawing.Point(123, 127);
            this.cboDownTime.Name = "cboDownTime";
            this.cboDownTime.Size = new System.Drawing.Size(132, 22);
            this.cboDownTime.TabIndex = 10;
            // 
            // LineInsUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 290);
            this.Name = "LineInsUp";
            this.Text = "LineInsUp";
            this.Load += new System.EventHandler(this.LineInsUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboFactoryName;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDownTime;
    }
}