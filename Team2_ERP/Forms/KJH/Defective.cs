using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class Defective : BaseForm
    {
        MainForm frm;

        public Defective()
        {
            InitializeComponent();
        }

        private void Defective_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            UtilClass.SettingDgv(dgvDefective);
            UtilClass.AddNewColum(dgvDefective, "불량번호", "Defective_ID");
            UtilClass.AddNewColum(dgvDefective, "공정번호", "Line_ID",false);
            UtilClass.AddNewColum(dgvDefective, "공정명", "Line_Name");
            



        }

        private void Defective_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
        }

        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.인쇄ToolStripMenuItem.Visible = flag;
        }

        private void Defective_Deactivate(object sender, EventArgs e)
        {
            new SettingMenuStrip().UnsetMenu(this);
        }
    }
}
