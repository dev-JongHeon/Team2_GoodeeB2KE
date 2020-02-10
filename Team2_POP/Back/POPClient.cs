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
        public bool IsLine { get; set; }

        public bool Connected { get; set; }

        #endregion

        public event ReceiveEventHandler Received;


        // 이벤트발생이 필요함(생산완료 or 생산실패)
        // 어떤 라인인지 필요
        // 서버에 접속할 client 필요  (AppConfig에 추가할 목록)
        string host = "127.0.0.1";
        int port = 5000;
        NetworkStream netStream;
        System.Timers.Timer timer;
        TcpClient client;

        // 빈 생성자
        public POPClient()
        {
            timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        // 매초 서버로부터 메세지를 수신받는 이벤트
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Connected)
                {
                    await Read();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowDialog("서버접속끊김", "서버와의 연결이 끊겼습니다.", MessageBoxIcon.Error
                    , MessageBoxButtons.OK);
                ErrorMessage(ex);
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
                DisConnected();
            }
        }

        public void Start()
        {
            try
            {
                if (Connected && timer.Enabled)
                {
                    Writer(netStream, new object[] { 1, PerformanceID, RequestQty, ProduceID, LineID });
                }
                else if (Connected)
                {
                    timer.Enabled = true;
                    timer.Start();
                    Writer(netStream, new object[] { 1, PerformanceID, RequestQty, ProduceID, LineID });

                }
                else
                {
                    Connect();
                    Start();
                }
            }
            catch (Exception ex)
            {
                string sss = ex.Message;
            }
        }

        // 서버 연결
        public bool Connect()
        {
            IPEndPoint clientIP = new IPEndPoint(IPAddress.Parse(host), new Random((int)DateTime.UtcNow.Ticks).Next(5001, 8901));
            client = new TcpClient(clientIP);
            client.ConnectAsync(host, port).Wait();
            client.NoDelay = true;

            netStream = client.GetStream();
            
            try
            {
                if (client.Connected)
                {
                    Connected = client.Connected;
                }

                return client.Connected;
            }

            catch (Exception ex)
            {
                ErrorMessage(ex);
                return client.Connected;
            }
        }

        public void DisConnected()
        {
            if (netStream != null)
            {
                Writer(netStream, new object[] { 9 });
                client.Close();
                netStream.Close();
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
            Connected = false;
        }


        // 서버에 송신메서드 (생산 실적아이디를 윈도우 서비스(생산 기계)로 넘겨줌)
        public async void Writer(Stream stream, object[] objArr)
        {
            try
            {
                string ProductionInstruction = string.Join(",", objArr);
                StreamWriter writer = new StreamWriter(stream);

                writer.AutoFlush = true;
                await writer.WriteAsync(ProductionInstruction);
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                DisConnected();
            }
        }

        public void Certification()
        {
            try
            {
                Writer(netStream, new object[] { 0, LineID, IsLine });
            }
            catch (Exception ex)
            {
                ErrorMessage(ex);
                DisConnected();
            }
        }

        // 서버 수신메서드
        public async Task Read()
        {
            try
            {
                StreamReader reader = new StreamReader(netStream);
                string[] msg = (await reader.ReadLineAsync()).Split(',');

                if (msg.Length > 1)
                {
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


            catch (Exception ex)
            {
                ErrorMessage(ex);
                DisConnected();
            }
        }

        private void ErrorMessage(Exception ex)
        {
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
                Connected = false;
            }
        }
    }
}
