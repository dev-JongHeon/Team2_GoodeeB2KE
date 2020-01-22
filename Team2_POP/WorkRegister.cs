using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_DAC;

namespace Team2_POP
{
    public partial class WorkRegister : Form
    {
        public string ProduceID { get; set; } 
        public int FactoryDivision { get; set; } // 공장 구분 
                                                    // [0 => 반제품 | 1 => 완제품]

        public int EmployeeID { get; set; }
        

        public WorkRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WorkRegister_Load(object sender, EventArgs e)
        {
            // 콤보박스 바인딩 (작업자)
            // 생산번호 
            InitData();
            ComboBinding();
        }

        private void InitData()
        {
            lblProduceID.Text = ProduceID;
        }

        private void ComboBinding()
        {
            // 반제품 라인일 경우 생산 1팀
            // 완제품 라인일 경우 생산 2팀
           
                UtilClass.ComboBinding(cboWorker, new Service().GetWorker(FactoryDivision), "작업자 선택");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
           this.DialogResult = DialogResult.OK;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboWorker.SelectedIndex == 0)
                return;
            else
            {
                lblWork.Text = cboWorker.Text;
                EmployeeID = Convert.ToInt32(cboWorker.SelectedValue);
            }
        }
    }
}
