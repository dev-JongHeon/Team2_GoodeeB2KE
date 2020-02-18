using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public delegate void LineDelegate(LineMonitorControl lineMonitorControl, string[] msg);

    public partial class RealTimeLineState : Form
    {
        #region 전역변수

        System.Timers.Timer timer;
        TcpClient client;
        string host = "127.0.0.1";
        int port = 5000;
        NetworkStream netStream;
        List<LineMonitorControl> lineMonitors;

        #endregion

        public RealTimeLineState()
        {
            InitializeComponent();
        }

        /*----------------
         - SettingControl : 컨트롤 디자인, 프로퍼티 설정
         - InitData : 데이터 바인딩
         - ConnectServer : 서버에 접속
        ---------------- */

        private void RealTimeLineState_Load(object sender, EventArgs e)
        {
            SettingControl();
            InitData();
            ConnectServer();
            this.ActiveControl = splitLeft.Panel1;
        }

        private void SettingControl()
        {
            splitMain.IsSplitterFixed = splitRight.IsSplitterFixed = splitLeft.IsSplitterFixed = true;
        }

        private void InitData()
        {
            // DB에서 공장아이디, 라인아이디, 라인이름을 불러옴
            Service service = new Service();
            List<LineMonitor> list = service.GetLineInfo();
            lineMonitors = new List<LineMonitorControl>();

            // 공장아이디가 완제품 공장인것은 왼쪽 레이아웃
            // 공장아이디가 반제품 공장인것은 오른쪽 레이아웃
            // 컨트롤 Tag = 라인아이디


            #region 계기판 컨트롤 리스트에 담는 코드

            List<LineMonitor> listSemi = list.FindAll(elem => elem.Factory_ID == 1);
            List<LineMonitor> listProduct = list.FindAll(elem => elem.Factory_ID == 2);

            // 반제품 공정생성
            for (int i = 0; i < listSemi.Count; i++)
            {
                LineMonitorControl lineControl = new LineMonitorControl();
                lineControl.LabelLineNameText = listSemi[i].Line_Name;

                // 컨트롤 태그에 라인아이디를 지정
                lineControl.Tag = listSemi[i].Line_ID.ToString();

                // ProgressColor 3,4 : 게이지
                // ProgressColor 1,2 : 원 색깔 (Bottom :1, Top : 2)
                lineControl.CircleProgress.ProgressColor1 = lineControl.panel2.BackColor;
                lineControl.CircleProgress.ProgressColor2 = lineControl.panel2.BackColor;
                lineControl.CircleProgress.ProgressColor3 = Color.Violet;
                lineControl.CircleProgress.ProgressColor4 = Color.Red;

                lineMonitors.Add(lineControl);
                flowLayoutSemiProductLine.Controls.Add(lineControl);
            }

            // 완제품 공정 생성
            for (int i = 0; i < listProduct.Count; i++)
            {
                LineMonitorControl lineControl = new LineMonitorControl();
                lineControl.LabelLineNameText = listProduct[i].Line_Name;

                // 컨트롤 태그에 라인아이디를 지정
                lineControl.Tag = listProduct[i].Line_ID.ToString();

                // ProgressColor 3,4 : 게이지
                // ProgressColor 1,2 : 원 색깔 (Bottom :1, Top : 2)
                lineControl.CircleProgress.ProgressColor1 = lineControl.panel2.BackColor;
                lineControl.CircleProgress.ProgressColor2 = lineControl.panel2.BackColor;
                lineControl.CircleProgress.ProgressColor3 = Color.Violet;
                lineControl.CircleProgress.ProgressColor4 = Color.Red;              

                lineMonitors.Add(lineControl);
                flowLayoutProductLine.Controls.Add(lineControl);
            }

            #endregion
        }

        private void ConnectServer()
        {
            try
            {
                // 서버와 연결을 함 Write 한번 => (While Read)
                IPEndPoint clientIP = new IPEndPoint(IPAddress.Parse(host), new Random((int)DateTime.UtcNow.Ticks).Next(7001, 8901));
                client = new TcpClient(clientIP);
                client.ConnectAsync(host, port).Wait();
                client.NoDelay = true;
                netStream = client.GetStream();


                // 서버에 접속
                string msg = string.Join(",", new object[] { 0, 100, false });
                StreamWriter writer = new StreamWriter(netStream);
                writer.Write(msg);
                writer.Flush();

                // 0.5초마다 생산되는 부분이 있으면 읽음
                timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Interval = 500;
                timer.Elapsed += Timer_Elapsed;

                timer.Enabled = true;
                timer.Start();
            }

            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        // 매초 발생하는 타이머 이벤트
        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (timer.Enabled)
                {
                    await Read();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
                // 타이머 종료
                timer.Stop();
                timer.Enabled = false;
                timer.Dispose();
            }
        }



        // 서버로부터 메세지를 수신받는 코드
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

                if (nbytes < 1)
                    return;

                string[] msg = Encoding.UTF8.GetString(buff, 0, nbytes).Split(',');

                if (msg.Length > 0)
                {
                    msg.ToList().ForEach(m => Debug.WriteLine(m));


                    for (int i = 0; i < lineMonitors.Count; i++)
                    {
                        if (lineMonitors[i].Tag.ToString() == msg[0])
                        {

                            lineMonitors[i].Invoke(new LineDelegate(ReWrite), lineMonitors[i], msg);
                            Debug.WriteLine($" 서클 값 : {lineMonitors[i].CircleProgress.Value}");
                            break;
                        }
                    }

                    #region 주석
                    //foreach (LineMonitorControl lineMonitor in lineMonitors)
                    //{
                    //    Debug.WriteLine($"태그값 : {lineMonitor.Tag}");

                    //    if (lineMonitor.Tag.ToString() == msg[0])
                    //    {
                    //        lineMonitor.LabelRequestText = msg[1];
                    //        lineMonitor.LabelImportText = msg[2];
                    //        lineMonitor.LabelProduceText = (int.Parse(lineMonitor.LabelProduceText) + int.Parse(msg[3])).ToString();
                    //        lineMonitor.LabelDefectiveText = (int.Parse(lineMonitor.LabelDefectiveText) + int.Parse(msg[4])).ToString(); ;

                    //        if (Convert.ToInt32(lineMonitor.LabelDefectiveText) > 1)
                    //            lineMonitor.PictureStateImage = Properties.Resources.Img_CircleYellow;
                    //        else
                    //            lineMonitor.PictureStateImage = Properties.Resources.Img_CircleGreen;

                    //        lineMonitor.CircleProgress.Value = (int.Parse(lineMonitor.LabelProduceText) / int.Parse(lineMonitor.LabelRequestText)) * 100;


                    //        Debug.WriteLine($" 서클 값 : {lineMonitor.CircleProgress.Value}");

                    //        break;

                    //    }
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        //msg =  LineID, RequestQty, iTotalCnt, itemQuality, 1 - itemQuality
        private void ReWrite(LineMonitorControl lineMonitor, string[] msg)
        {
            // 불량이 한개도 없는 경우 연두색
            if (lineMonitor.LabelDefectiveText == "0")
            {
                lineMonitor.CircleProgress.ProgressColor3 = Color.AliceBlue;
                lineMonitor.CircleProgress.ProgressColor4 = Color.Green;                
            }
            // 불량이 한개라도 있는 경우 주황색
            else
            {
                lineMonitor.CircleProgress.ProgressColor3 = Color.Violet;
                lineMonitor.CircleProgress.ProgressColor4 = Color.Yellow;
            }

            lineMonitor.CircleProgress.Invoke((MethodInvoker)lineMonitor.CircleProgress.Invalidate);


            lineMonitor.LabelRequestText = msg[1];
            lineMonitor.LabelImportText = msg[2];
            lineMonitor.LabelProduceText = (int.Parse(lineMonitor.LabelProduceText) + int.Parse(msg[3])).ToString();
            lineMonitor.LabelDefectiveText = (int.Parse(lineMonitor.LabelDefectiveText) + int.Parse(msg[4])).ToString();
          

            //lineMonitor.CircleProgress.Increment((int)Math.Truncate((decimal)(int.Parse(lineMonitor.LabelProduceText) / int.Parse(lineMonitor.LabelRequestText)) * 100));
            lineMonitor.CircleProgress.Invoke(
            (MethodInvoker)delegate
            {
                lineMonitor.CircleProgress.Increment((int)Math.Truncate((int.Parse(lineMonitor.LabelProduceText) / decimal.Parse(lineMonitor.LabelRequestText)) * 100));
            }
            );

            if (lineMonitor.LabelProduceText.Equals(lineMonitor.LabelRequestText))
                ResetControl(lineMonitor);
        }



        /*--------------------------
         *  컨트롤 초기화해주는 코드
         --------------------------*/
        private void ResetControl(LineMonitorControl control)
        {
            try
            {
                control.LabelRequestText = "0";
                control.LabelImportText = "0";
                control.LabelProduceText = "0";
                control.LabelDefectiveText = "0";
                control.CircleProgress.ProgressColor3 = Color.Violet;
                control.CircleProgress.ProgressColor4 = Color.Red;
                control.CircleProgress.Invoke((MethodInvoker)delegate { control.CircleProgress.Decrement((int)control.CircleProgress.Value); });

            }
            catch (AggregateException ex)
            {
                WriteLog(ex);
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        /*------------------------
         *  로그 기록해주는 코드
         ------------------------*/
        private void WriteLog(Exception ex)
        {
            Program.Log.WriteError(ex.Message, ex);
        }
    }
}
