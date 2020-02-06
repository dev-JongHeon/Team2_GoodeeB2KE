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
    public partial class InOutList_SemiProductWarehouse : Base1Dgv
    {
        #region 전역변수
        StockService service = new StockService();
        List<StockReceipt> StockReceipt_AllList = null;
        MainForm main;
        #endregion
        public InOutList_SemiProductWarehouse()
        {
            InitializeComponent();
        }

        private void InOutList_SemiProductWarehouse_Load(object sender, EventArgs e)
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
            StockReceipt_AllList = service.GetStockReceipts(); // 수불내역 갱신

            // LINQ로 반제품창고에 속한 수불현황만 가져옴
            StockReceipt_AllList = (from list_Stock in StockReceipt_AllList
                                    where list_Stock.Warehouse_Division == true
                                    select list_Stock).ToList();
            //dgv_Stock.DataSource = StockReceipt_AllList;
        }
        private void Func_Refresh()  // 새로고침 기능
        {
            StockReceipt_AllList = service.GetStockReceipts();  // 수불내역 재조회 후 AllList에 저장

            // LINQ로 반제품창고에 속한것만 바인딩
            StockReceipt_AllList = (from list_Stock in StockReceipt_AllList
                                    where list_Stock.Warehouse_Division == true
                                    select list_Stock).ToList();
            dgv_Stock.DataSource = StockReceipt_AllList;

            // 검색조건 초기화
            Search_Period.Startdate.Clear();
            Search_Period.Enddate.Clear();
            Search_SemiProduct.CodeTextBox.Clear();
            Search_Warehouse.CodeTextBox.Clear();

            rdo_All.Checked = true;
        }

        #region 라디오버튼 검색조건
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_All.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true
                                        select list_Stock).ToList();
            }
            else if (rdo_In.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true && list_Stock.StockReceipt_Division1 == "입고"
                                        select list_Stock).ToList();
            }
            else if (rdo_Out.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true && list_Stock.StockReceipt_Division1 == "출고"
                                        select list_Stock).ToList();
            }
        }
        #endregion

        #region ToolStrip 기능정의

        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }
        public override void Search(object sender, EventArgs e)  // 검색
        {
            // 반제품에 해당하는 수불리스트 갱신
            StockReceipt_AllList = service.GetStockReceipts();              
            StockReceipt_AllList = (from list_Stock in StockReceipt_AllList
                                    where list_Stock.Warehouse_Division == true
                                    select list_Stock).ToList();

            if (Search_Warehouse.CodeTextBox.Text.Length > 0)  // 창고 검색조건 있으면
            {
                StockReceipt_AllList = (from item in StockReceipt_AllList
                                        where item.Warehouse_Name == Search_Warehouse.CodeTextBox.Text
                                        select item).ToList();
            }

            if (Search_SemiProduct.CodeTextBox.Text.Length > 0)  // 반제품 검색조건 있으면
            {
                StockReceipt_AllList = (from item in StockReceipt_AllList
                                        where item.Product_Name == Search_SemiProduct.CodeTextBox.Text
                                        select item).ToList();
            }

            if (Search_Employees.CodeTextBox.Text.Length > 0)  // 사원 검색조건 있으면
            {
                StockReceipt_AllList = (from item in StockReceipt_AllList
                                        where item.Employees_Name == Search_Employees.CodeTextBox.Text
                                        select item).ToList();
            }

            if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
            {
                if (Search_Period.Startdate.Text != Search_Period.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    StockReceipt_AllList = (from item in StockReceipt_AllList
                                            where item.StockReceipt_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                            item.StockReceipt_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                            select item).ToList();
                }
                else   // 같은경우
                {
                    StockReceipt_AllList = (from item in StockReceipt_AllList
                                            where item.StockReceipt_Date.Date == Convert.ToDateTime(Search_Period.Startdate.Text)
                                            select item).ToList();
                }
            }
            dgv_Stock.DataSource = StockReceipt_AllList;
            rdo_All.Checked = true;  // 라디오버튼 '전체'에 체크
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
            string[] exceptColumns = { "" };
            UtilClass.ExportToDataGridView<StockReceipt>(StockReceipt_AllList, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        } 
        #endregion

        #region Activated, OnOff, DeActivate
        private void InOutList_SemiProductWarehouse_Activated(object sender, EventArgs e)
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

        private void InOutList_SemiProductWarehouse_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        } 
        #endregion
    }
}
