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
    public partial class CompanyInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        int code = 0;

        string mode = string.Empty;

        public CompanyInsUp(EditMode editMode, CompanyVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                lblName.Text = "거래처 등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
            else
            {
                lblName.Text = "거래처 수정";
                mode = "Update";
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                code = item.Company_ID;
                txtCompanyName.Text = item.Company_Name;
                maskedCompanyNumber.Text = item.Company_Number;
                maskedCompanyFaxNumber.Text = item.Company_Fax;
                txtCompanyOwner.Text = item.Company_Owner;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> companyList = service.GetComboSector();
            UtilClass.ComboBinding(cboCompanyDivision, companyList, "선택");
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
                Company_Address = addrCompany.Address1 + "　" + addrCompany.Address2
            };

            if(item.Company_Fax.Replace("-", "").Trim().Length < 10)
            {
                item.Company_Fax = null;
            }

            StandardService service = new StandardService();
            service.InsertCompany(item);
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
                Company_Address = addrCompany.Address1 + "　" + addrCompany.Address2
            };

            if (item.Company_Fax.Replace("-", "").Trim().Length < 10)
            {
                item.Company_Fax = null;
            }

            StandardService service = new StandardService();
            service.UpdateCompany(item);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text.Length > 0 && maskedCompanyNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && cboCompanyDivision.SelectedValue != null && txtCompanyOwner.Text.Length > 0 && addrCompany.Address1.Length > 0 && addrCompany.Address2.Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertCompany();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.AddDone, Properties.Settings.Default.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateCompany();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.ModDone, Properties.Settings.Default.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default.isEssential, Properties.Settings.Default.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CompanyInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }
    }
}
