using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Team2_POP
{
    //POP <=> 서버
    public class POPClient
    {
        #region 프로퍼티
        public string PerformanceID { get; set; }
        public string RequestQty { get; set; }
        public int EmployeeID { get; set; }
        #endregion

        public EventHandler received;


        // 이벤트발생이 필요함(생산완료 or 생산실패)
        // 어떤 라인인지 필요
        // 서버에 접속할 client 필요
        string host = "127.0.0.1";
        int port = 5000;
        int timeout = 5000;
        NetworkStream netStream;
                
        // 빈 생성자
        public POPClient()
        {
            
        }

        // 서버 연결
        public async void Connect()
        {
            try
            {
                TcpClient client = new TcpClient();
                netStream = client.GetStream();

                //서버에 연결하는 코드
                await client.ConnectAsync(host, port);

                // 최대 수신시간 5초
                netStream.ReadTimeout = timeout;
            }
            catch(Exception ex) { }
        }


        // 서버에 송신메서드 (생산 실적아이디를 윈도우 서비스(생산 기계)로 넘겨줌)
        public async void Writer()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(netStream))
                {
                    // 송신할 내용을 자동으로 버퍼해줌
                    writer.AutoFlush = true;

                    string ProductionInstruction = string.Join(",", new object[] { PerformanceID, RequestQty, EmployeeID });
                    await writer.WriteLineAsync(ProductionInstruction);                    
                }
            }
            catch(Exception ex) { }
        }

        // 서버 수신메서드
        public async void Read()
        {
            try
            {
                using (StreamReader reader = new StreamReader(netStream)) // 수신
                {
                    string response = await reader.ReadLineAsync();
                    string[] msg = response.Split(',');
                    if (msg.Length != 5)
                        throw new Exception("메세지 전송 실패");

                    foreach (Form frm in Application.OpenForms)
                    {
                        // 활성화된 POP메인폼을 찾고
                        if(frm is PopMain)
                        {
                            PopMain pop = (PopMain)frm;                           
                            // 해당 POP의 라인아이디와 같은 경우
                            if(pop.WorkerInfo.LineID == Convert.ToInt32(msg[0]))
                            {
                                //respone 형태 (라인아이디(0),메세지(1),생산실적아이디(2),완료여부(3),총 투입수량(4)) 
                                ReceiveEventArgs e = new ReceiveEventArgs
                                {
                                    LineID = int.Parse(msg[0]),
                                    Message = msg[1],
                                    PerformanceID = msg[2],
                                    IsCompleted = bool.Parse(msg[3]),
                                    QtyImport = int.Parse(msg[4])
                                };

                                
                                Receive(response, e);
                            }
                        }
                    }

                }
            }
            catch(Exception ex) { }
        }

        // 이벤트 생성
        public void Receive(object sender, ReceiveEventArgs e)
        {            
        }
    }
}
