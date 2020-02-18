using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Properties;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class OrderMainForm : Base2Dgv
    {
        #region 전역변수
        OrderService service = new OrderService();
        List<Order> Order_AllList = null;  // Masters
        List<OrderDetail> OrderDetail_AllList = null;  // Details
        List<Order> SearchedList = null;  // 검색용
        MainForm main; 
        #endregion
        public OrderMainForm()
        {
            InitializeComponent();
        }

        private void OrderMainForm_Load(object sender, EventArgs e)
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
            UtilClass.AddNewColum(dgv_Order, "주문일시", "Order_Date", true, 170);
            UtilClass.AddNewColum(dgv_Order, "배송지주소", "Order_Address1", true, 300);
            UtilClass.AddNewColum(dgv_Order, "배송지상세주소", "Order_Address2", true, 250);
            UtilClass.AddNewColum(dgv_Order, "주문총액", "TotalPrice", true);
            dgv_Order.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Order.Columns[3].DefaultCellStyle.Format = "yyyy-MM-dd   HH:mm";
            dgv_Order.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Order.Columns[6].DefaultCellStyle.Format = "#,#0원";
            Order_AllList = service.GetOrderList();

            UtilClass.SettingDgv(dgv_OrderDetail);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문번호", "Order_ID", false);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품ID", "Product_ID", true);
            UtilClass.AddNewColum(dgv_OrderDetail, "제품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_OrderDetail, "주문수량", "OrderDetail_Qty", true);
            dgv_OrderDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_OrderDetail.Columns[3].DefaultCellStyle.Format = "#,#0개";

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
            Order_AllList = service.GetOrderList();
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
            main.NoticeMessage = Resources.RefreshDone;
        }

        public override void Modify(object sender, EventArgs e)  // 발주완료(수령)처리, 출하대기목록 Insert, 작업insert, 생산insert 
        {
            if (dgv_Order.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.NonData;
            }
            else
            {
                if (MessageBox.Show(Properties.Resources.IsOrder, Properties.Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string orderID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
                    service.UpOrder_InsShipment(orderID, Session.Employee_ID);
                    Func_Refresh();  // 새로고침
                    main.NoticeMessage = notice;
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Cancel, Properties.Resources.Notice);
                    main.NoticeMessage = notice;
                } 
            }
        }

        public override void Delete(object sender, EventArgs e)  // 삭제
        {
            if (dgv_Order.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.NonData;
            }
            else
            {
                if (MessageBox.Show(Properties.Resources.IsCancelOrder, Properties.Resources.Notice, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string order_ID = dgv_Order.CurrentRow.Cells[0].Value.ToString();
                    service.DeleteOrder(order_ID);
                    Func_Refresh();  // 새로고침
                    main.NoticeMessage = notice;
                }
                else
                {
                    MessageBox.Show(Properties.Resources.Cancel);
                    main.NoticeMessage = notice;
                }
            }
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            if (Search_Period.Startdate.Text == "    -  -") { main.NoticeMessage = Resources.PeriodError; }
            else
            {
                SearchedList = Order_AllList;
                if (Search_Customer.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
                {
                    SearchedList = (from item in SearchedList
                                     where item.Customer_Name == Search_Customer.CodeTextBox.Text
                                     select item).ToList();
                }

                if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
                {
                    SearchedList = (from item in SearchedList
                                     where item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                            item.Order_Date.Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                     select item).ToList();
                }
                dgv_Order.DataSource = SearchedList;
                dgv_OrderDetail.DataSource = null;
                GetOrderDetail_List();
                main.NoticeMessage = Resources.SearchDone;
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_Order.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.ExcelError;
            }
            else
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
            string[] exceptColumns = { "Order_DeletedYN", "OrderCompleted_Date" };
            UtilClass.ExportTo2DataGridView(master, detail, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {
            if (dgv_Order.Rows.Count == 0)
            {
                main.NoticeMessage = Properties.Resources.NonData;
            }
            else
            {
                using (WaitForm frm = new WaitForm())
                {
                    OrderReport br = new OrderReport();
                    dsOrder ds = new dsOrder();

                    ds.Relations.Clear();
                    ds.Tables.Clear();
                    ds.Tables.Add(UtilClass.ConvertToDataTable(SearchedList));
                    ds.Tables.Add(UtilClass.ConvertToDataTable(OrderDetail_AllList));
                    ds.Tables[0].TableName = "dtOrder";
                    ds.Tables[1].TableName = "dtOrderDetail";
                    ds.Relations.Add("dtOrder_dtOrderDetail", ds.Tables[0].Columns["Order_ID"], ds.Tables[1].Columns["Order_ID"]);

                    //ds.AcceptChanges();

                    br.DataSource = ds;
                    using (ReportPrintTool printTool = new ReportPrintTool(br))
                    {
                        printTool.ShowRibbonPreviewDialog();
                    }  
                }
            }
        }  
        #endregion

        #region Activated, OnOff, DeActivate
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
            main.삭제ToolStripMenuItem.Text = "주문취소";
            main.삭제ToolStripMenuItem.ToolTipText = "주문취소(Ctrl+D)";
            main.NoticeMessage = notice;
        }

        private void OrderMainForm_Deactivate(object sender, EventArgs e)
        {
            main.수정ToolStripMenuItem.Text = "수정";
            main.수정ToolStripMenuItem.ToolTipText = "수정(Ctrl+M)";
            main.삭제ToolStripMenuItem.Text = "삭제";
            main.삭제ToolStripMenuItem.ToolTipText = "삭제(Ctrl+D)";
            new SettingMenuStrip().UnsetMenu(this);
        } 
        #endregion
    }
}
