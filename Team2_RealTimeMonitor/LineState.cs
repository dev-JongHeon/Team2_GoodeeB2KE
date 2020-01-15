using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_RealTimeMonitor
{
    public partial class LineState : Form
    {
        public LineState()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count < 6)
                flowLayoutPanel1.Controls.Add(new Monitor());
        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }

        private void LineState_Load(object sender, EventArgs e)
        {
            this.lblNow.Text = DateTime.Now.ToString();
        }
    }
}
