using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class EmployeesInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        string mode = string.Empty;
        int eCode = 0;

        public Dictionary<string, string> menulist = new Dictionary<string, string>
        {
            {"UserAuth","사용자권한설정" },
            {"Work","작업지시현황" },
            {"Produce","생산실적현황" },
            {"DowntimeType","비가동유형" },
            {"Downtime","비가동현황" },
            {"DefectiveType","불량유형" },
            {"DefectiveHandle","불량처리유형" },
            {"Defective","불량처리현황" },
            {"StockStatus","재고현황" },
            {"InOutList_MaterialWarehouse","자재수불현황" },
            {"InOutList_SemiProductWarehouse","반제품수불현황" },
            {"BaljuList","발주현황" },
            {"BaljuList_Completed","발주완료현황" },
            {"OrderMainForm","주문현황" },
            {"OrderCompleteForm","주문처리완료현황" },
            {"ShipmentMainForm","출하현황" },
            {"ShipmentCompleteForm","출하완료현황" },
            {"SalesMainForm","매출현황" },
            {"Department","부서관리" },
            {"Employees","사원관리" },
            {"Company","거래처관리" },
            {"Customer","고객관리" },
            {"Category","카테고리관리" },
            {"Factory","공장&공정관리" },
            {"Resource","원자재관리" },
            {"Warehouse","창고관리" },
            {"BOM","BOM관리" },
        };

        public EmployeesInsUp(EditMode editMode, EmployeeVO item)
        {
            InitializeComponent();

            if(editMode.Equals(EditMode.Insert))
            {
                lblName.Text = "사원등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "사원수정";
                mode = "Update";
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                eCode = item.Employees_ID;
                txtEmployeesName.Text = item.Employees_Name;
                maskedEmployeesPhoneNumber.Text = item.Employees_Phone;
                dtpEmployeesHireDate.Value = Convert.ToDateTime(item.Employees_Hiredate);
            }
        }

        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> employeeList = service.GetComboEmployee();
            UtilClass.ComboBinding(cboEmployeesCategory, employeeList, "선택");
        }

        private void EmployeesInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
            txtEmployeesPassword.PasswordChar = '*';

            if(mode.Equals("Insert"))
            {
                dtpEmployeesHireDate.Enabled = true;
                dtpEmployeesResignDate.Enabled = false;
            }
            else
            {
                dtpEmployeesHireDate.Enabled = false;
                dtpEmployeesResignDate.Enabled = true;
                txtEmployeesPassword.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertEmployee()
        {
            EmployeeVO item = new EmployeeVO
            {
                Employees_Name = txtEmployeesName.Text,
                CodeTable_CodeID = cboEmployeesCategory.SelectedValue.ToString(),
                Employees_Hiredate = dtpEmployeesHireDate.Value.ToShortDateString(),
                Employees_PWD = txtEmployeesPassword.Text,
                Employees_Phone = maskedEmployeesPhoneNumber.Text,
                Employees_Birth = dtpEmployeesBirthDay.Value.ToShortDateString()
            };

            StandardService service = new StandardService();
            service.InsertEmployee(item);
        }

        private void UpdateEmployee()
        {
            EmployeeVO item = new EmployeeVO
            {
                Employees_Name = txtEmployeesName.Text,
                CodeTable_CodeID = cboEmployeesCategory.SelectedValue.ToString(),
                Employees_Resigndate = dtpEmployeesResignDate.Value.ToShortDateString(),
                Employees_PWD = txtEmployeesPassword.Text,
                Employees_Phone = maskedEmployeesPhoneNumber.Text,
                Employees_Birth = dtpEmployeesBirthDay.Value.ToShortDateString(),
                Employees_ID = eCode
            };

            StandardService service = new StandardService();
            service.UpdateEmployee(item);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                if(txtEmployeesName.Text.Length > 0 && cboEmployeesCategory.SelectedValue != null && dtpEmployeesHireDate.Value != null && txtEmployeesPassword.Text.Length > 0 && maskedEmployeesPhoneNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && dtpEmployeesBirthDay.Value != null)
                {
                    InsertEmployee();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.AddDone, Properties.Settings.Default.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Settings.Default.isEssential, Properties.Settings.Default.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (txtEmployeesName.Text.Length > 0 && cboEmployeesCategory.SelectedValue != null && dtpEmployeesResignDate.Value != null && txtEmployeesPassword.Text.Length > 0 && maskedEmployeesPhoneNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && dtpEmployeesBirthDay.Value != null)
                {
                    UpdateEmployee();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.ModDone, Properties.Settings.Default.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Settings.Default.isEssential, Properties.Settings.Default.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
