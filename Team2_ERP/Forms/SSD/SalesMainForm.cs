using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Service;

namespace Team2_ERP
{
    public partial class SalesMainForm : Base1Dgv
    {
        OrderService service = new OrderService();
        public SalesMainForm()
        {
            InitializeComponent();
        }

        private void SalesMainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_SalesStatus);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "고객ID", "Customer_userID", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문일시", "Order_Date", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "출하처리일시", "Shipment_DoneDate", true);
            UtilClass.AddNewColum(dgv_SalesStatus, "주문총액", "TotalPrice", true);

            dgv_SalesStatus.DataSource = service.GetSalesStatus();
        }
    }
}
