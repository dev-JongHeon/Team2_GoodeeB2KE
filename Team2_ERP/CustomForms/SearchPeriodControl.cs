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
using Team2_ERP.Properties;

namespace Team2_ERP
{
    public partial class SearchPeriodControl : UserControl
    {
        CalendarForm frm;
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
            errorProvider1.SetError(txtStart, "");
            errorProvider1.SetError(txtEnd, "");
            if (txtStart.Tag != null && txtEnd.Tag != null)
            {
                DateTime start;
                DateTime end;
                if (!DateTime.TryParse(txtEnd.Tag.ToString(), out end) || !DateTime.TryParse(txtStart.Tag.ToString(), out start))
                {
                    frm = new CalendarForm();
                }
                else
                {
                    frm = new CalendarForm(start, end);
                }
            }
            else
            {
                frm = new CalendarForm();
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                sdate = frm.Startdate;
                txtStart.Tag = frm.Startdate;
                edate = frm.Enddate;
                txtEnd.Tag = frm.Enddate;
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
            if (txtStart.Text == "    -  -")
            {
                //txtEnd.Clear();
                //txtEnd.Tag = null;
                txtStart.Tag = null;
                
            }
            else
            {
                txtStart.Tag = txtStart.Text;
            }

        }

        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtEnd.Text == "    -  -")
            {
                txtEnd.Tag = null;
            }
            else
            {
                txtEnd.Tag = txtEnd.Text;
            }

        }

        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
                txtStart.Tag = null;
                txtEnd.Tag = null;
            }
            
        }

        

    }
}
