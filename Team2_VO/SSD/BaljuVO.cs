using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Balju
    {
        [FieldName("발주식별ID")]
        public string Balju_ID { get; set; }

        [FieldName("거래처ID")]
        public int Company_ID { get; set; }

        [FieldName("거래처명")]
        public string Company_Name { get; set; }

        [FieldName("발주날짜")]
        public DateTime Balju_Date { get; set; }

        [FieldName("발주수령날짜")]
        public DateTime Balju_ReceiptDate { get; set; }

        [FieldName("발주요청사원")]
        public string Employees_Name { get; set; }

        [FieldName("수령사원")]
        public string ReceiptEmployees_Name { get; set; }

        [FieldName("총액")]
        public int Total { get; set; }

        [FieldName("발주삭제여부")]
        public bool Balju_DeletedYN { get; set; }
    }

    public class BaljuDetail
    {
        [FieldName("발주식별ID")]
        public string Balju_ID { get; set; }

        [FieldName("제품ID")]
        public string Product_ID { get; set; }

        [FieldName("제품명")]
        public string Product_Name { get; set; }

        [FieldName("발주수량")]
        public int BaljuDetail_Qty { get; set; }

        public override string ToString()
        {
            return Balju_ID;
        }
    }
}
