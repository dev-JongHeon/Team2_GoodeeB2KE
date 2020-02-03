﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_VO;

namespace Team2_ERP
{
    public partial class DowntimeType : Base1Dgv
    {
        MainForm frm;
        List<DowntimeTypeVO> list = new List<DowntimeTypeVO>();
        DowntimeTypeService service = new DowntimeTypeService();
        bool isFirst = true;
        public DowntimeType()
        {
            InitializeComponent();
        }

        private void DowntimeType_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDowntimeType);
            UtilClass.AddNewColum(dgvDowntimeType, "비가동유형번호", "DownID", true, 170);
            UtilClass.AddNewColum(dgvDowntimeType, "비가동유형명", "DownName", true, 130);
            UtilClass.AddNewColum(dgvDowntimeType, "비가동유형설명", "DownExplain", true, 300);

            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllDefectiveTypes();
                if (!isFirst)
                {
                    dgvDowntimeType.DataSource = list;
                    ClearDgv();
                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            searchDowntimeType.CodeTextBox.Clear();
            frm.NoticeMessage = "비가동유형 화면입니다.";
        }
        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = flag;
            frm.삭제ToolStripMenuItem.Visible = flag;
            frm.수정ToolStripMenuItem.Visible = flag;
            frm.인쇄ToolStripMenuItem.Visible = false;
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchDowntimeType.CodeTextBox.Tag != null)
            {
                List<DowntimeTypeVO> searchedlist = (from item in list
                                                      where item.DownID == searchDowntimeType.CodeTextBox.Tag.ToString()
                                                      select item).ToList();
                dgvDowntimeType.DataSource = searchedlist;
                frm.NoticeMessage = "검색 완료";
            }
            else
            {
                RefreshClicked();
            }
        }

        public override void Refresh(object sender, EventArgs e)
        {
            RefreshClicked();
        }

        public override void New(object sender, EventArgs e)
        {
            DowntimeTypeAdd dfrm = new DowntimeTypeAdd(DowntimeTypeAdd.EditMode.Insert, null);
            if (dfrm.ShowDialog() == DialogResult.OK)
            {
                frm.새로고침ToolStripMenuItem.PerformClick();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvDowntimeType.SelectedRows.Count > 0)
            {
                DowntimeTypeVO vo = new DowntimeTypeVO { DownID = dgvDowntimeType.SelectedRows[0].Cells[0].Value.ToString(), DownName = dgvDowntimeType.SelectedRows[0].Cells[1].Value.ToString(), DownExplain = dgvDowntimeType.SelectedRows[0].Cells[2].Value.ToString() };
                DowntimeTypeAdd dfrm = new DowntimeTypeAdd(DowntimeTypeAdd.EditMode.Update, vo);
                if (dfrm.ShowDialog() == DialogResult.OK)
                {
                    frm.새로고침ToolStripMenuItem.PerformClick();
                }
            }
            else
            {
                frm.NoticeMessage = "수정할 불량유형을 선택하지 않으셨습니다.";
            }
        }
        public override void Delete(object sender, EventArgs e)
        {
            if (dgvDowntimeType.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DefectiveTypeService service = new DefectiveTypeService();
                        if (service.DeleteDefectiveType(dgvDowntimeType.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            frm.NoticeMessage = "삭제 완료!";

                        }
                        else
                        {
                            frm.NoticeMessage = "삭제 실패..";
                        }

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                
                frm.새로고침ToolStripMenuItem.PerformClick();
            }
            else
            {
                frm.NoticeMessage = "삭제할 불량유형을 선택하지 않으셨습니다.";
            }
        }

        private void DowntimeType_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            frm.NoticeMessage = notice;
        }

        private void DowntimeType_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvDowntimeType.ClearSelection();
            dgvDowntimeType.CurrentCell = null;
        }

        private void DowntimeType_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
