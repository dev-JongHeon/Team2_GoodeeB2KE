using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Service;
using Team2_VO;
using DevExpress.XtraReports.UI;
using Team2_ERP.Properties;

namespace Team2_ERP
{
    public partial class BaljuList : Base2Dgv
    {
        #region 전역변수
        BaljuService service = new BaljuService();
        List<Balju> Balju_AllList = null;  // Masters
        List<BaljuDetail> BaljuDetail_AllList = null;  // Details
        List<Balju> SearchedList = null;  // 검색용
        MainForm main;
        CheckBox headerCheckbox = new CheckBox();  // 그리드뷰 맨앞 체크박스헤더
        #endregion

        public BaljuList()
        {
            InitializeComponent();
        }

        private void BaljuList_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        #region 체크박스 관련기능
        private void headerCheckbox_Click(object sender, EventArgs e)  // 체크박스 헤더 클릭 시 전체 체크/해제
        {
            dgv_Balju.EndEdit();
            foreach (DataGridViewRow row in dgv_Balju.Rows)
            {
                row.Cells[0].Value = headerCheckbox.Checked;
            }
        }

        private void dgv_Balju_CellContentClick(object sender, DataGridViewCellEventArgs e)  // 하나라도 체크안돼있으면 맨위 체크 품
        {
            if (dgv_Balju.Rows.Count > 0 && e.ColumnIndex == 0)
            {
                bool isChecked = true;
                foreach (DataGridViewRow row in dgv_Balju.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[0].EditedFormattedValue))
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckbox.Checked = isChecked;
            }
        }

        private void dgv_Balju_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)  // 체크박스 위치 바꿔주는 이벤트
        {
            Point headerLocation = dgv_Balju.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckbox.Location = new Point((headerLocation.X + dgv_Balju.Columns[0].Width / 2) - 7, headerLocation.Y + dgv_Balju.ColumnHeadersHeight / 5 + 1);
        }
        #endregion

        #region dgv 관련기능
        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Balju);

            #region 체크박스 컬럼추가
            DataGridViewCheckBoxColumn cbx = new DataGridViewCheckBoxColumn();
            cbx.DataPropertyName = "Check";
            cbx.Width = 30;
            dgv_Balju.Columns.Add(cbx);
            Point headerLocation = dgv_Balju.GetCellDisplayRectangle(0, -1, true).Location;
            headerCheckbox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 5);
            headerCheckbox.BackColor = Color.FromArgb(55, 113, 138);
            headerCheckbox.Size = new Size(16, 16);
            headerCheckbox.Click += new EventHandler(headerCheckbox_Click);
            dgv_Balju.Controls.Add(headerCheckbox);
            dgv_Balju.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            #endregion

            //dgv_Balju.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            UtilClass.AddNewColum(dgv_Balju, "발주지시번호", "Balju_ID", true, 130);
            UtilClass.AddNewColum(dgv_Balju, "거래처코드", "Company_ID", true, 110);
            UtilClass.AddNewColum(dgv_Balju, "거래처명칭", "Company_Name", true, 300);
            UtilClass.AddNewColum(dgv_Balju, "발주요청일시", "Balju_Date", true, 170);
            UtilClass.AddNewColum(dgv_Balju, "요청등록사원", "Employees_Name", true, 200);
            UtilClass.AddNewColum(dgv_Balju, "총액", "Total", true, 170);
            UtilClass.AddNewColum(dgv_Balju, "삭제여부", "Balju_DeletedYN", false);

            dgv_Balju.Columns[0].MinimumWidth = 30;
            dgv_Balju.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Balju.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Balju.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Balju.Columns[6].DefaultCellStyle.Format = "#,#0원";
            try { Balju_AllList = service.GetBaljuList(); }  // 발주리스트 갱신
            catch (Exception err) { Log.WriteError(err.Message, err); }

            UtilClass.SettingDgv(dgv_BaljuDetail);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", false, 130);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true, 100);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true, 500);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true, 130);
            dgv_BaljuDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_BaljuDetail.Columns[3].DefaultCellStyle.Format = "#,#0개";

            Search_Period.Startdate.BackColor = Color.LightYellow;
            Search_Period.Enddate.BackColor = Color.LightYellow;
        }

        private void dgv_Balju_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Master 더블클릭 이벤트
        {
            if (e.RowIndex > -1)
            {
                bool isChecked = true;
                string Balju_ID = dgv_Balju.CurrentRow.Cells[1].Value.ToString();
                List<BaljuDetail> BaljuDetail_List = (from list_detail in BaljuDetail_AllList
                                                      where list_detail.Balju_ID == Balju_ID
                                                      select list_detail).ToList();
                dgv_BaljuDetail.DataSource = BaljuDetail_List;

                if (Convert.ToBoolean(dgv_Balju.Rows[e.RowIndex].Cells[0].Value))  // 체크가 되어있으면
                    dgv_Balju.Rows[e.RowIndex].Cells[0].Value = false;              // 체크풀어줌
                else
                    dgv_Balju.Rows[e.RowIndex].Cells[0].Value = true;               // 체크 안되어있으면 다시체크
                
                foreach (DataGridViewRow row in dgv_Balju.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[0].EditedFormattedValue))
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckbox.Checked = isChecked;
            }
        }

        private void GetBaljuDetail_List()  // 현재 Dgv에 맞추어 DetailList 가져옴
        {
            if (dgv_Balju.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow row in dgv_Balju.Rows)
                {
                    sb.Append($"'{row.Cells[1].Value.ToString()}',");
                }

                try { BaljuDetail_AllList = service.GetBalju_DetailList(sb.ToString().Trim(',')); }  // BaljuDetail_AllList 갱신
                catch (Exception err) { Log.WriteError(err.Message, err); } 
            }
        }

        private bool Check_ExistCheckedRows()
        {
            bool check = false;
            foreach (DataGridViewRow row in dgv_Balju.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].EditedFormattedValue))  // 체크된 Row가 하나라도 있으면 check에 true 저장 없으면 그대로 false반환
                { 
                    check = true;
                    return check;
                }
            }
            return check;
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
            dgv_Balju.DataSource = null;

            try { Balju_AllList = service.GetBaljuList(); }  // Balju_AllList 갱신
            catch (Exception err) { Log.WriteError(err.Message, err); }

            // 검색조건 초기화
            Search_Period.Startdate.Clear();
            Search_Period.Enddate.Clear();
            Search_Company.CodeTextBox.Clear();
            Search_Employee.CodeTextBox.Clear();
            headerCheckbox.Checked = false;
        }
        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_Period.Startdate.Text == "    -  -") { main.NoticeMessage = Resources.PeriodError; }
            else
            {
                SearchedList = Balju_AllList;
                if (Search_Company.CodeTextBox.Text.Length > 0)  // 회사 검색조건
                {
                    SearchedList = (from item in SearchedList
                                    where item.Company_Name == Search_Company.CodeTextBox.Text
                                    select item).ToList();
                }
                if (Search_Employee.CodeTextBox.Text.Length > 0)  // 사원 검색조건
                {
                    SearchedList = (from item in SearchedList
                                    where item.Employees_Name == Search_Employee.CodeTextBox.Text
                                    select item).ToList();
                }
                if (Search_Period.Startdate.Text != "    -  -")   // 기간 검색조건
                {
                    SearchedList = (from item in SearchedList
                                    where item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                            item.Balju_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                    select item).ToList();
                }
                dgv_Balju.DataSource = SearchedList;
                dgv_BaljuDetail.DataSource = null;
                GetBaljuDetail_List();  // BaljuDetail_AllList 갱신
                headerCheckbox.Checked = false;
                main.NoticeMessage = Resources.SearchDone;
            }
        }



        public override void Modify(object sender, EventArgs e)  // 발주완료(수령)처리
        {
            if (dgv_Balju.Rows.Count == 0 || Check_ExistCheckedRows() != true) main.NoticeMessage = Resources.NonData;  // 데이터소스가 0개이거나, 체크된게 하나도 없으면
            else
            {
                if (MessageBox.Show(Resources.IsBalju, notice, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> IDList = new List<string>();
                    foreach (DataGridViewRow item in dgv_Balju.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].EditedFormattedValue) != false)
                        {
                            IDList.Add(item.Cells[1].Value.ToString());
                        }
                    }
                    bool check = true;

                    try { check = service.UpdateBalju_Processed(IDList, Session.Employee_ID); }
                    catch (Exception err) { Log.WriteError(err.Message, err); }

                    Func_Refresh();  // 새로고침
                    main.NoticeMessage = notice;

                    if (check) MessageBox.Show(Resources.ProcessSuccess, Resources.Notice);
                    else MessageBox.Show(Resources.ProcessFail, Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Resources.Cancel, Resources.Notice);
                    main.NoticeMessage = notice;
                }
            }
        }

        public override void Delete(object sender, EventArgs e)  // 삭제
        {
            if (dgv_Balju.Rows.Count == 0 || Check_ExistCheckedRows() != true) main.NoticeMessage = Resources.NonData;  // 데이터소스가 0개이거나, 체크된게 하나도 없으면
            else
            {
                if (MessageBox.Show(Resources.IsDeleteBalju, Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<string> IDList = new List<string>();
                    foreach (DataGridViewRow item in dgv_Balju.Rows)
                    {
                        if (Convert.ToBoolean(item.Cells[0].EditedFormattedValue) != false)
                        {
                            IDList.Add(item.Cells[1].Value.ToString());
                        }
                    }
                    bool check = true;

                    try { service.DeleteBalju(IDList); }
                    catch (Exception err) { Log.WriteError(err.Message, err); }

                    Func_Refresh();  // 새로고침
                    main.NoticeMessage = notice;

                    if (check) MessageBox.Show(Resources.ProcessSuccess, Resources.Notice);
                    else MessageBox.Show(Resources.ProcessFail, Resources.Notice, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(Resources.Cancel);
                    main.NoticeMessage = notice;
                }
            }
        }

        public override void Excel(object sender, EventArgs e)  // 엑셀 내보내기
        {
            if (dgv_Balju.Rows.Count == 0) main.NoticeMessage = Resources.ExcelError;
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
            string[] exceptColumns = { "Balju_DeletedYN", "Balju_ReceiptDate" };
            UtilClass.ExportTo2DataGridView(master, detail, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 보고서 인쇄
        {
            if (dgv_Balju.Rows.Count == 0) main.NoticeMessage = Resources.NonData;
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
            BaljuReport br = new BaljuReport();
            dsBalju ds = new dsBalju();

            ds.Relations.Clear();
            ds.Tables.Clear();
            ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
            ds.Tables.Add(UtilClass.ConvertToDataTable(BaljuDetail_AllList));
            ds.Tables[0].TableName = "dtBalju";
            ds.Tables[1].TableName = "dtBalju_Detail";
            ds.Relations.Add("dtBalju_dtBalju_Detail", ds.Tables[0].Columns["Balju_ID"], ds.Tables[1].Columns["Balju_ID"]);

            //dOrg.Tables.Add(UtilClass.ConvertToDataTable(BaljuDetail_AllList));
            //ds = (dsBalju)dOrg;
            ds.AcceptChanges();

            br.DataSource = ds;

            ReportPrintTool printTool = new ReportPrintTool(br);
           
            printTool.ShowRibbonPreviewDialog();
        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void BaljuList_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.수정ToolStripMenuItem.Text = "처리";
            main.수정ToolStripMenuItem.ToolTipText = "처리(Ctrl+M)";
            main.NoticeMessage = notice;
        }
   

        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = flag;
            main.삭제ToolStripMenuItem.Visible = flag;
            main.인쇄ToolStripMenuItem.Visible = flag;
            dgv_Balju.Columns[0].Visible = flag;
            headerCheckbox.Visible = flag;


        }

        private void BaljuList_Deactivate(object sender, EventArgs e)
        {
            main.수정ToolStripMenuItem.Text = "수정";
            main.수정ToolStripMenuItem.ToolTipText = "수정(Ctrl+M)";
            new SettingMenuStrip().UnsetMenu(this);
        }

        #endregion
    }
}
