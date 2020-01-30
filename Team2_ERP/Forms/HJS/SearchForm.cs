using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class SearchForm : Form
    {
        public SearchUserControl.Mode Mode { get; set; }
        string col1 = string.Empty;
        string col2 = string.Empty;
        int width1 = 0;
        int width2 = 0;
        public SearchedInfoVO info { get; set; }
        List<SearchedInfoVO> list;
        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(SearchedInfoVO info)
        {
            InitializeComponent();
            this.info = info;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            UtilClass.SettingDgv(dgvSearch);
            SettingData();
        }

        private void SettingData()
        {
            
            switch (Mode.ToString())
            {
                case "Employee":
                    SettingForm("사원", 100, 160);
                    break;
                case "DepOperation":
                    SettingForm("운영기획부사원", 160, 160);
                    break;
                case "DepMaterial":
                    SettingForm("자재부사원", 160, 160);
                    break;
                case "DepProd1":
                    SettingForm("생산1부사원", 160, 160);
                    break;
                case "DepProd2":
                    SettingForm("생산2부사원", 160, 160);
                    break;
                case "DepSales":
                    SettingForm("영업부사원", 160, 160);
                    break;
                case "Defective":
                    SettingForm("불량유형", 130, 160);
                    break;
                case "Product":
                    SettingForm("제품", 100, 300);
                    break;
                case "Meterial":
                    SettingForm("원자재", 100, 300);
                    break;
                case "SemiProduct":
                    SettingForm("반제품", 100, 300);
                    break;
                case "Downtime":
                    SettingForm("비가동유형", 160, 160);
                    break;
                case "Factory":
                    SettingForm("공장", 100, 160);
                    break;
                case "Line":
                    SettingForm("공정", 100, 160);
                    break;
                case "Customer":                    
                    SettingForm("고객", 100, 160);
                    break;
                case "Department":
                    SettingForm("부서", 100, 160);
                    break;
                case "Warehouse":
                    SettingForm("창고", 100, 160);
                    break;
                case "Company":
                    SettingForm("거래처", 100, 160);
                    break;
                case "ProductCategory":
                    SettingForm("제품카테고리", 150, 160);
                    break;
                case "Worker":
                    SettingForm("작업자", 100, 160);
                    break;
                case "Handle":
                    SettingForm("불량처리유형", 150, 160);
                    break;
                case "AllProduct":
                    SettingForm("품목", 100,160);
                    break;
            }

            txtSearch.PlaceHolderText = string.Concat(this.Text, " ", "키워드 입력");
            // Mode값에 따라 그리드뷰 컬럼명 및 검색 결과 
            UtilClass.SettingDgv(dgvSearch);
            UtilClass.AddNewColum(dgvSearch, col1, "ID",true,width1);
            UtilClass.AddNewColum(dgvSearch, col2, "Name", true, width2);
            try
            {
                SearchService service = new SearchService();
                list = service.GetInfo(Mode.ToString());
                dgvSearch.DataSource = list;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void SettingForm(string Text,int col1width, int col2width)
        {
            this.Text = Text;
            col1 = this.Text + "번호";
            col2 = this.Text + "명";
            width1 = col1width;
            width2 = col2width;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dgvSearch.SelectedRows.Count > 0 && info != null)
            {
                info.ID = dgvSearch.SelectedRows[0].Cells[0].Value.ToString();
                info.Name = dgvSearch.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            btnOK.PerformClick();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.isPlaceHolder)
            {
                dgvSearch.DataSource = list;
            }
            else
            {
                List<SearchedInfoVO> searchedInfo = (from item in list
                                                     where item.Name.Contains                                         (txtSearch.Text)
                                                     select item).ToList();
                dgvSearch.DataSource = searchedInfo;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch.PerformClick();
            }
        }

        private void dgvSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                int row = dgvSearch.CurrentCell.RowIndex;
                dgvSearch.CurrentCell = dgvSearch[0, row - 1];
                btnOK.PerformClick();
            }
        }
    }
}
