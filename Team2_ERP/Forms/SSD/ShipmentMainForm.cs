﻿using System;
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
    public partial class ShipmentMainForm : Base2Dgv
    {
        List<OrderDetail> ShipmentDetail_AllList = null;
        ShipmentService service = new ShipmentService();
        public ShipmentMainForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Shipment);
            UtilClass.AddNewColum(dgv_Shipment, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문일시", "Order_Date", true);
            UtilClass.AddNewColum(dgv_Shipment, "고객ID", "Customer_userID", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시일시", "Shipment_RequiredDate", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시자", "Employees_Name", true);
            dgv_Shipment.DataSource = service.GetShipmentList();

            UtilClass.SettingDgv(dgv_ShipmentDetail);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "주문수량", "OrderDetail_Qty", true);
            ShipmentDetail_AllList = service.GetOrderDetailList();
        }

        private void ShipmentMainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgv_Shipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Order_ID = dgv_Shipment.CurrentRow.Cells[1].Value.ToString();
            List<OrderDetail> ShipmentDetail_List = (from list_detail in ShipmentDetail_AllList
                                                     where list_detail.Order_ID == Order_ID
                                                     select list_detail).ToList();
            dgv_ShipmentDetail.DataSource = ShipmentDetail_List;
        }
    }
}
