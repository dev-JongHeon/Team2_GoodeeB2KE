using DevExpress.XtraReports.UI;
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
    public partial class SalesMainForm : Base1Dgv
    {
        #region 전역변수
        OrderService service = new OrderService();
        List<Sales> Order_AllList = null;
        List<Sales> SearchedList = null;
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
            UtilClass.AddNewColum(dgv_SalesStatus, "고객이름", "Customer_Name", true);
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

            Search_OrderIndexPeriod.Startdate.BackColor = Color.LightYellow;
            Search_OrderIndexPeriod.Enddate.BackColor = Color.LightYellow;
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            dgv_SalesStatus.DataSource = null;
            Order_AllList = service.GetSalesStatus();

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Clear();
            Search_OrderIndexPeriod.Startdate.Clear();
            Search_OrderIndexPeriod.Enddate.Clear();
            Search_ShipmentPeriod.Startdate.Clear();
            Search_ShipmentPeriod.Enddate.Clear();
            lbl_Total.Text = "0원";
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_OrderIndexPeriod.Startdate.Text == "    -  -") { main.NoticeMessage = Properties.Settings.Default.PeriodError; }
            else
            {
                SearchedList = Order_AllList;
                if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                     where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                     select item).ToList();
                }

                if (Search_ShipmentPeriod.Startdate.Text != "    -  -")   // 출하처리일시 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                     where item.Shipment_DoneDate.Date.CompareTo(Convert.ToDateTime(Search_ShipmentPeriod.Startdate.Text)) >= 0 &&
                                            item.Shipment_DoneDate.Date.CompareTo(Convert.ToDateTime(Search_ShipmentPeriod.Enddate.Text)) <= 0
                                     select item).ToList();
                }

                if (Search_OrderIndexPeriod.Startdate.Text != "    -  -")   // 주문일시 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                     where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderIndexPeriod.Startdate.Text)) >= 0 &&
                                            item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderIndexPeriod.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                dgv_SalesStatus.DataSource = SearchedList;
                main.NoticeMessage = Properties.Settings.Default.SearchDone;
                int total = 0;  // 매출총액 담을 변수
                for (int i = 0; i < dgv_SalesStatus.RowCount; i++)  // 매출총액 계산
                {
                    total += Convert.ToInt32(dgv_SalesStatus.Rows[i].Cells[5].Value);
                }

                lbl_Total.Text = total.ToString("#,#0원");
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_SalesStatus.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.ExcelError;
            }
            else
            {
                using (WaitForm frm = new WaitForm())
                {
                    frm.Processing = ExcelExport;
                    frm.ShowDialog();
                }
            }
        }
        public void ExcelExport()
        {
            string[] exceptColumns = { "" };
            UtilClass.ExportToDataGridView(dgv_SalesStatus, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {
            if (dgv_SalesStatus.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.NonData;
            }
            else
            {
                using (WaitForm frm = new WaitForm())
                {
                    SalesReport br = new SalesReport();
                    dsSales ds = new dsSales();

                    ds.Relations.Clear();
                    ds.Tables.Clear();
                    ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
                    ds.Tables[0].TableName = "dtSales";

                    //ds.AcceptChanges();

                    br.DataSource = ds;
                    using (ReportPrintTool printTool = new ReportPrintTool(br))
                    {
                        printTool.ShowRibbonPreviewDialog();
                    }  
                }
            }
        }
        #endregion

        #region Activated, OnOff, DeActivate

        private void SalesMainForm_Activated(object sender, EventArgs e)
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

        private void SalesMainForm_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
