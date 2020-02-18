using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class WarehouseVO
    {
        public int Warehouse_ID { get; set; }
        public string Warehouse_Name { get; set; }
        public string Warehouse_Address { get; set; }
        public string Warehouse_Number { get; set; }
        public string Warehouse_Fax { get; set; }
        public bool Warehouse_DeletedYN { get; set; }
        public int Warehouse_Division { get; set; }
        public string Warehouse_Division_Name { get; set; }
        public string Warehouse_AddrNumber { get; set; }
    }
}
