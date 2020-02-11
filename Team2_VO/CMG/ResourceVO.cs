using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class ResourceVO
    {
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Warehouse_ID { get; set; }
        public string Warehouse_Name { get; set; }
        public int Product_Price { get; set; }
        public int Product_Qty { get; set; }
        public int Product_Safety { get; set; }
        public bool Product_DeletedYN { get; set; }
        public string Product_Category { get; set; }
        public string CodeTable_CodeName { get; set; }
        public int Company_ID { get; set; }
    }
}
