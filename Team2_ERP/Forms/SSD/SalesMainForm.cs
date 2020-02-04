using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class SalesMainForm : Base1Dgv
    {
        #region 전역변수
        OrderService service = new OrderService();
        List<Sales> Order_AllList = null;
        MainForm main; 
        #endregion
        public SalesMainForm()
        {
            InitializeComponent();
        }

        private void SalesMainForm_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_SalesStatus);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "고객ID", "Customer_userID", true, 90);
            UtilClass.AddNewColum(dgv_SalesStatus, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문일시", "Order_Date", true, 170);
            UtilClass.AddNewColum(dgv_SalesStatus, "출하처리일시", "Shipment_DoneDate", true, 170);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문총액", "TotalPrice", true, 200);
            dgv_SalesStatus.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SalesStatus.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_SalesStatus.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_SalesStatus.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_SalesStatus.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesStatus.Columns[5].DefaultCellStyle.Format = "#,#0원";
            Order_AllList = service.GetSalesStatus();
            //dgv_SalesStatus.DataSource = Order_AllList;

            int total = 0;  // 매출총액 담을 변수
            for (int i = 0; i < dgv_SalesStatus.RowCount; i++)  // 매출총액 계산
            {
                total += Convert.ToInt32(dgv_SalesStatus.Rows[i].Cells[5].Value);
            }

            label3.Text = total.ToString("#,#0원");
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            LoadData();
            main.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            Order_AllList = service.GetSalesStatus();  // 주문리스트 갱신
            if (Search_Customer.CodeTextBox.Text.Length > 0)  
            {
                Order_AllList = (from item in Order_AllList
                                 where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                 select item).ToList();
            }// 고객명 검색조건 있으면

            if (Search_ShipmentPeriod.Startdate.Text != "    -  -")   
            {
                if (Search_ShipmentPeriod.Startdate.Text != Search_ShipmentPeriod.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Shipment_DoneDate.Date.CompareTo(Convert.ToDateTime(Search_ShipmentPeriod.Startdate.Text)) >= 0 &&
                                            item.Shipment_DoneDate.Date.CompareTo(Convert.ToDateTime(Search_ShipmentPeriod.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                else   // 같은경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Shipment_DoneDate.Date == Convert.ToDateTime(Search_ShipmentPeriod.Startdate.Text)
                                     select item).ToList();
                }
            }// 출하처리일시 검색조건 존재한다면

            if (Search_OrderIndexPeriod.Startdate.Text != "    -  -")   
            {
                if (Search_OrderIndexPeriod.Startdate.Text != Search_OrderIndexPeriod.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderIndexPeriod.Startdate.Text)) >= 0 &&
                                            item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderIndexPeriod.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                else   // 같은경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Order_Date.Date == Convert.ToDateTime(Search_OrderIndexPeriod.Startdate.Text)
                                     select item).ToList();
                }
            }// 주문일시 검색조건 존재한다면
            dgv_SalesStatus.DataSource = Order_AllList;
            main.NoticeMessage = Properties.Settings.Default.SearchDone;
        }

        public override void Excel(object sender, EventArgs e)
        {
            using (WaitForm frm = new WaitForm())
            {
                frm.Processing = ExcelExport;
                frm.ShowDialog();
            }
        }
        public void ExcelExport()
        {

        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate

        private void OrderMainForm_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.NoticeMessage = notice;
        }
        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = false;
            main.삭제ToolStripMenuItem.Visible = false;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void OrderMainForm_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
