using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class Stock
    {
        public string StockReceipt_ID { get; set; }
        public bool StockReceipt_Division { get; set; }
        public DateTime StockReceipt_Date { get; set; }
        public int Warehouse_ID { get; set; }
        public bool Warehouse_Division { get; set; }
        public string Warehouse_Name { get; set; }
        public string Product_Name { get; set; }
        public string Product_ID { get; set; }
        public string Employees_Name { get; set; }
        public int StockReceipt_Quantity { get; set; }
    }
}
