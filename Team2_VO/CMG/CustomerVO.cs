using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class CustomerVO
    {
        public int Customer_ID { get; set; }
        public string Customer_UserID { get; set; }
        public string Customer_PWD { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Phone { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Birth { get; set; }
        public string Customer_Address { get; set; }
        public bool Customer_DeletedYN { get; set; }
    }
}
