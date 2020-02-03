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
        DefectiveTypeService service = new DefectiveTypeService();
        bool isFirst = true;
        public DefectiveType()
        {
            InitializeComponent();
        }

        private void DefectiveType_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDefectiveType();
            RefreshClicked();
            frm.NoticeMessage = notice;
        }

        private void SettingDefectiveType()
        {
            UtilClass.SettingDgv(dgvDefectiveType);
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형번호", "DefecID", true, 130);
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형명", "DefecName", true, 130);
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형설명", "DefecExplain", true, 300);
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
                frm.NoticeMessage = Properties.Settings.Default.SearchDone;
            }
            else
            {
                RefreshClicked();
                frm.NoticeMessage = notice;
            }
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetAllDefectiveTypes();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            dgvDefectiveType.DataSource = null;
            if (!isFirst)
            {
                dgvDefectiveType.DataSource = list;
                ClearDgv();
            }
            isFirst = false;
            ClearSearchOption();
            frm.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }

        private void ClearSearchOption()
        {
            txtSearch.CodeTextBox.Clear();
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
                RefreshClicked();
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
                    RefreshClicked();
                }
            }
            else
            {
                frm.NoticeMessage = Properties.Settings.Default.ModDefectiveTypeError;
            }
        }
        public override void Delete(object sender, EventArgs e)
        {
            if (dgvDefectiveType.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(Properties.Settings.Default.IsDelete, Properties.Settings.Default.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DefectiveTypeService service = new DefectiveTypeService();
                        if (service.DeleteDefectiveType(dgvDefectiveType.SelectedRows[0].Cells[0].Value.ToString()))
                        {
                            frm.NoticeMessage = Properties.Settings.Default.DeleteDone;
                            
                        }
                        else
                        {
                            frm.NoticeMessage = Properties.Settings.Default.DeleteError;
                        }
                        
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                RefreshClicked();
            }
            else
            {
                frm.NoticeMessage = Properties.Settings.Default.DelDefectiveTypeError;
            }
        }

        private void DefectiveType_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void DefectiveType_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            ActiveControl = txtSearch;
            txtSearch.Focus();
            frm.NoticeMessage = notice;
        }
    }
}
