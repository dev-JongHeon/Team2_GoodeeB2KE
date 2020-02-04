using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class StockReceipt  // 자재수불 Property
    {
        [FieldName("수불내역ID")]
        public string StockReceipt_ID { get; set; }

        [FieldName("수불날짜")]
        public DateTime StockReceipt_Date { get; set; }

        [FieldName("창고ID")]
        public int Warehouse_ID { get; set; }

        [FieldName("창고구분")]
        public bool Warehouse_Division { get; set; }

        [FieldName("창고명")]
        public string Warehouse_Name { get; set; }

        [FieldName("제품명")]
        public string Product_Name { get; set; }

        [FieldName("제품ID")]
        public string Product_ID { get; set; }

        [FieldName("사원명")]
        public string Employees_Name { get; set; }

        [FieldName("수불수량")]
        public int StockReceipt_Quantity { get; set; }

        [FieldName("입출고구분")]
        public string StockReceipt_Division1 { get; set; }
    }

    public class StockStatus  // 자재현황 Property
    {
        [FieldName("제품ID")]
        public string Product_ID { get; set; }

        [FieldName("제품명")]
        public string Product_Name { get; set; }

        [FieldName("카테고리명")]
        public string CodeTable_CodeName { get; set; }

        [FieldName("창고ID")]
        public int Warehouse_ID { get; set; }

        [FieldName("창고명")]
        public string Warehouse_Name { get; set; }

        [FieldName("제품가격")]
        public int Product_Price { get; set; }

        [FieldName("제품수량")]
        public int Product_Qty { get; set; }

        [FieldName("제품안전재고량")]
        public int Product_Safety { get; set; }

        [FieldName("차이수량")]
        public int Count_Subtract { get; set; }

        [FieldName("제품삭제여부")]
        public bool Product_DeletedYN { get; set; }
    }
}
