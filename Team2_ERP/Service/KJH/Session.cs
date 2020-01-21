using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_ERP
{
    public static class Session
    {
        public static int Employee_ID { get; set; }
        public static string Employee_Name { get; set; }
        public static string Employee_Depart { get; set; }
        public static bool Employee_IsAdmin { get; set; }
        public static string Auth { get; set; }
    }
}
