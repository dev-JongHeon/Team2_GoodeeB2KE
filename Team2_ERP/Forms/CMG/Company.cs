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
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "거래처ID", "Company_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "거래처명", "Company_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "주소", "Company_Address", true, 100);
            UtilClass.AddNewColum(dataGridView1, "전화번호", "Company_Number", true, 100);
            UtilClass.AddNewColum(dataGridView1, "FAX번호", "Company_Fax", true, 100);
            UtilClass.AddNewColum(dataGridView1, "구분", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "대표명", "Company_Owner", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllCompany();
            List<CompanyVO> CompanyList = (from item in list where item.Company_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = CompanyList;
        }

        private void Company_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
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

            CompanyInsUp frm = new CompanyInsUp(CompanyInsUp.EditMode.Insert, null);
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

            if (item == null)
            {
                frm.NoticeMessage = "수정할 거래처를 선택해주세요.";
            }
            else
            {
                CompanyInsUp frm = new CompanyInsUp(CompanyInsUp.EditMode.Update, item);
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

            if (item == null)
            {
                frm.NoticeMessage = "삭제할 거래처를 선택해주세요.";
            }

            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StandardService service = new StandardService();
                    service.DeleteCompany(item.Company_ID);
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
                List<CompanyVO> searchList = (from item in list where item.Company_ID.Equals(Convert.ToInt32(searchUserControl1.CodeTextBox.Tag)) && item.Company_DeletedYN == false select item).ToList();
                dataGridView1.DataSource = searchList;
            }
            else
            {
                frm.NoticeMessage = "검색할 거래처를 선택해주세요.";
            }
        }

        private void Company_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
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

        private void Company_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[4].Value == null)
            {
                item = new CompanyVO
                {
                    Company_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                    Company_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Company_Number = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Company_Owner = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()
                };
            }
            else
            {
                item = new CompanyVO
                {
                    Company_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                    Company_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Company_Number = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Company_Fax = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    Company_Owner = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()
                };
            }
        }
    }
}