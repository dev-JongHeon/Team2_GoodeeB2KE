using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class BaljuList_Completed : Base2Dgv
    {
        #region 전역변수
        BaljuService service = new BaljuService();
        List<BaljuDetail> BaljuDetail_AllList = null;  // 발주디테일 List
        List<Balju> BaljuCompleted_AllList = null;  // 발주 List
        MainForm main; 
        #endregion

        public BaljuList_Completed()
        {
            InitializeComponent();
            
        }

        private void BaljuList_Completed_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_BaljuCompleted);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주지시번호", "Balju_ID", true, 130);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처코드", "Company_ID", true, 110);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처명칭", "Company_Name", true, 500);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주요청일시", "Balju_Date", true, 140);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "수령일시", "Balju_ReceiptDate", true, 120);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "삭제여부", "Balju_DeletedYN", false);
            dgv_BaljuCompleted.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_BaljuCompleted.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            BaljuCompleted_AllList = service.GetBalju_CompletedList(); // 발주리스트 갱신
            dgv_BaljuCompleted.DataSource = BaljuCompleted_AllList;

            UtilClass.SettingDgv(dgv_BaljuDetail);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", true, 130);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true, 500);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true, 130);
            BaljuDetail_AllList = service.GetBalju_DetailList(); // 발주디테일 AllList 갱신

            main.NoticeMessage = "발주완료현황 화면입니다.";
        }

        private void dgv_BaljuCompleted_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Master 더블클릭 이벤트
        {
            string Balju_ID = dgv_BaljuCompleted.CurrentRow.Cells[0].Value.ToString();
            List<BaljuDetail> BaljuDetail_List = (from list_detail in BaljuDetail_AllList
                                                  where list_detail.Balju_ID == Balju_ID
                                                  select list_detail).ToList();
            dgv_BaljuDetail.DataSource = BaljuDetail_List;
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            BaljuCompleted_AllList = service.GetBalju_CompletedList();
            dgv_BaljuCompleted.DataSource = BaljuCompleted_AllList;
            BaljuDetail_AllList = service.GetBalju_DetailList();

            // 검색조건 초기화
            chk_ReceiptDate.Checked = false;
            Search_Period.Startdate.Text = "";
            Search_Period.Enddate.Text = "";
            Search_Company.CodeTextBox.Text = "";
            Search_Employee.CodeTextBox.Text = "";
        }

        private void chk_ReceiptDate_CheckedChanged(object sender, EventArgs e)  // 수령일 체크박스 상태 바뀔 때 이벤트
        {
            if (chk_ReceiptDate.Checked) dtp_ReceiptDate.Enabled = true;
            else dtp_ReceiptDate.Enabled = false;
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = "새로고침(갱신) 되었습니다.";
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            BaljuCompleted_AllList = service.GetBalju_CompletedList();  // 발주리스트 갱신
            if (Search_Company.CodeTextBox.Text.Length > 0)   // 회사 검색조건 있으면
            {
                BaljuCompleted_AllList = (from item in BaljuCompleted_AllList
                                          where item.Company_Name == Search_Company.CodeTextBox.Text
                                          select item).ToList();
            }
            if (Search_Employee.CodeTextBox.Text.Length > 0)   // 사원 검색조건 있으면
            {
                BaljuCompleted_AllList = (from item in BaljuCompleted_AllList
                                          where item.Employees_Name == Search_Employee.CodeTextBox.Text
                                          select item).ToList();
            }
            if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
            {
                if (Search_Period.Startdate.Text != Search_Period.Enddate.Text)
                {
                    BaljuCompleted_AllList = (from item in BaljuCompleted_AllList
                                              where item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&                  item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                              select item).ToList();
                }
                else
                {
                    BaljuCompleted_AllList = (from item in BaljuCompleted_AllList
                                              where item.Balju_Date.Date == Convert.ToDateTime(Search_Period.Startdate.Text)
                                              select item).ToList();
                }
            }
            if (chk_ReceiptDate.Checked)
            {
                BaljuCompleted_AllList = (from item in BaljuCompleted_AllList
                                          where item.Balju_ReceiptDate.Date == dtp_ReceiptDate.Value.Date
                                          select item).ToList();
            }

            dgv_BaljuCompleted.DataSource = BaljuCompleted_AllList;
            dgv_BaljuDetail.DataSource = null;
            main.NoticeMessage = "검색 되었습니다.";
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void BaljuList_Completed_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
        }

        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = false;
            main.삭제ToolStripMenuItem.Visible = false;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void BaljuList_Completed_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        } 
        #endregion
    }
}
