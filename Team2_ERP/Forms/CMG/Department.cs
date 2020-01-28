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
    public partial class Department : BaseForm
    {
        List<CodeTableVO> list;
        MainForm frm;
        string code = string.Empty;
        string name = string.Empty;
        string context = string.Empty;

        public Department()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "부서코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "부서이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "부서설명", "CodeTable_CodeExplain", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = service.GetAllCodeTable();
            List<CodeTableVO> departmentList = (from item in list where item.CodeTable_CodeID.Contains("Depart") && item.CodeTable_DeletedYN==false select item).ToList();
            dataGridView1.DataSource = departmentList;
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
            searchUserControl1.CodeTextBox.Text = "";
            dataGridView1.CurrentCell = null;
            LoadGridView();
        }

        public override void New(object sender, EventArgs e)
        {
            DepartmentInsUp frm = new DepartmentInsUp(DepartmentInsUp.EditMode.Insert, null, null, null);
            frm.ShowDialog();
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (code == string.Empty)
            {
                frm.NoticeMessage = "수정할 부서를 선택해주세요.";
            }
            else
            {
                DepartmentInsUp frm = new DepartmentInsUp(DepartmentInsUp.EditMode.Update, code, name, context);

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

            if (code == string.Empty)
            {
                frm.NoticeMessage = "삭제할 부서를 선택해주세요.";
            }
            else
            {
                 if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CodeTableService service = new CodeTableService();
                    service.DeleteCodeTable(code);
                    dataGridView1.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchUserControl1.CodeTextBox.Text.Length > 0)
            {
                dataGridView1.DataSource = null;
                List<CodeTableVO> deptList = (from item in list where item.CodeTable_CodeID.Contains(searchUserControl1.CodeTextBox.Tag.ToString()) && item.CodeTable_DeletedYN == false select item).ToList();
                dataGridView1.DataSource = deptList;
            }
            else
            {
                frm.NoticeMessage = "검색할 부서를 선택해주세요.";
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
        }

        private void Department_Activated(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void Department_Deactivate(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            context = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Department_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }
    }
}
