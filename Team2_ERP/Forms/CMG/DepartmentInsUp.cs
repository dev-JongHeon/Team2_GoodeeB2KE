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
    public partial class DepartmentInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }
        string mode = string.Empty;
        string code = string.Empty;

        public DepartmentInsUp(EditMode editMode, CodeTableVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                lblName.Text = "부서 수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;
                code = item.CodeTable_CodeID;
                txtName.Text = item.CodeTable_CodeName;
                txtContext.Text = item.CodeTable_CodeExplain;
            }
            else
            {
                lblName.Text = "부서 등록";
                mode = "Insert";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
        }

        // 부서 등록
        private void InsertDepart()
        {
            CodeTableVO dept = new CodeTableVO();
            dept.CodeTable_CodeName = txtName.Text;
            dept.CodeTable_CodeExplain = txtContext.Text;

            try
            {
                CodeTableService service = new CodeTableService();
                service.InsertDepart(dept);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        public void UpdateDepart()
        {
            CodeTableVO depart = new CodeTableVO();
            depart.CodeTable_CodeName = txtName.Text;
            depart.CodeTable_CodeExplain = txtContext.Text;
            depart.CodeTable_CodeID = code;

            try
            {
                CodeTableService service = new CodeTableService();
                service.UpdateCodeTable(depart);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length > 0 && txtContext.Text.Trim().Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertDepart();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateDepart();
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
