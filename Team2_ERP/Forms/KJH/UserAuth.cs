using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class UserAuth : Base2Dgv
    {
        MainForm frm;
        CheckBox headerbox = new CheckBox();
        int uid = 0;
        List<SearchedInfoVO> list = new List<SearchedInfoVO>();
        SearchService service = new SearchService();
        bool isFirst = true;
        public UserAuth()
        {
            InitializeComponent();
        }

        private void UserAuth_Load(object sender, EventArgs e)
        {
            frm = (MainForm)this.ParentForm;
            SettingDgvUserAuth();
            RefreshClicked();
            frm.NoticeMessage = notice;
        }

        private void SettingDgvUserAuth()
        {
            UtilClass.SettingDgv(dgvEmpList);
            UtilClass.AddNewColum(dgvEmpList, "사원번호", "ID");
            UtilClass.AddNewColum(dgvEmpList, "사원명", "Name");

            UtilClass.SettingDgv(dgvAuthList);
            UtilClass.AddNewColum(dgvAuthList, "메뉴명", "Form");
            DataGridViewCheckBoxColumn cbx = new DataGridViewCheckBoxColumn();
            cbx.DataPropertyName = "Auth";
            cbx.Width = 30;
            dgvAuthList.Columns.Add(cbx);

            Point headerLocation = dgvAuthList.GetCellDisplayRectangle(1, -1, true).Location;
            headerbox.Location = new Point(headerLocation.X + 8, headerLocation.Y + 5);
            headerbox.BackColor = Color.FromArgb(55, 113, 138);
            headerbox.Size = new Size(16, 16);
            headerbox.Click += new EventHandler(headerbox_Click);
            dgvAuthList.Controls.Add(headerbox);
            dgvAuthList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
        }

        private void RefreshClicked()
        {
            try
            {
                list = service.GetInfo("Employee");
                dgvEmpList.DataSource = null;
                dgvAuthList.DataSource = null;
                if (!isFirst)
                {
                    dgvEmpList.DataSource = list; 
                }
                ClearDgv();
                isFirst = false;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            ClearSearchOption();
            frm.NoticeMessage = Resources.RefreshDone;
        }

        private void ClearSearchOption()
        {
            txtSearch.CodeTextBox.Clear();
            headerbox.Checked = false;
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvAuthList.DataSource != null)
            {
                List<AuthVO> authlist = new List<AuthVO>();
                foreach (DataGridViewRow item in dgvAuthList.Rows)
                {
                    authlist.Add(new AuthVO { Form = item.Cells[0].Value.ToString(), Auth = Convert.ToBoolean(item.Cells[1].EditedFormattedValue) });
                }
                AuthService service = new AuthService();
                if (service.UpdateAuth(uid, authlist))
                {
                    frm.NoticeMessage = Resources.AuthDone;
                }
                else
                {
                    frm.NoticeMessage = Resources.AuthError;
                }
                RefreshClicked();
            }
            else
            {
                frm.NoticeMessage = Resources.ModAuthError;
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (txtSearch.CodeTextBox.Tag != null)
            {
                List<SearchedInfoVO> SearchedInfo = (from item in list
                                                     where item.ID == txtSearch.CodeTextBox.Tag.ToString()
                                                     select item).ToList();
                dgvAuthList.DataSource = null;
                dgvEmpList.DataSource = SearchedInfo;
                int id = Convert.ToInt32(dgvEmpList.SelectedRows[0].Cells[0].Value);
                uid = id;
                AuthService service = new AuthService();
                dgvAuthList.DataSource = service.GetAuthByID(id);
                dgvAuthList.ClearSelection();
                dgvAuthList.CurrentCell = null;
                frm.NoticeMessage = Resources.SearchDone;
            }
            else
            {
                RefreshClicked();
                frm.NoticeMessage = notice;
            }
        }

        public override void Refresh(object sender, EventArgs e)
        {
            isFirst = true;
            RefreshClicked();
        }

        private void headerbox_Click(object sender, EventArgs e)
        {
            dgvAuthList.EndEdit();
            foreach (DataGridViewRow row in dgvAuthList.Rows)
            {
                row.Cells[1].Value = headerbox.Checked;
            }
        }

        private void UserAuth_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            frm.수정ToolStripMenuItem.Text = "권한설정";
            frm.수정ToolStripMenuItem.ToolTipText = "권한설정(Ctrl+M)";
            frm.NoticeMessage = notice;
        }


        public override void MenuStripONOFF(bool flag)
        {
            frm.신규ToolStripMenuItem.Visible = false;
            frm.삭제ToolStripMenuItem.Visible = false;
            frm.수정ToolStripMenuItem.Visible = flag;
            frm.인쇄ToolStripMenuItem.Visible = false;
        }

        private void UserAuth_Deactivate(object sender, EventArgs e)
        {
            frm.수정ToolStripMenuItem.Text = "수정";
            frm.수정ToolStripMenuItem.ToolTipText = "수정(Ctrl+M)";
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void dgvEmpList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAuthList.DataSource = null;
            if (dgvEmpList.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvEmpList.SelectedRows[0].Cells[0].Value);
                uid = id;
                try
                {
                    AuthService service = new AuthService();
                    dgvAuthList.DataSource=service.GetAuthByID(id);
                    dgvAuthList.ClearSelection();
                    dgvAuthList.CurrentCell = null;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void dgvAuthList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0&&e.ColumnIndex == 1)
            {
                bool isChecked = true;
                foreach (DataGridViewRow row in dgvAuthList.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerbox.Checked = isChecked;
            }
        }

        private void UserAuth_Shown(object sender, EventArgs e)
        {
            ClearDgv();
        }

        private void ClearDgv()
        {
            dgvEmpList.ClearSelection();
            dgvEmpList.CurrentCell = null;
            dgvAuthList.ClearSelection();
            dgvAuthList.CurrentCell = null;
        }

        private void dgvAuthList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
                bool isChecked = true;
                foreach (DataGridViewRow row in dgvAuthList.Rows)
                {
                    if (!Convert.ToBoolean(row.Cells[1].EditedFormattedValue))
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerbox.Checked = isChecked;
            }

        private void dgvAuthList_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Point headerLocation = dgvAuthList.GetCellDisplayRectangle(1, -1, true).Location;
            headerbox.Location = new Point((headerLocation.X+dgvAuthList.Columns[1].Width / 2)-7, headerLocation.Y+ dgvAuthList.ColumnHeadersHeight / 5+1);
        }
    }
}

