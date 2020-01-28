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
    public partial class InOutList_SemiProductWarehouse : Base1Dgv
    {
        StockService service = new StockService();
        List<StockReceipt> StockReceipt_AllList = null;
        public InOutList_SemiProductWarehouse()
        {
            InitializeComponent();
        }

        private void InOutList_SemiProductWarehouse_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Stock);
            UtilClass.AddNewColum(dgv_Stock, "수불번호", "StockReceipt_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "수불유형", "StockReceipt_Division1", true);
            UtilClass.AddNewColum(dgv_Stock, "처리일시", "StockReceipt_Date", true);
            UtilClass.AddNewColum(dgv_Stock, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "창고명", "Warehouse_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "품번", "Product_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "수불수량", "StockReceipt_Quantity", true);
            UtilClass.AddNewColum(dgv_Stock, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "창고유형", "Warehouse_Division", false);
            dgv_Stock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_Stock.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_Stock.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_Stock.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            StockReceipt_AllList = service.GetStockReceipts(); // 수불내역 갱신

            // LINQ로 반제품창고에 속한 수불현황만 가져옴
            List<StockReceipt> StockReceipt_list = (from list_Stock in StockReceipt_AllList
                                             where list_Stock.Warehouse_Division == true
                                             select list_Stock).ToList();
            dgv_Stock.DataSource = StockReceipt_list;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_All.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true
                                        select list_Stock).ToList();
            }
            else if (rdo_In.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true && list_Stock.StockReceipt_Division1 == "입고"
                                        select list_Stock).ToList();
            }
            else if (rdo_Out.Checked)
            {
                dgv_Stock.DataSource = (from list_Stock in StockReceipt_AllList
                                        where list_Stock.Warehouse_Division == true && list_Stock.StockReceipt_Division1 == "출고"
                                        select list_Stock).ToList();
            }
        }
    }
}
