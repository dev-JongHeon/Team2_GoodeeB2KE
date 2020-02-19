using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class DefectiveHandle : Base1Dgv
    {
        MainForm frm;
        List<DefectiveHandleVO> list = new List<DefectiveHandleVO>();
        DefectiveHandleService service = new DefectiveHandleService();
        bool isFirst = true;
        public DefectiveHandle()
        {
            InitializeComponent();
        }

        private void DefectiveHandle_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvDefectiveHandle();
            RefreshClicked();
            frm.NoticeMessage = notice;
        }

        private void SettingDgvDefectiveHandle()
        {
            UtilClass.SettingDgv(dgvDefectiveHandle);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형번호", "HandleID", false, 170);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형명", "HandleName", true, 150);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형설명", "HandleExplain", true, 300);
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllDefectiveHandle();
                if (!isFirst)
                {
                    dgvDefectiveHandle.DataSource = list;
                    ClearDgv();
                }
                isFirst = false;
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message,err);
            }
            txtSearch.CodeTextBox.Clear();
            frm.NoticeMessage = Resources.RefreshDone;
        }

        private void DefectiveHandle_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvDefectiveHandle.ClearSelection();
            dgvDefectiveHandle.CurrentCell = null;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        public override void Search(object sender, EventArgs e)
        {
            if (txtSearch.CodeTextBox.Tag != null)
            {
                List<DefectiveHandleVO> searchedlist = (from item in list
                                                      where item.HandleID == txtSearch.CodeTextBox.Tag.ToString()
                                                      select item).ToList();
                dgvDefectiveHandle.DataSource = searchedlist;
                frm.NoticeMessage = Resources.SearchDone;
            }
            else
            {
                RefreshClicked();
                frm.NoticeMessage = notice;
            }
        }

        public override void New(object sender, EventArgs e)
        {
            DefectiveHandleAdd dfrm = new DefectiveHandleAdd(DefectiveHandleAdd.EditMode.Insert, null);
            if (dfrm.ShowDialog() == DialogResult.OK)
            {
                RefreshClicked();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvDefectiveHandle.SelectedRows.Count > 0)
            {
                DefectiveHandleVO vo = new DefectiveHandleVO {  HandleID = dgvDefectiveHandle.SelectedRows[0].Cells[0].Value.ToString(),  HandleName = dgvDefectiveHandle.SelectedRows[0].Cells[1].Value.ToString(),  HandleExplain = dgvDefectiveHandle.SelectedRows[0].Cells[2].Value.ToString() };
                DefectiveHandleAdd dfrm = new DefectiveHandleAdd(DefectiveHandleAdd.EditMode.Update, vo);
                if (dfrm.ShowDialog() == DialogResult.OK)
                {
                    RefreshClicked();
                }
            }
            else
            {
                frm.NoticeMessage = Resources.ModDefectiveHandleError;
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvDefectiveHandle.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Resources.IsDelete, Resources.MsgBoxTitleDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DefectiveHandleService service = new DefectiveHandleService();
                        if (service.DeleteDefectiveHandle(dgvDefectiveHandle.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            frm.NoticeMessage = Resources.DeleteDone;

                        }
                        else
                        {
                            frm.NoticeMessage = Resources.DeleteError;
                        }

                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                }
                RefreshClicked();
            }
            else
            {
                frm.NoticeMessage = Resources.DelDefectiveHandleError;
            }
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = flag;
            frm.삭제ToolStripMenuItem.Visible = flag;
            frm.수정ToolStripMenuItem.Visible = flag;
            frm.인쇄ToolStripMenuItem.Visible = false;
        }

        private void DefectiveHandle_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = txtSearch;
            txtSearch.Focus();
            frm.NoticeMessage = notice;
        }

        private void DefectiveHandle_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
