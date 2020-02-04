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
    public partial class ShipmentMainForm : Base2Dgv
    {
        #region 전역변수
        List<Shipment> Shipment_AllList = null;
        List<ShipmentDetail> ShipmentDetail_AllList = null;
        ShipmentService service = new ShipmentService();
        MainForm main; 
        #endregion
        public ShipmentMainForm()
        {
            InitializeComponent();
        }

        private void ShipmentMainForm_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Shipment);
            UtilClass.AddNewColum(dgv_Shipment, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문번호", "Order_ID", true);
            UtilClass.AddNewColum(dgv_Shipment, "주문일시", "Order_Date", true, 170);
            UtilClass.AddNewColum(dgv_Shipment, "주문처리일시", "OrderCompleted_Date", true, 170);
            UtilClass.AddNewColum(dgv_Shipment, "고객ID", "Customer_userID", true, 90);
            UtilClass.AddNewColum(dgv_Shipment, "고객성명", "Customer_Name", true);
            UtilClass.AddNewColum(dgv_Shipment, "출하요청날짜", "Shipment_RequiredDate", true, 120);
            UtilClass.AddNewColum(dgv_Shipment, "출하지시자", "Employees_Name", true, 110);
            dgv_Shipment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Shipment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Shipment.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Shipment.Columns[6].DefaultCellStyle.Format = "yyyy-MM-dd";
            Shipment_AllList = service.GetShipmentList();
            //dgv_Shipment.DataSource = Shipment_AllList;

            UtilClass.SettingDgv(dgv_ShipmentDetail);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "출하번호", "Shipment_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_ShipmentDetail, "주문수량", "OrderDetail_Qty", true);
            dgv_ShipmentDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            ShipmentDetail_AllList = service.GetShipmentDetailList();
        } 

        private void dgv_Shipment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string shipment_id = dgv_Shipment.CurrentRow.Cells[0].Value.ToString();
            List<ShipmentDetail> ShipmentDetail_List = (from list_detail in ShipmentDetail_AllList
                                                        where list_detail.Shipment_ID == shipment_id
                                                        select list_detail).ToList();
            dgv_ShipmentDetail.DataSource = ShipmentDetail_List;
        }// Master 더블클릭 이벤트

        private void Func_Refresh()  // 새로고침 기능
        {
            Shipment_AllList = service.GetShipmentList();
            ShipmentDetail_AllList = service.GetShipmentDetailList();

            dgv_Shipment.DataSource = Shipment_AllList;
            dgv_ShipmentDetail.DataSource = null;

            // 검색조건 초기화
            Search_Customer.CodeTextBox.Clear();
            Search_Employees.CodeTextBox.Clear();
            Search_OrderPeriod.Startdate.Clear();
            Search_OrderPeriod.Enddate.Clear();
            Search_ShipmentIndexPeriod.Startdate.Clear();
            Search_ShipmentIndexPeriod.Enddate.Clear();
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = "새로고침(갱신) 되었습니다.";
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            Shipment_AllList = service.GetShipmentList();  // 출하리스트 갱신
            if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
            {
                Shipment_AllList = (from item in Shipment_AllList
                                    where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                    select item).ToList();
            }

            if (Search_Employees.CodeTextBox.Text.Length > 0)  // 출하지시자 검색조건 있으면
            {
                Shipment_AllList = (from item in Shipment_AllList
                                    where item.Employees_Name == Search_Employees.CodeTextBox.Text
                                    select item).ToList();
            }

            if (Search_OrderPeriod.Startdate.Text != "    -  -")  //주문일시 검색조건 존재한다면
            {
                if (Search_OrderPeriod.Startdate.Text != Search_OrderPeriod.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    Shipment_AllList = (from item in Shipment_AllList
                                     where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderPeriod.Startdate.Text)) >= 0 &&
                                            item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_OrderPeriod.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                else   // 같은경우
                {
                    Shipment_AllList = (from item in Shipment_AllList
                                        where item.Order_Date.Date == Convert.ToDateTime(Search_OrderPeriod.Startdate.Text)
                                        select item).ToList();
                }
            }

            if (Search_ShipmentIndexPeriod.Startdate.Text != "    -  -")  // 출하지시일시 검색조건 존재한다면
            {
                if (Search_ShipmentIndexPeriod.Startdate.Text != Search_ShipmentIndexPeriod.Enddate.Text)  // 시작, 끝 날짜가 다른경우
                {
                    Shipment_AllList = (from item in Shipment_AllList
                                        where item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_ShipmentIndexPeriod.Startdate.Text)) >= 0 
                                              &&
                                              item.Shipment_RequiredDate.Date.CompareTo
                                              (Convert.ToDateTime(Search_ShipmentIndexPeriod.Enddate.Text)) <= 0
                                        select item).ToList();
                }
                else   // 같은경우
                {
                    Shipment_AllList = (from item in Shipment_AllList
                                        where item.Shipment_RequiredDate.Date == Convert.ToDateTime(Search_ShipmentIndexPeriod.Startdate.Text)
                                        select item).ToList();
                }
            }
            dgv_Shipment.DataSource = Shipment_AllList;
            dgv_ShipmentDetail.DataSource = null;
            main.NoticeMessage = "검색 되었습니다.";
        }

        public override void Excel(object sender, EventArgs e)
        {
            using (WaitForm frm = new WaitForm())
            {
                frm.Processing = ExcelExport;
                frm.ShowDialog();
            }
        }
        public void ExcelExport()
        {

        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate
        private void ShipmentMainForm_Activated(object sender, EventArgs e)
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

        private void ShipmentMainForm_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
