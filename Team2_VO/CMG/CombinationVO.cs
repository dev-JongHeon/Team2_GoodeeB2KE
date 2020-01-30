using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class CombinationVO
    {
        public string Product_ID { get; set; }
        public string Combination_Product_ID { get; set; }
        public int Combination_RequiredQty { get; set; }
        public bool Combination_DeletedYN { get; set; }
    }
}
