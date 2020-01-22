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
    public partial class CategoryInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }
        string mode = string.Empty;
        string code = string.Empty;

        public CategoryInsUp(EditMode editMode, string prod, string name, string context)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                mode = "Update";
                code = prod;
                txtName.Text = name;
                txtContext.Text = context;
            }
            
            else if(editMode == EditMode.Insert)
            {
                mode = "Insert";
            }
        }

        // 반제품 등록
        private void InsertCategory()
        {
            CodeTableVO category = new CodeTableVO();
            CodeTableService service = new CodeTableService();

            category.CodeTable_CodeName = txtName.Text;
            category.CodeTable_CodeExplain = txtContext.Text;

            service.InsertCategory(category);
        }

        public void UpdateCategory()
        {
            CodeTableVO category = new CodeTableVO();
            CodeTableService service = new CodeTableService();

            category.CodeTable_CodeName = txtName.Text;
            category.CodeTable_CodeExplain = txtContext.Text;
            category.CodeTable_CodeID = code;

            service.UpdateCodeTable(category);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                InsertCategory();
            }
            else if (mode.Equals("Update"))
            {
                UpdateCategory();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void CategoryInsUp_Load(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                lblName.Text = "카테고리 등록";
            }
            else if (mode.Equals("Update"))
            {
                lblName.Text = "카테고리 수정";
            }
        }
    }
}