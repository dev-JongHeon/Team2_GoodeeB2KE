using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public class ServerMachine
    {
        #region 전역변수
        TcpListener listener;
        ClientInfo clientInfo;
        #endregion

        public ServerMachine()
        {

        }

        public void Start()
        {
            Program.Log.WriteInfo($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")} 머신 기계 가동시작");
            AsyncWorkerServer().Wait();
            Program.Log.WriteInfo($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")} 머신 기계 가동종료");
        }


        // 일을 받기전에 클라이언트와 연결하는 코드
        private async Task AsyncWorkerServer()
        {
            listener = new TcpListener(Dns.GetHostEntry(Dns.GetHostName()).AddressList.ToList().Find(i => i.AddressFamily == AddressFamily.InterNetwork), 5000);
            listener.Start();
            clientInfo = new ClientInfo();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                // 작업을 시작해라  
                if (client != null)
                {
                    //Task.Factory.StartNew(AsyncTcpProcess, client);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(AsyncTcpProcess), client);
                }
            }
        }


        // 실질적으로 작업하는 코드
        private void AsyncTcpProcess(object o)
        {
            #region 전역변수

            TcpClient client = null;
            NetworkStream stream = null;
            string lineID = string.Empty; // 라인아이디

            #endregion

            try
            {
                // 클라이언트 연결 접속값을 넘겨 받음
                client = (TcpClient)o;
                stream = client.GetStream();

                while (true)
                {
                    byte[] buff = new byte[1024];

                    // 계속 받음
                    Task<int> readTask = stream.ReadAsync(buff, 0, buff.Length);
                    int nbytes = readTask.Result;

                    if (nbytes == 0)
                        break;

                    if (nbytes > 2)
                    {
                        // 데이터를 가져옴(실적번호, 요구수량, 생산번호, 라인아이디)
                        // Worklist[0] => 개인정보 || Worklist[1] => 생산지시
                        string[] workList = Encoding.UTF8.GetString(buff, 0, nbytes).Trim().Split(',');


                        // 접속 정보를 담음
                        if (Convert.ToInt32(workList[0]) == 0)
                        {
                            Program.Log.WriteInfo($"{DateTime.Now.ToString("yyyymmdd HH:MM:ss")} 클라이언트 접속 \n접속공정 - {Convert.ToInt32(workList[1])}");
                            clientInfo.SetClient(client, Convert.ToInt32(workList[1]), Convert.ToBoolean(workList[2]));
                            lineID = workList[1];
                        }
                        else if (Convert.ToInt32(workList[0]) == 1)
                        {
                            string msg = "서버 : 접수 완료";
                            bool isCompleted = true;
                            if (workList.Length != 5)
                            {
                                msg = "서버 : 접수 실패";
                                isCompleted = false;
                            }

                            lineID = workList[4];
                            // 최초 : 라인아이디(0), 메세지(1), 성공여부(2)
                            Write(lineID, new object[] { lineID, msg, isCompleted });

                            OperationMachine machine = new OperationMachine();

                            machine.MsgSender += new MessageEventHandler(RecieveMonitor);
                            machine.LineID = int.Parse(lineID);
                            machine.PerformanceID = workList[1];
                            machine.RequestQty = Convert.ToInt32(workList[2]);
                            int totalQty = machine.ProductionMachine();
                            Program.Log.WriteInfo($"작업완료 : {totalQty}");
                            Program.Log.WriteInfo($"생산공정아이디 : {lineID}");

                            //두번째 : 라인아이디(0), 메세지(1), 실적(2), 성공(3), 투입수량(4)
                            Write(lineID, new object[] { lineID, "생산완료", machine.PerformanceID, true, totalQty });

                        }
                        else if (Convert.ToInt32(workList[0]) == 9)
                        {
                            Program.Log.WriteWarn("클라이언트 접속해제 요청");
                            break;
                        }
                    }
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
            finally
            {
                if (string.IsNullOrEmpty(lineID))
                    clientInfo.DeleteClient(100);
                else
                clientInfo.DeleteClient(Convert.ToInt32(lineID));

                stream.Close();
                client.Close();
                Program.Log.WriteInfo($"{DateTime.Now.ToString("yyyymmdd HH:MM:ss")} 클라이언트 접속해제");
            }
        }



        /// <summary>
        /// 서버 => 클라이언트로 메세지를 보내는 함수
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="arrObj"></param>
        /// <returns></returns>
        private async void Write(string lineID, object[] arrObj)
        {
            try
            {
                List<ClientInfo> list = clientInfo.GetClient();
                ClientInfo client = (from item in list
                                     where item.Line == true && item.LineID == Convert.ToInt32(arrObj[0])
                                     select item).FirstOrDefault();


                StreamWriter writer = new StreamWriter(client.ClientData.GetStream());
                writer.AutoFlush = true;
                string msg = string.Join(",", arrObj);
                await writer.WriteLineAsync(msg).ConfigureAwait(false);
                await writer.FlushAsync();

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
        }

        // 모니터링 화면에 메세지를 보내는 함수
        public void RecieveMonitor(object sender, MessageEventArgs e)
        {
            try
            {
                string msg = e.Message;

                if (e.Message.Length > 1)
                {

                    List<ClientInfo> list = clientInfo.GetClient();
                    ClientInfo client = list.Find(c => c.Line == false);

                    if (client.ClientData.Client.Connected)
                    {
                        // 라인아이디, 생산총 개수, 투입개수 , 성공수량, 실패수량
                        StreamWriter writer = new StreamWriter(client.ClientData.GetStream());
                        //writer.AutoFlush = true;
                        writer.Write(msg);
                        writer.Flush();
                    }
                    else
                    {
                        client.ClientData.Client.Disconnect(true);
                    }
                }

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
        }


        public void ServerDown()
        {
            listener.Stop();
            listener.Server.Close();
        }

        private void WriteErrorLog(Exception ex)
        {
            Program.Log.WriteError(ex.Message, ex);
        }
    }
}
