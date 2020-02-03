using System;
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
            UtilClass.SettingDgv(dgvDefectiveHandle);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형번호", "HandleID",true,170);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형명", "HandleName",true,150);
            UtilClass.AddNewColum(dgvDefectiveHandle, "불량처리유형설명", "HandleExplain",true,300);
            RefreshClicked();
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
                MessageBox.Show(err.Message);
            }
            txtSearch.CodeTextBox.Clear();
            frm.NoticeMessage = "불량처리유형 화면입니다.";
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
                frm.NoticeMessage = "검색 완료";
            }
            else
            {
                RefreshClicked();
            }
        }

        public override void New(object sender, EventArgs e)
        {
            DefectiveHandleAdd dfrm = new DefectiveHandleAdd(DefectiveHandleAdd.EditMode.Insert, null);
            if (dfrm.ShowDialog() == DialogResult.OK)
            {
                frm.새로고침ToolStripMenuItem.PerformClick();
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
                    frm.새로고침ToolStripMenuItem.PerformClick();
                }
            }
            else
            {
                frm.NoticeMessage = "수정할 불량처리유형을 선택하지 않으셨습니다.";
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvDefectiveHandle.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DefectiveHandleService service = new DefectiveHandleService();
                        if (service.DeleteDefectiveHandle(dgvDefectiveHandle.SelectedRows[0].Cells[0].Value.ToString()))
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
                frm.NoticeMessage = "삭제할 불량처리유형을 선택하지 않으셨습니다.";
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
