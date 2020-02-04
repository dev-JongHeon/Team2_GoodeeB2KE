using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            frm.NoticeMessage = notice;
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
                SettingByHandleColumns(dtbyhandle.Columns);
                SetDoNotSort(dgvDefectiveByDefecHandleType);

                dgvDefective.DataSource = null;
                dgvDefectiveByLine.DataSource = dtbyline.Clone();
                dgvDefectiveByDefecType.DataSource= dtbytype.Clone();
                dgvDefectiveByDefecHandleType.DataSource = dtbyhandle.Clone();
                if (!isFirst)
                {
                    if (tabDefective.SelectedIndex == 0)
                    {
                        dgvDefective.DataSource = list;
                    }
                    else if (tabDefective.SelectedIndex == 1)
                    {
                        BindingDgv(dgvDefectiveByLine, dtbyline);
                    }
                    else if (tabDefective.SelectedIndex == 2)
                    {
                        BindingDgv(dgvDefectiveByDefecType, dtbytype);
                    }
                    else
                    {
                        BindingDgv(dgvDefectiveByDefecHandleType, dtbyhandle);
                    }
                    ClearDgv();
                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            ClearSearchOption();
            frm.NoticeMessage = Properties.Settings.Default.RefreshDone;
            isFirst = false;
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
                    UtilClass.AddNewColum(dgvDefectiveByLine, "상품명", $"{name}", true, 130, DataGridViewContentAlignment.MiddleCenter);
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

                if (name == "DefectiveType_Name")
                {
                    UtilClass.AddNewColum(dgvDefectiveByDefecType, "불량유형", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDefectiveByDefecType, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
                }
            }
        }

        private void SettingByHandleColumns(DataColumnCollection dc)
        {
            foreach (DataColumn item in dc)
            {
                string name = item.ColumnName;

                if (name == "DefectiveHandleName")
                {
                    UtilClass.AddNewColum(dgvDefectiveByDefecHandleType, "불량처리유형", $"{name}", true, 150, DataGridViewContentAlignment.MiddleCenter);
                }
                else
                {
                    UtilClass.AddNewColum(dgvDefectiveByDefecHandleType, $"{name}", $"{name}", true, 130, DataGridViewContentAlignment.MiddleRight);
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
            dgvDefectiveByLine.ClearSelection();
            dgvDefectiveByLine.CurrentCell = null;
            dgvDefectiveByDefecType.ClearSelection();
            dgvDefectiveByDefecType.CurrentCell = null;
            dgvDefectiveByDefecHandleType.ClearSelection();
            dgvDefectiveByDefecHandleType.CurrentCell = null;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (tabDefective.SelectedIndex==0)
            {
                if (searchFactory.CodeTextBox.Tag == null && searchLine.CodeTextBox.Tag == null && searchProduct.CodeTextBox.Tag == null && searchWorker.CodeTextBox.Tag == null && searchPeriod.Startdate.Tag == null && searchPeriod.Enddate.Tag == null)
                {
                    RefreshClicked();
                    frm.NoticeMessage = notice;
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
                    frm.NoticeMessage = Properties.Settings.Default.SearchDone;
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
                    BindingDgv(dgvDefectiveByLine, searcheddt);
                    frm.NoticeMessage = Properties.Settings.Default.SearchDone;
                }
                else
                {
                    RefreshClicked();
                    frm.NoticeMessage = notice;
                }
            }
            else if (tabDefective.SelectedIndex == 2)
            {
                if (searchPeriodForBy.Startdate.Tag != null && searchPeriodForBy.Enddate.Tag != null)
                {
                    GetSearchDays();
                    ds2.Clear();
                    ds2 = service.GetDefectiveByDeftiveType(sb.ToString().TrimEnd(','));
                    DataTable searcheddt = ds2.Tables[0].Copy();
                    BindingDgv(dgvDefectiveByDefecType, searcheddt);
                    frm.NoticeMessage = Properties.Settings.Default.SearchDone;
                }
                else
                {
                    RefreshClicked();
                    frm.NoticeMessage = notice;
                }
            }
            else if (tabDefective.SelectedIndex == 3)
            {
                if (searchPeriodForBy.Startdate.Tag != null && searchPeriodForBy.Enddate.Tag != null)
                {
                    GetSearchDays();
                    ds3.Clear();
                    ds3 = service.GetDefectiveByDeftiveHandleType(sb.ToString().TrimEnd(','));
                    DataTable searcheddt = ds3.Tables[0].Copy();
                    BindingDgv(dgvDefectiveByDefecHandleType,searcheddt);
                    frm.NoticeMessage = Properties.Settings.Default.SearchDone;
                }
                else
                {
                    RefreshClicked();
                    frm.NoticeMessage = notice;
                }
            }
            
        }

        private void BindingDgv(DataGridView dgv, DataTable dt)
        {
            dgv.Columns.Clear();
            if (dgv.Name== "dgvDefectiveByLine")
            {
                CalcTotaltime2(dt);
                SettingByLineColumns(dt.Columns);
                dgv.DataSource = dt;
                for (int i = 2; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].DefaultCellStyle.Format = "#개";
                }
            }
            else
            {
                CalcTotaltime(dt);
                if (dgv.Name == "dgvDefectiveByDefecType")
                { 
                    SettingByTypeColumns(dt.Columns);
                }
                else
                {
                    SettingByHandleColumns(dt.Columns);
                }
                dgv.DataSource = dt;
                for (int i = 1; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].DefaultCellStyle.Format = "#개";
                }
            }
            SetDoNotSort(dgv);
        }

        private void CalcTotaltime(DataTable dt)
        {
            dt.Columns.Add("불량개수", typeof(string));
            int sum = 0;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i < dt.Columns.Count - 1; i++)
                {
                    if (row[dt.Columns[i].ColumnName].ToString() != string.Empty)
                    {
                        sum += Convert.ToInt32(row[dt.Columns[i]].ToString());
                    }
                }
                if (sum == 0)
                {
                    row["불량개수"] = null;
                }
                else
                {
                    row["불량개수"] = $"{sum}개";
                }
                sum = 0;
            }
        }
        private void CalcTotaltime2(DataTable dt)
        {
            dt.Columns.Add("불량개수", typeof(string));
            int sum = 0;
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 2; i < dt.Columns.Count - 1; i++)
                {
                    if (row[dt.Columns[i].ColumnName].ToString() != string.Empty)
                    {
                        sum += Convert.ToInt32(row[dt.Columns[i]].ToString());
                    }
                }
                if (sum == 0)
                {
                    row["불량개수"] = null;
                }
                else
                {
                    row["불량개수"] = $"{sum}개";
                }
                sum = 0;
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
            using (WaitForm frm = new WaitForm())
            {
                frm.Processing = ExportExcel;
                frm.ShowDialog();
            }
        }

        private void ExportExcel()
        {
            Thread.Sleep(10 * 1000);
        }

        public override void Print(object sender, EventArgs e)
        {
            MessageBox.Show("프린트");
        }

        private void tabDefective_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDefective.SelectedIndex != 0)
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
    }
}
