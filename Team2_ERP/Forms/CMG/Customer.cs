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
    public partial class Customer : BaseForm
    {
        List<CustomerVO> list;

        MainForm frm;

        public Customer()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "아이디", "Customer_UserID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "비밀번호", "Customer_PWD", true, 100);
            UtilClass.AddNewColum(dataGridView1, "이름", "Customer_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "연락처", "Customer_Phone", true, 100);
            UtilClass.AddNewColum(dataGridView1, "이메일", "Customer_Email", true, 100);
            UtilClass.AddNewColum(dataGridView1, "생년월일", "Customer_Birth", true, 100);
            UtilClass.AddNewColum(dataGridView1, "주소", "Customer_Address", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllCustomer();
            List<CustomerVO> CustomerList = (from item in list where item.Customer_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = CustomerList;
        }

        private void Customer_Load(object sender, EventArgs e)
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

        public override void Search(object sender, EventArgs e)
        {
            if (searchUserControl1.CodeTextBox.Text.Length > 0)
            {
                dataGridView1.DataSource = null;
                List<CustomerVO> searchList = (from item in list where item.Customer_ID == Convert.ToInt32(searchUserControl1.CodeTextBox.Tag) && item.Customer_DeletedYN == false select item).ToList();
                dataGridView1.DataSource = searchList;
            }
            else
            {
                frm.NoticeMessage = "검색할 고객을 선택해주세요.";
            }
        }

        private void Customer_Shown(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;
        }

        private void Customer_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
