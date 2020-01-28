using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Produce
    {
        public string Produce_ID { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Produce_QtyRequested { get; set; }
        public int Produce_QtyReleased { get; set; }
        public int Performance_QtyDefectiveItem { get; set; }
        public string Produce_State { get; set; }
        public string Work_ID { get; set; }
        public DateTime? Produce_StartDate { get; set; }
        public DateTime? Produce_DoneDate { get; set; }
    }
}
