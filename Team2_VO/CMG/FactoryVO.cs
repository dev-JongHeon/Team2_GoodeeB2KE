using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class FactoryVO
    {
        public int Factory_ID { get; set; }
        public string Factory_Name { get; set; }
        public string Factory_Division_Name { get; set; }
        public int Factory_Division { get; set; }
        public string Factory_Number { get; set; }
        public string Factory_Fax { get; set; }
        public string Factory_Address { get; set; }
        public bool Factory_DeletedYN { get; set; }
    }
}
