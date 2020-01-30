using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "카테고리코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리설명", "CodeTable_CodeExplain", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = service.GetAllCodeTable();
            List<CodeTableVO> categoryList = (from item in list where item.CodeTable_CodeID.Contains("CS") || item.CodeTable_CodeID.Contains("CM") && item.CodeTable_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = categoryList;
        }

        // 메인 폼 메세지 초기화
        private void InitMessage()
        {
            frm.NoticeMessage = "메세지";
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dataGridView1.DataSource = null;
            LoadGridView();
            dataGridView1.CurrentCell = null;
        }

        public override void New(object sender, EventArgs e)
        {
            InitMessage();

            CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dataGridView1.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            InitMessage();

            if (item.CodeTable_CodeID == string.Empty)
            {
                frm.NoticeMessage = "수정할 카테고리를 선택해주세요.";
            }
            else
            {
                CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Update, item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dataGridView1.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (item.CodeTable_CodeID == string.Empty)
            {
                frm.NoticeMessage = "삭제할 카테고리를 선택해주세요.";
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CodeTableService service = new CodeTableService();
                    service.DeleteCodeTable(item.CodeTable_CodeID);
                    dataGridView1.DataSource = null;
                    LoadGridView();
                }
            }
        }


        private void Category_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            InitGridView();
            LoadGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            item = new CodeTableVO
            {
                CodeTable_CodeID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                CodeTable_CodeName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
            };
        }

        private void Category_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
            ((MainForm)MdiParent).검색toolStripMenuItem.Visible = false;
        }

        private void Category_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Category_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }
    }
}
