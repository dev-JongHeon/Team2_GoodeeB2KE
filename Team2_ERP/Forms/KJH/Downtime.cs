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
    public partial class Downtime : BaseForm
    {
        MainForm frm;
        List<DowntimeVO> list = new List<DowntimeVO>();
        List<DowntimeVO> searchedlist = new List<DowntimeVO>();
        public Downtime()
        {
            InitializeComponent();
        }

        private void Downtime_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDowntime);
            UtilClass.AddNewColum(dgvDowntime, "공장번호", "Factory_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "공장명", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvDowntime, "공정번호", "Line_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "공정명", "Line_Name", true, 100);
            UtilClass.AddNewColum(dgvDowntime, "비가동유형번호", "DowntimeType_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "비가동유형", "DowntimeType_Name", true, 150);
            UtilClass.AddNewColum(dgvDowntime, "작업자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "작업자", "Employees_Name", true, 100);
            UtilClass.AddNewColum(dgvDowntime, "시작", "Downtime_StartDate", true,150);
            UtilClass.AddNewColum(dgvDowntime, "종료", "Downtime_EndDate", true, 150);
            UtilClass.AddNewColum(dgvDowntime, "비가동시간", "Downtime_TotalTime", true,100);

            dgvDowntime.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDowntime.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDowntime.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                DowntimeService service = new DowntimeService();
                list = service.GetAllDowntime();
                dgvDowntime.DataSource = list;
                dgvDowntime.ClearSelection();
                dgvDowntime.CurrentCell = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchDowntime.CodeTextBox.Clear();            
            searchWorker.CodeTextBox.Clear();
            searchPeriod.Startdate.Clear();
            searchPeriod.Enddate.Clear();
            frm.NoticeMessage = "비가동현황 화면입니다.";
        }

        private void Downtime_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = searchFactory;
            searchFactory.Focus();
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void Downtime_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Downtime_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvDowntime.ClearSelection();
            dgvDowntime.CurrentCell = null;
        }
        public override void Refresh(object sender, EventArgs e)
        {
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchFactory.CodeTextBox.Tag == null && searchLine.CodeTextBox.Tag == null && searchDowntime.CodeTextBox.Tag == null && searchWorker.CodeTextBox.Tag == null && searchPeriod.Startdate.Tag == null && searchPeriod.Enddate.Tag == null)
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
                if (searchDowntime.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.DowntimeType_ID == searchDowntime.CodeTextBox.Tag.ToString()
                                    select item).ToList();
                }
                if (searchWorker.CodeTextBox.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where item.Employees_ID == Convert.ToInt32(searchWorker.CodeTextBox.Tag)
                                    select item).ToList();
                }
                if (searchPeriod.Startdate.Tag != null && searchPeriod.Enddate.Tag != null)
                {
                    searchedlist = (from item in searchedlist
                                    where Convert.ToDateTime(item.Downtime_StartDate) >= Convert.ToDateTime(searchPeriod.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Downtime_StartDate) <= Convert.ToDateTime(searchPeriod.Enddate.Tag.ToString())
                                    select item).ToList();
                }

                dgvDowntime.DataSource = searchedlist;
                frm.NoticeMessage = "검색 완료";
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
    }
}
