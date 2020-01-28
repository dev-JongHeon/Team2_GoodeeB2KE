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
    public partial class CompanyInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        public CompanyInsUp(EditMode editMode, CompanyVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                lblName.Text = "거래처 등록";
            }
            else if(editMode == EditMode.Update)
            {
                lblName.Text = "거래처 수정";
            }
        }
    }
}
