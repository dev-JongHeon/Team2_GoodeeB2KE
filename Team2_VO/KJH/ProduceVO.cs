using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class ProduceVO
    {
        [FieldName("생산지시번호")]
        public string Produce_ID { get; set; }
        [FieldName("생산시작일")]
        public string Produce_StartDate { get; set; }
        [FieldName("생산완료일")]
        public string Produce_DoneDate { get; set; }        
        public int Factory_ID { get; set; }
        [FieldName("공장명")]
        public string Factory_Name { get; set; }
        public int Line_ID { get; set; }
        [FieldName("공정명")]
        public string Line_Name { get; set; }
        public string Product_ID { get; set; }
        [FieldName("품목명")]
        public string Product_Name { get; set; }
        [FieldName("요청수량")]
        public int Produce_QtyRequested { get; set; }
        [FieldName("투입수량")]
        public int Produce_QtyReleased { get; set; }
        [FieldName("생산상태")]
        public string Produce_State { get; set; }
    }
}
