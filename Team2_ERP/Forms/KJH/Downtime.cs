using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Downtime : BaseForm
    {
        MainForm frm;
        List<DowntimeVO> list = new List<DowntimeVO>();
        List<DowntimeVO> searchedlist = new List<DowntimeVO>();
        DataSet ds1 = new DataSet();
        DataTable dtbyline = new DataTable();
        DataTable dtbytype = new DataTable();
        DataSet ds2 = new DataSet();
        DowntimeService service = new DowntimeService();
        StringBuilder sb = new StringBuilder();

        public Downtime()
        {
            InitializeComponent();
        }

        private void Downtime_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvDowntime();
            RefreshClicked();
        }

        private void SettingByLineColumns(DataColumnCollection dc)
        {
            foreach (DataColumn item in dc)
            {
                string name = item.ColumnName;
                if (name == "Line_Name")
                {
                    UtilClass.AddNewColum(dgvDowntimeByLine, "공정명", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDowntimeByLine, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
                }
            }
        }

        private void SettingByTypeColumns(DataColumnCollection dc)
        {
            foreach (DataColumn item in dc)
            {
                string name = item.ColumnName;
                
               if (name == "DowntimeType_Name")
                {
                    UtilClass.AddNewColum(dgvDowntimeByType, "유형명", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDowntimeByType, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
                }
            }
        }

        private void CalcTotaltime(DataTable dt)
        {
            dt.Columns.Add("비가동시간",typeof(string));
            TimeSpan time = new TimeSpan();
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i < dt.Columns.Count-1; i++)
                {
                    if (row[dt.Columns[i].ColumnName].ToString() != string.Empty)
                    {
                        time += TimeSpan.Parse(row[dt.Columns[i]].ToString());
                    
                    }
                    if (time.ToString("hh\\:mm\\:ss") != "00:00:00")
                    {
                        row["비가동시간"] = time.ToString("hh\\:mm\\:ss");
                        time = new TimeSpan();
                    }
                }
            }
        }

        private void SettingDgvDowntime()
        {
            UtilClass.SettingDgv(dgvDowntime);
            UtilClass.AddNewColum(dgvDowntime, "공장번호", "Factory_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "공장명", "Factory_Name", true, 130);
            UtilClass.AddNewColum(dgvDowntime, "공정번호", "Line_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "공정명", "Line_Name", true, 130);
            UtilClass.AddNewColum(dgvDowntime, "비가동유형번호", "DowntimeType_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "비가동유형", "DowntimeType_Name", true, 150);
            UtilClass.AddNewColum(dgvDowntime, "작업자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvDowntime, "작업자", "Employees_Name", true, 130);
            UtilClass.AddNewColum(dgvDowntime, "시작", "Downtime_StartDate", true, 180);
            UtilClass.AddNewColum(dgvDowntime, "종료", "Downtime_EndDate", true, 180);
            UtilClass.AddNewColum(dgvDowntime, "비가동시간", "Downtime_TotalTime", true, 100);
            dgvDowntime.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDowntime.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDowntime.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            UtilClass.SettingDgv(dgvDowntimeByType);
            dgvDowntimeByType.AutoGenerateColumns = true;

            UtilClass.SettingDgv(dgvDowntimeByLine);
            dgvDowntimeByLine.AutoGenerateColumns = true;

        }

        private void SetDoNotSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn i in dgv.Columns)
            {
                i.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllDowntime();
                ds1 = service.GetDowntimeByLine($"[{DateTime.Now.ToString("yyyy-MM-dd")}]");
                dtbyline = ds1.Tables[0].Copy();
                ds2 = service.GetDowntimeByType($"[{DateTime.Now.ToString("yyyy-MM-dd")}]");
                dtbytype = ds2.Tables[0].Copy();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dgvDowntime.DataSource = list;
            dgvDowntime.ClearSelection();
            dgvDowntime.CurrentCell = null;

            dgvDowntimeByLine.Columns.Clear();
            SettingByLineColumns(dtbyline.Columns);
            SetDoNotSort(dgvDowntimeByLine);
            dgvDowntimeByLine.DataSource = dtbyline;
            dgvDowntimeByLine.ClearSelection();
            dgvDowntimeByLine.CurrentCell = null;

            dgvDowntimeByType.Columns.Clear();
            SettingByTypeColumns(dtbytype.Columns);
            SetDoNotSort(dgvDowntimeByType);
            dgvDowntimeByType.DataSource = dtbytype;
            dgvDowntimeByType.ClearSelection();
            dgvDowntimeByType.CurrentCell = null;

            ClearSearchOption();
            frm.NoticeMessage = "비가동현황 화면입니다.";
        }

        private void ClearSearchOption()
        {
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchDowntime.CodeTextBox.Clear();
            searchWorker.CodeTextBox.Clear();
            searchPeriod.Startdate.Clear();
            searchPeriod.Enddate.Clear();
            searchPeriodForBy.Startdate.Clear();
            searchPeriodForBy.Enddate.Clear();
        }

        private void Downtime_Activated(object sender, EventArgs e)
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
            if (tabDowntime.SelectedIndex == 0)
            {
                if (searchFactory.CodeTextBox.Tag == null && searchLine.CodeTextBox.Tag == null && searchDowntime.CodeTextBox.Tag == null && searchWorker.CodeTextBox.Tag == null && searchPeriod.Startdate.Tag == null && searchPeriod.Enddate.Tag == null)
                {
                    RefreshClicked();
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
            else if (tabDowntime.SelectedIndex == 1)
            {
                if (searchPeriodForBy.Startdate.Tag != null && searchPeriodForBy.Enddate.Tag != null)
                {
                    GetSearchDays();
                    ds1.Clear();
                    ds1 = service.GetDowntimeByLine(sb.ToString().TrimEnd(','));
                    DataTable searcheddt = ds1.Tables[0].Copy();
                    dgvDowntimeByLine.Columns.Clear();
                    CalcTotaltime(searcheddt);
                    SettingByLineColumns(searcheddt.Columns);
                    SetDoNotSort(dgvDowntimeByLine);
                    dgvDowntimeByLine.DataSource = searcheddt;
                    frm.NoticeMessage = "검색 완료";
                }
                else
                {
                    RefreshClicked();
                }
            }
            else if (tabDowntime.SelectedIndex == 2)
            {
                if (searchPeriodForBy.Startdate.Tag != null && searchPeriodForBy.Enddate.Tag != null)
                {
                    GetSearchDays();
                    ds2.Clear();
                    ds2 = service.GetDowntimeByType(sb.ToString().TrimEnd(','));
                    DataTable searcheddt2 = ds2.Tables[0].Copy();
                    dgvDowntimeByType.Columns.Clear();
                    CalcTotaltime(searcheddt2);
                    SettingByTypeColumns(searcheddt2.Columns);
                    SetDoNotSort(dgvDowntimeByType);
                    dgvDowntimeByType.DataSource = searcheddt2;
                    frm.NoticeMessage = "검색 완료";
                }
                else
                {
                    RefreshClicked();
                }
            }

        }

        private void GetSearchDays()
        {
            sb.Clear();
            DateTime date = Convert.ToDateTime(searchPeriodForBy.Startdate.Text);
            while (DateTime.Compare(date, Convert.ToDateTime(searchPeriodForBy.Enddate.Text).AddDays(1)) != 0)
            {
                sb.Append($"[{date.ToString("yyyy-MM-dd")}],");
                date = date.AddDays(1);
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

        private void tabDowntime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDowntime.SelectedIndex != 0)
            {
                searchPeriodForBy.Visible = true;
                searchPeriodForBy.Startdate.Clear();
                searchPeriodForBy.Enddate.Clear();
                SearchArea.Visible = false;
            }
            else
            {
                SearchArea.Visible = true;
                searchPeriodForBy.Visible = false;
                
            }
        }

        private void dgvDowntime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
