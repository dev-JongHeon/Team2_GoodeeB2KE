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
    public partial class Work : Base2Dgv
    {
        MainForm frm;
        List<WorkVO> list = new List<WorkVO>();
        List<WorkVO> filteredlist = new List<WorkVO>();
        List<WorkVO> searchedlist = new List<WorkVO>();
        public Work()
        {
            InitializeComponent();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
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
            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                WorkService service = new WorkService();
                list = service.GetAllWork();
                dgvWorkList.DataSource = list;
                dgvWorkList.ClearSelection();
                dgvWorkList.CurrentCell = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            searchSales.CodeTextBox.Clear();
            searchPeriodRequire.Startdate.Clear();
            searchPeriodRequire.Enddate.Clear();
            searchPeriodwork.Startdate.Clear();
            searchPeriodwork.Enddate.Clear();
            rbx0.Checked = true;
            frm.NoticeMessage = "작업지시현황 화면입니다.";
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
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchSales.CodeTextBox.Tag == null && searchPeriodwork.Startdate.Tag == null && searchPeriodwork.Startdate.Tag == null && searchPeriodwork.Enddate.Tag == null && searchPeriodRequire.Startdate.Tag == null && searchPeriodRequire.Enddate.Tag == null)
            {
                frm.새로고침ToolStripMenuItem.PerformClick();
            }
            else
            {
                searchedlist = filteredlist;
                if (searchSales.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Employees_ID == Convert.ToInt32(searchSales.CodeTextBox.Tag)
                                    select item).ToList();
                }
            }
            if (searchPeriodRequire.Startdate.Tag != null && searchPeriodRequire.Enddate.Tag != null)
            {
                searchedlist = (from item in searchedlist
                                where Convert.ToDateTime(item.Shipment_RequiredDate) >= Convert.ToDateTime(searchPeriodRequire.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Shipment_RequiredDate) <= Convert.ToDateTime(searchPeriodRequire.Enddate.Tag.ToString())
                                select item).ToList();
            }
            if (searchPeriodwork.Startdate.Tag != null && searchPeriodwork.Enddate.Tag != null)
            {
                searchedlist = (from item in searchedlist
                                where Convert.ToDateTime(item.Work_StartDate) >= Convert.ToDateTime(searchPeriodwork.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Work_StartDate) <= Convert.ToDateTime(searchPeriodwork.Enddate.Tag.ToString())
                                select item).ToList();
            }
            dgvWorkList.DataSource = searchedlist;
            frm.NoticeMessage = "검색 완료";
        }

        public override void Excel(object sender, EventArgs e)
        {
            MessageBox.Show("엑셀");
        }

        public override void Print(object sender, EventArgs e)
        {
            MessageBox.Show("프린트");
        }

        private void rbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbx0.Checked)
            {
                filteredlist = (from item in list
                                where item.Work_State == "작업대기"
                                select item).ToList();

            }
            else if (rbx1.Checked)
            {
                filteredlist = (from item in list
                                where item.Work_State == "작업중"
                                select item).ToList();

            }
            else if (rbx2.Checked)
            {
                filteredlist = (from item in list
                                where item.Work_State == "작업완료"
                                select item).ToList();

            }
            else if (rbxAll.Checked)
            {
                filteredlist = list;
            }
            dgvWorkList.DataSource = filteredlist;
            searchSales.CodeTextBox.Clear();
            searchPeriodRequire.Startdate.Clear();
            searchPeriodRequire.Enddate.Clear();
            searchPeriodwork.Startdate.Clear();
            searchPeriodwork.Enddate.Clear();
            ClearDgv();
        }
    }
}

