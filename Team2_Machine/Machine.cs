using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Team2_Machine
{
    public partial class Machine : ServiceBase
    {
        TcpListener listener;
        public Machine()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
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

                    workList.ToList().ForEach(p => Console.WriteLine(p));
                    
                    string LineID = workList[3].Substring(0,1);

                    OperationMachine machine = new OperationMachine();
                    machine.PerformanceID = workList[0];
                    machine.RequestQty = Convert.ToInt32(workList[1]);

                    string msg = string.Join(",", new object[] { LineID, "접수완료", true });
                    buff = Encoding.UTF8.GetBytes(msg);
                    await stream.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
                    int totalQty = machine.ProductionMachine();
                    Console.WriteLine("작업완료 : {0}",totalQty);

                    msg = string.Join(",", new object[] { LineID, "성공", machine.PerformanceID, true, totalQty });
                    buff = Encoding.UTF8.GetBytes(msg);
                    await stream.WriteAsync(buff, 0, buff.Length).ConfigureAwait(false);
                }

                stream.Close();
                client.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            listener.Server.Close();
            listener.Stop();
        }
        public void Pause()
        {
            OnStop();
        }
    }
}
