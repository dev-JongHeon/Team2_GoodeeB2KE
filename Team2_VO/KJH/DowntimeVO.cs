using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class DowntimeVO
    {
        public int Factory_ID { get; set; }
        public string Factory_Name { get; set; }
        public int Line_ID { get; set; }
        public string Line_Name { get; set; }
        public string DowntimeType_ID { get; set; }
        public string DowntimeType_Name { get; set; }
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
        public string Downtime_StartDate { get; set; }
        public string Downtime_EndDate { get; set; }
        public string Downtime_TotalTime { get; set; }
    }
}
