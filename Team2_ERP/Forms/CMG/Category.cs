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

        string code = string.Empty;
        string name = string.Empty;
        string context = string.Empty;
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = service.GetAllCodeTable();
            List<CodeTableVO> categoryList = (from item in list where item.CodeTable_CodeID.Contains("S") && !item.CodeTable_CodeID.Contains("e") || item.CodeTable_CodeID.Contains("M") && item.CodeTable_DeletedYN == false select item).ToList();
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
        }

        public override void New(object sender, EventArgs e)
        {
            InitMessage();

            CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Insert, null, null, null);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dataGridView1.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            InitMessage();

            if (code == string.Empty)
            {
                frm.NoticeMessage = "수정할 카테고리를 선택해 주세요.";
            }
            else
            {
                CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Update, code, name, context);
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

            if(MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CodeTableService service = new CodeTableService();
                service.DeleteCodeTable(code);
                dataGridView1.DataSource = null;
                LoadGridView();
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
            code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            context = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Category_Activated(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
            ((MainForm)MdiParent).검색toolStripMenuItem.Visible = false;
        }
    }
}
