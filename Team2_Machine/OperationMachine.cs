using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Team2_Machine
{
    //파일에 쓰인 견적서를 바탕으로 DB에 접속한다.
    public class OperationMachine
    {
        public string PerformanceID { get; set; }
        public string ProduceID { get; set; }
        public int RequestQty { get; set; }

        // Insert한 생산실적 아이디와 생산할 수량이 이미 파일에 기록되있어
        // 해당 파일을 가져와서 생산함

        int iCnt;
        private bool IsSuccessItem()
        {
            int iResult = new Random((int)DateTime.UtcNow.Ticks).Next(1, 101);

            return iResult > 5;
        }

        // 생산
        public int ProductionMachine()
        {
            try
            {
                Service service = new Service();
                
                for (int i = 0; i < RequestQty; i++)
                {
                    iCnt++;
                    bool b = IsSuccessItem();
                    Thread.Sleep(new Random().Next(100,120));

                    if (b)
                        service.Producing(PerformanceID, 1, 0);
                    else
                    {
                        service.Producing(PerformanceID, 0, 1);
                        i--;
                    }
                }

                // 생산 완료 ( 재고 감소 )

                Thread.Sleep(100);
                service.EndProduce(PerformanceID);

                return iCnt;
            }
            catch(Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
                Debug.WriteLine(Ex);
                return iCnt;
            }
        }
    }
}
