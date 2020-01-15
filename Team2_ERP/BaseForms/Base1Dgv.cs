using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class Base1Dgv : BaseForm
    {
        public new string FormName
        {
            get { return lblFormName.Text; }
            set { lblFormName.Text = value; }
        }

        public Base1Dgv()
        {
            InitializeComponent();
        }

        

    }
}
