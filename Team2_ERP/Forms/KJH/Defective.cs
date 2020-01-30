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
        public Defective()
        {
            InitializeComponent();
        }

        private void Defective_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDefective);
            UtilClass.AddNewColum(dgvDefective, "생산실적번호", "Performance_ID",true,130);
            UtilClass.AddNewColum(dgvDefective, "공장번호", "Factory_ID",false);
            UtilClass.AddNewColum(dgvDefective, "공장명", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvDefective, "공정번호", "Line_ID",false);
            UtilClass.AddNewColum(dgvDefective, "공정명", "Line_Name", true, 100);
            UtilClass.AddNewColum(dgvDefective, "품목번호", "Product_ID", false);
            UtilClass.AddNewColum(dgvDefective, "품목명", "Product_Name", true, 150);
            UtilClass.AddNewColum(dgvDefective, "불량유형번호", "DefectiveType_ID", false);
            UtilClass.AddNewColum(dgvDefective, "불량유형", "DefectiveType_Name", true, 100);
            UtilClass.AddNewColum(dgvDefective, "불량처리유형번호", "DefectiveHandle_ID", false);
            UtilClass.AddNewColum(dgvDefective, "불량처리유형", "DefectiveHandle_Name", true, 130);
            UtilClass.AddNewColum(dgvDefective, "작업자번호", "Employees_ID", false);
            UtilClass.AddNewColum(dgvDefective, "작업자", "Employees_Name", true, 100);
            UtilClass.AddNewColum(dgvDefective, "불량개수", "Defective_Num", true, 100);
            UtilClass.AddNewColum(dgvDefective, "처리날짜", "Defective_HandleDate", true, 100);
            dgvDefective.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDefective.Columns[13].DefaultCellStyle.Format = "#개";
            dgvDefective.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                DefectiveService service = new DefectiveService();
                list = service.GetAllDefective();
                dgvDefective.DataSource = list;
                dgvDefective.ClearSelection();
                dgvDefective.CurrentCell = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            searchFactory.CodeTextBox.Clear();
            searchLine.CodeTextBox.Clear();
            searchProduct.CodeTextBox.Clear();
            searchWorker.CodeTextBox.Clear();
            searchPeriod.Startdate.Clear();
            searchPeriod.Enddate.Clear();
            frm.NoticeMessage = "불량처리현황 화면입니다.";
        }

        private void Defective_Activated(object sender, EventArgs e)
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
            if(searchFactory.CodeTextBox.Tag==null&& searchLine.CodeTextBox.Tag == null&& searchProduct.CodeTextBox.Tag == null&& searchWorker.CodeTextBox.Tag == null&& searchPeriod.Startdate.Tag == null && searchPeriod.Enddate.Tag == null)
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
    }
}
