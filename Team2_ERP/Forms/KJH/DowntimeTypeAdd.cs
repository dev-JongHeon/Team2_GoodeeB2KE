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
    public partial class DowntimeTypeAdd : BasePopup
    {
        public enum EditMode { Insert, Update }
        public EditMode currentMode;
        public DowntimeTypeAdd()
        {
            InitializeComponent();
        }

        public DowntimeTypeAdd(EditMode mode, DowntimeTypeVO item)
        {
            InitializeComponent();
            switch (mode)
            {
                case EditMode.Insert:
                    currentMode = mode;
                    lblName.Text = "비가동유형등록";
                    btnOK.Text = "등록";
                    panel_Modi.Visible = false;
                    txtID.Text = "0";
                    pbxTitle.Image = Properties.Resources.AddFile_32x32;
                    break;
                case EditMode.Update:
                    currentMode = mode;
                    lblName.Text = "비가동유형수정";
                    btnOK.Text = "수정";
                    panel_Modi.Visible = true;
                    txtExplain.Text = item.DownExplain;
                    txtID.Text = item.DownID;
                    txtName.Text = item.DownName;
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
                    DowntimeTypeVO vo = new DowntimeTypeVO { DownID = txtID.Text, DownName = txtName.Text.Trim(), DownExplain = txtExplain.Text.Trim() };
                    DowntimeTypeService service = new DowntimeTypeService();
                    if (service.UpdateDefectiveType(vo))
                    {
                        if (vo.DownID != "0")
                        {
                            MessageBox.Show("수정성공", "수정성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("등록성공", "등록성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (vo.DownID != "0")
                        {
                            MessageBox.Show("수정실패", "수정실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("등록실패", "등록실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("필수항목을 입력하지 않으셨습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
