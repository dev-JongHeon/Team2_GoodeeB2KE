using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace Team2_ERP
{
    public partial class SearchPeriodControl : UserControl
    {
        public string Labelname
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }


        public SearchPeriodControl()
        {
            InitializeComponent();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CalendarForm frm = new CalendarForm();
            frm.ShowDialog();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                DateTime starttmp = dtpStart.Value;
                DateTime endtmp = dtpEnd.Value;
                dtpEnd.Value = starttmp;
                dtpStart.Value = endtmp;
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value > dtpEnd.Value)
            {
                DateTime starttmp = dtpStart.Value;
                DateTime endtmp = dtpEnd.Value;
                dtpEnd.Value = starttmp;
                dtpStart.Value = endtmp;
            }
        }
    }
}
