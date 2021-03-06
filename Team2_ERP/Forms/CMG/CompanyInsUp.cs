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
    public partial class CompanyInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        int code = 0;
        string division = string.Empty;

        string mode = string.Empty;

        public CompanyInsUp(EditMode editMode, CompanyVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                lblName.Text = "거래처 등록";
                mode = "Insert";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "거래처 수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;

                UpdateInfo(item);
            }
        }

        private void UpdateInfo(CompanyVO item)
        {
            code = item.Company_ID;
            txtCompanyName.Text = item.Company_Name;
            maskedCompanyNumber.Text = item.Company_Number;
            maskedCompanyFaxNumber.Text = item.Company_Fax;
            txtCompanyOwner.Text = item.Company_Owner;
            addrCompany.Zipcode = item.Company_AddrNumber;
            string[] str = item.Company_Address.Split('　');
            addrCompany.Address1 = str[0];
            addrCompany.Address2 = str[1];
            division = item.CodeTable_CodeID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //업종목록을 콤보바인딩 한다.
        private void InitCombo()
        {
            try
            {
                StandardService service = new StandardService();
                List<ComboItemVO> companyList = service.GetComboSector();
                UtilClass.ComboBinding(cboCompanyDivision, companyList, "선택");
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }

            if(mode.Equals("Update"))
            {
                cboCompanyDivision.SelectedValue = division;
            }
        }

        private void InsertCompany()
        {
            CompanyVO item = new CompanyVO
            {
                Company_Name = txtCompanyName.Text,
                Company_Number = maskedCompanyNumber.Text,
                Company_Fax = maskedCompanyFaxNumber.Text,
                CodeTable_CodeID = cboCompanyDivision.SelectedValue.ToString(),
                Company_Owner = txtCompanyOwner.Text,
                Company_Address = addrCompany.Address1 + "　" + addrCompany.Address2,
                Company_AddrNumber = addrCompany.Zipcode
            };

            if(item.Company_Fax.Replace("-", "").Trim().Length < 10)
            {
                item.Company_Fax = null;
            }

            try
            {
                StandardService service = new StandardService();
                service.InsertCompany(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void UpdateCompany()
        {
            CompanyVO item = new CompanyVO
            {
                Company_ID = code,
                Company_Name = txtCompanyName.Text,
                Company_Number = maskedCompanyNumber.Text,
                Company_Fax = maskedCompanyFaxNumber.Text,
                CodeTable_CodeID = cboCompanyDivision.SelectedValue.ToString(),
                Company_Owner = txtCompanyOwner.Text,
                Company_Address = addrCompany.Address1 + "　" + addrCompany.Address2,
                Company_AddrNumber = addrCompany.Zipcode
            };

            if (item.Company_Fax.Replace("-", "").Trim().Length < 10)
            {
                item.Company_Fax = null;
            }

            try
            {
                StandardService service = new StandardService();
                service.UpdateCompany(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text.Trim().Length > 0 && maskedCompanyNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && cboCompanyDivision.SelectedValue != null && txtCompanyOwner.Text.Trim().Length > 0 && addrCompany.Address1.Trim().Length > 0 && addrCompany.Address2.Trim().Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertCompany();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateCompany();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompanyInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }
    }
}
