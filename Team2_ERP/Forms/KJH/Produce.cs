using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Produce : Base2Dgv
    {
        MainForm frm;
        List<ProduceVO> list = new List<ProduceVO>();        
        List<ProduceVO> searchedlist = new List<ProduceVO>();
        public Produce()
        {
            InitializeComponent();
        }

        private void Produce_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvProduce);
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
            dgvProduce.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduce.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduce.Columns[9].DefaultCellStyle.Format = "#0개";
            dgvProduce.Columns[10].DefaultCellStyle.Format = "#0개";

            UtilClass.SettingDgv(dgvPerformance);
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

            dgvPerformance.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerformance.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPerformance.Columns[6].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[7].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[8].DefaultCellStyle.Format = "#0개";
            dgvPerformance.Columns[9].DefaultCellStyle.Format = "0.0#\\%";
            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                ProduceService service = new ProduceService();
                list = service.GetAllProduce();
                dgvProduce.DataSource = list;
                dgvProduce.ClearSelection();
                dgvProduce.CurrentCell = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchProduct.CodeTextBox.Clear();
            searchPeriodStart.Startdate.Clear();
            searchPeriodStart.Enddate.Clear();
            searchPeriodEnd.Startdate.Clear();
            searchPeriodEnd.Enddate.Clear();
            dgvPerformance.DataSource = null;
            frm.NoticeMessage = "생산실적현황 화면입니다.";
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
            RefreshClicked();

        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchFactory.CodeTextBox.Tag == null && searchLine.CodeTextBox.Tag==null&& searchProduct.CodeTextBox.Tag==null&& searchPeriodStart.Startdate.Tag == null && searchPeriodStart.Enddate.Tag == null && searchPeriodEnd.Enddate.Tag == null && searchPeriodEnd.Startdate.Tag == null)
            {
                frm.새로고침ToolStripMenuItem.PerformClick();
            }
            else
            {
                searchedlist = list;
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
                dgvProduce.DataSource = searchedlist;
                frm.NoticeMessage = "검색 완료";
                GetPerformance();
            }

        }

        private void GetPerformance()
        {
            dgvPerformance.DataSource = null;
            if (dgvProduce.SelectedRows.Count > 0)
            {
                string id = dgvProduce.SelectedRows[0].Cells[0].Value.ToString();

                try
                {
                    ProduceService service = new ProduceService();
                    dgvPerformance.DataSource = service.GetPerformanceByProduceID(id);
                    dgvPerformance.ClearSelection();
                    dgvPerformance.CurrentCell = null;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            MessageBox.Show("엑셀");
        }

        public override void Print(object sender, EventArgs e)
        {
            MessageBox.Show("프린트");
        }

        private void dgvProduce_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetPerformance();
        }
    }
}
