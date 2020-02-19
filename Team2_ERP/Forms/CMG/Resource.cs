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
    public partial class Resource : BaseForm
    {
        List<ResourceVO> list;

        MainForm frm;

        ResourceVO item;

        public Resource()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvResource);

            UtilClass.AddNewColum(dgvResource, "제품코드", "Product_ID", true, 100);
            UtilClass.AddNewColum(dgvResource, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvResource, "제품보관창고", "Warehouse_Name", true, 100);
            UtilClass.AddNewColum(dgvResource, "제품가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvResource, "제품개수", "Product_Qty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvResource, "안전재고량", "Product_Safety", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvResource, "제품카테고리", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvResource, "거래처ID", "Company_ID", false, 100);
            UtilClass.AddNewColum(dgvResource, "카테고리ID", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvResource, "창고ID", "Warehouse_ID", false, 100);
            dgvResource.Columns[3].DefaultCellStyle.Format = "#,##0원";
            dgvResource.Columns[4].DefaultCellStyle.Format = "#,##0개";
            dgvResource.Columns[5].DefaultCellStyle.Format = "#,##0개";

            dgvResource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                StandardService service = new StandardService();
                list = service.GetAllResource();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvResource.DataSource = list;
            dgvResource.CurrentCell = null;
        }

        private void Resource_Load(object sender, EventArgs e)
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
            dgvResource.DataSource = null;
            searchResourceName.CodeTextBox.Clear();
        }

        public override void New(object sender, EventArgs e)
        {
            ResourceInsUp popup = new ResourceInsUp(ResourceInsUp.EditMode.Insert, null);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                dgvResource.DataSource = null;
                frm.NoticeMessage = Resources.AddDone;
                LoadGridView();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvResource.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                ResourceInsUp popup = new ResourceInsUp(ResourceInsUp.EditMode.Update, item);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    dgvResource.DataSource = null;
                    frm.NoticeMessage = Resources.ModDone;
                    LoadGridView();
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvResource.SelectedRows.Count < 1)
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
                        service.DeleteResource(item.Product_ID);
                    }
                    catch (Exception err)
                    {
                        Log.WriteError(err.Message, err);
                    }
                    dgvResource.DataSource = null;
                    frm.NoticeMessage = Resources.DeleteDone;
                    LoadGridView();
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();

            //원자재 ID로 검색
            if (searchResourceName.CodeTextBox.Tag != null)
            {
                dgvResource.DataSource = null;
                List<ResourceVO> searchList = (from item in list where item.Product_ID.Contains(searchResourceName.CodeTextBox.Tag.ToString()) && item.Product_DeletedYN == false select item).ToList();
                dgvResource.DataSource = searchList;
            }

            frm.NoticeMessage = Resources.SearchDone;
        }

        private void Resource_Deactivate(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void Resource_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();
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
            if (e.RowIndex < dgvResource.Rows.Count && e.RowIndex > -1)
            {
                item = new ResourceVO
                {
                    Product_ID = dgvResource.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    Product_Name = dgvResource.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Product_Price = Convert.ToInt32(dgvResource.Rows[e.RowIndex].Cells[3].Value.ToString().Replace(",", "").Replace("원", "")),
                    Product_Qty = Convert.ToInt32(dgvResource.Rows[e.RowIndex].Cells[4].Value.ToString()),
                    Product_Safety = Convert.ToInt32(dgvResource.Rows[e.RowIndex].Cells[5].Value.ToString()),
                    Company_ID = Convert.ToInt32(dgvResource.Rows[e.RowIndex].Cells[7].Value),
                    Product_Category = dgvResource.Rows[e.RowIndex].Cells[8].Value.ToString(),
                    Warehouse_ID = Convert.ToInt32(dgvResource.Rows[e.RowIndex].Cells[9].Value)
                };
            }
        }
    }
}
