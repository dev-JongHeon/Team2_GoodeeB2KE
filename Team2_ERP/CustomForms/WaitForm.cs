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
    public partial class WaitForm : Form
    {
        public Action Processing { get; set; }

        public WaitForm()
        {
            InitializeComponent();
        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(Processing).ContinueWith(t => { this.Close(); },
               TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
