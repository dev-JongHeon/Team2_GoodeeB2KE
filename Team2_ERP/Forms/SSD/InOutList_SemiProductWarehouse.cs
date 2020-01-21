using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public partial class InOutList_SemiProductWarehouse : Base1Dgv
    {
        StockDAC dac = new StockDAC();
        List<Stock> StockReceipt_AllList = null;
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

            StockReceipt_AllList = dac.GetStockReceipts(); // 자재수불내역 갱신

            // LINQ로 반제품창고에 속한것만 가져옴
            List<Stock> StockReceipt_list = (from list_Stock in StockReceipt_AllList
                                             where list_Stock.Warehouse_Division == true
                                             select list_Stock).ToList();
            dgv_Stock.DataSource = StockReceipt_list;
        }
    }
}
