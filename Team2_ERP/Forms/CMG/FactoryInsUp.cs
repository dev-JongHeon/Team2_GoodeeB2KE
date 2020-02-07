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
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
            else
            {
                mode = "Update";
                lblName.Text = "공장수정";
                pbxTitle.Image = Properties.Resources.Edit_32x32;

                code = item.Factory_ID;
                txtFactoryName.Text = item.Factory_Name;
                txtFactoryNumber.Text = item.Factory_Number;
                txtFactoryFaxNumber.Text = item.Factory_Fax;
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
                    Factory_Number = txtFactoryNumber.Text,
                    Factory_Fax = txtFactoryFaxNumber.Text,
                    Factory_Address = addressControl1.Address1 + "　" + addressControl1.Address2
                };

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
                    Factory_Number = txtFactoryNumber.Text,
                    Factory_Fax = txtFactoryFaxNumber.Text,
                    Factory_Address = addressControl1.Address1 + "　" + addressControl1.Address2
                };

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

            this.DialogResult = DialogResult.OK;
        }
    }
}
