using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_POP
{
    public partial class ProducingForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int radiusX, int radiusY);

        public ProducingForm()
        {
            InitializeComponent();
            Region = (Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 35, 35)));
        }


        public Action Processing { get; set; }
        public bool IsCompleted { get; set; }

        private void ProducingForm_Load(object sender, EventArgs e)
        {
            IsCompleted = true;
            Task.Factory.StartNew(Processing).Wait();
        }

        private void ProducingForm_Shown(object sender, EventArgs e)
        {
           
        }

        private void ProducingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
