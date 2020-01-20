using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public partial class CategoryInsUp : BasePopup
    {
        public enum EditMode { Category, Depart }

        public CategoryInsUp(EditMode editMode)
        {
            InitializeComponent();

            if(editMode == EditMode.Category)
            {
                label1.Text = "카테고리이름";
                label2.Text = "카테고리설명";
            }

            else if(editMode == EditMode.Depart)
            {
                label1.Text = "부서이름";
                label2.Text = "부서설명";
            }
        }

        private void InsertCategory()
        {
            CodeTableVO category = new CodeTableVO();
            CodeTableDAC dac = new CodeTableDAC();

            category.CodeTable_CodeID = "S";
            category.CodeTable_CodeName = txtName.Text;
            category.CodeTable_CodeExplain = txtContext.Text;

            dac.InsertCategory(category);
        }

        private void InsertDepartMent()
        {
            CodeTableVO dept = new CodeTableVO();
            CodeTableDAC dac = new CodeTableDAC();
        }
    }
}
