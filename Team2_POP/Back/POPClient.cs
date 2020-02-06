using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Timers;

namespace Team2_POP
{
    //POP <=> 서버

    public delegate void ReceiveEventHandler(object sender, ReceiveEventArgs e);

    public class POPClient : IDisposable
    {
        #region 프로퍼티 실적아이디, 요구수량, 사원번호
        public string PerformanceID { get; set; }
        public int RequestQty { get; set; }
        public string ProduceID { get; set; }
        public int LineID { get; set; }

        public bool Connected { get; set; }

        #endregion

        public event ReceiveEventHandler Received;


        // 이벤트발생이 필요함(생산완료 or 생산실패)
        // 어떤 라인인지 필요
        // 서버에 접속할 client 필요  (AppConfig에 추가할 목록)
        string host = "127.0.0.1";
        int port = 5000;
        //string cIP = "192.168.0.1";
        //int cPort = new Random((int)DateTime.Now.Ticks).Next(5001, 5501);
        int timeout = 50000;
        NetworkStream netStream;
        System.Timers.Timer timer;
        TcpClient client;

        // 빈 생성자
        public POPClient()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 3000;
            timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Connected)
                await Read();
        }

        public void Start()
        {
            if (Connected && timer.Enabled)
            {
                Writer();                
            }
            else if (Connected)
            {
                Writer();
                timer.Start();
            }
        }

        // 서버 연결
        public async Task<bool> Connect()
        {
            //IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(cIP), cPort);

            client = new TcpClient();

            try
            {
                //서버에 연결하는 코드
                await client.ConnectAsync(IPAddress.Parse(host), port);

                if (client.Connected)
                {
                    netStream = client.GetStream();
                    Connected = client.Connected;
                    // 최대 수신시간 5초
                    netStream.ReadTimeout = timeout;
                }

                return await Task.FromResult(client.Connected);
            }

            catch (Exception ex)
            {
                ErrorMessage(ex);
                return await Task.FromResult(client.Connected);
            }
        }


        // 서버에 송신메서드 (생산 실적아이디를 윈도우 서비스(생산 기계)로 넘겨줌)
        public async void Writer()
        {
            try
            {
                StreamWriter writer = new StreamWriter(netStream);

                // 송신할 내용을 자동으로 버퍼해줌
                writer.AutoFlush = true;

                string ProductionInstruction = string.Join(",", new object[] { PerformanceID, RequestQty, ProduceID, LineID });
                await writer.WriteAsync(ProductionInstruction.Trim()).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        // 서버 수신메서드
        public async Task Read()
        {
            try
            {
                #region 주석
                //using (StreamReader reader = new StreamReader(netStream)) // 수신
                //{                    
                //    string response = await reader.ReadLineAsync();
                //    string[] msg = response.Split(',');
                //    if (msg.Length != 5)
                //        throw new Exception("메세지 전송 실패");

                //    foreach (Form frm in Application.OpenForms)
                //    {
                //        // 활성화된 POP메인폼을 찾고
                //        if (frm is PopMain)
                //        {
                //            PopMain pop = (PopMain)frm;
                //            // 해당 POP의 라인아이디와 같은 경우
                //            if (pop.WorkerInfo.LineID == Convert.ToInt32(msg[0]))
                //            {
                //                //respone 형태 (라인아이디(0),메세지(1),생산실적아이디(2),완료여부(3),총 투입수량(4)) 
                //                ReceiveEventArgs e = new ReceiveEventArgs
                //                {
                //                    LineID = int.Parse(msg[0]),
                //                    Message = msg[1],
                //                    PerformanceID = msg[2],
                //                    IsCompleted = bool.Parse(msg[3]),
                //                    QtyImport = int.Parse(msg[4])
                //                };
                //                Received(response, e);
                //            }
                //        }
                //    }

                //}
                #endregion

                byte[] buff = new byte[1024];

                int nbytes = await netStream.ReadAsync(buff, 0, buff.Length);

                string[] msg = Encoding.UTF8.GetString(buff, 0, nbytes).Split(',');
                if (nbytes > 0)
                {
                    // 현재까지 열린 폼을 기준으로 반복문을 수행함
                    FormCollection frms = Application.OpenForms;

                    for (int i = 0; i < frms.Count; i++)
                    {
                        if (frms[i] == null)
                        {
                            i++;
                            continue;
                        }

                        if (frms[i] is PopMain)
                        {
                            PopMain pop = (PopMain)frms[i];
                            // 해당 POP의 라인아이디와 같은 경우
                            if (pop.WorkerInfo.LineID == Convert.ToInt32(msg[0]))
                            {
                                //respone 형태 (실시간모니터인지 아닌지(0), 라인아이디(1),메세지(2),생산실적아이디(3),완료여부(4),총 투입수량(5)) 
                                ReceiveEventArgs e = new ReceiveEventArgs();
                                if (msg.Length == 5)
                                {
                                    e.LineID = int.Parse(msg[0]);
                                    e.Message = msg[1];
                                    e.PerformanceID = msg[2];
                                    e.IsCompleted = bool.Parse(msg[3]);
                                    e.QtyImport = int.Parse(msg[4]);
                                }
                                else if (msg.Length == 3)
                                {
                                    e.LineID = int.Parse(msg[0]);
                                    e.Message = msg[1];
                                    e.IsCompleted = bool.Parse(msg[2]);
                                }

                                if (e.Message != null)
                                {
                                    Debug.WriteLine(msg[0]);
                                    if (Received != null)
                                        Received?.Invoke(this, e);
                                }
                            }
                        }
                    }
                }
            }

        //    foreach (Form frm in frms)
        //    {
        //        // 활성화된 POP메인폼을 찾고
        //        if (frm is PopMain)
        //        {
        //            PopMain pop = (PopMain)frm;
        //            // 해당 POP의 라인아이디와 같은 경우
        //            if (pop.WorkerInfo.LineID == Convert.ToInt32(msg[0]))
        //            {
        //                //respone 형태 (라인아이디(0),메세지(1),생산실적아이디(2),완료여부(3),총 투입수량(4)) 
        //                ReceiveEventArgs e = new ReceiveEventArgs();
        //                if (msg.Length == 5)
        //                {
        //                    e.LineID = int.Parse(msg[0]);
        //                    e.Message = msg[1];
        //                    e.PerformanceID = msg[2];
        //                    e.IsCompleted = bool.Parse(msg[3]);
        //                    e.QtyImport = int.Parse(msg[4]);
        //                }
        //                else if (msg.Length == 3)
        //                {
        //                    e.LineID = int.Parse(msg[0]);
        //                    e.Message = msg[1];
        //                    e.IsCompleted = bool.Parse(msg[2]);
        //                }

        //                if (e.Message != null)
        //                {
        //                    Debug.WriteLine(msg[0]);
        //                    if (Received != null)
        //                        Received.Invoke(this, e);
        //                }
        //            }
        //        }
        //    }
        //}
            catch (Exception ex)
            {
                ErrorMessage(ex);
            }
        }

        private void ErrorMessage(Exception ex)
        {
            foreach (Form frm in Application.OpenForms)
            {
                // 활성화된 POP메인폼을 찾고
                if (frm is PopMain)
                {
                    PopMain pop = (PopMain)frm;
                    // 해당 POP의 라인아이디와 같은 경우
                    if (pop.WorkerInfo.LineID == LineID)
                    {
                        ReceiveEventArgs e = new ReceiveEventArgs();
                        e.Message = string.Join("오류", ex.Message);
                        e.LineID = LineID;
                        e.IsCompleted = false;

                        if (Received != null)
                            Received.Invoke(this, e);

                    }
                }
            }
        }


        public void Dispose()
        {
            if (netStream != null)
            {
                netStream.Close();
                client.Close();
            }
        }
    }
}
