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
using Team2_VO;

namespace Team2_ERP
{
    public partial class BaljuList : Base2Dgv
    {
        BaljuService service = new BaljuService();
        List<Balju> Balju_AllList = null;  // 발주 List
        List<BaljuDetail> BaljuDetail_AllList = null;  // 발주디테일 List
        MainForm main;

        public BaljuList()
        {
            InitializeComponent();
        }

        private void BaljuList_Load(object sender, EventArgs e)
        {
            LoadData();
            main = (MainForm)this.MdiParent;
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Balju);
            UtilClass.AddNewColum(dgv_Balju, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_Balju, "거래처코드", "Company_ID", true);
            UtilClass.AddNewColum(dgv_Balju, "거래처명칭", "Company_Name", true);
            UtilClass.AddNewColum(dgv_Balju, "발주요청일시", "Balju_Date", true);
            UtilClass.AddNewColum(dgv_Balju, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_Balju, "삭제여부", "Balju_DeletedYN", false);
            dgv_Balju.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Balju.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Balju.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Balju.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Balju_AllList = service.GetBaljuList();  // 발주리스트 갱신
            dgv_Balju.DataSource = Balju_AllList;

            UtilClass.SettingDgv(dgv_BaljuDetail);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true);
            dgv_BaljuDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BaljuDetail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_BaljuDetail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_BaljuDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            BaljuDetail_AllList = service.GetBalju_DetailList(); // 발주디테일 AllList 갱신

        }

        private void dgv_Balju_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Balju_ID = dgv_Balju.CurrentRow.Cells[0].Value.ToString();
            List<BaljuDetail> BaljuDetail_List = (from   list_detail in BaljuDetail_AllList
                                                  where  list_detail.Balju_ID == Balju_ID
                                                  select list_detail).ToList();
            dgv_BaljuDetail.DataSource = BaljuDetail_List;
        }

        public override void Search(object sender, EventArgs e)
        {
            Balju_AllList = service.GetBaljuList();  // 발주리스트 갱신
            if (Search_Company.CodeTextBox.Text.Length > 0)  // 회사 검색조건 있으면
            {
                Balju_AllList = (from   item in Balju_AllList
                                    where  item.Company_Name == Search_Company.CodeTextBox.Text
                                    select item).ToList();
            }
            if (Search_Employee.CodeTextBox.Text.Length > 0)  // 사원 검색조건 있으면
            {
                Balju_AllList = (from   item in Balju_AllList
                                    where  item.Employees_Name == Search_Employee.CodeTextBox.Text
                                    select item).ToList();
            }
            if (Search_Period.Startdate.Text != "    -  -")   // 시작기간 text가 존재하면
            {
                if (Search_Period.Startdate.Text != Search_Period.Enddate.Text)  // 시작~끝 날짜 다른경우
                {
                    Balju_AllList = (from   item in Balju_AllList
                                        where  item.Balju_Date.CompareTo(Convert.ToDateTime(Search_Period.Startdate.Text)) >= 0 &&
                                               item.Balju_Date.CompareTo(Convert.ToDateTime(Search_Period.Enddate.Text)) <= 0
                                        select item).ToList();
                }
                else   // 같은경우
                {
                    Balju_AllList = (from   item in Balju_AllList
                                        where  item.Balju_Date.Date == Convert.ToDateTime(Search_Period.Startdate.Text)
                                        select item).ToList();
                }
            }
            dgv_Balju.DataSource = Balju_AllList;
            dgv_BaljuDetail.DataSource = null;
        }

        public override void Refresh(object sender, EventArgs e)  // 새로고침
        {
            Func_Refresh();
        }

        public override void Modify(object sender, EventArgs e)  // 발주완료(수령)처리
        {
            if (MessageBox.Show("정말로 발주완료 처리하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Balju_ID = dgv_Balju.CurrentRow.Cells[0].Value.ToString();
                service.UpdateBalju_Processed(Balju_ID);
                Func_Refresh();  // 새로고침
            }
        }

        public override void Delete(object sender, EventArgs e)  // 삭제
        {
            if (MessageBox.Show("정말로 해당 발주요청을 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string Balju_ID = dgv_Balju.CurrentRow.Cells[0].Value.ToString();
                service.DeleteBalju(Balju_ID);
                Func_Refresh();  // 새로고침
            }
        }

        public override void Print(object sender, EventArgs e)  // 인쇄
        {

        }

        private void Func_Refresh()  // 새로고침 기능
        {
            Balju_AllList = service.GetBaljuList();
            BaljuDetail_AllList = service.GetBalju_DetailList();

            dgv_Balju.DataSource = Balju_AllList;
            dgv_BaljuDetail.DataSource = null;

            // 검색조건 초기화
            Search_Period.Startdate.Text = "";
            Search_Period.Enddate.Text = "";
            Search_Company.CodeTextBox.Text = "";
            Search_Employee.CodeTextBox.Text = "";
        }

        private void BaljuList_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            main.수정ToolStripMenuItem.Text = "처리";
            main.수정ToolStripMenuItem.ToolTipText = "처리(Ctrl+M)";
        }

        public override void MenuStripONOFF(bool flag)
        {
            main.신규ToolStripMenuItem.Visible = false;
            main.수정ToolStripMenuItem.Visible = flag;
            main.삭제ToolStripMenuItem.Visible = flag;
            main.인쇄ToolStripMenuItem.Visible = flag;
        }


        private void BaljuList_Deactivate(object sender, EventArgs e)
        {
            main.수정ToolStripMenuItem.Text = "수정";
            main.수정ToolStripMenuItem.ToolTipText = "수정(Ctrl+M)";
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
