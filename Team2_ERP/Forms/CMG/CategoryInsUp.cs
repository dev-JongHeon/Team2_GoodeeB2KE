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

        public CategoryInsUp(EditMode editMode, string name, string context)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                txtName.Text = name;
                txtContext.Text = context;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InsertCategory();
        }

        private void CategoryInsUp_Load(object sender, EventArgs e)
        {

        }
    }
}