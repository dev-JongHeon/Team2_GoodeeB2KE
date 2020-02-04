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
        [FieldName("선도1")]
        public string Balju_ID { get; set; }
        [FieldName("선도2")]
        public int Company_ID { get; set; }
        [FieldName("선도3")]
        public string Company_Name { get; set; }
        [FieldName("선도4")]
        public DateTime Balju_Date { get; set; }
        [FieldName("선도5")]
        public DateTime Balju_ReceiptDate { get; set; }
        [FieldName("선도6")]
        public string Employees_Name { get; set; }
        [FieldName("선도7")]
        public bool Balju_DeletedYN { get; set; }
    }

    public class BaljuDetail
    {
        public string Balju_ID { get; set; }
        public string Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int BaljuDetail_Qty { get; set; }
    }
}
