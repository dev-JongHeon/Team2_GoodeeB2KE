using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class CompanyVO
    {
        public int Company_ID { get; set; }
        public string Company_Name { get; set; }
        public string Company_Address { get; set; }
        public string Company_Number { get; set; }
        public string Company_Fax { get; set; }
        public string CodeTable_CodeName { get; set; }
        public string CodeTable_CodeID { get; set; }
        public string Company_Owner { get; set; }
        public bool Company_DeletedYN { get; set; }
    }
}
