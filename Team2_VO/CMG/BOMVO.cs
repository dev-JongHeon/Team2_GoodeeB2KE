using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class BOMVO
    {
        [FieldName("제품ID")]
        public string Product_ID { get; set; }
        [FieldName("제품명")]
        public string Product_Name { get; set; }
        [FieldName("제품개수")]
        public int Combination_RequiredQty { get; set; }
        [FieldName("가격")]
        public int Product_Price { get; set; }
        public string Combination_Product_ID { get; set; }
        public string Category_Division { get; set; }
        public int Combination_ID { get; set; }
        public bool Combination_DeletedYN { get; set; }

        public override string ToString()
        {
            return Product_ID;
        }

        public override bool Equals(object obj)
        {
            if(Convert.ToString(obj)== Combination_Product_ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = 155131702;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Product_ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Product_Name);
            hashCode = hashCode * -1521134295 + Combination_RequiredQty.GetHashCode();
            hashCode = hashCode * -1521134295 + Product_Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Combination_Product_ID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Category_Division);
            hashCode = hashCode * -1521134295 + Combination_ID.GetHashCode();
            hashCode = hashCode * -1521134295 + Combination_DeletedYN.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(BOMVO left, BOMVO right)
        {
            return EqualityComparer<BOMVO>.Default.Equals(left, right);
        }

        public static bool operator !=(BOMVO left, BOMVO right)
        {
            return !(left == right);
        }
    }
}
