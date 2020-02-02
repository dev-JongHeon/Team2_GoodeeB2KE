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

namespace Team2_POP
{
    public partial class PopMain : Form
    {
        // 프로퍼티
        public WorkerInfoPOP WorkerInfo { get; set; }
        string workID = string.Empty;

        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            SettingControl();
            InitData();
            GetTime();
        }


        #region 디자인

        private void SettingControl()
        {
            BtnDisable(btnDefective);
            BtnDisable(btnWorker);
            BtnDisable(btnProduceStart);

            ImageList imageList = new ImageList();

            imageList.Images.Add("close", Properties.Resources.exit);
            imageList.Images.Add("logout", Properties.Resources.logout);

            imageList.ImageSize = btnExit.Size;

            PictureBox picture1 = new PictureBox();
            PictureBox picture2 = new PictureBox();
            picture1.SizeMode = PictureBoxSizeMode.StretchImage;
            picture2.SizeMode = PictureBoxSizeMode.StretchImage;

            picture1.Image = Properties.Resources.LeftArrow;
            picture2.Image = Properties.Resources.RightArrow;

            btnPreDate.Image = picture1.Image;
            btnNextDate.Image = picture2.Image;




            btnExit.Image = imageList.Images["close"];
            btnLogout.Image = imageList.Images["logout"];

            


            // =============================================
            //               스플릿 컨테이너 디자인
            // =============================================

            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed =
                splitContainer6.IsSplitterFixed = splitContainer7.IsSplitterFixed = splitContainer8.IsSplitterFixed
                = splitContainer9.IsSplitterFixed = splitContainer10.IsSplitterFixed = true;


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
            UtilClass.AddNewColum(dgvWork, "출하 요청일", "Shipment_RequiredDate", true, 130);

            // 생산 그리드뷰
            UtilClass.SettingDgv(dgvProduce);

            UtilClass.AddNewColum(dgvProduce, "생산지시번호", "Produce_ID", true, 160);
            UtilClass.AddNewColum(dgvProduce, "상품코드", "Product_ID", true, 100);
            UtilClass.AddNewColum(dgvProduce, "생산시작날짜", "Produce_StartDate", true, 135);
            UtilClass.AddNewColum(dgvProduce, "생산완료날짜", "Produce_DoneDate", true, 135);
            UtilClass.AddNewColum(dgvProduce, "상품명", "Product_Name", true, 200);
            UtilClass.AddNewColum(dgvProduce, "요청", "Produce_QtyRequested", true, 70, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduce, "진행", "Produce_QtyReleased", true, 70, DataGridViewContentAlignment.MiddleRight);
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

            dgvWork.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvWork.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvProduce.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvProduce.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd";

            dgvPerformance.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgvPerformance.Columns[5].DefaultCellStyle.Format = "HH:mm:ss";
            dgvPerformance.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";

            dgvPerformance.Columns[9].DefaultCellStyle.Format = "0.0#\\%";
        }

        #endregion

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

            IsDowntime(false);
        }

        private void IsDowntime(bool type)
        {
            bool bResult = new Service().IsDowntime(WorkerInfo.LineID);
            pictureBox1.Tag = bResult;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (type)
            {
                if (bResult)
                {
                    pictureBox1.Image = Properties.Resources.iconfinder_Circle_Green_34211;
                    btnDownTime.Text = "비가동 전환";
                    CustomMessageBox.ShowDialog($"{btnDownTime.Text} 완료", $"{lblLine.Text}가 {btnDownTime.Text.Split(' ')[0]}상태로 전환됬습니다.",
                        MessageBoxIcon.Information);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.iconfinder_Circle_Red_34214;
                    btnDownTime.Text = "가동 전환";
                    CustomMessageBox.ShowDialog($"{btnDownTime.Text} 완료", $"{lblLine.Text}가 {btnDownTime.Text.Split(' ')[0]}상태로 전환됬습니다.",
                        MessageBoxIcon.Information);
                }
            }
        }



        // 작업을 가져오는 메서드
        private void GetWork(string data)
        {
            List<Work> list = new Service().GetWorks(data, Convert.ToInt32(lblLine.Tag));

            dgvWork.DataSource = null;
            dgvProduce.DataSource = null;
            dgvPerformance.DataSource = null;

            if (list.Count > 0)
                dgvWork.DataSource = list;
            else
                CustomMessageBox.ShowDialog("작업내역 없음", $"작업날짜 : {data} \n공정 : {lblLine.Text} \n위의 작업내역이 존재하지 않습니다.", MessageBoxIcon.Information);              

        }

        #region 상단 버튼 - 날짜 클릭, 비가동

        // 날짜를 클릭한 경우
        private void lblDate_Click(object sender, EventArgs e)
        {
            using (MonthCalandarForm calandarForm = new MonthCalandarForm())
            {
                calandarForm.DSelected = DateTime.Parse(lblDate.Text);
                if (DialogResult.OK == calandarForm.ShowDialog())
                    lblDate.Text = calandarForm.DSelected.ToShortDateString();
            }
        }

        // 비가동 전환버튼을 누른경우
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
                new Service().SetDowntime(WorkerInfo.LineID, "none", WorkerInfo.WorkID);
                IsDowntime(true);
            }

        }

        #endregion

        #region 하단 버튼 - 생산시작, 작업자설정, 불량유형

        //생산시작
        private void btnProduceStart_Click(object sender, EventArgs e)
        {            
            try
            {
                string[] result = null;


                if (dgvProduce.SelectedRows.Count < 1)
                {
                    return;
                }
                else
                {                   
                    string produceID = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();
                    result = new Service().StartProduce(produceID);
                    

                    ProduceMachine machine = new ProduceMachine
                    {
                        PerformanceID = result[0],
                        ProduceID = produceID,
                        LineID = Convert.ToInt32(lblLine.Tag),
                        RequestQty = Convert.ToInt32(result[1])
                    };

                    if(machine.Start())
                    {
                        dgvProduce.DataSource = dgvPerformance.DataSource = null;
                        dgvProduce.DataSource = new Service().GetProduce(workID);
                        dgvPerformance.DataSource = new Service().GetPerformance(produceID);
                    }

                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
            }
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
                if (dgvPerformance.SelectedRows[0].Cells[0].Value != null)
                {
                    DefectiveRegister defective = new DefectiveRegister();
                    defective.Performance_ID = dgvPerformance.SelectedRows[0].Cells[0].Value.ToString();

                    if (defective.ShowDialog() == DialogResult.OK)
                        CustomMessageBox.ShowDialog("불량등록 성공", "불량등록을 성공했습니다.", MessageBoxIcon.Question);
                }
            }
            catch(Exception ex) 
            {
                CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
            }
        }

        #endregion


        // 공정조회 버튼을 누른 경우
        private void btnLineSearch_Click(object sender, EventArgs e)
        {
            // DAC단에서 오늘날짜의 작업을 가져옴
            //dgvWork.DataSource = new Service().GetWorks(lblDate.Text);
            GetWork(lblDate.Text);
        }
        #region 날짜 관련 버튼 ( 날짜조회버튼 , 이전버튼 , 다음버튼)

        //날짜조회 버튼을 누른 경우
        private void btnDate_Click(object sender, EventArgs e)
        {
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

                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    workID = dgvWork.SelectedRows[0].Cells[0].Value.ToString();
                    dgvProduce.DataSource = new Service().GetProduce(workID);
                    dgvProduce.ClearSelection();
                }
            }
            catch(Exception ex)
            {
                CustomMessageBox.ShowDialog("에러", ex.Message, MessageBoxIcon.Error);
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
                    if (dgvProduce.SelectedRows[0].Cells[8].Value.ToString() == "생산완료")
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
            catch(Exception ex)
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
            btn.BackColor = Color.SteelBlue;
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
            System.Timers.Timer timer = new System.Timers.Timer(1000);
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
            catch { }
        }

        #endregion

        //===================
        //    테스트 구역
        //===================
       
    }
}
