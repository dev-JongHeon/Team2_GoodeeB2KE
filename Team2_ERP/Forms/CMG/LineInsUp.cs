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
    public partial class LineInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        public LineInsUp(EditMode editMode, LineVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {

            }
            else if(editMode == EditMode.Update)
            {

            }
        }
    }
}
