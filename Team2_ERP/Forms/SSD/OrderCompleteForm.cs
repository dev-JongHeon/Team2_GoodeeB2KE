using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class OrderCompleteForm : Base2Dgv
    {
        #region 전역변수
        OrderService service = new OrderService();
        List<Order> Order_AllList = null;  // Masters
        List<OrderDetail> OrderDetail_AllList = null;  // Details
        List<Order> SearchedList = null;  // 검색용
        MainForm main; 
        #endregion
        public OrderCompleteForm()
        {
            InitializeComponent();
        }

        private void OrderCompleteForm_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Order);
            UtilClass.AddNewColum(dgv_Order, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Order, "고객ID", "Customer_UserID", true, 90);
            UtilClass.AddNewColum(dgv_Order, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_Order, "주문일시", "Order_Date", true, 140);
            UtilClass.AddNewColum(dgv_Order, "주문처리일시", "OrderCompleted_Date", true, 140);
            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true, 300);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true, 250);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            dgv_Order.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Order.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dgv_Order.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Order.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dgv_Order.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Order.Columns[7].DefaultCellStyle.Format = "#,#0원";
            Order_AllList = service.GetOrderCompletedList();

            UtilClass.SettingDgv(dgv_OrderDetail);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문번호", "Order_ID", false);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문수량", "OrderDetail_Qty", true);
            dgv_OrderDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Search_Period.Startdate.BackColor = Color.LightYellow;
            Search_Period.Enddate.BackColor = Color.LightYellow;
        }

        private void dgv_Order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Master 더블클릭 이벤트
        {
            string Order_ID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
            List<OrderDetail> OrderDetail_List = (from list_detail in OrderDetail_AllList
                                                  where list_detail.Order_ID == Order_ID
                                                  select list_detail).ToList();
            dgv_OrderDetail.DataSource = OrderDetail_List;
        }

        private void GetOrderDetail_List()  // 현재 위의 Dgv의 Row수 따라 그에맞는 DetailList 가져옴
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_Order.Rows)
            {
                sb.Append($"'{row.Cells[0].Value.ToString()}',");
            }
            OrderDetail_AllList = service.GetOrderDetailList(sb.ToString().Trim(','));  // 디테일 AllList 갱신
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            dgv_Order.DataSource = null;
            dgv_OrderDetail.DataSource = null;
            Order_AllList = service.GetOrderCompletedList();
            GetOrderDetail_List();            

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Clear();
            Search_Period.Startdate.Clear();
            Search_Period.Enddate.Clear();
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_Period.Startdate.Text == "    -  -") { main.NoticeMessage = Properties.Settings.Default.PeriodError; }
            else
            {
                SearchedList = Order_AllList;
                if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
                {
                    SearchedList = (from   item in SearchedList
                                    where  item.Customer_Name == Search_Customer.CodeTextBox.Text
                                    select item).ToList();
                }

                if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
                {
                    SearchedList = (from   item in SearchedList
                                    where  item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                           item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                    select item).ToList();
                }
                dgv_Order.DataSource = SearchedList;
                dgv_OrderDetail.DataSource = null;
                GetOrderDetail_List();
                main.NoticeMessage = Properties.Settings.Default.SearchDone; 
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_Order.Rows.Count > 0)
            {
                using (WaitForm frm = new WaitForm())
                {
                    frm.Processing = ExcelExport;
                    frm.ShowDialog();
                }
            }
        }
        public void ExcelExport()
        {
            List<Order> master = SearchedList.ToList();
            List<OrderDetail> detail = OrderDetail_AllList.ToList();
            string[] exceptColumns = { "Order_DeletedYN" };
            UtilClass.ExportTo2DataGridView(master, detail, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void OrderCompleteForm_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.NoticeMessage = notice;
        }

        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = false;
            main.삭제ToolStripMenuItem.Visible = false;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void OrderCompleteForm_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
