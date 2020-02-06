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
            }
            else if(editMode == EditMode.Update)
            {
                lblName.Text = "거래처 수정";
                mode = "Update";
                code = item.Company_ID;
                txtCompanyName.Text = item.Company_Name;
                txtCompanyNumber.Text = item.Company_Number;
                txtCompanyFaxNumber.Text = item.Company_Fax;
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
                Company_Number = txtCompanyNumber.Text,
                Company_Fax = txtCompanyFaxNumber.Text,
                CodeTable_CodeID = cboCompanyDivision.SelectedValue.ToString(),
                Company_Owner = txtCompanyOwner.Text
            };

            StandardService service = new StandardService();
            service.InsertCompany(item);
        }

        private void UpdateCompany()
        {
            CompanyVO item = new CompanyVO
            {
                Company_Name = txtCompanyName.Text,
                Company_Number = txtCompanyNumber.Text,
                Company_Fax = txtCompanyFaxNumber.Text,
                CodeTable_CodeID = cboCompanyDivision.SelectedValue.ToString(),
                Company_Owner = txtCompanyOwner.Text
            };

            StandardService service = new StandardService();
            service.UpdateCompany(item);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
                InsertCompany();
            else
                UpdateCompany();
        }

        private void CompanyInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }
    }
}
