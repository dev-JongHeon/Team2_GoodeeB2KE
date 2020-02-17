using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);

    //파일에 쓰인 견적서를 바탕으로 DB에 접속한다.
    public class OperationMachine
    {
        #region 프로퍼티
        public string PerformanceID { get; set; }
        public string ProduceID { get; set; }
        public int RequestQty { get; set; }
        public int LineID { get; set; }
        #endregion

        #region 전역변수

        int iTotalCnt; // 총 투입개수(소요개수)
        #endregion

        public event MessageEventHandler MsgSender;

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
                MessageEventArgs me = new MessageEventArgs();
                string msg = string.Empty;

                // currentQty = 현재투입량, RequestQty = 요청수량
                for (int currentQty = 0; currentQty < RequestQty; currentQty++)
                {
                    iTotalCnt++;
                    bool IsSuccess = IsSuccessItem(); // true => 양품 false => 불량품
                    Thread.Sleep(new Random().Next(1300, 1720));

                    int itemQuality = 0;

                    if (IsSuccess)
                        itemQuality = 1;
                    else
                        currentQty--;

                    // 생산중
                    service.Producing(PerformanceID, itemQuality, 1 - itemQuality);



                    //생산중 - 모니터링 화면

                    // 라인아이디, 요청개수, 진행개수 ,성공개수, 실패개수
                    msg = string.Join(",", LineID, RequestQty, iTotalCnt, itemQuality, 1 - itemQuality);
                    me.Message = msg;

                    if (MsgSender != null)
                        MsgSender.Invoke(this, me);
                }

                // 생산 완료 ( 재고 감소 )
                Thread.Sleep(3000);
                service.EndProduce(PerformanceID);

                // 생산 완료 - 모니터링 화면
                msg = string.Join(",", LineID, RequestQty, iTotalCnt, 1, 0);
                me.Message = msg;

                if (MsgSender != null)
                    MsgSender.Invoke(this, me);


                return iTotalCnt;
            }
            catch (Exception ex)
            {
                Program.Log.WriteError(ex.Message, ex);
                new Service().EndProduce(PerformanceID);
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex);
                return iTotalCnt;
            }
        }
    }
}
