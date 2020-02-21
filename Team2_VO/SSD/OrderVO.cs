using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Order
    {
        [FieldName("주문ID")]
        public string Order_ID { get; set; }  

        [FieldName("주문자ID")]
        public string Customer_UserID { get; set; }  

        [FieldName("고객이름")]
        public string Customer_Name { get; set; }  

        [FieldName("주문날짜")]
        public DateTime Order_Date { get; set; } 

        [FieldName("주문처리날짜")]
        public DateTime OrderCompleted_Date { get; set; }  

        [FieldName("주문주소1")]
        public string Order_Address1 { get; set; }  

        [FieldName("주문주소2")]
        public string Order_Address2 { get; set; } 

        [FieldName("주문삭제여부")]
        public bool Order_DeletedYN { get; set; }  

        [FieldName("주문상태")]
        public int Order_State { get; set; }  

        [FieldName("총액")]
        public int TotalPrice { get; set; }
        
        [FieldName("주문처리사원")]
        public string Employees_Name { get; set; }
    }

    public class OrderDetail
    {
        [FieldName("주문ID")]
        public string Order_ID { get; set; }  // 주문번호

        [FieldName("제품ID")]
        public string Product_ID { get; set; }  // 제품ID

        [FieldName("제품명")]
        public string Product_Name { get; set; }  // 제품명

        [FieldName("주문수량")]
        public int OrderDetail_Qty { get; set; }  // 주문갯수

        public override string ToString()
        {
            return Order_ID;
        }
    }
}
