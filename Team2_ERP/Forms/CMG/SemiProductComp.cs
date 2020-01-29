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
    public partial class SemiProductComp : BasePopup
    {
        public enum EditMode { Insert, Update }

        public SemiProductComp(EditMode editMode, BOMVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                lblName.Text = "반제품 등록";
            }
        }

        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
            UtilClass.ComboBinding(cboCategory, categoryList, "선택");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SemiProductComp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
