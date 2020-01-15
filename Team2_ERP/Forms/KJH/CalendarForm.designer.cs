namespace Team2_ERP
{
    partial class CalendarForm
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
            this.EndCalendar = new System.Windows.Forms.MonthCalendar();
            this.StartCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btnLastMonth = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnLastweek = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EndCalendar
            // 
            this.EndCalendar.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EndCalendar.Location = new System.Drawing.Point(395, 100);
            this.EndCalendar.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.EndCalendar.MaxSelectionCount = 1;
            this.EndCalendar.Name = "EndCalendar";
            this.EndCalendar.TabIndex = 7;
            this.EndCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.EndCalendar_DateChanged);
            // 
            // StartCalendar
            // 
            this.StartCalendar.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StartCalendar.Location = new System.Drawing.Point(10, 100);
            this.StartCalendar.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.StartCalendar.MaxSelectionCount = 1;
            this.StartCalendar.Name = "StartCalendar";
            this.StartCalendar.TabIndex = 6;
            this.StartCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.StartCalendar_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 54F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(269, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 83);
            this.label1.TabIndex = 10;
            this.label1.Text = "~";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(324, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "취소";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button21);
            this.panel1.Controls.Add(this.button22);
            this.panel1.Controls.Add(this.button23);
            this.panel1.Controls.Add(this.button24);
            this.panel1.Controls.Add(this.button25);
            this.panel1.Controls.Add(this.button26);
            this.panel1.Controls.Add(this.button15);
            this.panel1.Controls.Add(this.button16);
            this.panel1.Controls.Add(this.button17);
            this.panel1.Controls.Add(this.button18);
            this.panel1.Controls.Add(this.button19);
            this.panel1.Controls.Add(this.button20);
            this.panel1.Controls.Add(this.button13);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.btn);
            this.panel1.Controls.Add(this.btnLastMonth);
            this.panel1.Controls.Add(this.btnWeek);
            this.panel1.Controls.Add(this.btnLastweek);
            this.panel1.Controls.Add(this.btnToday);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 94);
            this.panel1.TabIndex = 13;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(570, 64);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(45, 23);
            this.button21.TabIndex = 37;
            this.button21.Text = "12월";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(468, 64);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(45, 23);
            this.button22.TabIndex = 36;
            this.button22.Text = "10월";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(366, 64);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(45, 23);
            this.button23.TabIndex = 35;
            this.button23.Text = "8월";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(264, 64);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(45, 23);
            this.button24.TabIndex = 34;
            this.button24.Text = "6월";
            this.button24.UseVisualStyleBackColor = true;
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(111, 64);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(45, 23);
            this.button25.TabIndex = 33;
            this.button25.Text = "3월";
            this.button25.UseVisualStyleBackColor = true;
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(60, 64);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(45, 23);
            this.button26.TabIndex = 32;
            this.button26.Text = "2월";
            this.button26.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(519, 64);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(45, 23);
            this.button15.TabIndex = 31;
            this.button15.Text = "11월";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(417, 64);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(45, 23);
            this.button16.TabIndex = 30;
            this.button16.Text = "9월";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(315, 64);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(45, 23);
            this.button17.TabIndex = 29;
            this.button17.Text = "7월";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(213, 64);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(45, 23);
            this.button18.TabIndex = 28;
            this.button18.Text = "5월";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(162, 64);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(45, 23);
            this.button19.TabIndex = 27;
            this.button19.Text = "4월";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(9, 64);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(45, 23);
            this.button20.TabIndex = 26;
            this.button20.Text = "1월";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(520, 35);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(96, 23);
            this.button13.TabIndex = 25;
            this.button13.Text = "하반기";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(418, 35);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(96, 23);
            this.button14.TabIndex = 24;
            this.button14.Text = "상반기";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(315, 35);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(97, 23);
            this.button11.TabIndex = 23;
            this.button11.Text = "4/4 분기";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(213, 35);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(96, 23);
            this.button12.TabIndex = 22;
            this.button12.Text = "3/4 분기";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(111, 35);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 23);
            this.button9.TabIndex = 21;
            this.button9.Text = "2/4 분기";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(9, 35);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 23);
            this.button10.TabIndex = 20;
            this.button10.Text = "1/4 분기";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(520, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 19;
            this.button7.Text = "올해";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(418, 6);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(96, 23);
            this.btn.TabIndex = 18;
            this.btn.Text = "당월";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.Location = new System.Drawing.Point(315, 6);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(97, 23);
            this.btnLastMonth.TabIndex = 17;
            this.btnLastMonth.Text = "전월";
            this.btnLastMonth.UseVisualStyleBackColor = true;
            // 
            // btnWeek
            // 
            this.btnWeek.Location = new System.Drawing.Point(213, 6);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(96, 23);
            this.btnWeek.TabIndex = 16;
            this.btnWeek.Text = "주간";
            this.btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnLastweek
            // 
            this.btnLastweek.Location = new System.Drawing.Point(111, 6);
            this.btnLastweek.Name = "btnLastweek";
            this.btnLastweek.Size = new System.Drawing.Size(96, 23);
            this.btnLastweek.TabIndex = 15;
            this.btnLastweek.Text = "전주";
            this.btnLastweek.UseVisualStyleBackColor = true;
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(9, 6);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(96, 23);
            this.btnToday.TabIndex = 14;
            this.btnToday.Text = "오늘";
            this.btnToday.UseVisualStyleBackColor = true;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 307);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndCalendar);
            this.Controls.Add(this.StartCalendar);
            this.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalendarForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CalenderForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MonthCalendar EndCalendar;
        private System.Windows.Forms.MonthCalendar StartCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnLastMonth;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnLastweek;
        private System.Windows.Forms.Button btnToday;
    }
}