using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class ProductComp : BasePopup
    {
        public enum EditMode { Insert, Update }

        public ProductComp(EditMode editMode, BOMVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                lblName.Text = "완제품 등록";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
