﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Service;

namespace Team2_ERP
{
    public partial class StockStatus : Base1Dgv
    {
        #region 전역변수
        StockService service = new StockService();
        List<Team2_VO.StockStatus> StockStatus_AllList = null;
        List<Team2_VO.StockStatus> SearchedList = null;
        MainForm main; 
        #endregion
        public StockStatus()
        {
            InitializeComponent();
        }
        private void StockStatus_Load(object sender, EventArgs e)
        {
            main = (MainForm)this.MdiParent;
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
            StockStatus_AllList = service.GetStockStatus();
        }

        private void Func_Refresh()  // 새로고침 기능
        {
            dgv_StockStatus.DataSource = null;
            StockStatus_AllList = service.GetStockStatus();

            // 검색조건 초기화
            Search_Product.CodeTextBox.Clear();
            Search_Warehouse.CodeTextBox.Clear();
            Search_Category.CodeTextBox.Clear();
        }

        #region ToolStrip 기능정의
        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
            main.NoticeMessage = Properties.Settings.Default.RefreshDone;
        }

        public override void Search(object sender, EventArgs e)  // 검색
        {
            SearchedList = StockStatus_AllList;
            if (Search_Product.CodeTextBox.Text.Length > 0)  // 고객명 검색조건 있으면
            {
                SearchedList = (from item in SearchedList
                                       where item.Product_Name == Search_Product.CodeTextBox.Text
                                       select item).ToList();
            }

            if (Search_Warehouse.CodeTextBox.Text.Length > 0)  // 출하지시자 검색조건 있으면
            {
                SearchedList = (from item in SearchedList
                                       where item.Warehouse_Name == Search_Warehouse.CodeTextBox.Text
                                       select item).ToList();
            }
            if (Search_Category.CodeTextBox.Text.Length > 0)  // 출하지시자 검색조건 있으면
            {
                SearchedList = (from item in SearchedList
                                       where item.CodeTable_CodeName == Search_Category.CodeTextBox.Text
                                       select item).ToList();
            }
            dgv_StockStatus.DataSource = SearchedList;
            main.NoticeMessage = Properties.Settings.Default.SearchDone;
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgv_StockStatus.Rows.Count > 0)
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
            string[] exceptColumns = { "Warehouse_Division" };
            UtilClass.ExportToDataGridView(dgv_StockStatus, exceptColumns);
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }
        #endregion

        #region Activated, OnOff, DeActivate
        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = false;
            main.삭제ToolStripMenuItem.Visible = false;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void StockStatus_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.NoticeMessage = notice;
        }

        private void StockStatus_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
        #endregion
    }
}
