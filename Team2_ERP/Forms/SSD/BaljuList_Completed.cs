﻿using DevExpress.XtraReports.UI;
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
    public partial class BaljuList_Completed : Base2Dgv
    {
        #region 전역변수
        BaljuService service = new BaljuService();
        List<Balju> BaljuCompleted_AllList = null;  // Masterss
        List<BaljuDetail> BaljuDetail_AllList = null;  // Details
        List<Balju> SearchedList = null;  // 검색용
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

        #region dgv 관련기능
        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_BaljuCompleted);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주지시번호", "Balju_ID", true, 130);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처코드", "Company_ID", true, 110);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처명칭", "Company_Name", true, 200);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주요청일시", "Balju_Date", true, 170);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "요청등록사원", "Employees_Name", true, 150);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "수령일시", "Balju_ReceiptDate", true, 170);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "수령사원", "ReceiptEmployees_Name", true, 150);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "총액", "Total", true, 170);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "삭제여부", "Balju_DeletedYN", false);
            dgv_BaljuCompleted.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_BaljuCompleted.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_BaljuCompleted.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_BaljuCompleted.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_BaljuCompleted.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_BaljuCompleted.Columns[7].DefaultCellStyle.Format = "#,#0원";

            try { BaljuCompleted_AllList = service.GetBalju_CompletedList(); }// 발주리스트 갱신
            catch (Exception err) { Log.WriteError(err.Message, err); }

            UtilClass.SettingDgv(dgv_BaljuDetail);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", false, 130);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true, 500);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true, 130);
            dgv_BaljuDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_BaljuDetail.Columns[3].DefaultCellStyle.Format = "#,#0개";

            Search_ReceiptPeriod.Startdate.BackColor = Color.LightYellow;
            Search_ReceiptPeriod.Enddate.BackColor = Color.LightYellow;
        }

        private void dgv_BaljuCompleted_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Master 더블클릭 이벤트
        {
            if (e.RowIndex > -1)
            {
                string Balju_ID = dgv_BaljuCompleted.CurrentRow.Cells[0].Value.ToString();
                List<BaljuDetail> BaljuDetail_List = (from list_detail in BaljuDetail_AllList
                                                      where list_detail.Balju_ID == Balju_ID
                                                      select list_detail).ToList();
                dgv_BaljuDetail.DataSource = BaljuDetail_List;
            }
        }

        private void GetBaljuCompletedDetail_List()  // 현재 위의 Dgv의 Row수 따라 그에맞는 DetailList 가져옴
        {
            if (dgv_BaljuCompleted.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgv_BaljuCompleted.Rows)
                {
                    sb.Append($"'{row.Cells[0].Value.ToString()}',");
                }

                try { BaljuDetail_AllList = service.GetBalju_DetailList(sb.ToString().Trim(',')); }  // 디테일 AllList 갱신
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
            dgv_BaljuDetail.DataSource = null;
            dgv_BaljuCompleted.DataSource = null;

            try { BaljuCompleted_AllList = service.GetBalju_CompletedList(); }
            catch (Exception err) { Log.WriteError(err.Message, err); }

            // 검색조건 초기화
            Search_Period.Startdate.Clear();
            Search_Period.Enddate.Clear();
            Search_ReceiptPeriod.Startdate.Clear();
            Search_ReceiptPeriod.Enddate.Clear();
            Search_Company.CodeTextBox.Clear();
            Search_Employee.CodeTextBox.Clear();
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_ReceiptPeriod.Startdate.Text == "    -  -") { main.NoticeMessage = Resources.PeriodError; }
            else
            {
                SearchedList = BaljuCompleted_AllList;
                if (Search_Company.CodeTextBox.Text.Length > 0)   // 회사 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                    where item.Company_Name == Search_Company.CodeTextBox.Text
                                    select item).ToList();
                }
                if (Search_Employee.CodeTextBox.Text.Length > 0)   // 사원 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                    where item.Employees_Name == Search_Employee.CodeTextBox.Text
                                    select item).ToList();
                }
                if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
                {
                    SearchedList = (from item in SearchedList
                                    where item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 && item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                    select item).ToList();
                }
                if (Search_ReceiptPeriod.Startdate.Text != "    -  -")
                {
                    SearchedList = (from item in SearchedList
                                    where item.Balju_ReceiptDate.Date.CompareTo(Convert.ToDateTime(Search_ReceiptPeriod.Startdate.Text)) >= 0 && item.Balju_ReceiptDate.Date.CompareTo(Convert.ToDateTime(Search_ReceiptPeriod.Enddate.Text)) <= 0
                                    select item).ToList();
                }
                dgv_BaljuCompleted.DataSource = SearchedList;
                dgv_BaljuDetail.DataSource = null;
                GetBaljuCompletedDetail_List();
                main.NoticeMessage = Resources.SearchDone;
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_BaljuCompleted.Rows.Count == 0) main.NoticeMessage = Properties.Resources.ExcelError;
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
            List<Balju> master = SearchedList.ToList();
            List<BaljuDetail> detail = BaljuDetail_AllList.ToList();
            string[] exceptColumns = { "Balju_DeletedYN" };
            UtilClass.ExportTo2DataGridView(master, detail, exceptColumns);
        }
        public override void Print(object sender, EventArgs e)  // 인쇄
        {
            if (dgv_BaljuCompleted.Rows.Count == 0) main.NoticeMessage = Properties.Resources.NonData;
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
            BaljuCompletedReport br = new BaljuCompletedReport();
            dsBalju ds = new dsBalju();

            ds.Relations.Clear();
            ds.Tables.Clear();
            ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
            ds.Tables.Add(UtilClass.ConvertToDataTable(BaljuDetail_AllList));
            ds.Tables[0].TableName = "dtBalju";
            ds.Tables[1].TableName = "dtBalju_Detail";
            ds.Relations.Add("dtBalju_dtBalju_Detail", ds.Tables[0].Columns["Balju_ID"], ds.Tables[1].Columns["Balju_ID"]);

            //ds.AcceptChanges();

            br.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(br))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void BaljuList_Completed_Activated(object sender, EventArgs e)
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

        private void BaljuList_Completed_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
