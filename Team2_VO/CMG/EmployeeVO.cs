using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class EmployeeVO
    {
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
        public string CodeTable_CodeID { get; set; }
        public string Employees_Hiredate { get; set; }
        public string Employees_Resigndate { get; set; }
        public string Employees_PWD { get; set; }
        public string Employees_Phone { get; set; }
        public string Employees_Birth { get; set; }
        public bool Employees_IsAdmin { get; set; }
        public bool Employees_DeletedYN { get; set; }
    }
}
