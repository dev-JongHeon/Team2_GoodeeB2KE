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
        OrderService service = new OrderService();
        List<OrderDetail> OrderDetail_AllList = null;
        public OrderCompleteForm()
        {
            InitializeComponent();
        }

        private void OrderCompleteForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Order);
            UtilClass.AddNewColum(dgv_Order, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Order, "고객ID", "Customer_UserID", true);
            UtilClass.AddNewColum(dgv_Order, "주문일시", "Order_Date", true);
            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            UtilClass.AddNewColum(dgv_Order, "삭제여부", "Order_DeletedYN", false);
            UtilClass.AddNewColum(dgv_Order, "주문상태", "Order_State", false);
            dgv_Order.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Order.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Order.Columns[5].DefaultCellStyle.Format = "#,#0원";
            dgv_Order.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_Order.DataSource = service.GetOrderCompletedList();

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
    }
}
