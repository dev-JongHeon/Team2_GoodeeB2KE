using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Service;

namespace Team2_ERP
{
    public partial class StockStatus : Base1Dgv
    {
        StockService service = new StockService();
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
            UtilClass.SettingDgv(dgv_StockStatus);
            UtilClass.AddNewColum(dgv_StockStatus, "품번", "Product_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "품명", "Product_Name", true, 300);
            UtilClass.AddNewColum(dgv_StockStatus, "카테고리", "CodeTable_CodeName", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고코드", "Warehouse_ID", true);
            UtilClass.AddNewColum(dgv_StockStatus, "창고명", "Warehouse_Name", true, 160);
            UtilClass.AddNewColum(dgv_StockStatus, "단가", "Product_Price", true);
            UtilClass.AddNewColum(dgv_StockStatus, "재고량", "Product_Qty", true, 90);
            UtilClass.AddNewColum(dgv_StockStatus, "안전재고량", "Product_Safety", true, 110);
            UtilClass.AddNewColum(dgv_StockStatus, "차이수량", "Count_Subtract", true);
            UtilClass.AddNewColum(dgv_StockStatus, "삭제여부", "Product_DeletedYN", false);
            dgv_StockStatus.Columns[5].DefaultCellStyle.Format = "#,#0원";
            dgv_StockStatus.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_StockStatus.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_StockStatus.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_StockStatus.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv_StockStatus.DataSource = service.GetStockStatus();
        }
    }
}
