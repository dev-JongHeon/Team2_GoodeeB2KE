using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Work
    {
        public string Work_ID { get; set; } 
        public DateTime Work_StartDate { get; set; }
        public DateTime Work_EndDate { get; set; }
        public string Shipment_ID { get; set; }
        public string Work_State { get; set; }
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
        public DateTime? Shipment_RequiredDate { get; set; }
    }
}
