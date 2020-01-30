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
    public partial class SemiProductCompControl : UserControl
    {
        public string CategoryName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string CategoryTag
        {
            get { return lblName.Tag.ToString(); }
            set { lblName.Tag = value; }
        }
        public string ResourceName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string ResourceMoney
        {
            get { return lblMoney.Text; }
            set { lblMoney.Text = value; }
        }
        public SemiProductCompControl()
        {
            InitializeComponent();
        }
    }
}
