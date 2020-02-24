using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Defective : BaseForm
    {
        #region 전역변수
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
        #endregion

        #region 폼관련
        /// <summary>
        /// 생성자
        /// </summary>
        public Defective()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 로드 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defective_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm; // 부모폼을 저장
            SettingDgvDefective();
            RefreshClicked();
            frm.NoticeMessage = notice;
            SetEssentialSearchOption();
        }

        /// <summary>
        /// 필수입력정보 색상설정 메서드
        /// </summary>
        private void SetEssentialSearchOption()
        {
            searchPeriod.Startdate.BackColor = Color.LightYellow;
            searchPeriod.Enddate.BackColor = Color.LightYellow;
            searchPeriodForBy1.Startdate.BackColor = Color.LightYellow;
            searchPeriodForBy1.Enddate.BackColor = Color.LightYellow;
            searchPeriodForBy2.Startdate.BackColor = Color.LightYellow;
            searchPeriodForBy2.Enddate.BackColor = Color.LightYellow;
            searchPeriodForBy3.Startdate.BackColor = Color.LightYellow;
            searchPeriodForBy3.Enddate.BackColor = Color.LightYellow;
        }

        /// <summary>
        /// 검색옵션 초기화 메서드
        /// </summary>
        private void ClearSearchOption()
        {
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchProduct.CodeTextBox.Clear();
            searchWorker.CodeTextBox.Clear();
            searchPeriod.Startdate.Clear();
            searchPeriod.Enddate.Clear();
            searchPeriodForBy1.Startdate.Clear();
            searchPeriodForBy1.Enddate.Clear();
            searchPeriodForBy2.Startdate.Clear();
            searchPeriodForBy2.Enddate.Clear();
            searchPeriodForBy3.Startdate.Clear();
            searchPeriodForBy3.Enddate.Clear();
        }

        /// <summary>
        /// 활성화 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defective_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = searchFactory;
            searchFactory.Focus();
            frm.NoticeMessage = notice;
            frm.인쇄ToolStripMenuItem.DropDownItems[1].Visible = false;
        }

        /// <summary>
        /// 비활성화 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defective_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
            frm.인쇄ToolStripMenuItem.DropDownItems[1].Visible = true;
        }

        /// <summary>
        /// 화면 보일때 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defective_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void tabDefective_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDefective.SelectedIndex == 0)
            {
                SearchArea.Visible = true;
                searchPeriodForBy1.Visible = false;
                searchPeriodForBy2.Visible = false;
                searchPeriodForBy3.Visible = false;
            }
            else if (tabDefective.SelectedIndex == 1)
            {
                SearchArea.Visible = false;
                searchPeriodForBy1.Visible = true;
                searchPeriodForBy2.Visible = false;
                searchPeriodForBy3.Visible = false;
            }
            else if (tabDefective.SelectedIndex == 2)
            {
                SearchArea.Visible = false;
                searchPeriodForBy1.Visible = false;
                searchPeriodForBy2.Visible = true;
                searchPeriodForBy3.Visible = false;
            }
            else if (tabDefective.SelectedIndex == 3)
            {
                SearchArea.Visible = false;
                searchPeriodForBy1.Visible = false;
                searchPeriodForBy2.Visible = false;
                searchPeriodForBy3.Visible = true;
            }
        }
        #endregion


        #region DataGridView관련
        /// <summary>
        /// Dgv의 처음 바인딩후 선택제거 메서드
        /// </summary>
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
        /// <summary>
        /// Dgv설정 메서드
        /// </summary>
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

        /// <summary>
        /// 정렬기능 해제 메서드
        /// </summary>
        /// <param name="dgv"></param>
        private void SetDoNotSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn i in dgv.Columns)
            {
                i.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 라인별 화면 컬럼 설정 메서드
        /// </summary>
        /// <param name="dc"></param>
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

        /// <summary>
        /// 유형별 화면 컬럼 설정 메서드
        /// </summary>
        /// <param name="dc"></param>
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

        /// <summary>
        /// 처리유형별 화면 컬럼 설정 메서드
        /// </summary>
        /// <param name="dc"></param>
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

        /// <summary>
        /// Dgv DataBinding 메서드
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dt"></param>
        private void BindingDgv(DataGridView dgv, DataTable dt)
        {
            dgv.Columns.Clear();
            if (dgv.Name == "dgvDefectiveByLine")
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
                CalcTotal(dt);
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

        /// <summary>
        /// 총 불량개수 구하는 메서드
        /// </summary>
        /// <param name="dt"></param>
        private void CalcTotal(DataTable dt)
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

        /// <summary>
        /// 총 불량개수 구하는 메서드2
        /// </summary>
        /// <param name="dt"></param>
        private void CalcTotaltime2(DataTable dt)
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

        /// <summary>
        /// 검색날짜범위 구하는 메서드
        /// </summary>
        /// <param name="sp"></param>
        private void GetSearchDays(SearchPeriodControl sp)
        {
            sb.Clear();
            DateTime date = Convert.ToDateTime(sp.Startdate.Text);
            while (DateTime.Compare(date, Convert.ToDateTime(sp.Enddate.Text).AddDays(1)) != 0)
            {
                sb.Append($"[{date.ToString("yyyy-MM-dd")}],");
                date = date.AddDays(1);
            }
        }
        #endregion

        #region 버튼이벤트관련
        /// <summary>
        /// 새로고침 버튼클릭 이벤트
        /// </summary>
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
                dgvDefectiveByLine.Columns[1].Visible = false;
                SetDoNotSort(dgvDefectiveByLine);

                dgvDefectiveByDefecType.Columns.Clear();
                SettingByTypeColumns(dtbytype.Columns);
                dgvDefectiveByDefecType.Columns[1].Visible = false;
                SetDoNotSort(dgvDefectiveByDefecType);

                dgvDefectiveByDefecHandleType.Columns.Clear();
                SettingByHandleColumns(dtbyhandle.Columns);
                dgvDefectiveByDefecHandleType.Columns[1].Visible = false;
                SetDoNotSort(dgvDefectiveByDefecHandleType);

                dgvDefective.DataSource = null;
                dgvDefectiveByLine.DataSource = dtbyline.Clone();
                dgvDefectiveByDefecType.DataSource = dtbytype.Clone();
                dgvDefectiveByDefecHandleType.DataSource = dtbyhandle.Clone();
                if (!isFirst) // 처음켜진게 아니면
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
                Log.WriteError(err.Message, err);
            }
            ClearSearchOption();
            frm.NoticeMessage = Resources.RefreshDone;
            isFirst = false;
        }
        #endregion



        #region 상속메서드들
        /// <summary>
        /// 메뉴 ON/OFF 메서드
        /// </summary>
        /// <param name="flag"></param>
        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = flag;
        }

        /// <summary>
        /// 새로고침 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        /// <summary>
        /// 검색 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Search(object sender, EventArgs e)
        {
            if (tabDefective.SelectedIndex == 0)
            {
                if (searchPeriod.Startdate.Tag == null || searchPeriod.Enddate.Tag == null)
                {
                    frm.NoticeMessage = Resources.PeriodError;
                }
                else
                {
                    searchedlist = list;
                    if (searchPeriod.Startdate.Tag != null && searchPeriod.Enddate.Tag != null)
                    {
                        searchedlist = (from item in searchedlist
                                        where Convert.ToDateTime(item.Defective_HandleDate) >= Convert.ToDateTime(searchPeriod.Startdate.Tag.ToString()) && Convert.ToDateTime(item.Defective_HandleDate) <= Convert.ToDateTime(searchPeriod.Enddate.Tag.ToString())
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
                    if (searchWorker.CodeTextBox.Tag != null)
                    {
                        searchedlist = (from item in searchedlist
                                        where item.Employees_ID == Convert.ToInt32(searchWorker.CodeTextBox.Tag)
                                        select item).ToList();
                    }

                    dgvDefective.DataSource = searchedlist;
                    frm.NoticeMessage = Resources.SearchDone;
                }
            }
            else if (tabDefective.SelectedIndex == 1)
            {
                if (searchPeriodForBy1.Startdate.Tag != null && searchPeriodForBy1.Enddate.Tag != null)
                {
                    GetSearchDays(searchPeriodForBy1);
                    ds1.Clear();
                    try
                    {
                        ds1 = service.GetDefectiveByLine(sb.ToString().TrimEnd(','));
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    DataTable searcheddt = ds1.Tables[0].Copy();
                    BindingDgv(dgvDefectiveByLine, searcheddt);
                    frm.NoticeMessage = Resources.SearchDone;
                }
                else
                {
                    frm.NoticeMessage = "기간을 선택하셔야 합니다.";
                }
            }
            else if (tabDefective.SelectedIndex == 2)
            {
                if (searchPeriodForBy1.Startdate.Tag != null && searchPeriodForBy1.Enddate.Tag != null)
                {
                    GetSearchDays(searchPeriodForBy2);
                    ds2.Clear();
                    try
                    {
                        ds2 = service.GetDefectiveByDeftiveType(sb.ToString().TrimEnd(','));
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    DataTable searcheddt = ds2.Tables[0].Copy();
                    BindingDgv(dgvDefectiveByDefecType, searcheddt);
                    frm.NoticeMessage = Resources.SearchDone;
                }
                else
                {
                    frm.NoticeMessage = Resources.PeriodError;
                }
            }
            else if (tabDefective.SelectedIndex == 3)
            {
                if (searchPeriodForBy1.Startdate.Tag != null && searchPeriodForBy1.Enddate.Tag != null)
                {
                    GetSearchDays(searchPeriodForBy3);
                    ds3.Clear();
                    try
                    {
                        ds3 = service.GetDefectiveByDeftiveHandleType(sb.ToString().TrimEnd(','));
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    DataTable searcheddt = ds3.Tables[0].Copy();
                    BindingDgv(dgvDefectiveByDefecHandleType, searcheddt);
                    frm.NoticeMessage = Resources.SearchDone;
                }
                else
                {
                    frm.NoticeMessage = Resources.PeriodError;
                }
            }

        }
        
        /// <summary>
        /// 엑셀버튼 클릭 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Excel(object sender, EventArgs e)
        {
            if ((tabDefective.SelectedIndex == 0 && dgvDefective.Rows.Count > 0) || (tabDefective.SelectedIndex == 1 && dgvDefectiveByLine.Rows.Count > 0) || (tabDefective.SelectedIndex == 2 && dgvDefectiveByDefecType.Rows.Count > 0) || (tabDefective.SelectedIndex == 3 && dgvDefectiveByDefecHandleType.Rows.Count > 0))
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
            string[] exceptlist = new string[] { "DefectiveHandle_ID", "DefectiveType_ID", "Employees_ID", "Factory_ID", "Line_ID", "Product_ID" };
            if (tabDefective.SelectedIndex == 0)
            {
                UtilClass.ExportToDataGridView(dgvDefective, exceptlist);
            }
            else if (tabDefective.SelectedIndex == 1)
            {
                UtilClass.ExportToDataGridView(dgvDefectiveByLine, exceptlist);
            }
            else if (tabDefective.SelectedIndex == 2)
            {
                UtilClass.ExportToDataGridView(dgvDefectiveByDefecType, exceptlist);
            }
            else
            {
                UtilClass.ExportToDataGridView(dgvDefectiveByDefecHandleType, exceptlist);
            }
        }

        #endregion

    }
}