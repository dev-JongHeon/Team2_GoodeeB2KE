using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;
using Excel = Microsoft.Office.Interop.Excel;

namespace Team2_ERP
{
    public partial class Produce : Base2Dgv
    {
        MainForm frm;
        List<ProduceVO> list = new List<ProduceVO>();
        List<ProduceVO> searchedlist = new List<ProduceVO>();
        List<PerformanceVO> performances = new List<PerformanceVO>();
        bool isFirst = true;
        ProduceService service = new ProduceService();
        public Produce()
        {
            InitializeComponent();
        }

        private void Produce_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvProduce();
            RefreshClicked();
            SetEssentialSearchOption();
        }
        private void SetEssentialSearchOption()
        {
            searchPeriodStart.Startdate.BackColor = Color.LightYellow;
            searchPeriodStart.Enddate.BackColor = Color.LightYellow;
        }

        private void SettingDgvProduce()
        {
            string[] exceptlist = new string[] { "Employees_ID", "Factory_ID", "Line_ID", "Product_ID" };
            UtilClass.SettingDgv(dgvProduce);
            UtilClass.AddNewColum(dgvProduce, "작업지시번호", "ProduceWork_ID", false, 130);
            UtilClass.AddNewColum(dgvProduce, "생산지시번호", "Produce_ID", true, 130);
            UtilClass.AddNewColum(dgvProduce, "생산시작일", "Produce_StartDate", true, 180);
            UtilClass.AddNewColum(dgvProduce, "생산완료일", "Produce_DoneDate", true, 180);
            UtilClass.AddNewColum(dgvProduce, "공장번호", "Factory_ID", false);
            UtilClass.AddNewColum(dgvProduce, "공장명", "Factory_Name", true, 130);
            UtilClass.AddNewColum(dgvProduce, "공정번호", "Line_ID", false);
            UtilClass.AddNewColum(dgvProduce, "공정명", "Line_Name", true, 130);
            UtilClass.AddNewColum(dgvProduce, "품목번호", "Product_ID", false);
            UtilClass.AddNewColum(dgvProduce, "품목명", "Product_Name", true, 150);
            UtilClass.AddNewColum(dgvProduce, "요청수량", "Produce_QtyRequested", true);
            UtilClass.AddNewColum(dgvProduce, "투입수량", "Produce_QtyReleased", true);
            UtilClass.AddNewColum(dgvProduce, "생산상태", "Produce_State", true);

            dgvProduce.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduce.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProduce.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduce.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduce.Columns[10].DefaultCellStyle.Format = "#0개";
            dgvProduce.Columns[11].DefaultCellStyle.Format = "#0개";

            UtilClass.SettingDgv(dgvPerformance);
            UtilClass.AddNewColum(dgvPerformance, "생산지시번호", "PerformanceProduce_ID", false, 130);
            UtilClass.AddNewColum(dgvPerformance, "생산실적번호", "Performance_ID", true, 130);
            UtilClass.AddNewColum(dgvPerformance, "실적시작시간", "Performance_StartDate", true, 180);
            UtilClass.AddNewColum(dgvPerformance, "실적종료시간", "Performance_EndDate", true, 180);
            UtilClass.AddNewColum(dgvPerformance, "경과시간", "Performance_ElapsedTime", true);
            UtilClass.AddNewColum(dgvPerformance, "품목번호", "Product_ID", false);
            UtilClass.AddNewColum(dgvPerformance, "품목명", "Product_Name", true, 150);
            UtilClass.AddNewColum(dgvPerformance, "요청수량", "Performance_QtyImport", true);
            UtilClass.AddNewColum(dgvPerformance, "양품수량", "Performance_QtySuccessItem", true);
            UtilClass.AddNewColum(dgvPerformance, "불량수량", "Performance_QtyDefectiveItem", true);
            UtilClass.AddNewColum(dgvPerformance, "불량률", "Performance_DefectiveRate", true);
            UtilClass.AddNewColum(dgvPerformance, "작업자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvPerformance, "작업자", "Employees_Name", true);

            dgvPerformance.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[7].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[8].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[9].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[10].DefaultCellStyle.Format = "0.0#\\%";
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllProduce();

            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvProduce.DataSource = null;
            dgvPerformance.DataSource = null;
            if (!isFirst)
            {
                dgvProduce.DataSource = list;
                ClearDgv();
            }
            isFirst = false;
            ClearSearchOption();
            frm.NoticeMessage = Resources.RefreshDone;
        }

        private void ClearSearchOption()
        {
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchProduct.CodeTextBox.Clear();
            searchPeriodStart.Startdate.Clear();
            searchPeriodStart.Enddate.Clear();
            searchPeriodEnd.Startdate.Clear();
            searchPeriodEnd.Enddate.Clear();
        }

        private void Produce_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = searchFactory;
            searchFactory.Focus();
            frm.NoticeMessage = notice;
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void Produce_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Produce_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvProduce.ClearSelection();
            dgvProduce.CurrentCell = null;
            dgvPerformance.ClearSelection();
            dgvPerformance.CurrentCell = null;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchPeriodStart.Startdate.Tag == null || searchPeriodStart.Enddate.Tag == null)
            {
                frm.NoticeMessage = Resources.PeriodError;
            }
            else
            {
                searchedlist = list;
                if (searchPeriodStart.Startdate.Tag != null && searchPeriodStart.Enddate.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where Convert.ToDateTime(item.Produce_StartDate) >= Convert.ToDateTime(searchPeriodStart.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Produce_StartDate) <= Convert.ToDateTime(searchPeriodStart.Enddate.Tag.ToString())
                                    orderby item.Produce_StartDate
                                    select item
                                    ).ToList();
                }
                if (searchPeriodEnd.Startdate.Tag != null && searchPeriodEnd.Enddate.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where Convert.ToDateTime(item.Produce_DoneDate) >= Convert.ToDateTime(searchPeriodEnd.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Produce_DoneDate) <= Convert.ToDateTime(searchPeriodEnd.Enddate.Tag.ToString())
                                    orderby item.Produce_DoneDate
                                    select item).ToList();
                }
                if (searchFactory.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Factory_ID == Convert.ToInt32(searchFactory.CodeTextBox.Tag)
                                    select item).ToList();
                }
                if (searchLine.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Line_ID == Convert.ToInt32(searchLine.CodeTextBox.Tag)
                                    select item).ToList();
                }
                if (searchProduct.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Product_ID == searchProduct.CodeTextBox.Tag.ToString()
                                    select item).ToList();
                }
                
                dgvProduce.DataSource = searchedlist;
                frm.NoticeMessage = Resources.SearchDone;
                GetPerformance();
       
            }
        }

        private void GetPerformance()
        {
            if (dgvProduce.SelectedRows.Count > 0)
            {
                string id = SettingID(dgvProduce, 1);
                try
                {
                    ProduceService service = new ProduceService();
                    performances= service.GetPerformanceByProduceID(id);
                }
                catch (Exception err)
                {
                    Log.WriteError(err.Message, err);
                }
            }
        }

        private void SetPerformance(string id)
        {
            List<PerformanceVO> search = performances.ToList();
            dgvPerformance.DataSource = null;
            List<PerformanceVO> searched = (from item in search
                                        where item.PerformanceProduce_ID == id
                                        select item).ToList();
            if (searched != null)
                dgvPerformance.DataSource = searched;
        }
        private string SettingID(DataGridView dgv, int i)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                sb.Append($"'{item.Cells[i].Value.ToString()}',");
            }
            return sb.ToString().TrimEnd(',');
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgvProduce.Rows.Count > 0)
            {
                using (WaitForm frm = new WaitForm())
                {
                    frm.Processing = ExcelExport;
                    frm.ShowDialog();
                }
                frm.WindowState = FormWindowState.Minimized;
            }
            else
            {
                frm.NoticeMessage = Resources.ExcelError;
            }
        }

        private void ExcelExport()
        {
            List<ProduceVO> excellist = searchedlist.ToList();
            List<PerformanceVO> detaillist = performances.ToList();

            string[] exceptlist = new string[] { "ProduceWork_ID","Employees_ID", "Factory_ID", "Line_ID", "Product_ID","PerformanceProduce_ID" };
            UtilClass.ExportTo2DataGridView(excellist,detaillist,exceptlist);
        }

        public override void Print(object sender, EventArgs e)
        {
            if (dgvProduce.Rows.Count == 0) frm.NoticeMessage = Properties.Resources.NonData;
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
            ProduceReport pr = new ProduceReport();
            dsProduce ds = new dsProduce();

            ds.Relations.Clear();
            ds.Tables.Clear();
            ds.Tables.Add(UtilClass.ConvertToDataTable(searchedlist));
            ds.Tables.Add(UtilClass.ConvertToDataTable(performances));
            ds.Tables[0].TableName = "dtProduce";
            ds.Tables[1].TableName = "dtProduceDetail";
            ds.Relations.Add("dtProduce_dtProduceDetail", ds.Tables[0].Columns["Produce_ID"], ds.Tables[1].Columns["PerformanceProduce_ID"]);

            pr.DataSource = ds;
            using (ReportPrintTool printTool = new ReportPrintTool(pr))
            {
                printTool.ShowRibbonPreviewDialog();
            }
        }

        private void dgvProduce_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SetPerformance(dgvProduce.SelectedRows[0].Cells[1].Value.ToString());
            }
        }
    }
}
