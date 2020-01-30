using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Sales
    {
        public string Order_ID { get; set; }
        public string Customer_UserID { get; set; }
        public string Customer_Name { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Shipment_DoneDate { get; set; }
        public int TotalPrice { get; set; }
    }
}
