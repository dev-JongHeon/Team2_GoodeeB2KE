using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Work : Base2Dgv
    {
        MainForm frm;
        List<WorkVO> list = new List<WorkVO>();
        List<WorkVO> filteredlist = new List<WorkVO>();
        List<WorkVO> searchedlist = new List<WorkVO>();
        List<ProduceVO> produces = new List<ProduceVO>();
        WorkService service = new WorkService();
        bool isFirst = true;
        public Work()
        {
            InitializeComponent();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvWork();
            RefreshClicked();
            frm.NoticeMessage = notice;
            EssentialSearchOption();
        }

        private void EssentialSearchOption()
        {
            searchPeriodwork.Startdate.BackColor = Color.LightYellow;
            searchPeriodwork.Enddate.BackColor = Color.LightYellow;
        }

        private void SettingDgvWork()
        {
            UtilClass.SettingDgv(dgvWorkList);
            UtilClass.AddNewColum(dgvWorkList, "작업지시번호", "Work_ID", true, 150);
            UtilClass.AddNewColum(dgvWorkList, "작업지시일", "Work_StartDate", true, 180);
            UtilClass.AddNewColum(dgvWorkList, "작업완료일", "Work_EndDate", true, 180);
            UtilClass.AddNewColum(dgvWorkList, "출하지시번호", "Shipment_ID", true, 150);
            UtilClass.AddNewColum(dgvWorkList, "납기일", "Shipment_RequiredDate", true, 180);
            UtilClass.AddNewColum(dgvWorkList, "작업상태", "Work_State", true);
            UtilClass.AddNewColum(dgvWorkList, "작업자지시자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvWorkList, "작업지시자", "Employees_Name", true);
            dgvWorkList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvWorkList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllWork();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dgvWorkList.DataSource = null;
            dgvProduce.DataSource = null;
            ClearSearchOption();
            if (!isFirst)
            {
                dgvWorkList.DataSource = list;
                ClearDgv();
                rbxAll.Checked = true;
            }
            frm.NoticeMessage = Resources.RefreshDone;
            isFirst = false;
        }

        private void ClearSearchOption()
        {
            searchSales.CodeTextBox.Clear();
            searchPeriodRequire.Startdate.Clear();
            searchPeriodRequire.Enddate.Clear();
            searchPeriodwork.Startdate.Clear();
            searchPeriodwork.Enddate.Clear();
            rbx0.Checked = false;
            rbx1.Checked = false;
            rbx2.Checked = false;
            rbxAll.Checked = false;
            gbxSearch.Enabled = false;
        }

        private void Work_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = searchSales;
            searchSales.Focus();
            
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void Work_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
            
        }

        private void Work_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvWorkList.ClearSelection();
            dgvWorkList.CurrentCell = null;
            dgvProduce.ClearSelection();
            dgvProduce.CurrentCell = null;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {

            if (searchPeriodwork.Startdate.Tag == null && searchPeriodwork.Enddate.Tag == null)
            {
                frm.NoticeMessage = Resources.PeriodError;
            }
            else
            {
                searchedlist = list;
                if (searchPeriodwork.Startdate.Tag != null && searchPeriodwork.Enddate.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where Convert.ToDateTime(item.Work_StartDate) >= Convert.ToDateTime(searchPeriodwork.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Work_StartDate) <= Convert.ToDateTime(searchPeriodwork.Enddate.Tag.ToString())
                                    orderby item.Work_StartDate
                                    select item).ToList();
                }
                if (searchSales.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Employees_ID == Convert.ToInt32(searchSales.CodeTextBox.Tag)
                                    select item).ToList();
                }
                if (searchPeriodRequire.Startdate.Tag != null && searchPeriodRequire.Enddate.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where Convert.ToDateTime(item.Shipment_RequiredDate) >= Convert.ToDateTime(searchPeriodRequire.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Shipment_RequiredDate) <= Convert.ToDateTime(searchPeriodRequire.Enddate.Tag.ToString())
                                    orderby item.Shipment_RequiredDate
                                    select item
                                    ).ToList();
                }
                dgvWorkList.DataSource = searchedlist;
                frm.NoticeMessage = Resources.SearchDone;
                GetProduce();
                gbxSearch.Enabled = true;
                rbxAll.Checked = true;
            }

        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgvWorkList.Rows.Count > 0)
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
            List<WorkVO> excellist = searchedlist.ToList();
            List<ProduceVO> detaillist = produces.ToList();
            string[] exceptlist = new string[] { "Employees_ID", "Factory_ID", "Line_ID", "Product_ID", "ProduceWork_ID" };
            UtilClass.ExportTo2DataGridView(excellist,detaillist, exceptlist);
        }

        public override void Print(object sender, EventArgs e)
        {
            MessageBox.Show("프린트");
        }

        private void rbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx0.Checked)
            {
                filteredlist = (from item in searchedlist
                                where item.Work_State == "작업대기"
                                select item).ToList();

            }
            else if (rbx1.Checked)
            {
                filteredlist = (from item in searchedlist
                                where item.Work_State == "작업중"
                                select item).ToList();

            }
            else if (rbx2.Checked)
            {
                filteredlist = (from item in searchedlist
                                where item.Work_State == "작업완료"
                                select item).ToList();

            }
            else if (rbxAll.Checked)
            {
                filteredlist = searchedlist;
            }
            dgvWorkList.DataSource = filteredlist;

        }

        private void GetProduce()
        {
            if (dgvWorkList.Rows.Count > 0)
            {
                string id = SettingID(dgvWorkList, 0);
                try
                {
                    ProduceService service = new ProduceService();
                    produces = service.GetProduceByWorkID(id);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void SetProduce(string id)
        {
            List<ProduceVO> search = produces.ToList();
            dgvProduce.DataSource = null;
            List<ProduceVO> searched = (from item in search
                                        where item.ProduceWork_ID == id
                                        select item).ToList();
            if (searched != null)
                dgvProduce.DataSource = searched;
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

        private void dgvWorkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                SetProduce(dgvWorkList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}

