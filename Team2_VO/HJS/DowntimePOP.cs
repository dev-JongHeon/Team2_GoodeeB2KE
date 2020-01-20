using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class DowntimePOP
    {
        public string Downtime_ID { get; set; }
        public int Line_ID { get; set; }
        public string CodeTable_CodeID { get; set; }
        public int Employees_ID { get; set; }
        public DateTime Downtime_StartDate { get; set; }
        public DateTime? Downtime_EndDate { get; set; }
        public int? Downtime_TotalTime { get; set; }

    }
}
