using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class BOMVO
    {
        [FieldName("품목명")]
        public string Category_Division { get; set; }
        [FieldName("제품명")]
        public string Product_Name { get; set; }
        public int Combination_ID { get; set; }
        public string Product_ID { get; set; }
        public string Combination_Product_ID { get; set; }
        public int Combination_RequiredQty { get; set; }
        [FieldName("가격")]
        public int Product_Price { get; set; }
        public bool Combination_DeletedYN { get; set; }

        public override string ToString()
        {
            return Product_ID;
        }
    }
}
