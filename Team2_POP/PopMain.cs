using System;
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
    public partial class PopMain : Form
    {
        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            SettingData();
        }

        private void SettingData()
        {
            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed = true;
        }

        private void btnDownTime_Click(object sender, EventArgs e)
        {
            DowntimeRegister downtime = new DowntimeRegister();            
            downtime.ShowDialog();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            WorkRegister work = new WorkRegister();
            work.ShowDialog();
        }

        private void btnDefective_Click(object sender, EventArgs e)
        {
            DefectiveRegister defective = new DefectiveRegister();
            defective.ShowDialog();
        }
    }
}
