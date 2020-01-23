namespace Team2_POP
{
    partial class MonthCalandarForm
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
            this.singleMonthCalandar1 = new Team2_POP.SingleMonthCalandar();
            this.SuspendLayout();
            // 
            // singleMonthCalandar1
            // 
            this.singleMonthCalandar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleMonthCalandar1.Location = new System.Drawing.Point(0, 0);
            this.singleMonthCalandar1.Name = "singleMonthCalandar1";
            this.singleMonthCalandar1.TabIndex = 0;
            this.singleMonthCalandar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.singleMonthCalandar1_DateSelected);
            // 
            // MonthCalandarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 43F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 432);
            this.Controls.Add(this.singleMonthCalandar1);
            this.Font = new System.Drawing.Font("나눔고딕", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Name = "MonthCalandarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "달력선택화면";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SingleMonthCalandar singleMonthCalandar1;
    }
}