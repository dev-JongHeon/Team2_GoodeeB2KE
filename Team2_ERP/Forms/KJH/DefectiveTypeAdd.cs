using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class DefectiveTypeAdd : BasePopup
    {
        public enum EditMode { Insert, Update }
        public EditMode currentMode;

        public DefectiveTypeAdd()
        {
            InitializeComponent();
        }

        public DefectiveTypeAdd(EditMode mode , DefectiveTypeVO item)
        {
            InitializeComponent();
            switch (mode)
            {
                case EditMode.Insert:
                    currentMode = mode;
                    lblName.Text = "불량유형등록";
                    btnOK.Text = "등록";
                    panel_Modi.Visible = false;
                    break;
                case EditMode.Update:
                    currentMode = mode;
                    lblName.Text = "불량유형수정";
                    btnOK.Text = "수정";
                    panel_Modi.Visible = true;
                    txtExplain.Text = item.Explain;
                    txtID.Text = item.ID;
                    txtName.Text = item.Name;
                    break;
                default:
                    break;
            }
        }
    }
}
