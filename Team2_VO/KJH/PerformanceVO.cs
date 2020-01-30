using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class PerformanceVO
    {
        public string Performance_ID { get; set; }
        public string Performance_StartDate { get; set; }
        public string Performance_EndDate { get; set; }
        public string Performance_ElapsedTime { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Performance_QtyImport { get; set; }
        public int Performance_QtySuccessItem { get; set; }
        public int Performance_QtyDefectiveItem { get; set; }
        public decimal Performance_DefectiveRate { get; set; }
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
    }
}
