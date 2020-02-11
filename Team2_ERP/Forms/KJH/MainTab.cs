using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;

namespace Team2_ERP
{
    public partial class MainTab : TabForm
    {
        MainForm frm;
        public MainTab()
        {
            InitializeComponent();
        }

        private void MainTab_Activated(object sender, EventArgs e)
        {
            frm = (MainForm)this.MdiParent;
            frm.NoticeMessage = Resources.Welcome;
        }
    }
}
