using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class OrderMainForm : Base2Dgv
    {
        OrderService service = new OrderService();
        List<Order> Order_AllList = null;
        List<OrderDetail> OrderDetail_AllList = null;
        MainForm main;
        public OrderMainForm()
        {
            InitializeComponent();
        }

        private void OrderMainForm_Load(object sender, EventArgs e)
        {
            LoadData();
            main = (MainForm)this.MdiParent;
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Order);
            UtilClass.AddNewColum(dgv_Order, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Order, "고객ID", "Customer_UserID", true);
            UtilClass.AddNewColum(dgv_Order, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_Order, "주문일시", "Order_Date", true);
            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            UtilClass.AddNewColum(dgv_Order, "삭제여부", "Order_DeletedYN", false);
            UtilClass.AddNewColum(dgv_Order, "주문상태", "Order_State", false);
            dgv_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Order.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[6].DefaultCellStyle.Format = "#,#0원";
            dgv_Order.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Order_AllList = service.GetOrderList();
            dgv_Order.DataSource = Order_AllList;

            UtilClass.SettingDgv(dgv_OrderDetail);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문수량", "OrderDetail_Qty", true);
            dgv_OrderDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_OrderDetail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_OrderDetail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_OrderDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            OrderDetail_AllList = service.GetOrderDetailList();
        }

        private void dgv_Order_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Order_ID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
            List<OrderDetail> OrderDetail_List = (from list_detail in OrderDetail_AllList
                                                  where list_detail.Order_ID == Order_ID
                                                  select list_detail).ToList();
            dgv_OrderDetail.DataSource = OrderDetail_List;
        }

        public override void Modify(object sender, EventArgs e)  // 발주완료(수령)처리 및 출하대기목록 Insert
        {
            if (MessageBox.Show("정말 해당주문을 처리하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string orderID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
                service.UpOrder_InsShipment(orderID, Session.Employee_ID);
                
                Func_Refresh();  // 새로고침
            }
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            Order_AllList = service.GetOrderList();
            OrderDetail_AllList = service.GetOrderDetailList();

            dgv_Order.DataSource = Order_AllList;
            dgv_OrderDetail.DataSource = null;

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Text = "";
            Search_Period.Startdate.Text = "";
            Search_Period.Enddate.Text = "";
        }


        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = flag;
            main.삭제ToolStripMenuItem.Visible = flag;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void OrderMainForm_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.수정ToolStripMenuItem.Text = "주문처리";
            main.수정ToolStripMenuItem.ToolTipText = "주문처리(Ctrl+M)";
        }

        private void OrderMainForm_Deactivate(object sender, EventArgs e)
        {
            main.수정ToolStripMenuItem.Text = "수정";
            main.수정ToolStripMenuItem.ToolTipText = "수정(Ctrl+M)";
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
