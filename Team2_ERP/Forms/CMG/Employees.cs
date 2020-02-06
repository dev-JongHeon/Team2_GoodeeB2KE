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
    public partial class Employees : BaseForm
    {
        List<EmployeeVO> list;

        MainForm frm;

        EmployeeVO item;

        public Employees()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvEmployee);

            UtilClass.AddNewColum(dgvEmployee, "사원번호", "Employees_ID", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "사원이름", "Employees_Name", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "소속부서", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "입사일", "Employees_Hiredate", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "퇴사일", "Employees_Resigndate", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "연락망", "Employees_Phone", true, 100);
            UtilClass.AddNewColum(dgvEmployee, "생년월일", "Employees_Birth", true, 100);

            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllEmployee();
            dgvEmployee.DataSource = list;
            dgvEmployee.CurrentCell = null;
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            StandardService service = new StandardService();
            list = service.GetAllEmployee();
        }

        private void Employees_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        private void Employees_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dgvEmployee.DataSource = null;
            searchEmployeeName.CodeTextBox.Text = "";
            searchDepartmentName.CodeTextBox.Text = "";
        }

        public override void New(object sender, EventArgs e)
        {
            InitMessage();

            EmployeesInsUp frm = new EmployeesInsUp(EmployeesInsUp.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dgvEmployee.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvEmployee.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "수정할 사원을 선택해주세요.";
            }
            else
            {
                EmployeesInsUp frm = new EmployeesInsUp(EmployeesInsUp.EditMode.Update, item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dgvEmployee.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvEmployee.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "삭제할 사원을 선택해주세요.";
            }

            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StandardService service = new StandardService();
                    service.DeleteEmployee(item.Employees_ID);
                    dgvEmployee.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchEmployeeName.CodeTextBox.Text.Length > 0 && searchDepartmentName.CodeTextBox.Text.Length > 0)
            {
                List<EmployeeVO> searchList = (from item in list where item.Employees_ID.Equals(Convert.ToInt32(searchEmployeeName.CodeTextBox.Tag)) && item.CodeTable_CodeID.Equals(searchDepartmentName.CodeTextBox.Tag.ToString()) && item.Employees_DeletedYN == false select item).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = searchList;
            }
            else if (searchEmployeeName.CodeTextBox.Text.Length > 0)
            {
                List<EmployeeVO> searchList = (from item in list where item.Employees_ID.Equals(Convert.ToInt32(searchEmployeeName.CodeTextBox.Tag)) && item.Employees_DeletedYN == false select item).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = searchList;
            }
            else if (searchDepartmentName.CodeTextBox.Text.Length > 0)
            {
                List<EmployeeVO> searchList = (from item in list where item.CodeTable_CodeID.Equals(searchDepartmentName.CodeTextBox.Tag.ToString()) && item.Employees_DeletedYN == false select item).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = searchList;
            }
            else
            {
                LoadGridView();
            }

            dgvEmployee.CurrentCell = null;
            InitMessage();
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvEmployee.Rows.Count && e.RowIndex > -1)
            {
                item = new EmployeeVO
                {
                    Employees_ID = Convert.ToInt32(dgvEmployee.Rows[e.RowIndex].Cells[0].Value),
                    Employees_Name = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Employees_Hiredate = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Employees_Phone = dgvEmployee.Rows[e.RowIndex].Cells[5].Value.ToString(),
                    Employees_Birth = dgvEmployee.Rows[e.RowIndex].Cells[6].Value.ToString()
                };
            }
        }
    }
}
