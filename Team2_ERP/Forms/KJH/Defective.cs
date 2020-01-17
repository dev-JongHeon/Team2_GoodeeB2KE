using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class Defective : BaseForm
    {
        public Defective()
        {
            InitializeComponent();
        }

        private void Defective_Load(object sender, EventArgs e)
        {
            SettingData();
        }

        private void SettingData()
        {
            //this.lblFormName.Text = "불량유형";        

            new SettingMenuStrip().SetMenu(this, a, a, a, a, a, a, a);
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = false;
        }

        private void a(object sender, EventArgs e)
        {
            new SettingMenuStrip().SetMenu(this, a, a, a, a, a, a, a);
        }

    }
}
