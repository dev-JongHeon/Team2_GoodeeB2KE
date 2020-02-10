using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_VO
{
    public class PerformanceVO
    {
        [FieldName("생산지시번호")]
        public string PerformanceProduce_ID { get; set; }
        [FieldName("생산실적번호")]
        public string Performance_ID { get; set; }
        [FieldName("실적시작시간")]
        public string Performance_StartDate { get; set; }
        [FieldName("실적종료시간")]
        public string Performance_EndDate { get; set; }
        [FieldName("경과시간")]
        public string Performance_ElapsedTime { get; set; }
        public string Product_ID { get; set; }
        [FieldName("품목명")]
        public string Product_Name { get; set; }
        [FieldName("요청수량")]
        public int Performance_QtyImport { get; set; }
        [FieldName("양품수량")]
        public int Performance_QtySuccessItem { get; set; }
        [FieldName("불량수량")]
        public int Performance_QtyDefectiveItem { get; set; }
        [FieldName("불량률")]
        public decimal Performance_DefectiveRate { get; set; }
        public int Employees_ID { get; set; }
        [FieldName("작업자")]
        public string Employees_Name { get; set; }

        public override string ToString()
        {
            return PerformanceProduce_ID;
        }
    }
}
