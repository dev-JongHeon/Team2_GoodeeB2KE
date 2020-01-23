using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Balju
    {
        public string Balju_ID { get; set; }
        public int Company_ID { get; set; }
        public string Company_Name { get; set; }
        public DateTime Balju_Date { get; set; }
        public DateTime Balju_ReceiptDate { get; set; }
        public string Employees_Name { get; set; }
        public bool Balju_DeletedYN { get; set; }
    }

    public class BaljuDetail
    {
        public string Balju_ID { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int BaljuDetail_Qty { get; set; }
    }
}
