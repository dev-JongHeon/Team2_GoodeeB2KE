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
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
        }

        private void StartCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            StartCalendar.SelectionStart = e.Start;
            
        }

        private void EndCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            EndCalendar.SelectionStart = e.Start;
            
        }

        
    }
}
