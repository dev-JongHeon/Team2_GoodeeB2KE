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
        public MaskedTextBox Startdate
        {
            set { txtStart = value; }
            get { return txtStart; }
        }
        public MaskedTextBox Enddate
        {
            set { txtEnd = value; }
            get { return txtEnd; }
        }

        public DateTime sdate { set => txtStart.Text = value.ToString(); }
        public DateTime edate { set => txtEnd.Text = value.ToString(); }

        public SearchPeriodControl()
        {
            InitializeComponent();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CalendarForm frm = new CalendarForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                sdate = frm.Startdate;
                edate = frm.Enddate;
            }
        }

        private void txtEnd_Click(object sender, EventArgs e)
        {
            txtEnd.SelectAll();
        }

        private void txtStart_Click(object sender, EventArgs e)
        {
            txtStart.SelectAll();
        }

        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            if (txtStart.TextLength == 0)
            {
                txtEnd.Clear();
            }
        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtEnd.TextLength == 0)
            {
                txtStart.Clear();
            }
        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        //private void dtpStart_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dtpStart.Value > dtpEnd.Value)
        //    {
        //        DateTime starttmp = dtpStart.Value;
        //        DateTime endtmp = dtpEnd.Value;
        //        dtpEnd.Value = starttmp;
        //        dtpStart.Value = endtmp;
        //    }
        //}

        //private void dtpEnd_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dtpStart.Value > dtpEnd.Value)
        //    {
        //        DateTime starttmp = dtpStart.Value;
        //        DateTime endtmp = dtpEnd.Value;
        //        dtpEnd.Value = starttmp;
        //        dtpStart.Value = endtmp;
        //    }
        //}
    }
}
