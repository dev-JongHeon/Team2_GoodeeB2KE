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
using Team2_ERP.Properties;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class InOutList_MaterialWarehouse : Base1Dgv
    {
        #region 전역변수
        StockService service = new StockService();
        List<StockReceipt> StockReceipt_AllList = null;
        List<StockReceipt> SearchedList = null;
        MainForm main; 
        #endregion
        public InOutList_MaterialWarehouse()
        {
            InitializeComponent();
        }

        private void InOutList_MaterialWarehouse_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }
        

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Stock);
            UtilClass.AddNewColum(dgv_Stock, "수불번호", "StockReceipt_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "수불유형", "StockReceipt_Division1", true);
            UtilClass.AddNewColum(dgv_Stock, "처리일시", "StockReceipt_Date", true, 170);
            UtilClass.AddNewColum(dgv_Stock, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "창고명", "Warehouse_Name", true, 160);
            UtilClass.AddNewColum(dgv_Stock, "품번", "Product_ID", true, 70);
            UtilClass.AddNewColum(dgv_Stock, "품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_Stock, "수불수량", "StockReceipt_Quantity", true);
            UtilClass.AddNewColum(dgv_Stock, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "창고유형", "Warehouse_Division", false);
            dgv_Stock.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Stock.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Stock.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Stock.Columns[7].DefaultCellStyle.Format = "#,#0개";

            try { StockReceipt_AllList = service.GetStockReceipts(false); }  //  자재, 반제품 수불내역 전체 갱신
            catch (Exception err) { Log.WriteError(err.Message, err); }

            Search_Period.Startdate.BackColor = Color.LightYellow;
            Search_Period.Enddate.BackColor = Color.LightYellow;
            Group_Rdo.Enabled = false;
        }
        private void Func_Refresh()  // 새로고침 기능
        {
            dgv_Stock.DataSource = null;

            try { StockReceipt_AllList = service.GetStockReceipts(false); }  //  자재, 반제품 수불내역 전체 갱신
            catch (Exception err) { Log.WriteError(err.Message, err); }

            // 검색조건 초기화
            Search_Period.Startdate.Clear();
            Search_Period.Enddate.Clear();
            Search_Material.CodeTextBox.Clear();
            Search_Warehouse.CodeTextBox.Clear();

            rdo_All.Checked = false;
            rdo_In.Checked = false;
            rdo_Out.Checked = false;
            Group_Rdo.Enabled = false;
        }

        #region 라디오버튼 검색조건
        private void radioButton1_CheckedChanged(object sender, EventArgs e) // 라디오버튼 체크상황 별 검색조건
        {
            if (rdo_All.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in SearchedList
                                        where list_Stock.Warehouse_Division == false
                                        select list_Stock).ToList();
            }
            else if (rdo_In.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in SearchedList
                                        where list_Stock.Warehouse_Division == false && list_Stock.StockReceipt_Division1 == "입고"
                                        select list_Stock).ToList();
            }
            else if (rdo_Out.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in SearchedList
                                        where list_Stock.Warehouse_Division == false && list_Stock.StockReceipt_Division1 == "출고"
                                        select list_Stock).ToList();
            }
        }
        #endregion

        #region ToolStrip 기능정의

        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Resources.RefreshDone;
        }
        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_Period.Startdate.Text == "    -  -") { main.NoticeMessage = Resources.PeriodError; }
            else
            {
                SearchedList = StockReceipt_AllList;
                if (Search_Warehouse.CodeTextBox.Text.Length > 0)  // 창고 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                            where item.Warehouse_Name == Search_Warehouse.CodeTextBox.Text
                                            select item).ToList();
                }

                if (Search_Material.CodeTextBox.Text.Length > 0)  // 원자재명 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                            where item.Product_Name == Search_Material.CodeTextBox.Text
                                            select item).ToList();
                }

                if (Search_Employees.CodeTextBox.Text.Length > 0)  // 사원 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                            where item.Employees_Name == Search_Employees.CodeTextBox.Text
                                            select item).ToList();
                }

                if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
                {
                    SearchedList = (from item in SearchedList
                                            where item.StockReceipt_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 && item.StockReceipt_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                            select item).ToList();
                }
                dgv_Stock.DataSource = SearchedList;
                rdo_All.Checked = true;  // 라디오버튼 '전체'에 체크
                main.NoticeMessage = Resources.SearchDone;
                Group_Rdo.Enabled = true;
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_Stock.Rows.Count == 0)
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
            UtilClass.ExportToDataGridView(dgv_Stock, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {
            if (dgv_Stock.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.NonData;
            }
            else
            {
                using (WaitForm frm = new WaitForm())
                {
                    InOutMaterialWarehouseReport br = new InOutMaterialWarehouseReport();
                    dsStockReceipt ds = new dsStockReceipt();

                    ds.Relations.Clear();
                    ds.Tables.Clear();
                    ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
                    ds.Tables[0].TableName = "dtStockReceipt";

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
        private void InOutList_MaterialWarehouse_Activated(object sender, EventArgs e)
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

        private void InOutList_MaterialWarehouse_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        } 
        #endregion
    }
}
