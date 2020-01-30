using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class WorkVO
    {
        public string Work_ID { get; set; }
        public string Work_StartDate { get; set; }
        public string Work_EndDate { get; set; }
        public string Shipment_ID { get; set; }
        public string Shipment_RequiredDate { get; set; }
        public string Work_State { get; set; }
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
    }
}
