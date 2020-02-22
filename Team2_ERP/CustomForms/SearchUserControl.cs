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
    /// <summary>
    /// 공통 검색용 UserControl
    /// </summary>
    public partial class SearchUserControl : UserControl
    {
        #region 전역변수
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

        /// <summary>
        /// 모드 정의
        /// </summary>
        public enum Mode
        {
            Employee, DepOperation, DepMaterial, DepSales, DepProd1, DepProd2, Defective, Product, Downtime, Company,
            Factory, Line, Meterial, SemiProduct, Customer, Warehouse, Department, ProductCategory,Worker,Handle,AllProduct,WorkListWorker, DowntimeWorker, DefectiveWorker, InOutWorker, semiInOutWokrer, baljureqWorker, baljuacceptWorker
        };

        Mode Modes = Mode.Employee;

        /// <summary>
        /// 모드 설정
        /// </summary>
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
                        this.CodeLabel.Text = "운영기획부사원";
                        break;
                    case Mode.DepMaterial:
                        this.CodeLabel.Text = "자재부사원";
                        break;
                    case Mode.DepProd1:
                        this.CodeLabel.Text = "생산1부사원";
                        break;
                    case Mode.DepProd2:
                        this.CodeLabel.Text = "생산2부사원";
                        break;
                    case Mode.DepSales:
                        this.CodeLabel.Text = "영업부사원";
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
                        this.CodeLabel.Text = "거래처";
                        break;
                    case Mode.ProductCategory:
                        this.CodeLabel.Text = "제품카테고리";
                        break;
                    case Mode.Worker:
                        this.CodeLabel.Text = "작업자";
                        break;
                    case Mode.Handle:
                        this.CodeLabel.Text = "불량처리유형";
                        break;
                    case Mode.AllProduct:
                        this.CodeLabel.Text = "품목";
                        break;
                    case Mode.WorkListWorker:
                        this.CodeLabel.Text = "작업지시자";
                        break;
                    case Mode.DowntimeWorker:
                        this.CodeLabel.Text = "작업자";
                        break;
                    case Mode.DefectiveWorker:
                        this.CodeLabel.Text = "작업자";
                        break;
                    case Mode.InOutWorker:
                        this.CodeLabel.Text = "등록사원";
                        break;
                    case Mode.semiInOutWokrer:
                        this.CodeLabel.Text = "등록사원";
                        break;
                    case Mode.baljureqWorker:
                        this.CodeLabel.Text = "요청등록사원";
                        break;
                    case Mode.baljuacceptWorker:
                        this.CodeLabel.Text = "수령사원";
                        break;
                        
                }
            }
        }
        #endregion

        #region 폼관련
        public SearchUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 이벤트 관련
        /// <summary>
        /// 검색버튼 클릭 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 키보드 입력 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back))) // 백스페이스만 가능
            {
                e.Handled = true;
            }
            else // 백스페이스 입력하면
            {
                txtCode.Tag = null; // Tag=null
            }
        }

        /// <summary>
        /// 마우스 클릭 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.SelectAll(); //전체 선택
        }

        /// <summary>
        /// Text값 변경 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.TextLength == 0) // 길이가 0이되면
            {
                txtCode.Tag = null; //Tag=null
            }
        }
        #endregion
    }
}
