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
    public partial class Employees : BaseForm
    {
        List<EmployeeVO> list;
        List<EmployeeVO> searchList;

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
            try
            {
                StandardService service = new StandardService();
                list = service.GetAllEmployee();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }

            //재직자
            if (rdoWork.Checked)
            {
                list = (from item in list where item.Employees_DeletedYN == false select item).ToList();
            }
            //퇴사자
            else
            {
                list = (from item in list where item.Employees_DeletedYN == true select item).ToList();
            }
            dgvEmployee.DataSource = list;
            dgvEmployee.CurrentCell = null;
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            rdoWork.Checked = true;
            searchResigndate.Visible = false;
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
            frm.NoticeMessage = Resources.RefreshDone;
            dgvEmployee.DataSource = null;
            searchEmployeeName.CodeTextBox.Clear();
            searchDepartmentName.CodeTextBox.Clear();
            searchHiredate.Startdate.Clear();
            searchHiredate.Enddate.Clear();
            searchResigndate.Startdate.Clear();
            searchResigndate.Enddate.Clear();
        }

        public override void New(object sender, EventArgs e)
        {
            EmployeesInsUp popup = new EmployeesInsUp(EmployeesInsUp.EditMode.Insert, null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                frm.NoticeMessage = Resources.AddDone;
                dgvEmployee.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                EmployeesInsUp popup = new EmployeesInsUp(EmployeesInsUp.EditMode.Update, item);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.ModDone;
                    dgvEmployee.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.DelEmpty;
            }

            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        StandardService service = new StandardService();
                        service.DeleteEmployee(item.Employees_ID);
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    frm.NoticeMessage = Resources.DeleteDone;
                    dgvEmployee.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();
            searchList = list;

            //부서 검색
            if(searchDepartmentName.CodeTextBox.Tag != null)
            {
                searchList = (from item in searchList where item.CodeTable_CodeID.Equals(searchDepartmentName.CodeTextBox.Tag.ToString()) select item).ToList();
            }
            //사원이름 검색
            if(searchEmployeeName.CodeTextBox.Tag != null)
            {
                searchList = (from item in searchList where item.Employees_ID.Equals(Convert.ToInt32(searchEmployeeName.CodeTextBox.Tag)) select item).ToList();
            }
            //입사일 검색
            if(searchHiredate.Startdate.Tag != null && searchHiredate.Enddate.Tag != null)
            {
                searchList = (from item in searchList where Convert.ToDateTime(Convert.ToDateTime(item.Employees_Hiredate).ToShortDateString()) >= Convert.ToDateTime(searchHiredate.Startdate.Tag.ToString()) && Convert.ToDateTime(Convert.ToDateTime(item.Employees_Hiredate).ToShortDateString()) <= Convert.ToDateTime(searchHiredate.Enddate.Tag.ToString()) select item).ToList();
            }
            //퇴사일 검색
            if(searchResigndate.Startdate.Tag != null && searchResigndate.Enddate.Tag != null)
            {
                searchList = (from item in searchList where Convert.ToDateTime(Convert.ToDateTime(item.Employees_Resigndate).ToShortDateString()) >= Convert.ToDateTime(searchResigndate.Startdate.Tag.ToString()) && Convert.ToDateTime(Convert.ToDateTime(item.Employees_Resigndate).ToShortDateString()) <= Convert.ToDateTime(searchResigndate.Enddate.Tag.ToString()) select item).ToList();
            }

            dgvEmployee.DataSource = searchList;
            dgvEmployee.CurrentCell = null;

            frm.NoticeMessage = Resources.SearchDone;
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

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            //재직자는 퇴사일은 검색할 수 없게 한다.
            if (rdoWork.Checked)
            {
                searchResigndate.Visible = false;
                searchHiredate.Visible = true;
            }
            //퇴사자는 입사일은 검색할 수 없게 한다.
            else
            {
                searchResigndate.Visible = true;
                searchHiredate.Visible = false;
            }
        }
    }
}
