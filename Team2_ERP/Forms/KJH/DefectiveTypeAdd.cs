﻿using System;
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

        public DefectiveTypeAdd(EditMode mode, DefectiveTypeVO item)
        {
            InitializeComponent();
            switch (mode)
            {
                case EditMode.Insert:
                    currentMode = mode;
                    lblName.Text = "불량유형등록";
                    btnOK.Text = "등록";
                    panel_Modi.Visible = false;
                    txtID.Text = "0";
                    pbxTitle.Image = Properties.Resources.AddFile_32x32;
                    break;
                case EditMode.Update:
                    currentMode = mode;
                    lblName.Text = "불량유형수정";
                    btnOK.Text = "수정";
                    panel_Modi.Visible = true;
                    txtExplain.Text = item.DefecExplain;
                    txtID.Text = item.DefecID;
                    txtName.Text = item.DefecName;
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
                    DefectiveTypeVO vo = new DefectiveTypeVO { DefecID = txtID.Text, DefecName = txtName.Text.Trim(), DefecExplain = txtExplain.Text.Trim() };
                    DefectiveTypeService service = new DefectiveTypeService();
                    if (service.UpdateDefectiveType(vo))
                    {
                        if (vo.DefecID != "0")
                        {
                            MessageBox.Show(Properties.Settings.Default.ModDone, Properties.Settings.Default.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Properties.Settings.Default.AddDone, Properties.Settings.Default.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (vo.DefecID != "0")
                        {
                            MessageBox.Show(Properties.Settings.Default.ModError, Properties.Settings.Default.ModError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Properties.Settings.Default.AddError, Properties.Settings.Default.AddError, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(Properties.Settings.Default.isEssential, Properties.Settings.Default.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

