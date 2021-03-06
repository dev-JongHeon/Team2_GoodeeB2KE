﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class EmployeesInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        string mode = string.Empty;
        int eCode = 0;
        string departID = string.Empty;

        public EmployeesInsUp(EditMode editMode, EmployeeVO item)
        {
            InitializeComponent();

            if(editMode.Equals(EditMode.Insert))
            {
                lblName.Text = "사원등록";
                mode = "Insert";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "사원수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;

                UpdateInfo(item);
            }
        }

        private void UpdateInfo(EmployeeVO item)
        {
            eCode = item.Employees_ID;
            txtEmployeesName.Text = item.Employees_Name;
            maskedEmployeesPhoneNumber.Text = item.Employees_Phone;
            departID = item.CodeTable_CodeID;
            dtpEmployeesBirthDay.Value = Convert.ToDateTime(item.Employees_Birth);
            dtpEmployeesHireDate.Value = Convert.ToDateTime(item.Employees_Hiredate);
        }

        //부서목록을 콤보바인딩
        private void InitCombo()
        {
            try
            {
                StandardService service = new StandardService();
                List<ComboItemVO> employeeList = service.GetComboEmployee();
                UtilClass.ComboBinding(cboEmployeesCategory, employeeList, "선택");
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void EmployeesInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
            txtEmployeesPassword.PasswordChar = '*';

            //수정 시 비밀번호 수정은 불가능하게 한다.(비밀번호 수정은 로그인창에서 가능)
            if(mode.Equals("Update"))
            {
                txtEmployeesPassword.Enabled = false;
                cboEmployeesCategory.SelectedValue = departID;
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

            try
            {
                StandardService service = new StandardService();
                service.InsertEmployee(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void UpdateEmployee()
        {
            EmployeeVO item = new EmployeeVO
            {
                Employees_Name = txtEmployeesName.Text,
                CodeTable_CodeID = cboEmployeesCategory.SelectedValue.ToString(),
                Employees_Hiredate = dtpEmployeesHireDate.Value.ToShortDateString(),
                Employees_Phone = maskedEmployeesPhoneNumber.Text,
                Employees_Birth = dtpEmployeesBirthDay.Value.ToShortDateString(),
                Employees_ID = eCode
            };

            try
            {
                StandardService service = new StandardService();
                service.UpdateEmployee(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                if(txtEmployeesName.Text.Trim().Length > 0 && cboEmployeesCategory.SelectedValue != null && dtpEmployeesHireDate.Value != null && txtEmployeesPassword.Text.Trim().Length > 0 && maskedEmployeesPhoneNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && dtpEmployeesBirthDay.Value != null)
                {
                    InsertEmployee();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (txtEmployeesName.Text.Trim().Length > 0 && cboEmployeesCategory.SelectedValue != null && maskedEmployeesPhoneNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && dtpEmployeesBirthDay.Value != null)
                {
                    UpdateEmployee();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
