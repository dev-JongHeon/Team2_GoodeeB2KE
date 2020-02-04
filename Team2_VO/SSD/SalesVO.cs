using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Sales
    {
        [FieldName("주문ID")]
        public string Order_ID { get; set; }

        [FieldName("주문자ID")]
        public string Customer_UserID { get; set; }

        [FieldName("고객이름")]
        public string Customer_Name { get; set; }

        [FieldName("주문날짜")]
        public DateTime Order_Date { get; set; }

        [FieldName("출하완료날짜")]
        public DateTime Shipment_DoneDate { get; set; }

        [FieldName("총액")]
        public int TotalPrice { get; set; }
    }
}
