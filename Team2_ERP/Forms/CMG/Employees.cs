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
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "사원번호", "Employees_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "사원이름", "Employees_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "소속부서", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "입사일", "Employees_Hiredate", true, 100);
            UtilClass.AddNewColum(dataGridView1, "퇴사일", "Employees_Resigndate", true, 100);
            UtilClass.AddNewColum(dataGridView1, "연락망", "Employees_Phone", true, 100);
            UtilClass.AddNewColum(dataGridView1, "생년월일", "Employees_Birth", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllEmployee();
            dataGridView1.DataSource = list;
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
        }

        private void Employees_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            frm.NoticeMessage = notice;
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
            InitMessage();

            EmployeesInsUp frm = new EmployeesInsUp(EmployeesInsUp.EditMode.Insert, null);
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

            if (dataGridView1.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "수정할 사원을 선택해주세요.";
            }
            else
            {
                EmployeesInsUp frm = new EmployeesInsUp(EmployeesInsUp.EditMode.Update, item);
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
            //InitMessage();

            //if (dataGridView1.SelectedRows.Count < 1)
            //{
            //    frm.NoticeMessage = "삭제할 사원을 선택해주세요.";
            //}

            //else
            //{
            //    if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        StandardService service = new StandardService();
            //        service.DeleteResource(item.Employees_ID);
            //        dataGridView1.DataSource = null;
            //        LoadGridView();
            //    }
            //}
        }

        public override void Search(object sender, EventArgs e)
        {
            //if (searchUserControl1.CodeTextBox.Text.Length > 0)
            //{
            //    dataGridView1.DataSource = null;
            //    List<ResourceVO> searchList = (from item in list where item.Product_ID.Contains(searchUserControl1.CodeTextBox.Tag.ToString()) && item.Product_DeletedYN == false select item).ToList();
            //    dataGridView1.DataSource = searchList;
            //}
            //else
            //{
            //    frm.NoticeMessage = "검색할 원자재를 선택해주세요.";
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            item = new EmployeeVO
            {
                Employees_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                Employees_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                Employees_Hiredate = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                Employees_Phone = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(),
                Employees_Birth = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()
            };
        }
    }
}
