namespace Team2_POP
{
    partial class LoginPOP
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cboFactory = new System.Windows.Forms.ComboBox();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.cboWorker = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::Team2_POP.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(18, 108);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(391, 263);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // cboFactory
            // 
            this.cboFactory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFactory.FormattingEnabled = true;
            this.cboFactory.Location = new System.Drawing.Point(511, 19);
            this.cboFactory.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.cboFactory.Name = "cboFactory";
            this.cboFactory.Size = new System.Drawing.Size(624, 48);
            this.cboFactory.TabIndex = 0;
            this.cboFactory.SelectedIndexChanged += new System.EventHandler(this.cboFactory_SelectedIndexChanged);
            // 
            // cboLine
            // 
            this.cboLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(511, 195);
            this.cboLine.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(624, 48);
            this.cboLine.TabIndex = 2;
            // 
            // cboWorker
            // 
            this.cboWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWorker.FormattingEnabled = true;
            this.cboWorker.Location = new System.Drawing.Point(511, 107);
            this.cboWorker.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.cboWorker.Name = "cboWorker";
            this.cboWorker.Size = new System.Drawing.Size(624, 48);
            this.cboWorker.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(511, 299);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(251, 72);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "접속";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 79);
            this.label1.TabIndex = 5;
            this.label1.Text = "사원카드를 찍어주세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(884, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(251, 72);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "종료";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LoginPOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 40F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1166, 408);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cboWorker);
            this.Controls.Add(this.cboLine);
            this.Controls.Add(this.cboFactory);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("나눔고딕", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.Name = "LoginPOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인 화면";
            this.Load += new System.EventHandler(this.LoginPOP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cboFactory;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.ComboBox cboWorker;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}