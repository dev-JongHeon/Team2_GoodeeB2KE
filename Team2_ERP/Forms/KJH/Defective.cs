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
    public partial class Defective : BaseForm
    {
        MainForm frm;
        List<DefectiveVO> list = new List<DefectiveVO>();
        List<DefectiveVO> searchedlist = new List<DefectiveVO>();
        DefectiveService service = new DefectiveService();
        bool isFirst = true;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataTable dtbyline = new DataTable();
        DataTable dtbytype = new DataTable();
        DataTable dtbyhandle = new DataTable();
        StringBuilder sb = new StringBuilder();

        public Defective()
        {
            InitializeComponent();
        }

        private void Defective_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvDefective();
            RefreshClicked();
        }

        private void SettingDgvDefective()
        {
            UtilClass.SettingDgv(dgvDefective);
            UtilClass.AddNewColum(dgvDefective, "생산실적번호", "Performance_ID", true, 130);
            UtilClass.AddNewColum(dgvDefective, "공장번호", "Factory_ID", false);
            UtilClass.AddNewColum(dgvDefective, "공장명", "Factory_Name", true, 130);
            UtilClass.AddNewColum(dgvDefective, "공정번호", "Line_ID", false);
            UtilClass.AddNewColum(dgvDefective, "공정명", "Line_Name", true, 130);
            UtilClass.AddNewColum(dgvDefective, "품목번호", "Product_ID", false);
            UtilClass.AddNewColum(dgvDefective, "품목명", "Product_Name", true, 150);
            UtilClass.AddNewColum(dgvDefective, "불량유형번호", "DefectiveType_ID", false);
            UtilClass.AddNewColum(dgvDefective, "불량유형", "DefectiveType_Name", true);
            UtilClass.AddNewColum(dgvDefective, "불량처리유형번호", "DefectiveHandle_ID", false);
            UtilClass.AddNewColum(dgvDefective, "불량처리유형", "DefectiveHandle_Name", true, 130);
            UtilClass.AddNewColum(dgvDefective, "작업자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvDefective, "작업자", "Employees_Name", true, 100);
            UtilClass.AddNewColum(dgvDefective, "불량개수", "Defective_Num", true, 100);
            UtilClass.AddNewColum(dgvDefective, "처리날짜", "Defective_HandleDate", true, 100);
            dgvDefective.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDefective.Columns[13].DefaultCellStyle.Format = "#개";
            dgvDefective.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            UtilClass.SettingDgv(dgvDefectiveByLine);
            dgvDefectiveByLine.AutoGenerateColumns = true;

            UtilClass.SettingDgv(dgvDefectiveByDefecType);
            dgvDefectiveByDefecType.AutoGenerateColumns = true;

            UtilClass.SettingDgv(dgvDefectiveByDefecHandleType);
            dgvDefectiveByDefecHandleType.AutoGenerateColumns = true;
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
                list = service.GetAllDefective();

                ds1 = service.GetDefectiveByLine($"[{DateTime.Now.ToString("yyyy-MM-dd")}]");
                dtbyline = ds1.Tables[0].Copy();

                ds2 = service.GetDefectiveByDeftiveType($"[{DateTime.Now.ToString("yyyy-MM-dd")}]");
                dtbytype = ds2.Tables[0].Copy();

                ds3 = service.GetDefectiveByDeftiveHandleType($"[{DateTime.Now.ToString("yyyy-MM-dd")}]");
                dtbyhandle = ds3.Tables[0].Copy();

                dgvDefectiveByLine.Columns.Clear();
                SettingByLineColumns(dtbyline.Columns);
                SetDoNotSort(dgvDefectiveByLine);

                dgvDefectiveByDefecType.Columns.Clear();
                SettingByTypeColumns(dtbytype.Columns);
                SetDoNotSort(dgvDefectiveByDefecType);

                dgvDefectiveByDefecHandleType.Columns.Clear();
                SettingByTypeColumns(dtbyhandle.Columns);
                SetDoNotSort(dgvDefectiveByDefecHandleType);

                if (!isFirst)
                {
                    if (tabDefective.SelectedIndex == 0)
                    {
                        dgvDefective.DataSource = list;
                    }
                    else if (tabDefective.SelectedIndex == 1)
                    {
                        dgvDefectiveByLine.Columns.Clear();
                        SettingByLineColumns(dtbyline.Columns);
                        SetDoNotSort(dgvDefectiveByLine);
                        dgvDefectiveByLine.DataSource = dtbyline;
                    }
                    else if (tabDefective.SelectedIndex == 2)
                    {
                        dgvDefectiveByDefecType.Columns.Clear();
                        SettingByTypeColumns(dtbytype.Columns);
                        SetDoNotSort(dgvDefectiveByDefecType);
                        dgvDefectiveByDefecType.DataSource = dtbytype;
                    }
                    else
                    {
                        dgvDefectiveByDefecHandleType.Columns.Clear();
                        SettingByTypeColumns(dtbyhandle.Columns);
                        SetDoNotSort(dgvDefectiveByDefecHandleType);
                        dgvDefectiveByDefecHandleType.DataSource = dtbyhandle;
                    }
                    ClearDgv();
                }
                isFirst = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            ClearSearchOption();
            frm.NoticeMessage = "불량처리현황 화면입니다.";
        }

        private void ClearSearchOption()
        {
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchProduct.CodeTextBox.Clear();
            searchWorker.CodeTextBox.Clear();
            searchPeriod.Startdate.Clear();
            searchPeriod.Enddate.Clear();
            searchPeriodForBy.Startdate.Clear();
            searchPeriodForBy.Enddate.Clear();
        }

        private void SettingByLineColumns(DataColumnCollection dc)
        {
            foreach (DataColumn item in dc)
            {
                string name = item.ColumnName;
                if (name == "Line_Name")
                {
                    UtilClass.AddNewColum(dgvDefectiveByLine, "공정명", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else if (name == "Product_Name")
                {
                    UtilClass.AddNewColum(dgvDefectiveByLine, "상품명", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDefectiveByLine, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
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
                    UtilClass.AddNewColum(dgvDefectiveByDefecType, "불량유형", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDefectiveByDefecType, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
                }
            }
        }

        private void Defective_Activated(object sender, EventArgs e)
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

        private void Defective_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Defective_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvDefective.ClearSelection();
            dgvDefective.CurrentCell = null;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (tabDefective.SelectedIndex==0)
            {
                if (searchFactory.CodeTextBox.Tag == null && searchLine.CodeTextBox.Tag == null && searchProduct.CodeTextBox.Tag == null && searchWorker.CodeTextBox.Tag == null && searchPeriod.Startdate.Tag == null && searchPeriod.Enddate.Tag == null)
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
                    if (searchWorker.CodeTextBox.Tag != null)
                    {
                        searchedlist = (from item in searchedlist
                                        where item.Employees_ID == Convert.ToInt32(searchWorker.CodeTextBox.Tag)
                                        select item).ToList();
                    }
                    if (searchPeriod.Startdate.Tag != null && searchPeriod.Enddate.Tag != null)
                    {
                        searchedlist = (from item in searchedlist
                                        where Convert.ToDateTime(item.Defective_HandleDate) >= Convert.ToDateTime(searchPeriod.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Defective_HandleDate) <= Convert.ToDateTime(searchPeriod.Enddate.Tag.ToString())
                                        select item).ToList();
                    }
                    dgvDefective.DataSource = searchedlist;
                    frm.NoticeMessage = "검색 완료";
                } 
            }
            else if (tabDefective.SelectedIndex == 1)
            {
                if (searchPeriodForBy.Startdate.Tag != null && searchPeriodForBy.Enddate.Tag != null)
                {
                    GetSearchDays();
                    ds1.Clear();
                    ds1 = service.GetDefectiveByLine(sb.ToString().TrimEnd(','));
                    DataTable searcheddt = ds1.Tables[0].Copy();
                    dgvDefectiveByLine.Columns.Clear();
                    CalcTotaltime(searcheddt);
                    SettingByLineColumns(searcheddt.Columns);
                    //SetDoNotSort(dgvDowntimeByLine);
                    //dgvDowntimeByLine.DataSource = searcheddt;
                    frm.NoticeMessage = "검색 완료";
                }
                else
                {
                    RefreshClicked();
                }
            }
            
        }

        private void CalcTotaltime(DataTable dt)
        {
            dt.Columns.Add("불량개수", typeof(string));
            TimeSpan time = new TimeSpan();
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (row[dt.Columns[i].ColumnName].ToString() != string.Empty)
                    {
                        time += TimeSpan.Parse(row[dt.Columns[i]].ToString());

                    }
                    if (time.ToString("hh\\:mm\\:ss") != "00:00:00")
                    {
                        row["불량개수"] = time.ToString("hh\\:mm\\:ss");
                        time = new TimeSpan();
                    }
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

        
    }
}
