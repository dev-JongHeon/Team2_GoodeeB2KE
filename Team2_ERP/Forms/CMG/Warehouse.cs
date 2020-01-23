using System;
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
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "창고코드", "Warehouse_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "창고이름", "Warehouse_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "창고주소", "Warehouse_Address", true, 100);
            UtilClass.AddNewColum(dataGridView1, "전화번호", "Warehouse_Number", true, 100);
            UtilClass.AddNewColum(dataGridView1, "FAX번호", "Warehouse_Fax", true, 100);
            UtilClass.AddNewColum(dataGridView1, "구분", "Warehouse_Division_Name", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllWarehouse();
            List<WarehouseVO> warehouseList = (from item in list where item.Warehouse_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = warehouseList;
        }

        // 메인 폼 메세지 초기화
        private void InitMessage()
        {
            frm.NoticeMessage = "메세지";
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
        }

        private void Warehouse_Activated(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void Warehouse_Deactivate(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dataGridView1.DataSource = null;
            searchUserControl1.CodeTextBox.Text = "";
            LoadGridView();
        }

        public override void New(object sender, EventArgs e)
        {
            InitMessage();

            WarehouseInsUp frm = new WarehouseInsUp(WarehouseInsUp.EditMode.Insert, null);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frm.Close();
                dataGridView1.DataSource = null;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            InitMessage();

            if (item == null)
            {
                frm.NoticeMessage = "수정할 창고를 선택해주세요.";
            }
            else
            {
                WarehouseInsUp frm = new WarehouseInsUp(WarehouseInsUp.EditMode.Update, item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dataGridView1.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (item == null)
            {
                frm.NoticeMessage = "삭제할 창고를 선택해주세요.";
            }
            else
            {
                if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    StandardService service = new StandardService();
                    service.DeleteWarehouse(item.Warehouse_ID);
                    dataGridView1.DataSource = null;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            List<WarehouseVO> searchList = (from item in list where item.Warehouse_ID == Convert.ToInt32(searchUserControl1.CodeTextBox.Tag) && item.Warehouse_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = searchList;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 전화번호가 없을 때
            if(dataGridView1.Rows[e.RowIndex].Cells[3].Value == null)
            {
                // 전화번호와 FAX번호 둘 다 없을 때
                if(dataGridView1.Rows[e.RowIndex].Cells[4].Value == null)
                {
                    item = new WarehouseVO
                    {
                        Warehouse_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                        Warehouse_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
                    };
                }
                // 전화번호는 없고 FAX번호만 있을 때
                else
                {
                    item = new WarehouseVO
                    {
                        Warehouse_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                        Warehouse_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Warehouse_Fax = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()
                    };
                }
            }
            // 전화번호와 FAX번호 둘 다 있을 때
            else
            {
                item = new WarehouseVO
                {
                    Warehouse_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                    Warehouse_Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Warehouse_Address = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Warehouse_Number = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Warehouse_Fax = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()
                };
            }
        }
    }
}