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
    public partial class InOutList_MaterialWarehouse : Base1Dgv
    {
        StockDAC dac = new StockDAC();
        List<Stock> StockReceipt_AllList = null;
        public InOutList_MaterialWarehouse()
        {
            InitializeComponent();
        }

        private void InOutList_MaterialWarehouse_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        

        private void LoadData()
        {
            UtilClass.AddNewColum(dgv_Stock, "수불번호", "StockReceipt_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "수불유형", "StockReceipt_Division", true);
            UtilClass.AddNewColum(dgv_Stock, "수불일자", "StockReceipt_Date", true);
            UtilClass.AddNewColum(dgv_Stock, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "창고명", "Warehouse_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "품번", "Product_ID", true);
            UtilClass.AddNewColum(dgv_Stock, "품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_Stock, "수불수량", "StockReceipt_Quantity", true);
            UtilClass.AddNewColum(dgv_Stock, "등록사원", "Employees_ID", true);
            StockReceipt_AllList = dac.GetStockReceipts(); // 자재수불내역 갱신

            List<Stock> BaljuDetail_List = (from list_Stock in StockReceipt_AllList
                                                  where list_Stock.Warehouse_Division == false
                                                  select list_Stock).ToList();
            dgv_Stock.DataSource = BaljuDetail_List;
        }
    }
}
