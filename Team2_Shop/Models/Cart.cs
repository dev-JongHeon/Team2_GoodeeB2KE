using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team2_Shop.Models
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Qty { get; set; }
    }

    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();

        public void AddItem(Product product, int qty)
        {
            CartLine line = lines.Where(p => p.Product.Product_ID == product.Product_ID).FirstOrDefault();

            if (line == null)
            {
                lines.Add(new CartLine
                {
                    Product = product,
                    Qty = qty
                });
            }
            else
            {
                line.Qty += qty;
            }
        }

        public void RemoveItem(Product product)
        {
            lines.RemoveAll(i => i.Product.Product_ID == product.Product_ID);
        }

        public void Clear()
        {
            lines.Clear();
        }

        public List<CartLine> Lines
        {
            get { return lines; }
        }

        public decimal ComputeTotalValue()
        {
            return lines.Sum(i => i.Product.Product_Price * i.Qty);
        }
    }
}