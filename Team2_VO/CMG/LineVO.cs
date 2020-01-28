using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class LineVO
    {
        public int Line_ID { get; set; }
        public string Line_Name { get; set; }
        public int Factory_ID { get; set; }
        public string Factory_Name { get; set; }
        public string Line_Downtome_Name { get; set; }
        public bool Line_Downtime { get; set; }
        public bool Line_DeletedYN { get; set; }
    }
}
