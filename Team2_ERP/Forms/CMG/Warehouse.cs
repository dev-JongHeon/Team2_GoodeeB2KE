using System;
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
    public partial class Warehouse : BaseForm
    {
        List<WarehouseVO> list;

        MainForm frm;

        WarehouseVO item;

        public Warehouse()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvWarehouse);

            UtilClass.AddNewColum(dgvWarehouse, "창고코드", "Warehouse_ID", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "창고이름", "Warehouse_Name", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "우편번호", "Warehouse_AddrNumber", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "창고주소", "Warehouse_Address", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "전화번호", "Warehouse_Number", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "FAX번호", "Warehouse_Fax", true, 100);
            UtilClass.AddNewColum(dgvWarehouse, "구분", "Warehouse_Division_Name", true, 100);

            dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllWarehouse();
            dgvWarehouse.DataSource = list;
            dgvWarehouse.CurrentCell = null;
        }

        // 메인 폼 메세지 초기화
        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            StandardService service = new StandardService();
            list = service.GetAllWarehouse();
        }

        private void Warehouse_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
        }

        private void Warehouse_Deactivate(object sender, EventArgs e)
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

        public override void Refresh(object sender, EventArgs e)
        {
            frm.NoticeMessage = Resources.RefreshDone;
            dgvWarehouse.DataSource = null;
            searchWarehouseName.CodeTextBox.Clear();
        }

        public override void New(object sender, EventArgs e)
        {
            WarehouseInsUp popup = new WarehouseInsUp(WarehouseInsUp.EditMode.Insert, null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                frm.NoticeMessage = Resources.AddDone;
                dgvWarehouse.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                WarehouseInsUp popup = new WarehouseInsUp(WarehouseInsUp.EditMode.Update, item);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.ModEmpty;
                    dgvWarehouse.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvWarehouse.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.DelEmpty;
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StandardService service = new StandardService();
                    service.DeleteWarehouse(item.Warehouse_ID);
                    dgvWarehouse.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchWarehouseName.CodeTextBox.Text.Length > 0)
            {
                dgvWarehouse.DataSource = null;
                List<WarehouseVO> searchList = (from item in list where item.Warehouse_ID == Convert.ToInt32(searchWarehouseName.CodeTextBox.Tag) && item.Warehouse_DeletedYN == false select item).ToList();
                dgvWarehouse.DataSource = searchList;
            }
            else
            {
                LoadGridView();
            }

            frm.NoticeMessage = Resources.SearchDone;
            dgvWarehouse.CurrentCell = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvWarehouse.Rows.Count && e.RowIndex > -1)
            {
                // 전화번호가 없을 때
                if (dgvWarehouse.Rows[e.RowIndex].Cells[4].Value == null)
                {
                    // 전화번호와 FAX번호 둘 다 없을 때
                    if (dgvWarehouse.Rows[e.RowIndex].Cells[5].Value == null)
                    {
                        item = new WarehouseVO
                        {
                            Warehouse_ID = Convert.ToInt32(dgvWarehouse.Rows[e.RowIndex].Cells[0].Value),
                            Warehouse_Name = dgvWarehouse.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            Warehouse_AddrNumber = dgvWarehouse.Rows[e.RowIndex].Cells[2].Value.ToString(),
                            Warehouse_Address = dgvWarehouse.Rows[e.RowIndex].Cells[3].Value.ToString(),
                            Warehouse_Division_Name = dgvWarehouse.Rows[e.RowIndex].Cells[6].Value.ToString()
                        };
                    }
                    // 전화번호는 없고 FAX번호만 있을 때
                    else
                    {
                        item = new WarehouseVO
                        {
                            Warehouse_ID = Convert.ToInt32(dgvWarehouse.Rows[e.RowIndex].Cells[0].Value),
                            Warehouse_Name = dgvWarehouse.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            Warehouse_Fax = dgvWarehouse.Rows[e.RowIndex].Cells[4].Value.ToString()
                        };
                    }
                }
                // 전화번호와 FAX번호 둘 다 있을 때
                else
                {
                    item = new WarehouseVO
                    {
                        Warehouse_ID = Convert.ToInt32(dgvWarehouse.Rows[e.RowIndex].Cells[0].Value),
                        Warehouse_Name = dgvWarehouse.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Warehouse_Address = dgvWarehouse.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        Warehouse_Number = dgvWarehouse.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Warehouse_Fax = dgvWarehouse.Rows[e.RowIndex].Cells[4].Value.ToString()
                    };
                }
            }
        }
    }
}