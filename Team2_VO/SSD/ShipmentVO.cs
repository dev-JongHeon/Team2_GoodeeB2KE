using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Shipment
    {
        public string Shipment_ID { get; set; }  // 출하번호
        public string Order_ID { get; set; }  // 주문번호
        public DateTime Order_Date { get; set; }  // 주문일시
        public string Customer_userID { get; set; }  // 고객ID
        public DateTime Shipment_RequiredDate { get; set; }  // 출하지시일
        public string Employees_Name { get; set; }  // 출하지시자
        public DateTime Shipment_DoneDate { get; set; }  // 출하날짜
    }

    public class ShipmentDetail
    {
        public string Shipment_ID { get; set; }  // 출하번호
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }  // 제품명
        public int OrderDetail_Qty { get; set; }  // 주문갯수
    }
}
