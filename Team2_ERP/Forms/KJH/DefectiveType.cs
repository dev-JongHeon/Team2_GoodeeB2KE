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
    public partial class DefectiveType : Base1Dgv
    {
        MainForm frm;
        List<DefectiveTypeVO> list = new List<DefectiveTypeVO>();
        public DefectiveType()
        {
            InitializeComponent();
        }

        private void DefectiveType_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDefectiveType);
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형번호", "DefecID");
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형명", "DefecName");
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형설명", "DefecExplain");

            RefreshClicked();

        }

        private void DefectiveType_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvDefectiveType.ClearSelection();
            dgvDefectiveType.CurrentCell = null;
        }

        public override void Search(object sender, EventArgs e)
        {
            if (txtSearch.CodeTextBox.Tag != null)
            {
                List<DefectiveTypeVO> searchedlist = (from item in list
                                                      where item.DefecID == txtSearch.CodeTextBox.Tag.ToString()
                                                      select item).ToList();
                dgvDefectiveType.DataSource = searchedlist;
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

        private void RefreshClicked()
        {
            try
            {
                DefectiveTypeService service = new DefectiveTypeService();
                list = service.GetAllDefectiveTypes();
                dgvDefectiveType.DataSource = list;
                dgvDefectiveType.ClearSelection();
                dgvDefectiveType.CurrentCell = null;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            txtSearch.CodeTextBox.Clear();
            frm.NoticeMessage = "불량유형 화면입니다.";
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = flag;
            frm.삭제ToolStripMenuItem.Visible = flag;
            frm.수정ToolStripMenuItem.Visible = flag;
            frm.인쇄ToolStripMenuItem.Visible = false;
        }

        public override void New(object sender, EventArgs e)
        {
            DefectiveTypeAdd dfrm = new DefectiveTypeAdd(DefectiveTypeAdd.EditMode.Insert, null);
            if (dfrm.ShowDialog() == DialogResult.OK)
            {
                frm.새로고침ToolStripMenuItem.PerformClick();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvDefectiveType.SelectedRows.Count > 0)
            {
                DefectiveTypeVO vo = new DefectiveTypeVO { DefecID = dgvDefectiveType.SelectedRows[0].Cells[0].Value.ToString(), DefecName = dgvDefectiveType.SelectedRows[0].Cells[1].Value.ToString(), DefecExplain = dgvDefectiveType.SelectedRows[0].Cells[2].Value.ToString() };
                DefectiveTypeAdd dfrm = new DefectiveTypeAdd(DefectiveTypeAdd.EditMode.Update, vo);
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
            if (dgvDefectiveType.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DefectiveTypeService service = new DefectiveTypeService();
                        if (service.DeleteDefectiveType(dgvDefectiveType.SelectedRows[0].Cells[0].Value.ToString()))
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

        private void DefectiveType_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void DefectiveType_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
        }
    }
}
