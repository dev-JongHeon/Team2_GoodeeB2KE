namespace Team2_ERP
{
    partial class CalendarForm
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.EndCalendar = new System.Windows.Forms.MonthCalendar();
            this.StartCalendar = new System.Windows.Forms.MonthCalendar();
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
            this.panel1.Size = new System.Drawing.Size(626, 401);
            // 
            // panel_Title
            // 
            this.panel_Title.Size = new System.Drawing.Size(624, 32);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(422, 0);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.EndCalendar);
            this.panel5.Controls.Add(this.StartCalendar);
            this.panel5.Location = new System.Drawing.Point(0, 67);
            this.panel5.Size = new System.Drawing.Size(624, 297);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 364);
            this.panel4.Size = new System.Drawing.Size(624, 35);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(624, 35);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new System.Drawing.Point(365, 3);
            this.btnCancel.Size = new System.Drawing.Size(83, 28);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.Location = new System.Drawing.Point(174, 3);
            this.btnOK.Size = new System.Drawing.Size(83, 28);
            this.btnOK.Text = "확인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(570, 64);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(45, 23);
            this.button21.TabIndex = 37;
            this.button21.Tag = "23";
            this.button21.Text = "12월";
            this.button21.UseVisualStyleBackColor = false;
            this.button21.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(468, 64);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(45, 23);
            this.button22.TabIndex = 36;
            this.button22.Tag = "21";
            this.button22.Text = "10월";
            this.button22.UseVisualStyleBackColor = false;
            this.button22.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(366, 64);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(45, 23);
            this.button23.TabIndex = 35;
            this.button23.Tag = "19";
            this.button23.Text = "8월";
            this.button23.UseVisualStyleBackColor = false;
            this.button23.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(264, 64);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(45, 23);
            this.button24.TabIndex = 34;
            this.button24.Tag = "17";
            this.button24.Text = "6월";
            this.button24.UseVisualStyleBackColor = false;
            this.button24.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(111, 64);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(45, 23);
            this.button25.TabIndex = 33;
            this.button25.Tag = "14";
            this.button25.Text = "3월";
            this.button25.UseVisualStyleBackColor = false;
            this.button25.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(60, 64);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(45, 23);
            this.button26.TabIndex = 32;
            this.button26.Tag = "13";
            this.button26.Text = "2월";
            this.button26.UseVisualStyleBackColor = false;
            this.button26.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(519, 64);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(45, 23);
            this.button15.TabIndex = 31;
            this.button15.Tag = "22";
            this.button15.Text = "11월";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(417, 64);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(45, 23);
            this.button16.TabIndex = 30;
            this.button16.Tag = "20";
            this.button16.Text = "9월";
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(315, 64);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(45, 23);
            this.button17.TabIndex = 29;
            this.button17.Tag = "18";
            this.button17.Text = "7월";
            this.button17.UseVisualStyleBackColor = false;
            this.button17.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(213, 64);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(45, 23);
            this.button18.TabIndex = 28;
            this.button18.Tag = "16";
            this.button18.Text = "5월";
            this.button18.UseVisualStyleBackColor = false;
            this.button18.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(162, 64);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(45, 23);
            this.button19.TabIndex = 27;
            this.button19.Tag = "15";
            this.button19.Text = "4월";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(9, 64);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(45, 23);
            this.button20.TabIndex = 26;
            this.button20.Tag = "12";
            this.button20.Text = "1월";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(520, 35);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(96, 23);
            this.button13.TabIndex = 25;
            this.button13.Tag = "11";
            this.button13.Text = "하반기";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(418, 35);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(96, 23);
            this.button14.TabIndex = 24;
            this.button14.Tag = "10";
            this.button14.Text = "상반기";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(315, 35);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(97, 23);
            this.button11.TabIndex = 23;
            this.button11.Tag = "9";
            this.button11.Text = "4/4 분기";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(213, 35);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(96, 23);
            this.button12.TabIndex = 22;
            this.button12.Tag = "8";
            this.button12.Text = "3/4 분기";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(111, 35);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(96, 23);
            this.button9.TabIndex = 21;
            this.button9.Tag = "7";
            this.button9.Text = "2/4 분기";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(9, 35);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(96, 23);
            this.button10.TabIndex = 20;
            this.button10.Tag = "6";
            this.button10.Text = "1/4 분기";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.ButtonClick);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(520, 6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(96, 23);
            this.button7.TabIndex = 19;
            this.button7.Tag = "5";
            this.button7.Text = "올해";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn.Location = new System.Drawing.Point(418, 6);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(96, 23);
            this.btn.TabIndex = 18;
            this.btn.Tag = "4";
            this.btn.Text = "당월";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLastMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastMonth.Location = new System.Drawing.Point(315, 6);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(97, 23);
            this.btnLastMonth.TabIndex = 17;
            this.btnLastMonth.Tag = "3";
            this.btnLastMonth.Text = "전월";
            this.btnLastMonth.UseVisualStyleBackColor = false;
            this.btnLastMonth.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnWeek
            // 
            this.btnWeek.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.Location = new System.Drawing.Point(213, 6);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(96, 23);
            this.btnWeek.TabIndex = 16;
            this.btnWeek.Tag = "2";
            this.btnWeek.Text = "주간";
            this.btnWeek.UseVisualStyleBackColor = false;
            this.btnWeek.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnLastweek
            // 
            this.btnLastweek.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLastweek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastweek.Location = new System.Drawing.Point(111, 6);
            this.btnLastweek.Name = "btnLastweek";
            this.btnLastweek.Size = new System.Drawing.Size(96, 23);
            this.btnLastweek.TabIndex = 15;
            this.btnLastweek.Tag = "1";
            this.btnLastweek.Text = "전주";
            this.btnLastweek.UseVisualStyleBackColor = false;
            this.btnLastweek.Click += new System.EventHandler(this.ButtonClick);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Location = new System.Drawing.Point(9, 6);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(96, 23);
            this.btnToday.TabIndex = 14;
            this.btnToday.Tag = "0";
            this.btnToday.Text = "오늘";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.ButtonClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button21);
            this.panel6.Controls.Add(this.button22);
            this.panel6.Controls.Add(this.button23);
            this.panel6.Controls.Add(this.button24);
            this.panel6.Controls.Add(this.button25);
            this.panel6.Controls.Add(this.button26);
            this.panel6.Controls.Add(this.button15);
            this.panel6.Controls.Add(this.button16);
            this.panel6.Controls.Add(this.button17);
            this.panel6.Controls.Add(this.button18);
            this.panel6.Controls.Add(this.button19);
            this.panel6.Controls.Add(this.button20);
            this.panel6.Controls.Add(this.button13);
            this.panel6.Controls.Add(this.button14);
            this.panel6.Controls.Add(this.button11);
            this.panel6.Controls.Add(this.button12);
            this.panel6.Controls.Add(this.button9);
            this.panel6.Controls.Add(this.button10);
            this.panel6.Controls.Add(this.button7);
            this.panel6.Controls.Add(this.btn);
            this.panel6.Controls.Add(this.btnLastMonth);
            this.panel6.Controls.Add(this.btnWeek);
            this.panel6.Controls.Add(this.btnLastweek);
            this.panel6.Controls.Add(this.btnToday);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(622, 96);
            this.panel6.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 54F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(268, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 83);
            this.label1.TabIndex = 16;
            this.label1.Text = "~";
            // 
            // EndCalendar
            // 
            this.EndCalendar.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EndCalendar.Location = new System.Drawing.Point(394, 109);
            this.EndCalendar.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.EndCalendar.MaxSelectionCount = 1;
            this.EndCalendar.Name = "EndCalendar";
            this.EndCalendar.ShowTodayCircle = false;
            this.EndCalendar.TabIndex = 15;
            // 
            // StartCalendar
            // 
            this.StartCalendar.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StartCalendar.Location = new System.Drawing.Point(9, 109);
            this.StartCalendar.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.StartCalendar.MaxSelectionCount = 1;
            this.StartCalendar.Name = "StartCalendar";
            this.StartCalendar.ShowTodayCircle = false;
            this.StartCalendar.TabIndex = 14;
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(626, 401);
            this.Name = "CalendarForm";
            this.Load += new System.EventHandler(this.CalendarForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Title.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTitle)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar EndCalendar;
        private System.Windows.Forms.MonthCalendar StartCalendar;
    }
}
