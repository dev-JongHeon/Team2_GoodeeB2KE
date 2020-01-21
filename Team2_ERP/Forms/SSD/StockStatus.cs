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
            UtilClass.AddNewColum(dgv_StockStatus, "품번", "Product_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "품명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_StockStatus, "카테고리", "Product_Category", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고명", "Warehouse_Name", true);
            UtilClass.AddNewColum(dgv_StockStatus, "단가", "Product_Price", true);
            UtilClass.AddNewColum(dgv_StockStatus, "재고량", "Product_Qty", true);
            UtilClass.AddNewColum(dgv_StockStatus, "안전재고량", "Product_Safety", true);
            UtilClass.AddNewColum(dgv_StockStatus, "차이수량", "Count_Subtract", true);
            UtilClass.AddNewColum(dgv_StockStatus, "삭제여부", "Product_DeletedYN", false); 
        }


    }
}
