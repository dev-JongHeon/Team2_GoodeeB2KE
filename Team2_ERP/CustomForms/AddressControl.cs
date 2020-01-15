using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class AddressControl : UserControl
    {
        [Description("우편번호 조회")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Zipcode { get { return textBox1.Text; } }
        [Description("주소1 조회")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public string Address1 { get { return textBox2.Text; } }
        [Description("주소2 조회")]
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]

        public string Address2 { get { return textBox3.Text; } }

        public AddressControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddressSearch frm = new AddressSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = frm.Zipcode;
                textBox2.Text = frm.Address1;
                textBox3.Text = frm.Address2;
            }
        }
    }
}
