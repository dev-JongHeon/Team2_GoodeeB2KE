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
        List<DefectiveTypeVO> list= new List<DefectiveTypeVO>();
        public DefectiveType()
        {
            InitializeComponent();
        }

        private void DefectiveType_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDefectiveType);
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형번호", "ID");
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형명", "Name");
            UtilClass.AddNewColum(dgvDefectiveType, "불량유형설명", "Explain");

            RefreshClicked();
            frm.인쇄ToolStripMenuItem.Visible = false;
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
                                                      where item.ID == txtSearch.CodeTextBox.Tag.ToString()
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
            DefectiveTypeAdd frm = new DefectiveTypeAdd(DefectiveTypeAdd.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {

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
