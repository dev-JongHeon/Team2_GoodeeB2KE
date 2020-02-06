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
    public partial class Company : BaseForm
    {
        List<CompanyVO> list;

        MainForm frm;

        CompanyVO item;

        public Company()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvCompany);

            UtilClass.AddNewColum(dgvCompany, "거래처ID", "Company_ID", true, 100);
            UtilClass.AddNewColum(dgvCompany, "거래처명", "Company_Name", true, 100);
            UtilClass.AddNewColum(dgvCompany, "주소", "Company_Address", true, 100);
            UtilClass.AddNewColum(dgvCompany, "전화번호", "Company_Number", true, 100);
            UtilClass.AddNewColum(dgvCompany, "FAX번호", "Company_Fax", true, 100);
            UtilClass.AddNewColum(dgvCompany, "구분", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvCompany, "대표명", "Company_Owner", true, 100);

            dgvCompany.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllCompany();
            dgvCompany.DataSource = list;
            dgvCompany.CurrentCell = null;
        }

        private void Company_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            StandardService service = new StandardService();
            list = service.GetAllCompany();
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dgvCompany.DataSource = null;
            searchCompanyName.CodeTextBox.Text = "";
        }

        public override void New(object sender, EventArgs e)
        {
            InitMessage();

            CompanyInsUp frm = new CompanyInsUp(CompanyInsUp.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dgvCompany.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvCompany.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "수정할 거래처를 선택해주세요.";
            }
            else
            {
                CompanyInsUp frm = new CompanyInsUp(CompanyInsUp.EditMode.Update, item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dgvCompany.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvCompany.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "삭제할 거래처를 선택해주세요.";
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StandardService service = new StandardService();
                    service.DeleteCompany(item.Company_ID);
                    dgvCompany.DataSource = null;
                    LoadGridView();
                }
            }
        }
        public override void Search(object sender, EventArgs e)
        {
            if (searchCompanyName.CodeTextBox.Text.Length > 0)
            {
                dgvCompany.DataSource = null;
                List<CompanyVO> searchList = (from item in list where item.Company_ID.Equals(Convert.ToInt32(searchCompanyName.CodeTextBox.Tag)) select item).ToList();
                dgvCompany.DataSource = searchList;
            }
            else
            {
                LoadGridView();
                InitMessage();
            }

            dgvCompany.CurrentCell = null;
        }

        private void Company_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        private void Company_Deactivate(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvCompany.Rows.Count && e.RowIndex > -1)
            {
                if (dgvCompany.Rows[e.RowIndex].Cells[4].Value == null)
                {
                    item = new CompanyVO
                    {
                        Company_ID = Convert.ToInt32(dgvCompany.Rows[e.RowIndex].Cells[0].Value),
                        Company_Name = dgvCompany.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Company_Number = dgvCompany.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Company_Owner = dgvCompany.Rows[e.RowIndex].Cells[6].Value.ToString()
                    };
                }
                else
                {
                    item = new CompanyVO
                    {
                        Company_ID = Convert.ToInt32(dgvCompany.Rows[e.RowIndex].Cells[0].Value),
                        Company_Name = dgvCompany.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Company_Number = dgvCompany.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Company_Fax = dgvCompany.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        Company_Owner = dgvCompany.Rows[e.RowIndex].Cells[6].Value.ToString()
                    };
                }
            }
        }
    }
}