﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_POP
{
    public partial class MonthCalandarForm : Form
    {
        public DateTime DSelected { get; set; }

        public MonthCalandarForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            singleMonthCalandar1.MaxSelectionCount = 1;
            singleMonthCalandar1.SelectionStart = DSelected;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void singleMonthCalandar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DSelected = e.Start;
            DialogResult = DialogResult.OK;
        }
    }
}