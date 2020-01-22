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

namespace Team2_POP
{
    public partial class PopMain : Form
    {
        List<ComboItemVO> listFactory = null;
        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            SettingControl();
            InitData();
        }

        private void SettingControl()
        {
            // =============================================
            //               스플릿 컨테이너 디자인
            // =============================================

            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed =
                splitContainer6.IsSplitterFixed = true;

            // =============================================
            //                라벨 초기값 
            // =============================================
            lblDate.Text = DateTime.Now.ToShortDateString();


            // =============================================
            //                콤보박스 디자인
            // =============================================
            cboFactory.DropDownStyle = cboLine.DropDownStyle = ComboBoxStyle.DropDownList;


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
            UtilClass.AddNewColum(dgvProduce, "생산요청수량", "Produce_QtyRequested", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvProduce, "불량수", "Performance_QtyDefectiveItem", true, 80, DataGridViewContentAlignment.MiddleRight);
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

            dgvPerformance.Columns[5].DefaultCellStyle.Format = "HH:mm:ss";
            dgvPerformance.Columns[6].DefaultCellStyle.Format = "HH:mm:ss";
            dgvPerformance.Columns[9].DefaultCellStyle.Format = "##0.0#%";
        }

        private void InitData()
        {
            // =============================================
            //                콤보박스 바인딩 
            // =============================================
            try
            {
                listFactory = new Service().GetFactoryList();
                UtilClass.ComboBinding(cboFactory, listFactory , "공장 선택");
            }
            catch
            {

            }
        }

        private void GetWork(string data)
        {
            if (cboLine.SelectedValue != null && char.IsDigit(Convert.ToChar(cboLine.SelectedValue)))
            {
                List<Work> list = new Service().GetWorks(data, Convert.ToInt32(cboLine.SelectedValue));

                if (list.Count > 0)
                {
                    dgvWork.DataSource = null;
                    dgvWork.DataSource = list;
                }
                else
                {
                    MessageBox.Show($"작업날짜 : {data} \n공정 : {cboLine.Text} \n 위의 작업내역이 존재하지 않습니다.");
                }

            }
        }

        // 비가동 전환버튼을 누른경우
        private void btnDownTime_Click(object sender, EventArgs e)
        {
            DowntimeRegister downtime = new DowntimeRegister();
            downtime.ShowDialog();
        }

        // 작업자 설정버튼을 누른 경우
        private void btnWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboFactory.Tag == null || dgvProduce.SelectedRows[0].Cells[0].Value == null)
                    return;
            }
            catch
            {
                return;
            }

            using (WorkRegister work = new WorkRegister())
            {
                work.ProduceID = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();
                work.FactoryDivision = Convert.ToInt32(cboFactory.Tag);
                if (work.ShowDialog() == DialogResult.OK)
                {
                    // 생산실적 추가 프로시저 
                    new Service().SetWorker(work.ProduceID, work.EmployeeID);
                    new Service().GetPerformance(work.ProduceID);
                }
            }
                
        }

        // 불량유형 버튼을 누른 경우
        private void btnDefective_Click(object sender, EventArgs e)
        {
            DefectiveRegister defective = new DefectiveRegister();
            defective.ShowDialog();
        }

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


        // 공정 콤보박스가 변경될때
        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                object value = cboFactory.SelectedValue;
                if (cboFactory.SelectedIndex != 0 && value != null)
                {
                    UtilClass.ComboBinding(cboLine, new Service().GetLineList(Convert.ToInt32(value)), "공정 선택");
                    cboFactory.Tag = (listFactory.Find(f => f.ID == value.ToString())).CodeType;
                }


            }
            catch (Exception err)
            {
                string ss = err.Message;
            }
        }

        #region 그리드뷰 클릭 이벤트

        private void dgvWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    dgvProduce.DataSource = null;
                    dgvProduce.DataSource = new Service().GetProduce(dgvWork.SelectedRows[0].Cells[0].Value.ToString());
                    dgvProduce.ClearSelection();
                }
            }
            catch
            {

            }
        }

        private void dgvProduce_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    dgvPerformance.DataSource = null;
                    dgvPerformance.DataSource = new Service().GetPerformance(dgvProduce.SelectedRows[0].Cells[0].Value.ToString());
                    dgvPerformance.ClearSelection();
                }
            }
            catch
            {

            }
        }

        private void dgvPerformance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgvPerformance.SelectedRows[0].Cells[8].Value != null)
                    lblWorker.Text = "작업자명 : " + dgvPerformance.SelectedRows[0].Cells[8].Value.ToString();
            }
        }

        #endregion
    }
}
