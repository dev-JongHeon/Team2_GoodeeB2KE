﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Category : BaseForm
    {
        List<CodeTableVO> list;
        string name = string.Empty;
        string context = string.Empty;

        public Category()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "카테고리코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리설명", "CodeTable_CodeExplain", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = service.GetAllCodeTable();
            List<CodeTableVO> categoryList = (from item in list where item.CodeTable_CodeID.Contains("S") && !item.CodeTable_CodeID.Contains("e") || item.CodeTable_CodeID.Contains("M") select item).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void Refresh(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            LoadGridView();
        }

        private void New(object sender, EventArgs e)
        {
            CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Insert, null, null);
            frm.ShowDialog();
        }

        private void Modify(object sender, EventArgs e)
        {
            CategoryInsUp frm = new CategoryInsUp(CategoryInsUp.EditMode.Update, name, context);
            frm.ShowDialog();
        }

        private void Delete(object sender, EventArgs e)
        {

        }

        private void Search(object sender, EventArgs e)
        {

        }
        
        private void Print(object sender, EventArgs e)
        {

        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingMenu()
        {
            new SettingMenuStrip().SetMenu(this, Refresh, New, Modify, Delete, Search, Print, Close);
        }

        private void Category_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadGridView();
            SettingMenu();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            context = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
