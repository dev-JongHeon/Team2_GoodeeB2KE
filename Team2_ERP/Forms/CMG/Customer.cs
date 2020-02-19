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
    public partial class Customer : BaseForm
    {
        List<CustomerVO> list;
        List<CustomerVO> searchList;

        MainForm frm;

        public Customer()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvCustomer);

            UtilClass.AddNewColum(dgvCustomer, "아이디", "Customer_UserID", true, 100);
            UtilClass.AddNewColum(dgvCustomer, "비밀번호", "Customer_PWD", false, 100);
            UtilClass.AddNewColum(dgvCustomer, "이름", "Customer_Name", true, 100);
            UtilClass.AddNewColum(dgvCustomer, "연락처", "Customer_Phone", true, 100);
            UtilClass.AddNewColum(dgvCustomer, "이메일", "Customer_Email", true, 100);
            UtilClass.AddNewColum(dgvCustomer, "생년월일", "Customer_Birth", true, 100);
            UtilClass.AddNewColum(dgvCustomer, "주소", "Customer_Address", true, 100);

            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                StandardService service = new StandardService();
                list = service.GetAllCustomer();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvCustomer.DataSource = list;
            dgvCustomer.CurrentCell = null;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            frm.NoticeMessage = Resources.RefreshDone;
            dgvCustomer.DataSource = null;
            searchCustomerName.CodeTextBox.Clear();
            searchCustomerBirth.Startdate.Clear();
            searchCustomerBirth.Enddate.Clear();
        }

        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();

            searchList = list;

            if(searchCustomerName.CodeTextBox.Tag != null)
            {
                searchList = (from item in searchList where item.Customer_ID.Equals(Convert.ToInt32(searchCustomerName.CodeTextBox.Tag)) select item).ToList();
            }
            if(searchCustomerBirth.Startdate.Tag != null && searchCustomerBirth.Enddate.Tag != null)
            {
                searchList = (from item in searchList where Convert.ToDateTime(Convert.ToDateTime(item.Customer_Birth).ToShortDateString()) >= Convert.ToDateTime(searchCustomerBirth.Startdate.Tag.ToString()) && Convert.ToDateTime(Convert.ToDateTime(item.Customer_Birth).ToShortDateString()) <= Convert.ToDateTime(searchCustomerBirth.Enddate.Tag.ToString()) select item).ToList();
            }

            dgvCustomer.DataSource = searchList;
            dgvCustomer.CurrentCell = null;
            frm.NoticeMessage = Resources.SearchDone;
        }

        private void Customer_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Customer_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = false;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = false;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = false;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }
    }
}
