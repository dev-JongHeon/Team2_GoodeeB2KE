using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Order
    {
        
        public string Order_ID { get; set; }  // 주문번호
        public string Customer_UserID { get; set; }  // 고객ID
        public string Customer_Name { get; set; }  // 고객이름
        public DateTime Order_Date { get; set; }  // 주문일시
        public DateTime OrderCompleted_Date { get; set; }  // 주문완료일시
        public string Order_Address1 { get; set; }  // 배송지주소
        public string Order_Address2 { get; set; }  // 배송지상세주소
        public bool Order_DeletedYN { get; set; }  // 주문총액
        public int Order_State { get; set; }  // 삭제여부
        public int TotalPrice { get; set; }  // 주문상태
    }

    public class OrderDetail
    {
        public string Order_ID { get; set; }  // 주문번호
        public string Product_ID { get; set; }  // 제품ID
        public string Product_Name { get; set; }  // 제품명
        public int OrderDetail_Qty { get; set; }  // 주문갯수
    }
}
