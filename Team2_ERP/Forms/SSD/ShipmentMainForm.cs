using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class ShipmentMainForm : Base2Dgv
    {

        public ShipmentMainForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Shipment);
            UtilClass.AddNewColum(dgv_Shipment, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문일시", "Order_date", true);
            UtilClass.AddNewColum(dgv_Shipment, "고객ID", "Customer_UserID", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시일", "Shipment_RequiredDate", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시자", "Empolyees_Name", true);
            UtilClass.AddNewColum(dgv_Shipment, "X", "Shipment_DoneDate", false);


            UtilClass.SettingDgv(dgv_ShipmentDetail);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "출하번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "주문수량", "OrderDetail_Qty", true);

        }

        private void ShipmentMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
