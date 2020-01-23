using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class UserAuth : Base2Dgv
    {
        MainForm frm;
        public UserAuth()
        {
            InitializeComponent();
        }

        private void UserAuth_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvEmpList);
            UtilClass.AddNewColum(dgvEmpList, "사원번호", "ID");
            UtilClass.AddNewColum(dgvEmpList, "사원명", "Name");

            UtilClass.SettingDgv(dgvAuthList);

            try
            {
                SearchService service = new SearchService();
                dgvEmpList.DataSource = service.GetInfo("Employee");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

           
        }

        private void UserAuth_Activated(object sender, EventArgs e)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = false;
        }

        private void UserAuth_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
