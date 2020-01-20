using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class LoginVO
    {
        public int Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Depart { get; set; }
        public string Employee_PWD { get; set; }
        public bool Employee_IsAdmin { get; set; }
        public bool IsLogout { get; set; }
    }
}
