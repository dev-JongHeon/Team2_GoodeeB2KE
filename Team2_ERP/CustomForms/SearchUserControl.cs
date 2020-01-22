using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class SearchUserControl : UserControl
    {

        public TextBox CodeTextBox
        {
            get { return txtCode; }
            set { txtCode = value; }
        }

        public Label CodeLabel
        {
            get { return lblName; }
            set { lblName = value; }
        }

        public Button CodeButton
        {
            get { return btnSearch; }
            set { btnSearch = value; }
        }

        public string Labelname { get => lblName.Text; set => lblName.Text = value; }

        public enum Mode
        {
            Employee, DepOperation, DepMaterial, DepSales, DepProd1, DepProd2, Defective, Product, Downtime, Company,
            Factory, Line, Meterial, SemiProduct, Customer, Warehouse, Department, ProductCategory
        };

        Mode Modes = Mode.Employee;

        public Mode ControlType
        {
            get { return Modes; }
            set
            {
                Modes = value;

                switch (Modes)
                {
                    case Mode.Employee:
                        this.CodeLabel.Text = "사원";
                        break;
                    case Mode.DepOperation:
                        this.CodeLabel.Text = "운영기획부";
                        break;
                    case Mode.DepMaterial:
                        this.CodeLabel.Text = "자재부";
                        break;
                    case Mode.DepProd1:
                        this.CodeLabel.Text = "생산1부";
                        break;
                    case Mode.DepProd2:
                        this.CodeLabel.Text = "생산2부";
                        break;
                    case Mode.DepSales:
                        this.CodeLabel.Text = "영업부";
                        break;
                    case Mode.Defective:
                        this.CodeLabel.Text = "불량유형";
                        break;
                    case Mode.Product:
                        this.CodeLabel.Text = "제품";
                        break;
                    case Mode.Meterial:
                        this.CodeLabel.Text = "원자재";
                        break;
                    case Mode.SemiProduct:
                        this.CodeLabel.Text = "반제품";
                        break;
                    case Mode.Downtime:
                        this.CodeLabel.Text = "비가동유형";
                        break;
                    case Mode.Factory:
                        this.CodeLabel.Text = "공장";
                        break;
                    case Mode.Line:
                        this.CodeLabel.Text = "공정";
                        break;
                    case Mode.Customer:
                        this.CodeLabel.Text = "고객";
                        break;
                    case Mode.Department:
                        this.CodeLabel.Text = "부서";
                        break;
                    case Mode.Warehouse:
                        this.CodeLabel.Text = "창고";
                        break;
                    case Mode.Company:
                        this.CodeLabel.Text = "회사";
                        break;
                    case Mode.ProductCategory:
                        this.CodeLabel.Text = "제품카테고리";
                        break;
                }
            }
        }


        public SearchUserControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 원하는 폼 띄우기
            SearchedInfoVO info = new SearchedInfoVO();
            SearchForm search = new SearchForm(info);
            search.Mode = this.Modes;
            if (search.ShowDialog() == DialogResult.OK)
            {
                txtCode.Text = info.Name;
                txtCode.Tag = info.ID;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                txtCode.Tag = string.Empty;
            }
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.SelectAll();
        }
    }
}
