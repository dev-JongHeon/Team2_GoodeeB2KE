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
    public partial class ShipmentCompleteForm : Base2Dgv
    {
        ShipmentService service = new ShipmentService();
        List<ShipmentDetail> ShipmentDetail_AllList = null;
        MainForm main;
        public ShipmentCompleteForm()
        {
            InitializeComponent();
        }

        private void ShipmentCompleteForm_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Shipment);
            UtilClass.AddNewColum(dgv_Shipment, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문일시", "Order_Date", true, 140);
            UtilClass.AddNewColum(dgv_Shipment, "고객ID", "Customer_userID", true, 90);
            UtilClass.AddNewColum(dgv_Shipment, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시일시", "Shipment_RequiredDate", true, 140);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시자", "Employees_Name", true, 110);
            UtilClass.AddNewColum(dgv_Shipment, "출하처리일시", "Shipment_DoneDate", true, 140);
            dgv_Shipment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd   hh:mm:ss";
            dgv_Shipment.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[5].DefaultCellStyle.Format = "yyyy-MM-dd   hh:mm:ss";
            dgv_Shipment.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[7].DefaultCellStyle.Format = "yyyy-MM-dd   hh:mm:ss";
            dgv_Shipment.DataSource = service.GetShipmentCompletedList();

            UtilClass.SettingDgv(dgv_ShipmentDetail);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "주문수량", "OrderDetail_Qty", true);
            ShipmentDetail_AllList = service.GetShipmentDetailList();

            main.NoticeMessage = "출하완료현황 화면입니다.";
        }

        private void dgv_Shipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string shipment_id = dgv_Shipment.CurrentRow.Cells[0].Value.ToString();
            List<ShipmentDetail> ShipmentDetail_List = (from list_detail in ShipmentDetail_AllList
                                                        where list_detail.Shipment_ID == shipment_id
                                                        select list_detail).ToList();
            dgv_ShipmentDetail.DataSource = ShipmentDetail_List;
        }
    }
}
