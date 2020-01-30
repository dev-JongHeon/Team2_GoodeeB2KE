using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class ProduceVO
    {
        public string Produce_ID { get; set; }
        public string Produce_StartDate { get; set; }
        public string Produce_DoneDate { get; set; }
        public int Factory_ID { get; set; }
        public string Factory_Name { get; set; }
        public int Line_ID { get; set; }
        public string Line_Name { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Produce_QtyRequested { get; set; }
        public int Produce_QtyReleased { get; set; }
        public string Produce_State { get; set; }
    }
}
