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
        TcpListener listener;

        public ServerMachine()
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")} 머신 기계 가동시작");
            AsyncWorkerServer().Wait();
            Console.WriteLine($"{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")} 머신 기계 가동종료");
        }


        // 일을 받기전에 클라이언트와 연결하는 코드
        private async Task AsyncWorkerServer()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

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
        private  void AsyncTcpProcess(object o)
        {
            TcpClient client = null;
            NetworkStream stream = null;

            try
            {
                client = (TcpClient)o;
                stream = client.GetStream();

                while (client.Connected)
                {
                    byte[] buff = new byte[1024];

                    Task<int> readTask = stream.ReadAsync(buff, 0, buff.Length);
                    int nbytes = readTask.Result;

                    if (nbytes > 2)
                    {
                        // 데이터를 가져옴(실적번호, 요구수량, 생산번호, 라인아이디)
                        // Worklist[0] => 개인정보 || Worklist[1] => 생산지시
                        string[] workList = Encoding.UTF8.GetString(buff, 0, nbytes).Trim().Split(',');

                        workList.ToList().ForEach(p => Console.WriteLine(p)); // 확인코드

                        // 접속 정보를 담음
                        if (Convert.ToInt32(workList[0]) == 0)
                        {
                            Console.WriteLine($"{DateTime.Now.ToString("yyyymmdd HH:MM:ss")} 클라이언트 접속 \n접속공정 - {Convert.ToInt32(workList[1])}");

                            ClientInfo info = new ClientInfo();
                            info.SetClient(client, Convert.ToInt32(workList[1]), Convert.ToBoolean(workList[2]));
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

                            string lineID = workList[4];
                            // 최초 : 라인아이디(0), 메세지(1), 성공여부(2)
                            Write(stream, new object[] { lineID, msg, isCompleted });

                            OperationMachine machine = new OperationMachine();
                            machine.PerformanceID = workList[1];
                            machine.RequestQty = Convert.ToInt32(workList[2]);
                            int totalQty = machine.ProductionMachine();
                            Console.WriteLine("작업완료 : {0}", totalQty);


                            //두번째 : 라인아이디(0), 메세지(1), 실적(2), 성공(3), 투입수량(4)
                            Write(stream, new object[] { lineID, "생산완료", machine.PerformanceID, true, totalQty });     

                        }
                        else if (Convert.ToInt32(workList[0]) == 9)
                        {
                            break;
                        }
                    }
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream.Close();
                client.Close();
                Console.WriteLine($"{DateTime.Now.ToString("yyyymmdd HH:MM:ss")} 클라이언트 접속해제");
            }
        }



        /// <summary>
        /// 서버 => 클라이언트로 메세지를 보내는 함수
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="arrObj"></param>
        /// <returns></returns>
        private async void Write(NetworkStream stream, object[] arrObj)
        {
            try
            {               
                StreamWriter writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                string msg = string.Join(",", arrObj);                
                await writer.WriteLineAsync(msg).ConfigureAwait(false);
                await writer.FlushAsync();

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
       

        public void ServerDown()
        {
            listener.Server.Close();
            listener.Stop();
        }

        private void WriteErrorLog(Exception ex)
        {

        }

        private void WriteLog(string log)
        {
            string logTxt = string.Concat(DateTime.UtcNow.ToString("yyyyMMdd HH:mm:ss"), log);
        }
    }
}
