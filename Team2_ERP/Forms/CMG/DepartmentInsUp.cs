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

        public DepartmentInsUp(EditMode editMode, string dept, string name, string context)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                mode = "Update";
                code = dept;
                txtName.Text = name;
                txtContext.Text = context;
            }
            else if (editMode == EditMode.Insert)
            {
                mode = "Insert";
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
            {
                InsertDepart();
            }
            else if (mode.Equals("Update"))
            {
                UpdateDepart();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void DepartmentInsUp_Load(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                lblName.Text = "부서 등록";
            }
            else if (mode.Equals("Update"))
            {
                lblName.Text = "부서 수정";
            }
        }
    }
}
