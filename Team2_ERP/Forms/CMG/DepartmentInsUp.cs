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
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                code = item.CodeTable_CodeID;
                txtName.Text = item.CodeTable_CodeName;
                txtContext.Text = item.CodeTable_CodeExplain;
            }
            else
            {
                lblName.Text = "부서 등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
        }

        // 부서 등록
        private void InsertDepart()
        {
            CodeTableVO dept = new CodeTableVO();
            CodeTableService service = new CodeTableService();

            dept.CodeTable_CodeName = txtName.Text;
            dept.CodeTable_CodeExplain = txtContext.Text;

            service.InsertDepart(dept);
        }

        public void UpdateDepart()
        {
            CodeTableVO depart = new CodeTableVO();
            CodeTableService service = new CodeTableService();

            depart.CodeTable_CodeName = txtName.Text;
            depart.CodeTable_CodeExplain = txtContext.Text;
            depart.CodeTable_CodeID = code;

            service.UpdateCodeTable(depart);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
                InsertDepart();
            else if (mode.Equals("Update"))
                UpdateDepart();

            this.DialogResult = DialogResult.OK;
        }
    }
}
