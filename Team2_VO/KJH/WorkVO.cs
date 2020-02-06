using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class WorkVO
    {
        [FieldName("작업지시번호")]
        public string Work_ID { get; set; }
        [FieldName("작업지시일")]
        public string Work_StartDate { get; set; }
        [FieldName("작업완료일")]
        public string Work_EndDate { get; set; }
        [FieldName("출하지시번호")]
        public string Shipment_ID { get; set; }
        [FieldName("납기일")]
        public string Shipment_RequiredDate { get; set; }
        [FieldName("작업상태")]
        public string Work_State { get; set; }
        public int Employees_ID { get; set; }
        [FieldName("작업지시자")]
        public string Employees_Name { get; set; }
    }
}
