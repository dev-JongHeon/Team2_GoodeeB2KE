﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public class ServerMachine
    {
        TcpListener listener;

        public ServerMachine()
        {
            Console.WriteLine("머신 기계 가동시작");
            AsyncWorkerServer().Wait();
            Console.WriteLine("머신 기계 가동종료");
        }


        // 일을 받기전에 클라이언트와 연결하는 코드
        private async Task AsyncWorkerServer()
        {
            listener = new TcpListener(IPAddress.Any, 5000);
            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                Console.WriteLine("클라이언트 접속");
                // 작업을 시작해라
                await Task.Factory.StartNew(AsyncTcpProcess, client);
            }
        }


        // 실질적으로 작업하는 코드
        private async void AsyncTcpProcess(object o)
        {
            TcpClient client = (TcpClient)o;
            try
            {
                NetworkStream stream = client.GetStream();

                byte[] buff = new byte[1024];

                Task<int> readTask = stream.ReadAsync(buff, 0, buff.Length);

                int nbytes = readTask.Result;

                if (nbytes > 0)
                {
                    // 데이터를 가져옴(실적번호, 요구수량, 생산번호, 라인아이디)
                    string[] workList = Encoding.UTF8.GetString(buff, 0, nbytes).Trim().Split(',');

                    workList.ToList().ForEach(p => Console.WriteLine(p)); // 확인코드

                    string lineID = workList[3];

                    string msg = "서버 : 접수 완료";
                    bool isCompleted = true;
                    if (workList.Length != 4)
                    {
                        msg = "서버 : 접수 실패";
                        isCompleted = !isCompleted;
                    }
                    await Write(stream, new object[] { lineID, msg, isCompleted });

                    OperationMachine machine = new OperationMachine();
                    machine.PerformanceID = workList[0];
                    machine.RequestQty = Convert.ToInt32(workList[1]);
                    int totalQty = machine.ProductionMachine();

                    Console.WriteLine("작업완료 : {0}", totalQty);
                    await Write(stream, new object[] { lineID, "성공", machine.PerformanceID, true, totalQty });


                    #region 주석
                    //string msg = string.Join(",", new object[] { LineID, "접수완료", true });
                    //buff = Encoding.UTF8.GetBytes(msg);
                    //await stream.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
                    //int totalQty = machine.ProductionMachine();
                    //Console.WriteLine("작업완료 : {0}", totalQty);

                    //msg = string.Join(",", new object[] { LineID, "성공", machine.PerformanceID, true, totalQty });
                    //buff = Encoding.UTF8.GetBytes(msg);
                    //await stream.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
                    #endregion
                }

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 서버 => 클라이언트로 메세지를 보내는 함수
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="arrObj"></param>
        /// <returns></returns>
        private async Task Write(NetworkStream stream, object[] arrObj)
        {
            string msg = string.Join(",", arrObj);
            byte[] buff = Encoding.UTF8.GetBytes(msg);
            await stream.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
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