using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        
        public string Labelname { get => lblName.Text; set => lblName.Text=value; }

        public enum Mode { Worker, Defective, Product, Downtime, Company,
            Factory, Line, Meterial, SemiProduct,Customer, Warehouse, Department };

        Mode Modes = Mode.Worker;

        public Mode ControlType
        {
            get { return Modes; }
            set
            {
                Modes = value;

                switch (Modes)
                {
                    case Mode.Worker:
                        this.CodeLabel.Text = "작업자";
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
            SearchForm search = new SearchForm();
            search.Mode = this.Modes;
            search.ShowDialog();
        }
    }
}
