namespace Team2_POP
{
    partial class DefectiveRegister
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDefItem = new System.Windows.Forms.Label();
            this.btnDefProSelect = new System.Windows.Forms.Button();
            this.cboDefItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPerformance = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDefectiveName = new System.Windows.Forms.ComboBox();
            this.btnDefNameSelect = new System.Windows.Forms.Button();
            this.lblDefectiveName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboHandle = new System.Windows.Forms.ComboBox();
            this.btnHandle = new System.Windows.Forms.Button();
            this.lblHandle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(180, 640);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 78);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "불량 등록";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDefItem
            // 
            this.lblDefItem.AutoSize = true;
            this.lblDefItem.Location = new System.Drawing.Point(16, 230);
            this.lblDefItem.Name = "lblDefItem";
            this.lblDefItem.Size = new System.Drawing.Size(197, 31);
            this.lblDefItem.TabIndex = 10;
            this.lblDefItem.Text = "선택된 불량품목";
            // 
            // btnDefProSelect
            // 
            this.btnDefProSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefProSelect.Location = new System.Drawing.Point(340, 175);
            this.btnDefProSelect.Name = "btnDefProSelect";
            this.btnDefProSelect.Size = new System.Drawing.Size(104, 39);
            this.btnDefProSelect.TabIndex = 2;
            this.btnDefProSelect.Text = "선택";
            this.btnDefProSelect.UseVisualStyleBackColor = true;
            this.btnDefProSelect.Click += new System.EventHandler(this.btnDefProSelect_Click);
            // 
            // cboDefItem
            // 
            this.cboDefItem.BackColor = System.Drawing.Color.White;
            this.cboDefItem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDefItem.FormattingEnabled = true;
            this.cboDefItem.Location = new System.Drawing.Point(22, 175);
            this.cboDefItem.Name = "cboDefItem";
            this.cboDefItem.Size = new System.Drawing.Size(293, 39);
            this.cboDefItem.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "불량코드";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "생산 실적 번호";
            // 
            // lblPerformance
            // 
            this.lblPerformance.AutoSize = true;
            this.lblPerformance.Location = new System.Drawing.Point(16, 62);
            this.lblPerformance.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblPerformance.Name = "lblPerformance";
            this.lblPerformance.Size = new System.Drawing.Size(222, 31);
            this.lblPerformance.TabIndex = 0;
            this.lblPerformance.Text = "2020010500001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 290);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "불량유형";
            // 
            // cboDefectiveName
            // 
            this.cboDefectiveName.BackColor = System.Drawing.Color.White;
            this.cboDefectiveName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboDefectiveName.FormattingEnabled = true;
            this.cboDefectiveName.Location = new System.Drawing.Point(22, 335);
            this.cboDefectiveName.Name = "cboDefectiveName";
            this.cboDefectiveName.Size = new System.Drawing.Size(293, 39);
            this.cboDefectiveName.TabIndex = 4;
            // 
            // btnDefNameSelect
            // 
            this.btnDefNameSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefNameSelect.Location = new System.Drawing.Point(340, 335);
            this.btnDefNameSelect.Name = "btnDefNameSelect";
            this.btnDefNameSelect.Size = new System.Drawing.Size(104, 39);
            this.btnDefNameSelect.TabIndex = 5;
            this.btnDefNameSelect.Text = "선택";
            this.btnDefNameSelect.UseVisualStyleBackColor = true;
            this.btnDefNameSelect.Click += new System.EventHandler(this.btnDefNameSelect_Click);
            // 
            // lblDefectiveName
            // 
            this.lblDefectiveName.AutoSize = true;
            this.lblDefectiveName.Location = new System.Drawing.Point(16, 393);
            this.lblDefectiveName.Name = "lblDefectiveName";
            this.lblDefectiveName.Size = new System.Drawing.Size(197, 31);
            this.lblDefectiveName.TabIndex = 6;
            this.lblDefectiveName.Text = "선택된 불량유형";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 448);
            this.label7.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "불량처리";
            // 
            // cboHandle
            // 
            this.cboHandle.BackColor = System.Drawing.Color.White;
            this.cboHandle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboHandle.FormattingEnabled = true;
            this.cboHandle.Location = new System.Drawing.Point(22, 493);
            this.cboHandle.Name = "cboHandle";
            this.cboHandle.Size = new System.Drawing.Size(293, 39);
            this.cboHandle.TabIndex = 7;
            // 
            // btnHandle
            // 
            this.btnHandle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandle.Location = new System.Drawing.Point(340, 493);
            this.btnHandle.Name = "btnHandle";
            this.btnHandle.Size = new System.Drawing.Size(104, 39);
            this.btnHandle.TabIndex = 8;
            this.btnHandle.Text = "선택";
            this.btnHandle.UseVisualStyleBackColor = true;
            this.btnHandle.Click += new System.EventHandler(this.btnHandle_Click);
            // 
            // lblHandle
            // 
            this.lblHandle.AutoSize = true;
            this.lblHandle.Location = new System.Drawing.Point(16, 551);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(255, 31);
            this.lblHandle.TabIndex = 9;
            this.lblHandle.Text = "선택된 불량 처리유형";
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(340, 640);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 78);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAs.Location = new System.Drawing.Point(22, 640);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(146, 78);
            this.btnSaveAs.TabIndex = 10;
            this.btnSaveAs.Text = "불량 추가 등록";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // DefectiveRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(469, 742);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHandle);
            this.Controls.Add(this.lblDefectiveName);
            this.Controls.Add(this.btnHandle);
            this.Controls.Add(this.lblDefItem);
            this.Controls.Add(this.cboHandle);
            this.Controls.Add(this.btnDefNameSelect);
            this.Controls.Add(this.cboDefectiveName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDefProSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboDefItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPerformance);
            this.Font = new System.Drawing.Font("나눔고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "DefectiveRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "불량 품목 등록";
            this.Load += new System.EventHandler(this.DefectiveRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDefItem;
        private System.Windows.Forms.Button btnDefProSelect;
        private System.Windows.Forms.ComboBox cboDefItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPerformance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDefectiveName;
        private System.Windows.Forms.Button btnDefNameSelect;
        private System.Windows.Forms.Label lblDefectiveName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboHandle;
        private System.Windows.Forms.Button btnHandle;
        private System.Windows.Forms.Label lblHandle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveAs;
    }
}