using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Shipment
    {
        [FieldName("출하ID")]
        public string Shipment_ID { get; set; }  // 출하번호

        [FieldName("주문ID")]
        public string Order_ID { get; set; }  // 주문번호

        [FieldName("주문날짜")]
        public DateTime Order_Date { get; set; }  // 주문일시

        [FieldName("주문처리날짜")]
        public DateTime OrderCompleted_Date { get; set; }  // 주문처리일시

        [FieldName("주문자ID")]
        public string Customer_userID { get; set; }  // 고객ID

        [FieldName("고객이름")]
        public string Customer_Name { get; set; }  // 고객이름

        [FieldName("출하요청날짜")]
        public DateTime Shipment_RequiredDate { get; set; }  // 출하지시일

        [FieldName("사원명")]
        public string Employees_Name { get; set; }  // 출하지시자

        [FieldName("출하완료날짜")]
        public DateTime Shipment_DoneDate { get; set; }  // 출하날짜
    }

    public class ShipmentDetail
    {
        [FieldName("출하ID")]
        public string Shipment_ID { get; set; }  // 출하번호

        [FieldName("제품ID")]
        public string Product_ID { get; set; }

        [FieldName("제품명")]
        public string Product_Name { get; set; }  // 제품명

        [FieldName("주문수량")]
        public int OrderDetail_Qty { get; set; }  // 주문수량
    }
}
