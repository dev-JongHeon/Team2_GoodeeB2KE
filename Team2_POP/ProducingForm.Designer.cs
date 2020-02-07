namespace Team2_POP
{
    partial class ProducingForm
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
            this.picProducing = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picProducing)).BeginInit();
            this.SuspendLayout();
            // 
            // picProducing
            // 
            this.picProducing.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picProducing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProducing.Image = global::Team2_POP.Properties.Resources.생산;
            this.picProducing.Location = new System.Drawing.Point(0, 0);
            this.picProducing.Name = "picProducing";
            this.picProducing.Size = new System.Drawing.Size(555, 284);
            this.picProducing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProducing.TabIndex = 0;
            this.picProducing.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(217, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "생산중입니다.";
            // 
            // ProducingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picProducing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProducingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProducingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProducingForm_FormClosing);
            this.Load += new System.EventHandler(this.ProducingForm_Load);
            this.Shown += new System.EventHandler(this.ProducingForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picProducing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picProducing;
        private System.Windows.Forms.Label label1;
    }
}