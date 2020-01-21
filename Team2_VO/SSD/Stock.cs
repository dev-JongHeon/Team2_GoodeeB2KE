using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class StockReceipt  // 자재수불 Property
    {
        public string StockReceipt_ID { get; set; }
        public DateTime StockReceipt_Date { get; set; }
        public int Warehouse_ID { get; set; }
        public bool Warehouse_Division { get; set; }
        public string Warehouse_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_ID { get; set; }
        public string Employees_Name { get; set; }
        public int StockReceipt_Quantity { get; set; }
        public string StockReceipt_Division1 { get; set; }
    }

    public class StockStatus  // 자재현황 Property
    {
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Category { get; set; }
        public int Warehouse_ID { get; set; }
        public string Warehouse_Name { get; set; }
        public int Product_Price { get; set; }
        public int Product_Qty { get; set; }
        public int Product_Safety { get; set; }
        public int Count_Subtract { get; set; }
        public bool Product_DeletedYN { get; set; }
    }
}
