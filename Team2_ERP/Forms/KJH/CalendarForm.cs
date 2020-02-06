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
            set
            {
                calendarmode = value;

                switch (CalendarMode)
                {
                    case Mode.Today:
                        StartCalendar.SelectionStart = DateTime.Now;
                        EndCalendar.SelectionStart = DateTime.Now;
                        break;
                    case Mode.LastWeek:
                        StartCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 7);
                        EndCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek - 1);
                        break;
                    case Mode.Week:
                        StartCalendar.SelectionStart = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
                        EndCalendar.SelectionStart = DateTime.Now;
                        break;
                    case Mode.LastMonth:
                        DateTime dt = DateTime.Now.AddMonths(-1);
                        StartCalendar.SelectionStart = new DateTime(dt.Year, dt.Month, 1);
                        EndCalendar.SelectionStart = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
                        break;
                    case Mode.Month:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                        break;
                    case Mode.Year:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 1, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 12, 31);
                        break;
                    case Mode.Year1_4:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 1, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 3, 31);
                        break;
                    case Mode.Year2_4:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 4, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 6, 30);
                        break;
                    case Mode.Year3_4:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 7, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 9, 30);
                        break;
                    case Mode.Year4_4:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 10, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 12, 31);
                        break;
                    case Mode.YearFirstHalf:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 1, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 6, 30);
                        break;
                    case Mode.YearSecondHalf:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 7, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 12, 31);
                        break;
                    case Mode.Jan:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 1, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 1, DateTime.DaysInMonth(DateTime.Now.Year, 1));
                        break;
                    case Mode.Feb:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 2, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 2, DateTime.DaysInMonth(DateTime.Now.Year, 2));
                        break;
                    case Mode.Mar:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 3, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 3, DateTime.DaysInMonth(DateTime.Now.Year, 3));
                        break;
                    case Mode.Apr:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 4, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 4, DateTime.DaysInMonth(DateTime.Now.Year, 4));
                        break;
                    case Mode.May:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 5, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 5, DateTime.DaysInMonth(DateTime.Now.Year, 5));
                        break;
                    case Mode.Jun:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 6, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 6, DateTime.DaysInMonth(DateTime.Now.Year, 6));
                        break;
                    case Mode.Jul:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 7, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 7, DateTime.DaysInMonth(DateTime.Now.Year, 7));
                        break;
                    case Mode.Aug:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 8, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 8, DateTime.DaysInMonth(DateTime.Now.Year, 8));
                        break;
                    case Mode.Sep:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 9, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 9, DateTime.DaysInMonth(DateTime.Now.Year, 9));
                        break;
                    case Mode.Oct:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 10, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 10, DateTime.DaysInMonth(DateTime.Now.Year, 10));
                        break;
                    case Mode.Nov:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 11, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 11, DateTime.DaysInMonth(DateTime.Now.Year, 11));
                        break;
                    case Mode.Dec:
                        StartCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 12, 1);
                        EndCalendar.SelectionStart = new DateTime(DateTime.Now.Year, 12, DateTime.DaysInMonth(DateTime.Now.Year, 12));
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
            Startdate = start;
            Enddate = end;

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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (StartCalendar.SelectionStart > EndCalendar.SelectionStart)
            {
                MessageBox.Show(Properties.Settings.Default.CalendarError, Properties.Settings.Default.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
            else if ((EndCalendar.SelectionStart - StartCalendar.SelectionStart).Days > 366)
            {
                MessageBox.Show(Properties.Settings.Default.CalendarMaxError, Properties.Settings.Default.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
    }
}
