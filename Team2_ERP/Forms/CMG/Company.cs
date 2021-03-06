﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Company : BaseForm
    {
        List<CompanyVO> list;

        MainForm frm;

        CompanyVO item;

        public Company()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvCompany);

            UtilClass.AddNewColum(dgvCompany, "거래처ID", "Company_ID", true, 100);
            UtilClass.AddNewColum(dgvCompany, "거래처명", "Company_Name", true, 100);
            UtilClass.AddNewColum(dgvCompany, "우편번호", "Company_AddrNumber", true, 100);
            UtilClass.AddNewColum(dgvCompany, "주소", "Company_Address", true, 100);
            UtilClass.AddNewColum(dgvCompany, "전화번호", "Company_Number", true, 100);
            UtilClass.AddNewColum(dgvCompany, "FAX번호", "Company_Fax", true, 100);
            UtilClass.AddNewColum(dgvCompany, "구분ID", "CodeTable_CodeID", false, 100);
            UtilClass.AddNewColum(dgvCompany, "구분", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvCompany, "대표명", "Company_Owner", true, 100);

            dgvCompany.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                StandardService service = new StandardService();
                list = service.GetAllCompany();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvCompany.DataSource = list;
            dgvCompany.CurrentCell = null;
        }

        private void Company_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            frm.NoticeMessage = Resources.RefreshDone;
            dgvCompany.DataSource = null;
            searchCompanyName.CodeTextBox.Clear();
        }

        public override void New(object sender, EventArgs e)
        {
            CompanyInsUp popup = new CompanyInsUp(CompanyInsUp.EditMode.Insert, null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                frm.NoticeMessage = Resources.AddDone;
                dgvCompany.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvCompany.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                CompanyInsUp popup = new CompanyInsUp(CompanyInsUp.EditMode.Update, item);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.ModDone;
                    dgvCompany.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvCompany.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.DelEmpty;
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        StandardService service = new StandardService();
                        service.DeleteCompany(item.Company_ID);
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    frm.NoticeMessage = Resources.DeleteDone;
                    dgvCompany.DataSource = null;
                    LoadGridView();
                }
            }
        }
        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();

            if (searchCompanyName.CodeTextBox.Tag != null)
            {
                dgvCompany.DataSource = null;
                List<CompanyVO> searchList = (from item in list where item.Company_ID.Equals(Convert.ToInt32(searchCompanyName.CodeTextBox.Tag)) select item).ToList();
                dgvCompany.DataSource = searchList;
            }

            frm.NoticeMessage = Resources.SearchDone;
            dgvCompany.CurrentCell = null;
        }

        private void Company_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        private void Company_Deactivate(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvCompany.Rows.Count && e.RowIndex > -1)
            {
                if (dgvCompany.Rows[e.RowIndex].Cells[5].Value == null)
                {
                    item = new CompanyVO
                    {
                        Company_ID = Convert.ToInt32(dgvCompany.Rows[e.RowIndex].Cells[0].Value),
                        Company_Name = dgvCompany.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Company_AddrNumber = dgvCompany.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        Company_Address = dgvCompany.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Company_Number = dgvCompany.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        CodeTable_CodeID = dgvCompany.Rows[e.RowIndex].Cells[6].Value.ToString(),
                        Company_Owner = dgvCompany.Rows[e.RowIndex].Cells[8].Value.ToString()
                    };
                }
                else
                {
                    item = new CompanyVO
                    {
                        Company_ID = Convert.ToInt32(dgvCompany.Rows[e.RowIndex].Cells[0].Value),
                        Company_Name = dgvCompany.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Company_AddrNumber = dgvCompany.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        Company_Address = dgvCompany.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Company_Number = dgvCompany.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        Company_Fax = dgvCompany.Rows[e.RowIndex].Cells[5].Value.ToString(),
                        CodeTable_CodeID = dgvCompany.Rows[e.RowIndex].Cells[6].Value.ToString(),
                        Company_Owner = dgvCompany.Rows[e.RowIndex].Cells[8].Value.ToString()
                    };
                }
            }
        }
    }
}