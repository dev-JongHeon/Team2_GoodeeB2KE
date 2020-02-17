using System;
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
    public partial class FactoryInsUp : BasePopup
    {
        public string FName { get; set; }
        public string Value { get; set; }

        string mode = string.Empty;
        int code = 0;

        public enum EditMode { Insert, Update }

        public FactoryInsUp(EditMode editMode, FactoryVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                mode = "Insert";
                lblName.Text = "공장등록";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else
            {
                mode = "Update";
                lblName.Text = "공장수정";
                pbxTitle.Image = Resources.Edit_32x32;

                code = item.Factory_ID;
                txtFactoryName.Text = item.Factory_Name;
                maskedFactoryNumber.Text = item.Factory_Number;
                maskedFactoryFaxNumber.Text = item.Factory_Fax;
            }
        }

        private void InitCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FName", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["FName"] = "선택";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "반제품 공장";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["FName"] = "완제품 공장";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            cboFactoryDivision.DataSource = dt;
            cboFactoryDivision.DisplayMember = "FName";
            cboFactoryDivision.ValueMember = "Value";
        }

        private void InsertFactory()
        {
            if(cboFactoryDivision.SelectedIndex != 0)
            {
                FactoryVO item = new FactoryVO
                {
                    Factory_Name = txtFactoryName.Text,
                    Factory_Division = Convert.ToInt32(cboFactoryDivision.SelectedValue),
                    Factory_Number = maskedFactoryNumber.Text,
                    Factory_Fax = maskedFactoryFaxNumber.Text,
                    Factory_Address = addrFactory.Address1 + "　" + addrFactory.Address2
                };

                if(item.Factory_Fax.Replace("-", "").Trim().Length < 10)
                {
                    item.Factory_Fax = null;
                }

                StandardService service = new StandardService();
                service.InsertFactory(item);
            }
        }

        private void UpdateFactory()
        {
            if (cboFactoryDivision.SelectedIndex != 0)
            {
                FactoryVO item = new FactoryVO
                {
                    Factory_ID = code,
                    Factory_Name = txtFactoryName.Text,
                    Factory_Division = Convert.ToInt32(cboFactoryDivision.SelectedValue),
                    Factory_Number = maskedFactoryNumber.Text,
                    Factory_Fax = maskedFactoryFaxNumber.Text,
                    Factory_Address = addrFactory.Address1 + "　" + addrFactory.Address2
                };

                if (item.Factory_Fax.Replace("-", "").Trim().Length < 10)
                {
                    item.Factory_Fax = null;
                }

                StandardService service = new StandardService();
                service.UpdateFactory(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FactoryInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(mode.Equals("Insert"))
                InsertFactory();
            else
                UpdateFactory();

            if(txtFactoryName.Text.Length > 0 && !cboFactoryDivision.SelectedText.Equals("선택") && maskedFactoryNumber.Text.Replace("_", "").Replace("-", "").Trim().Length > 10 && addrFactory.Address1.Length > 0 && addrFactory.Address2.Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertFactory();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateFactory();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
