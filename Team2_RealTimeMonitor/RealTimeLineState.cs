using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_RealTimeMonitor
{
    public partial class RealTimeLineState : Form
    {
        System.Timers.Timer timer;
        TcpClient client;
        string host = "127.0.0.1";
        int port = 5000;
        NetworkStream netStream;

        public RealTimeLineState()
        {
            InitializeComponent();
        }

        private void RealTimeLineState_Load(object sender, EventArgs e)
        {
            SettingControl();
            InitData();
            ConnectServer();
        }

        private void SettingControl()
        {
            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed = true;
        }

        private void InitData()
        {
            // DB에서 공장아이디, 라인아이디, 라인이름을 불러옴
            Service service = new Service();
            List<LineMonitor> list = service.GetLineInfo();

            // 공장아이디가 완제품 공장인것은 왼쪽 레이아웃
            // 공장아이디가 반제품 공장인것은 오른쪽 레이아웃
            // 컨트롤 Tag = 라인아이디

            List<LineMonitor> listSemi = list.FindAll(elem => elem.Factory_ID == 1);
            List<LineMonitor> listProduct = list.FindAll(elem => elem.Factory_ID == 2);

            // 반제품 공정생성
            for (int i = 0; i < listSemi.Count; i++)
            {
                LineMonitorControl lineControl = new LineMonitorControl();
                lineControl.LabelLineNameText = listSemi[i].Line_Name;
                lineControl.Tag = listSemi[i].Line_ID.ToString();

                flowLayoutSemiProductLine.Controls.Add(lineControl);
            }

            // 완제품 공정 생성
            for (int i = 0; i < listProduct.Count; i++)
            {
                LineMonitorControl lineControl = new LineMonitorControl();
                lineControl.LabelLineNameText = listProduct[i].Line_Name;
                lineControl.Tag = listProduct[i].Line_ID.ToString();

                flowLayoutProductLine.Controls.Add(lineControl);
            }
        }

        private void ConnectServer()
        {
            try
            {
                // 서버와 연결을 함 Write 한번 => (While Read)
                IPEndPoint clientIP = new IPEndPoint(IPAddress.Parse(host), new Random((int)DateTime.UtcNow.Ticks).Next(5001, 8901));
                client = new TcpClient(clientIP);
                client.ConnectAsync(host, port).Wait();
                client.NoDelay = true;

                netStream = client.GetStream();

                string msg = string.Join(",", new object[] { 0, 100, false });
                StreamWriter writer = new StreamWriter(netStream);
                writer.Write(msg);
                writer.Flush();

                timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Interval = 1000;
                timer.Elapsed += Timer_Elapsed;

                timer.Enabled = true;
                timer.Start();
            }

            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (timer.Enabled)
                {
                    await Read();
                }
                ResetControl();
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
        }

        public async Task Read()
        {
            if (!netStream.CanRead) return;

            try
            {
                // 라인아이디, 요청개수, 현재개수, 성공, 불량
                //StreamReader reader = new StreamReader(netStream);
                //string[] msg = (await reader.ReadLineAsync()).Split(',');

                byte[] buff = new byte[1024];

                int nbytes = await netStream.ReadAsync(buff, 0, buff.Length);                         

                if(nbytes < 1)
                {
                    return;
                }

                string[] msg = Encoding.UTF8.GetString(buff, 0, nbytes).Split(',');

                if (msg.Length > 1)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is LineMonitorControl)
                        {
                            LineMonitorControl lineMonitor = (LineMonitorControl)control;
                            if (lineMonitor.Tag.ToString() == msg[0])
                            {
                                lineMonitor.LabelRequestText = msg[1];
                                lineMonitor.LabelImportText = msg[2];
                                lineMonitor.LabelProduceText = (int.Parse(lineMonitor.LabelProduceText) + int.Parse(msg[3])).ToString();
                                lineMonitor.LabelDefectiveText = (int.Parse(lineMonitor.LabelDefectiveText) + int.Parse(msg[4])).ToString(); ;

                                if (Convert.ToInt32(lineMonitor.LabelDefectiveText) > 1)
                                    lineMonitor.PictureStateImage = Properties.Resources.Img_CircleYellow;
                                else
                                    lineMonitor.PictureStateImage = Properties.Resources.Img_CircleGreen;

                                lineMonitor.CircleProgress.Value = (int.Parse(lineMonitor.LabelProduceText) / int.Parse(lineMonitor.LabelRequestText)) * 100;



                                break;
                            }
                        }
                    }
                }
            }


            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        private void ResetControl()
        {
            try
            {
                foreach (Control control in this.Controls)
                {
                    if (control is LineMonitorControl)
                    {
                        LineMonitorControl lineMonitor = (LineMonitorControl)control;

                        if (lineMonitor.CircleProgress.Value == 100)
                        {
                            lineMonitor.CircleProgress.Value = 0;
                            lineMonitor.LabelRequestText = "0";
                            lineMonitor.LabelImportText = "0";
                            lineMonitor.LabelProduceText = "0";
                            lineMonitor.LabelDefectiveText = "0";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex);
            }
        }

        private void WriteLog(Exception ex)
        {
            Program.Log.WriteError(ex.Message, ex);
        }
    }
}
