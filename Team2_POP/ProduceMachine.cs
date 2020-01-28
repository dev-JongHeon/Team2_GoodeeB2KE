using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team2_POP
{
    // 생산담당
    public class ProduceMachine : IDisposable
    {
        // 생산을 하는 클래스 -- 생산실적아이디와 라인아이디 필요

        // 1 ~ 100 난수를 뽑아 5 이하일 경우 불량 발생 
        //
        public string LineID { get; set; }
        public string PerformanceID { get; set; }
        public string ProduceID { get; set; }
        public int RequestQty { get; set; }

        public ProduceMachine()
        {

        }

        //public async Task<bool> Start()
        //{
        //    bool s = await Task.Factory.StartNew(OperationMachine).ContinueWith(t => t.IsCompleted);
        //    return s;
        //}

        public bool Start()
        {
            try
            {
                OperationMachine();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // 불량인지 양품인지 뽑는 함수
        private bool IsSuccessItem()
        {
            int iResult = new Random().Next(1, 101);

            return iResult > 5;
        }

        // 생산
        private void OperationMachine()
        {
            try
            {
                Service service = new Service();

                for (int i = 0; i < 10; i++)
                {
                    bool b = IsSuccessItem();
                    if (b)
                        service.Producing(PerformanceID, 1, 0);
                    else
                        service.Producing(PerformanceID, 0, 1);
                }

                // 생산 완료 ( 재고 감소 )
                service.EndProduce(PerformanceID);
            }
            catch
            {

            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
