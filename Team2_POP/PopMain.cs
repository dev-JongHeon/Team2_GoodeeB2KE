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
        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            SettingControl();
            InitData();
        }

        private void SettingControl()
        {
            // =============================================
            //               스플릿 컨테이너 디자인
            // =============================================

            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed = true;

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

            UtilClass.AddNewColum(dgvWork, "작업지시번호", "Work_ID", true, 150);
            UtilClass.AddNewColum(dgvWork, "작업 시작날짜", "Work_StartDate", true, 150);
            UtilClass.AddNewColum(dgvWork, "작업 종료날짜", "Work_EndDate", true, 150);
            UtilClass.AddNewColum(dgvWork, "출하지시번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgvWork, "작업 현황", "Work_State", true);
            UtilClass.AddNewColum(dgvWork, "작업지시자 사번", "Employees_ID", false);
            UtilClass.AddNewColum(dgvWork, "작업지시자 이름", "Employees_Name", true, 120);
            UtilClass.AddNewColum(dgvWork, "출하 요청날짜", "Shipment_RequiredDate", true, 150);

            // 생산 그리드뷰
            UtilClass.SettingDgv(dgvProduce);

            UtilClass.AddNewColum(dgvProduce, "생산지시번호", "Produce_ID", true, 150);
            UtilClass.AddNewColum(dgvProduce, "상품코드", "Product_ID", true, 150);
            UtilClass.AddNewColum(dgvProduce, "상품명", "Product_Name", true, 150);
            UtilClass.AddNewColum(dgvProduce, "생산요청수량", "Produce_QtyRequested", true);
            UtilClass.AddNewColum(dgvProduce, "불량품 수", "Performance_QtyDefectiveItem", true);
            UtilClass.AddNewColum(dgvProduce, "생산 상태", "Produce_State", true);
            
            
            // 실적 그리드뷰
            UtilClass.SettingDgv(dgvPerformance);

            UtilClass.AddNewColum(dgvPerformance, "생산실적번호", "Performance_ID", true, 150);
            UtilClass.AddNewColum(dgvPerformance, "생산지시번호", "Produce_ID", false, 150);
            UtilClass.AddNewColum(dgvPerformance, "양품수", "Performance_QtySuccessItem", true, 150);
            UtilClass.AddNewColum(dgvPerformance, "불량수", "Performance_QtyDefectiveItem", true);
            UtilClass.AddNewColum(dgvPerformance, "시작 날짜", "Performance_StartDate", true);
            UtilClass.AddNewColum(dgvPerformance, "종료 날짜", "Performance_EndDate", true);
            UtilClass.AddNewColum(dgvPerformance, "사원번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvPerformance, "사원이름", "Employees_Name", true);
            UtilClass.AddNewColum(dgvPerformance, "불량률", "Performance_DefectiveRate", true);
            UtilClass.AddNewColum(dgvPerformance, "가동시간", "Performance_ElapsedTime", true);

        }

        private void InitData()
        {
            // =============================================
            //                콤보박스 바인딩 
            // =============================================
            try
            {
                UtilClass.ComboBinding(cboFactory, new Service().GetFactoryList(), "공장 선택");
            }
            catch
            {

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
            WorkRegister work = new WorkRegister();
            work.ShowDialog();
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

            if (cboLine.SelectedValue != null && char.IsDigit(Convert.ToChar(cboLine.SelectedValue)))
            {                
                List<Work> list = new Service().GetWorks("2020-01-26", Convert.ToInt32(cboLine.SelectedValue));

                if (list.Count > 0)
                {
                    dgvWork.DataSource = null;
                    dgvWork.DataSource = list;
                }
                else
                {
                    MessageBox.Show($"작업날짜 : {"2020-01-26"} \n공정 : {cboLine.Text} \n 위의 작업내역이 존재하지 않습니다.");
                }

            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 해당 날짜의 작업을 가져옴
        }

        private void btnPreDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 어제 날짜의 작업을 가져옴
            // 라벨 날짜를 어제 날짜로 변경
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 내일 날짜의 작업을 가져옴
            // 라벨 날짜를 내일 날짜로 변경
        }

        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboFactory.SelectedIndex != 0 && cboFactory.SelectedValue != null)
                    UtilClass.ComboBinding(cboLine, new Service().GetLineList(Convert.ToInt32(cboFactory.SelectedValue)), "공정 선택");


            }
            catch (Exception err)
            {
                string ss = err.Message;
            }
        }

        private void dgvWork_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    dgvProduce.DataSource = null;
                    dgvProduce.DataSource = new Service().GetProduce(dgvWork.SelectedRows[e.RowIndex].Cells[0].Value.ToString());
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
                    dgvPerformance.DataSource = new Service().GetPerformance(dgvProduce.SelectedRows[e.RowIndex].Cells[0].Value.ToString());
                    dgvPerformance.ClearSelection();
                }
            }
            catch
            {

            }
        }
    }
}
