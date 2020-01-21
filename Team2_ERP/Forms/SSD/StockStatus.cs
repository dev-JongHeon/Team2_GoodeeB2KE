using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class StockStatus : Base1Dgv
    {
        public StockStatus()
        {
            InitializeComponent();
        }
        private void StockStatus_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            UtilClass.AddNewColum(dgv_StockStatus, "수불번호", "StockReceipt_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "수불유형", "StockReceipt_Division1", true);
            UtilClass.AddNewColum(dgv_StockStatus, "처리일시", "StockReceipt_Date", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고명", "Warehouse_Name", true);
            UtilClass.AddNewColum(dgv_StockStatus, "품번", "Product_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_StockStatus, "수불수량", "StockReceipt_Quantity", true);
            UtilClass.AddNewColum(dgv_StockStatus, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고유형", "Warehouse_Division", false);

            
        }


    }
}
