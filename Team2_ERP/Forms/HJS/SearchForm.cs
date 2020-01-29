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
            string col1 = string.Empty;
            string col2 = string.Empty;
            switch (Mode.ToString())
            {
                case "Employee":
                    this.Text = "사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "DepOperation":
                    this.Text = "운영기획부 사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "DepMaterial":
                    this.Text = "자재부 사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "DepProd1":
                    this.Text = "생산1부 사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "DepProd2":
                    this.Text = "생산2부 사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "DepSales":
                    this.Text = "영업부 사원";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Defective":
                    this.Text = "불량유형";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Product":
                    this.Text = "제품";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Meterial":
                    this.Text = "원자재";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "SemiProduct":
                    this.Text = "반제품";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Downtime":
                    this.Text = "비가동유형";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Factory":
                    this.Text = "공장";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Line":
                    this.Text = "공정";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Customer":
                    this.Text = "고객";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Department":
                    this.Text = "부서";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Warehouse":
                    this.Text = "창고";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Company":
                    this.Text = "회사";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "ProductCategory":
                    this.Text = "제품카테고리";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Worker":
                    this.Text = "작업자";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "Handle":
                    this.Text = "불량처리유형";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
                case "AllProduct":
                    this.Text = "품목";
                    col1 = this.Text + "번호";
                    col2 = this.Text + "명";
                    break;
            }

            txtSearch.PlaceHolderText = string.Concat(this.Text, " ", "키워드 입력");
            // Mode값에 따라 그리드뷰 컬럼명 및 검색 결과 
            UtilClass.SettingDgv(dgvSearch);
            UtilClass.AddNewColum(dgvSearch, col1, "ID",true,150);
            UtilClass.AddNewColum(dgvSearch, col2, "Name", true, 150);
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
