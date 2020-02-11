using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class DefectiveHandleAdd : BasePopup
    {
        public enum EditMode { Insert, Update }
        public EditMode currentMode;

        public DefectiveHandleAdd()
        {
            InitializeComponent();
        }

        public DefectiveHandleAdd(EditMode mode, DefectiveHandleVO item)
        {
            InitializeComponent();
            switch (mode)
            {
                case EditMode.Insert:
                    currentMode = mode;
                    lblName.Text = "불량처리유형등록";
                    btnOK.Text = "등록";
                    panel_Modi.Visible = false;
                    txtID.Text = "0";
                    pbxTitle.Image = Properties.Resources.AddFile_32x32;
                    break;
                case EditMode.Update:
                    currentMode = mode;
                    lblName.Text = "불량처리유형수정";
                    btnOK.Text = "수정";
                    panel_Modi.Visible = true;
                    txtExplain.Text = item.HandleExplain;
                    txtID.Text = item.HandleID;
                    txtName.Text = item.HandleName;
                    pbxTitle.Image = Properties.Resources.Edit_32x32;
                    break;
                default:
                    break;
            }
            this.ActiveControl = txtName;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtExplain.TextLength > 0 && txtName.TextLength > 0)
            {
                try
                {
                    DefectiveHandleVO vo = new DefectiveHandleVO { HandleID = txtID.Text, HandleName = txtName.Text.Trim(), HandleExplain = txtExplain.Text.Trim() };
                    DefectiveHandleService service = new DefectiveHandleService();
                    if (service.UpdateDefectiveHandle(vo))
                    {
                        if (vo.HandleID != "0")
                        {
                            MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (vo.HandleID != "0")
                        {
                            MessageBox.Show(Resources.ModError, Resources.ModError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Resources.AddError, Resources.AddError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

