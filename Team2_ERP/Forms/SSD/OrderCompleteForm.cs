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
        List<Order> Order_AllList = null;
        List<OrderDetail> OrderDetail_AllList = null;
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
            UtilClass.AddNewColum(dgv_Order, "주문처리일시", "OrderComplete_Date", true, 140);

            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true, 300);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true, 250);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            dgv_Order.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Order.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            dgv_Order.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Order.Columns[4].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            dgv_Order.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Order.Columns[6].DefaultCellStyle.Format = "#,#0원";
            dgv_Order.DataSource = service.GetOrderCompletedList();

            UtilClass.SettingDgv(dgv_OrderDetail);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문수량", "OrderDetail_Qty", true);
            OrderDetail_AllList = service.GetOrderDetailList();
        }

        private void dgv_Order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  // Master 더블클릭 이벤트
        {
            string Order_ID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
            List<OrderDetail> OrderDetail_List = (from list_detail in OrderDetail_AllList
                                                  where list_detail.Order_ID == Order_ID
                                                  select list_detail).ToList();
            dgv_OrderDetail.DataSource = OrderDetail_List;
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            Order_AllList = service.GetOrderCompletedList();
            OrderDetail_AllList = service.GetOrderDetailList();

            dgv_Order.DataSource = Order_AllList;
            dgv_OrderDetail.DataSource = null;

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Text = "";
            Search_Period.Startdate.Text = "";
            Search_Period.Enddate.Text = "";
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = "새로고침(갱신) 되었습니다.";
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            Order_AllList = service.GetOrderCompletedList();  // 주문리스트 갱신
            if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
            {
                Order_AllList = (from item in Order_AllList
                                 where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                 select item).ToList();
            }

            if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
            {
                if (Search_Period.Startdate.Text != Search_Period.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                            item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                else   // 같은경우
                {
                    Order_AllList = (from item in Order_AllList
                                     where item.Order_Date.Date == Convert.ToDateTime(Search_Period.Startdate.Text)
                                     select item).ToList();
                }
            }
            dgv_Order.DataSource = Order_AllList;
            dgv_OrderDetail.DataSource = null;
            main.NoticeMessage = "검색 되었습니다.";
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void BaljuList_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.NoticeMessage = "주문완료현황 화면입니다.";
        }

        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = false;
            main.삭제ToolStripMenuItem.Visible = false;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void BaljuList_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
