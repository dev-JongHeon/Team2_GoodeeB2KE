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

        CodeTableVO item;

        public Department()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvDepartment);

            UtilClass.AddNewColum(dgvDepartment, "부서코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dgvDepartment, "부서이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvDepartment, "부서설명", "CodeTable_CodeExplain", true, 100);

            dgvDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = (from item in service.GetAllCodeTable() where item.CodeTable_CodeID.Contains("Depart") select item).ToList();
            dgvDepartment.DataSource = list;
            dgvDepartment.CurrentCell = null;
        }

        // 메인 폼 메세지 초기화
        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dgvDepartment.DataSource = null;
            searchDepartmentName.CodeTextBox.Text = "";
        }

        public override void New(object sender, EventArgs e)
        {
            DepartmentInsUp frm = new DepartmentInsUp(DepartmentInsUp.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dgvDepartment.DataSource = null;
                InitMessage();
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvDepartment.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "수정할 부서를 선택해주세요.";
            }
            else
            {
                DepartmentInsUp frm = new DepartmentInsUp(DepartmentInsUp.EditMode.Update, item);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dgvDepartment.DataSource = null;
                    InitMessage();
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvDepartment.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "삭제할 부서를 선택해주세요.";
            }
            else
            {
                 if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    CodeTableService service = new CodeTableService();
                    service.DeleteCodeTable(item.CodeTable_CodeID);
                    dgvDepartment.DataSource = null;
                    InitMessage();
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchDepartmentName.CodeTextBox.Text.Length > 0)
            {
                dgvDepartment.DataSource = null;
                List<CodeTableVO> deptList = (from item in list where item.CodeTable_CodeID.Contains(searchDepartmentName.CodeTextBox.Tag.ToString()) && item.CodeTable_DeletedYN == false select item).ToList();
                dgvDepartment.DataSource = deptList;
            }
            else
            {
                LoadGridView();
                InitMessage();
            }

            dgvDepartment.CurrentCell = null;
        }

        private void Department_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            CodeTableService service = new CodeTableService();
            list = (from item in service.GetAllCodeTable() where item.CodeTable_CodeID.Contains("Depart") select item).ToList();
        }

        private void Department_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        private void Department_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvDepartment.Rows.Count && e.RowIndex > -1)
            {
                item = new CodeTableVO
                {
                    CodeTable_CodeID = dgvDepartment.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    CodeTable_CodeName = dgvDepartment.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    CodeTable_CodeExplain = dgvDepartment.Rows[e.RowIndex].Cells[2].Value.ToString()
                };
            }
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }
    }
}
