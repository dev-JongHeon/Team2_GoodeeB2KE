using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class DefectiveVO
    {
        
        public string Performance_ID { get; set; }
        public int Factory_ID { get; set; }
        public string Factory_Name { get; set; }
        public int Line_ID { get; set; }
        public string Line_Name { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string DefectiveType_ID { get; set; }
        public string DefectiveType_Name { get; set; }
        public string DefectiveHandle_ID { get; set; }
        public string DefectiveHandle_Name { get; set; }
        public int Employees_ID { get; set; }
        public string Employees_Name { get; set; }
        public int Defective_Num { get; set; }
        public string Defective_HandleDate { get; set; }
    }
}
