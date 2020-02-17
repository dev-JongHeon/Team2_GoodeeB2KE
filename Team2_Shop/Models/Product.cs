using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class Product
    {
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public byte[] Product_Image { get; set; }
    }

    public class ProductUrl : Product
    {
        public string Return_Url { get; set; }
    }
}