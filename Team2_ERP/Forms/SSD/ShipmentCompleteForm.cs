using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Properties;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class ShipmentCompleteForm : Base2Dgv
    {
        #region 전역변수
        ShipmentService service = new ShipmentService();
        List<Shipment> Shipment_AllList = null;  // Masters
        List<ShipmentDetail> ShipmentDetail_AllList = null;  // Details
        List<Shipment> SearchedList = null;  // 검색용
        MainForm main; 
        #endregion
        public ShipmentCompleteForm()
        {
            InitializeComponent();
        }

        private void ShipmentCompleteForm_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        #region dgv 관련기능
        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Shipment);
            UtilClass.AddNewColum(dgv_Shipment, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문일시", "Order_Date", true, 170);
            UtilClass.AddNewColum(dgv_Shipment, "주문처리일시", "OrderCompleted_Date", true, 170);
            UtilClass.AddNewColum(dgv_Shipment, "고객ID", "Customer_userID", true, 90);
            UtilClass.AddNewColum(dgv_Shipment, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하요청일시", "Shipment_RequiredDate", true, 170);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시자", "Employees_Name", true, 120);
            UtilClass.AddNewColum(dgv_Shipment, "출하완료일시", "Shipment_DoneDate", true, 170);
            dgv_Shipment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Shipment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Shipment.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgv_Shipment.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[8].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            try { Shipment_AllList = service.GetShipmentCompletedList(); }
            catch (Exception err) { Log.WriteError(err.Message, err); }

            UtilClass.SettingDgv(dgv_ShipmentDetail);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "출하번호", "Shipment_ID", false);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "주문수량", "OrderDetail_Qty", true);
            dgv_ShipmentDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_ShipmentDetail.Columns[3].DefaultCellStyle.Format = "#,#0개";

            Search_OrderCompletedPeriod.Startdate.BackColor = Color.LightYellow;
            Search_OrderCompletedPeriod.Enddate.BackColor = Color.LightYellow;
        }

        private void dgv_Shipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string shipment_id = dgv_Shipment.CurrentRow.Cells[0].Value.ToString();
                List<ShipmentDetail> ShipmentDetail_List = (from list_detail in ShipmentDetail_AllList
                                                            where list_detail.Shipment_ID == shipment_id
                                                            select list_detail).ToList();
                dgv_ShipmentDetail.DataSource = ShipmentDetail_List;
            }
        }

        private void GetShipmentDetail_List()  // 현재 위의 Dgv의 Row수 따라 그에맞는 DetailList 가져옴
        {
            if (dgv_Shipment.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgv_Shipment.Rows)
                {
                    sb.Append($"'{row.Cells[0].Value.ToString()}',");
                }

                try { ShipmentDetail_AllList = service.GetShipmentDetailList(sb.ToString().Trim(',')); }  // 디테일 AllList 갱신
                catch (Exception err) { Log.WriteError(err.Message, err); } 
            }
        } 
        #endregion

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Resources.RefreshDone;
        }
        private void Func_Refresh()  // 새로고침 기능
        {
            dgv_Shipment.DataSource = null;
            dgv_ShipmentDetail.DataSource = null;
            try { Shipment_AllList = service.GetShipmentCompletedList(); }
            catch (Exception err) { Log.WriteError(err.Message, err); }

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Clear();
            Search_Employees.CodeTextBox.Clear();
            Search_OrderPeriod.Startdate.Clear();
            Search_OrderPeriod.Enddate.Clear();
            Search_OrderCompletedPeriod.Startdate.Clear();
            Search_OrderCompletedPeriod.Enddate.Clear();
            Search_ShipmentRequiredPeriod.Startdate.Clear();
            Search_ShipmentRequiredPeriod.Enddate.Clear();
            Search_OrderCompletedPeriod.Startdate.Clear();
            Search_OrderCompletedPeriod.Enddate.Clear();
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_OrderCompletedPeriod.Startdate.Text == "    -  -") { main.NoticeMessage = Resources.PeriodError; }
            else
            {
                SearchedList = Shipment_AllList;
                if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객성명 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                        where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                        select item).ToList();
                }

                if (Search_Employees.CodeTextBox.Text.Length > 0)  // 출하지시자 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                        where item.Employees_Name == Search_Employees.CodeTextBox.Text
                                        select item).ToList();
                }

                if (Search_OrderPeriod.Startdate.Text != "    -  -")  // 주문일자 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                        where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderPeriod.Startdate.Text)) >= 0 &&
                                               item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderPeriod.Enddate.Text)) <= 0
                                        select item).ToList();
                }

                if (Search_OrderCompletedPeriod.Startdate.Text != "    -  -")  // 주문처리일자 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                        where item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_OrderCompletedPeriod.Startdate.Text)) >= 0
                                              &&
                                              item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_OrderCompletedPeriod.Enddate.Text)) <= 0
                                        select item).ToList();
                }

                if (Search_ShipmentRequiredPeriod.Startdate.Text != "    -  -")  // 출하요청일자 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                        where item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_ShipmentRequiredPeriod.Startdate.Text)) >= 0
                                              &&
                                              item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_ShipmentRequiredPeriod.Enddate.Text)) <= 0
                                        select item).ToList();
                }

                if (Search_ShipmentDonePeriod.Startdate.Text != "    -  -")  // 출하처리일자 검색조건 존재한다면
                {
                    SearchedList = (from item in SearchedList
                                    where item.Shipment_DoneDate.Date.CompareTo
                                          (Convert.ToDateTime(Search_ShipmentDonePeriod.Startdate.Text)) >= 0
                                          &&
                                          item.Shipment_DoneDate.Date.CompareTo
                                          (Convert.ToDateTime(Search_ShipmentDonePeriod.Enddate.Text)) <= 0
                                    select item).ToList();
                }
                dgv_Shipment.DataSource = SearchedList;
                dgv_ShipmentDetail.DataSource = null;
                GetShipmentDetail_List();
                main.NoticeMessage = Resources.SearchDone;
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_Shipment.Rows.Count == 0) main.NoticeMessage = Properties.Resources.ExcelError;
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
            List<Shipment> master = SearchedList.ToList();
            List<ShipmentDetail> detail = ShipmentDetail_AllList.ToList();
            string[] exceptColumns = { "OrderCompleted_Date" };
            UtilClass.ExportTo2DataGridView(master, detail, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {
            if (dgv_Shipment.Rows.Count == 0)main.NoticeMessage = Properties.Resources.NonData;
            else
            {
                using (WaitForm frm = new WaitForm())
                {
                    frm.Processing = ExportPrint;
                    frm.ShowDialog();
                }
            }
        }

        private void ExportPrint()
        {
            ShipmentCompletedReport sr = new ShipmentCompletedReport();
            dsShipment ds = new dsShipment();

            ds.Relations.Clear();
            ds.Tables.Clear();
            ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
            ds.Tables.Add(UtilClass.ConvertToDataTable(ShipmentDetail_AllList));
            ds.Tables[0].TableName = "dtShipment";
            ds.Tables[1].TableName = "dtShipmentDetail";
            ds.Relations.Add("dtShipment_dtShipmentDetail", ds.Tables[0].Columns["Shipment_ID"], ds.Tables[1].Columns["Shipment_ID"]);

            //ds.AcceptChanges();

            sr.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(sr))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void ShipmentCompleteForm_Activated(object sender, EventArgs e)
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

        private void ShipmentCompleteForm_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
