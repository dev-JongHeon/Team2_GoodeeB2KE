using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;
using System.Threading;
using System.Timers;
using Team2_POP.Properties;

namespace Team2_POP
{
    public partial class PopMain : Form
    {

        #region 프로퍼티 & 전역변수
        //===============
        //    프로퍼티
        //===============
        public WorkerInfoPOP WorkerInfo { get; set; }

        //===============
        //    전역변수
        //===============
        string workID = string.Empty;
        System.Timers.Timer timer;
        POPClient client;

        #endregion

        #region 생성자 & 로드 이벤트
        // 생성자
        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            ConnectServer();
            SettingControl();
            InitData();
            GetTime();
        }

        #endregion

        #region 디자인

        private void SettingControl()
        {
            //폼이 뜰때
            this.WindowState = FormWindowState.Maximized;

            //버튼 활성화 관련
            BtnDisable(btnDefective);
            BtnDisable(btnWorker);
            BtnDisable(btnProduceStart);

            #region 이미지관련
            ImageList imageList = new ImageList();

            imageList.Images.Add("close", Properties.Resources.Img_Exit);
            imageList.Images.Add("logout", Properties.Resources.Img_Logout);

            imageList.ImageSize = btnExit.Size;

            PictureBox picture1 = new PictureBox();
            PictureBox picture2 = new PictureBox();
            picture1.SizeMode = PictureBoxSizeMode.StretchImage;
            picture2.SizeMode = PictureBoxSizeMode.StretchImage;

            picture1.Image = Properties.Resources.Img_LeftArrow;
            picture2.Image = Properties.Resources.RightArrow;

            btnPreDate.Image = picture1.Image;
            btnNextDate.Image = picture2.Image;

            btnExit.Image = imageList.Images["close"];
            btnLogout.Image = imageList.Images["logout"];

            #endregion



            // =============================================
            //               스플릿 컨테이너 디자인
            // =============================================

            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed =
                splitContainer6.IsSplitterFixed = splitContainer7.IsSplitterFixed = splitContainer8.IsSplitterFixed
                = splitContainer9.IsSplitterFixed = splitContainer10.IsSplitterFixed =
                splitContainer11.IsSplitterFixed = true;

            #region 그리드뷰 디자인
            // =============================================
            //                그리드뷰 디자인 
            // =============================================


            // 작업 그리드뷰
            UtilClass.SettingDgv(dgvWork);

            UtilClass.AddNewColum(dgvWork, "작업지시번호", "Work_ID", true, 160);
            UtilClass.AddNewColum(dgvWork, "작업 시작날짜", "Work_StartDate", true, 150);
            UtilClass.AddNewColum(dgvWork, "작업 종료날짜", "Work_EndDate", true, 150);
            UtilClass.AddNewColum(dgvWork, "출하지시번호", "Shipment_ID", true, 170);
            UtilClass.AddNewColum(dgvWork, "작업 현황", "Work_State", true);
            UtilClass.AddNewColum(dgvWork, "작업지시자 사번", "Employees_ID", false);
            UtilClass.AddNewColum(dgvWork, "작업지시자 이름", "Employees_Name", true, 120);
            UtilClass.AddNewColum(dgvWork, "출하 요청일", "Shipment_RequiredDate", true, 150);

            // 생산 그리드뷰
            UtilClass.SettingDgv(dgvProduce);

            UtilClass.AddNewColum(dgvProduce, "생산지시번호", "Produce_ID", true, 160);
            UtilClass.AddNewColum(dgvProduce, "상품코드", "Product_ID", true, 100);
            UtilClass.AddNewColum(dgvProduce, "생산시작날짜", "Produce_StartDate", true, 135);
            UtilClass.AddNewColum(dgvProduce, "생산완료날짜", "Produce_DoneDate", true, 135);
            UtilClass.AddNewColum(dgvProduce, "상품명", "Product_Name", true, 200);
            UtilClass.AddNewColum(dgvProduce, "요청", "Produce_QtyRequested", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduce, "투입", "Produce_QtyReleased", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduce, "불량", "Performance_QtyDefectiveItem", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduce, "생산 상태", "Produce_State", true);


            // 실적 그리드뷰
            UtilClass.SettingDgv(dgvPerformance);

            UtilClass.AddNewColum(dgvPerformance, "생산실적번호", "Performance_ID", true, 160);
            UtilClass.AddNewColum(dgvPerformance, "실적날짜", "Performance_Date", true, 130);
            UtilClass.AddNewColum(dgvPerformance, "생산지시번호", "Produce_ID", false, 150);
            UtilClass.AddNewColum(dgvPerformance, "양품", "Performance_QtySuccessItem", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvPerformance, "불량", "Performance_QtyDefectiveItem", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvPerformance, "생산 시작", "Performance_StartDate", true, 110);
            UtilClass.AddNewColum(dgvPerformance, "생산 종료", "Performance_EndDate", true, 110);
            UtilClass.AddNewColum(dgvPerformance, "사원번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvPerformance, "작업자 명", "Employees_Name", false);
            UtilClass.AddNewColum(dgvPerformance, "불량률", "Performance_DefectiveRate", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvPerformance, "가동시간", "Performance_ElapsedTime", true, 100, DataGridViewContentAlignment.MiddleRight);


            //그리드뷰 포멧 관련
            dgvWork.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvWork.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvWork.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvProduce.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvProduce.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvPerformance.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvPerformance.Columns[5].DefaultCellStyle.Format = "HH:mm:ss";
            dgvPerformance.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";

            dgvPerformance.Columns[9].DefaultCellStyle.Format = "0.0#\\%";

            #endregion 그리드뷰 디자인
        }

        #endregion


        #region 기본 데이터 설정
        // 기본 데이터 불러오기
        private void InitData()
        {
            // =============================================
            //                라벨 초기값 
            // =============================================
            lblDate.Text = DateTime.Now.ToShortDateString();

            lblFactory.Text = WorkerInfo.FactoryName;
            lblFactory.Tag = WorkerInfo.FactoryID;

            lblLine.Text = WorkerInfo.LineName;
            lblLine.Tag = WorkerInfo.LineID;

            lblWorkerName.Text = WorkerInfo.Worker;
            lblWorkerName.Tag = WorkerInfo.WorkID;

            // 비가동 상태 가져오기
            IsDowntime(false);
        }

        #endregion



        /// <summary>
        /// 비가동인지 아닌지 여부
        /// </summary>
        /// <param name="isNotFirst">(true : 가동상태 false: 비가동상태)</param>
        private void IsDowntime(bool isNotFirst)
        {
            bool bResult = new Service().IsDowntime(WorkerInfo.LineID);
            pictureBox1.Tag = bResult;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            // 가동일때
            if (bResult)
            {
                pictureBox1.Image = Resources.Img_CircleGreen;
                btnDownTime.Text = "비가동 전환";
            }
            // 비가동일때
            else
            {
                pictureBox1.Image = Resources.Img_CircleRed;
                btnDownTime.Text = "가동 전환";
            }

            // true : 처음이 아닐때만 
            // false: 처음일때 
            if (isNotFirst)
            {
                CustomMessageBox.ShowDialog($"{btnDownTime.Text} 완료", $"{lblLine.Text}가 {btnDownTime.Text.Split(' ')[0]}상태로 전환됬습니다.",
                        MessageBoxIcon.Information);
            }
        }



        /// <summary>
        /// 작업을 가져오는 메서드
        /// </summary>
        /// <param name="date">날짜</param>
        private void GetWork(string date)
        {
            List<Work> list = new Service().GetWorks(date, Convert.ToInt32(lblLine.Tag));

            dgvWork.DataSource = null;
            dgvProduce.DataSource = null;
            dgvPerformance.DataSource = null;

            if (list.Count > 0)
                dgvWork.DataSource = list;
            else
                CustomMessageBox.ShowDialog(Resources.MsgWorkResultNulllHeader
                    ,string.Format(Resources.MsgWorkResultNullContent, date, lblLine.Text), MessageBoxIcon.Information);

        }

        #region 상단 버튼 - 날짜 클릭, 비가동

        /// <summary>
        /// 날짜를 클릭한 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDate_Click(object sender, EventArgs e)
        {
            // 달력 화면을 보여줌
            using (MonthCalandarForm calandarForm = new MonthCalandarForm())
            {
                calandarForm.DSelected = DateTime.Parse(lblDate.Text);
                if (DialogResult.OK == calandarForm.ShowDialog())
                    lblDate.Text = calandarForm.DSelected.ToShortDateString();
            }
        }


        /// <summary>
        /// 비가동 전환 버튼을 선택한 경우
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownTime_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(pictureBox1.Tag) == true)
            {
                DowntimeRegister downtime = new DowntimeRegister();

                downtime.LineName = WorkerInfo.LineName;
                downtime.LineID = WorkerInfo.LineID;
                downtime.EmployeeID = WorkerInfo.WorkID;

                if (downtime.ShowDialog() == DialogResult.OK)
                {
                    IsDowntime(true);
                }
            }
            else
            {
                bool bResult = new Service().SetDowntime(WorkerInfo.LineID, "none", WorkerInfo.WorkID);
                if (bResult)
                    IsDowntime(true);
                else
                    CustomMessageBox.ShowDialog(Resources.MsgDowntimeSetResultFailHeader
                        , Resources.MsgDowntimeSetResultFailContent, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region 하단 버튼 - 생산시작, 작업자설정, 불량유형

        //생산시작
        private void btnProduceStart_Click(object sender, EventArgs e)
        {
            ProduceStart();
        }
        private void ConnectServer()
        {
            client = new POPClient()
            {
                LineID = WorkerInfo.LineID
            };

            client.Received -= Receive;
            client.Received += new EventHandler(Receive);
        }
        private async void ProduceStart()
        {
            string[] result = null;

            // 생산실적의 선택된 데이터가 없는 경우
            if (dgvProduce.SelectedRows.Count < 1)
            {
                CustomMessageBox.ShowDialog("데이터 오류", "생산목록을 선택해주세요.", MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                string produceID = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();

                // 생산해야할 개수와 생산실적아이디를 가져옴
                result = new Service().StartProduce(produceID); 

                if (result.Length == 2)
                {
                    client.PerformanceID = result[0];
                    client.RequestQty = Convert.ToInt32(result[1]);
                    client.ProduceID = produceID;

                    bool bConnect = await client.Connect();

                    //서버와 연결되어있지 않은경우
                    if (!client.Connected)
                    {
                        CustomMessageBox.ShowDialog("기계통신오류", "기계와의 작동이 원할하지 않습니다. \n기계서버의 상태를 점검한후 다시 시도해주세요.", MessageBoxIcon.Error);
                        ConnectServer();
                    }
                    //서버와 연결된 경우
                    else
                        client.Start();
                }
                else
                {
                    CustomMessageBox.ShowDialog("데이터 통신 오류", "처리하는 과정에서 오류가 발생하였습니다. \n다시 시도해주세요.", MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowDialog("오류", ex.Message, MessageBoxIcon.Error);
            }

        }
        public void Receive(object sender, EventArgs e)
        {
            ReceiveEventArgs re = (ReceiveEventArgs)e;
            if (re.IsCompleted)
                CustomMessageBox.ShowDialog("성공", re.Message, MessageBoxIcon.Information);
            else
                CustomMessageBox.ShowDialog("실패", re.Message, MessageBoxIcon.Error);
        }



        // 작업자 설정버튼을 누른 경우
        private void btnWorker_Click(object sender, EventArgs e)
        {
            if (dgvProduce.SelectedRows.Count < 1)
                return;

            string produceID = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();

            bool bResult = new Service().SetWorker(produceID, Convert.ToInt32(lblWorkerName.Tag));
            dgvPerformance.DataSource = null;
            dgvPerformance.DataSource = new Service().GetPerformance(produceID);

            // 작업자 설정을 성공한 경우
            if (bResult)
                CustomMessageBox.ShowDialog("작업자 설정 성공", $"{produceID}의 \n작업자 : {lblWorkerName.Text}에게 할당했습니다.", MessageBoxIcon.Question);
            else
                CustomMessageBox.ShowDialog("작업자 설정 실패", $"{produceID}의 작업 할당을 실패했습니다.", MessageBoxIcon.Error);
        }


        // 불량유형 버튼을 누른 경우
        private void btnDefective_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPerformance.SelectedRows.Count < 1)
                {
                    CustomMessageBox.ShowDialog("불량 선택 실패", "실적 목록을 선택해주세요.", MessageBoxIcon.Warning);
                    return;
                }

                var performanceRow = dgvPerformance.SelectedRows[0];

                if (performanceRow.Cells[0].Value != null)
                {
                    DefectiveRegister defective = new DefectiveRegister();
                    defective.Performance_ID = performanceRow.Cells[0].Value.ToString();

                    defective.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowDialog(Resources.MsgDefectiveResultFailHeader, ex.Message, MessageBoxIcon.Error);
            }
        }

        #endregion


        // 공정조회 버튼을 누른 경우
        private void btnLineSearch_Click(object sender, EventArgs e)
        {
            // DAC단에서 오늘날짜의 작업을 가져옴
            GetWork(lblDate.Text);
        }

        #region 날짜 관련 버튼 ( 날짜조회버튼 , 이전버튼 , 다음버튼)

        //날짜조회 버튼을 누른 경우
        private void btnDate_Click(object sender, EventArgs e)
        {
            BtnDisable(btnDefective);
            BtnDisable(btnWorker);
            BtnDisable(btnProduceStart);
            GetWork(lblDate.Text);
        }

        private void btnPreDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 어제 날짜의 작업을 가져옴
            // 라벨 날짜를 어제 날짜로 변경
            lblDate.Text = DateTime.Parse(lblDate.Text).AddDays(-1).ToShortDateString();
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 내일 날짜의 작업을 가져옴
            // 라벨 날짜를 내일 날짜로 변경
            lblDate.Text = DateTime.Parse(lblDate.Text).AddDays(1).ToShortDateString();
        }

        #endregion

        #region 그리드뷰 클릭 이벤트
        //=====================
        //    작업 그리드뷰
        //=====================
        private void dgvWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvProduce.DataSource = null;
                dgvPerformance.DataSource = null;

                if (e.RowIndex > -1 && e.ColumnIndex > -1 && dgvWork.SelectedRows[0].Cells[0].Value !=null)
                {
                    workID = dgvWork.SelectedRows[0].Cells[0].Value.ToString();

                    Service service = new Service();

                    List<Produce> list = service.GetProduce(workID);

                    // 불러온 값이 없는 경우
                    if (list == null)
                    {
                       DialogResult dResult = CustomMessageBox.ShowDialog(Resources.MsgLoadResultFailHeader
                           , "생산데이터를 불러오는 중에 실패했습니다. 다시 시도하시겠습니까?", MessageBoxIcon.Information, true);
                        if(dResult == DialogResult.OK)
                        {
                            list = service.GetProduce(workID);
                        }
                    }

                    dgvProduce.DataSource = new Service().GetProduce(workID);
                    dgvProduce.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowDialog("오류", ex.Message, MessageBoxIcon.Error);
            }
        }
        //=====================
        //    생산 그리드뷰
        //=====================
        private void dgvProduce_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvPerformance.DataSource = null;

                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (dgvProduce.SelectedRows[0].Cells[0].Value == null)
                        return;

                    string produceID = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();

                    Service service = new Service();

                    dgvPerformance.DataSource = service.GetPerformance(produceID);
                    dgvPerformance.ClearSelection();

                    object dgvDefective = dgvProduce.SelectedRows[0].Cells[7].Value;
                    if (dgvDefective == null || Convert.ToInt32(dgvDefective) == 0 || !service.GetDefectiveByProduce(produceID))
                    {
                        BtnDisable(btnDefective);
                    }
                    else
                    {
                        BtnEnable(btnDefective);
                    }


                    // 생산완료 or 생산중인경우 생산시작, 작업자 막는 코드
                    if (dgvProduce.SelectedRows[0].Cells[8].Value.ToString() == "생산완료" ||
                        Convert.ToInt32(dgvProduce.SelectedRows[0].Cells[5].Value) <= Convert.ToInt32(dgvProduce.SelectedRows[0].Cells[6].Value))
                    {
                        BtnDisable(btnProduceStart);
                        BtnDisable(btnWorker);
                    }
                    else
                    {
                        BtnEnable(btnProduceStart);
                        BtnEnable(btnWorker);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
            }
        }

        //=====================
        //    실적 그리드뷰
        //=====================
        private void dgvPerformance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgvPerformance.SelectedRows[0].Cells[8].Value != null)
                    lblWorker.Text = "작업자명 : " + dgvPerformance.SelectedRows[0].Cells[8].Value.ToString();
            }
        }

        private void BtnEnable(Button btn)
        {
            btn.Enabled = true;
            btn.BackColor = Color.FromArgb(8, 15, 23);
            btn.ForeColor = Color.White;
        }

        private void BtnDisable(Button btn)
        {
            btn.Enabled = false;
            btn.BackColor = Color.LightGray;
            btn.ForeColor = Color.DarkGray;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        #endregion

        #region 시간관련

        private void GetTime()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                this.Invoke(new Action(delegate ()
                { lblTime.Text = DateTime.Now.ToString(); }
                ));
            }
            catch (Exception ex)
            {
                // 시간관련하여 컨트롤에 에러가 발생한 경우 
                CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
                if (timer.Enabled)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            }
        }

        private void PopMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 타이머를 종료함
            timer.Stop();
            timer.Dispose();
        }


        #endregion

        //===================
        //    테스트 구역
        //===================
        private void WriteLog(Exception ex)
        {

        }

        private void btnWorkStart_Click(object sender, EventArgs e)
        {

        }

        
    }
}
