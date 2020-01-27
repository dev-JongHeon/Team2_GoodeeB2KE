using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class CalendarForm : Team2_ERP.BasePopup
    {
        public DateTime Startdate { get => StartCalendar.SelectionStart; set => StartCalendar.SelectionStart = value; }
        public DateTime Enddate { get => EndCalendar.SelectionStart; set => EndCalendar.SelectionStart = value; }
        public enum Mode
        {
            Today, LastWeek, Week, LastMonth, Month, Year, Year1_4, Year2_4, Year3_4, Year4_4, YearFirstHalf, YearSecondHalf, Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        };
        private Mode calendarmode;
        public Mode CalendarMode
        {
            get { return calendarmode; }
            set {
                calendarmode = value;

                    switch (CalendarMode)
                {
                    case Mode.Today:
                        StartCalendar.SelectionStart = DateTime.Now;
                        EndCalendar.SelectionStart = DateTime.Now;
                        break;
                    case Mode.LastWeek:
                        StartCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 7);
                        EndCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek-1);
                        break;
                    case Mode.Week:
                        StartCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                        EndCalendar.SelectionStart = DateTime.Now;
                        break;
                    case Mode.LastMonth:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month));
                        break;
                    case Mode.Month:
                        break;
                    case Mode.Year:
                        break;
                    case Mode.Year1_4:
                        break;
                    case Mode.Year2_4:
                        break;
                    case Mode.Year3_4:
                        break;
                    case Mode.Year4_4:
                        break;
                    case Mode.YearFirstHalf:
                        break;
                    case Mode.YearSecondHalf:
                        break;
                    case Mode.Jan:
                        break;
                    case Mode.Feb:
                        break;
                    case Mode.Mar:
                        break;
                    case Mode.Apr:
                        break;
                    case Mode.May:
                        break;
                    case Mode.Jun:
                        break;
                    case Mode.Jul:
                        break;
                    case Mode.Aug:
                        break;
                    case Mode.Sep:
                        break;
                    case Mode.Oct:
                        break;
                    case Mode.Nov:
                        break;
                    case Mode.Dec:
                        break;
                    default:
                        break;
                }
            }
        }

        

        public CalendarForm()
        {
            InitializeComponent();
        }

        public CalendarForm(DateTime start, DateTime end)
        {
            InitializeComponent();
            if (start != null && end != null)
            {
                Startdate = start;
                Enddate = end;
            }
            
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            foreach (int num in Enum.GetValues(typeof(Mode)))
            {
                if (Convert.ToInt32(btn.Tag) == num)
                {
                    CalendarMode = (Mode)num;
                    break;
                }
            }
        }

        private void CalendarForm_Load(object sender, EventArgs e)
        {
            CalendarMode = Mode.Today;
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
