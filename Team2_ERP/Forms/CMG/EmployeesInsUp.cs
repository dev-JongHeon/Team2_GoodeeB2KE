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

        public EmployeesInsUp(EditMode editMode, EmployeeVO item)
        {
            InitializeComponent();

            if(editMode.Equals(EditMode.Insert))
            {
                lblName.Text = "사원등록";
                mode = "Insert";
            }
            else
            {
                lblName.Text = "사원수정";
                mode = "Update";
                eCode = item.Employees_ID;
                txtEmployeesName.Text = item.Employees_Name;
                txtEmployeesPhoneNumber.Text = item.Employees_Phone;
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

            if(mode.Equals("Insert"))
            {
                dtpEmployeesHireDate.Enabled = true;
                dtpEmployeesResignDate.Enabled = false;
            }
            else
            {
                dtpEmployeesHireDate.Enabled = false;
                dtpEmployeesResignDate.Enabled = true;
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
                Employees_Phone = txtEmployeesPhoneNumber.Text,
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
                Employees_Phone = txtEmployeesPhoneNumber.Text,
                Employees_Birth = dtpEmployeesBirthDay.Value.ToShortDateString(),
                Employees_ID = eCode
            };

            StandardService service = new StandardService();
            service.UpdateEmployee(item);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
                InsertEmployee();
            else
                UpdateEmployee();
        }
    }
}
