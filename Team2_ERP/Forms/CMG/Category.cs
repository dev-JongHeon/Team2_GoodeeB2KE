using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Category : BaseForm
    {
        List<CodeTableVO> list;

        CodeTableVO item;

        MainForm frm;
        public Category()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvCategory);

            UtilClass.AddNewColum(dgvCategory, "카테고리코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dgvCategory, "카테고리이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvCategory, "카테고리설명", "CodeTable_CodeExplain", true, 100);

            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                CodeTableService service = new CodeTableService();
                list = (from item in service.GetAllCodeTable() where item.CodeTable_CodeID.Contains("CS") || item.CodeTable_CodeID.Contains("CM") select item).ToList();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvCategory.DataSource = list;
            dgvCategory.CurrentCell = null;
        }

        // 메인 폼 메세지 초기화
        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            frm.NoticeMessage = Resources.RefreshDone;
            dgvCategory.DataSource = null;
            searchCategory.CodeTextBox.Clear();
        }

        public override void New(object sender, EventArgs e)
        {
            CategoryInsUp popup = new CategoryInsUp(CategoryInsUp.EditMode.Insert, null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                frm.NoticeMessage = Resources.AddDone;
                dgvCategory.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                CategoryInsUp popup = new CategoryInsUp(CategoryInsUp.EditMode.Update, item);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.ModDone;
                    dgvCategory.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.DelEmpty;
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        CodeTableService service = new CodeTableService();
                        service.DeleteCodeTable(item.CodeTable_CodeID);
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    frm.NoticeMessage = Resources.DeleteDone;
                    dgvCategory.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();
            if(searchCategory.CodeTextBox.Tag != null)
            {
                List<CodeTableVO> categoryList = (from item in list where item.CodeTable_CodeID.Equals(searchCategory.CodeTextBox.Tag.ToString()) select item).ToList();
                dgvCategory.DataSource = categoryList;
            }

            frm.NoticeMessage = Resources.SearchDone;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            InitGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvCategory.Rows.Count && e.RowIndex > -1)
            {
                item = new CodeTableVO
                {
                    CodeTable_CodeID = dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    CodeTable_CodeName = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    CodeTable_CodeExplain = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString()
                };
            }
        }

        private void Category_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).검색toolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void Category_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
