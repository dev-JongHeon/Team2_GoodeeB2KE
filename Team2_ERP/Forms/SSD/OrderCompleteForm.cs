using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;

namespace Team2_ERP
{ 
    public partial class OrderCompleteForm : Base2Dgv
    {
        OrderDAC dac = new OrderDAC();
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
            UtilClass.AddNewColum(dgv_Order, "주문일자", "Order_Date", true);
            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            UtilClass.AddNewColum(dgv_Order, "삭제여부", "Order_DeletedYN", false);
            UtilClass.AddNewColum(dgv_Order, "주문상태", "Order_State", false);

            dgv_Order.DataSource = dac.GetOrderList();

            UtilClass.SettingDgv(dgv_OrderDetail);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문갯수", "OrderDetail_Qty", true);
        }


    }
}
