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
    public partial class BOM : BaseForm
    {
        List<ProductVO> list;

        ToolStripDropDownItem tool;

        MainForm frm;

        ProductVO item;

        public BOM()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvBOM);

            UtilClass.AddNewColum(dgvBOM, "분류", "Category_Division", false, 100);
            UtilClass.AddNewColum(dgvBOM, "품목명", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvBOM, "제품ID", "Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOM, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOM, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOM.Columns[4].DefaultCellStyle.Format = "#,###원";

            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "전개";
            btn.Width = 100;
            dgvBOM.Columns.Add(btn);
            dgvBOM.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvBOM.Columns[5].Width = 70;

            UtilClass.SettingDgv(dgvBOMDetail);

            UtilClass.AddNewColum(dgvBOMDetail, "분류", "Category_Division", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail, "개수", "Combination_RequiredQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOMDetail.Columns[2].DefaultCellStyle.Format = "#,###개";
            dgvBOMDetail.Columns[3].DefaultCellStyle.Format = "#,###원";

            dgvBOMDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBOMDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllProduct();
            List<ProductVO> productList = (from item in list where item.Product_DeletedYN == false select item).ToList();
            dgvBOM.DataSource = productList;
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
        }

        private void dgvBOM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                string str = dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString();

                if(str.Equals("원자재"))
                {
                    e.Value = "역 전 개";
                }
                else if(str.Equals("반제품"))
                {
                    e.Value = "역 전 개";
                }
                else
                {
                    e.Value = "정 전 개";
                }
            }
        }

        private void BOM_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);

            //등록 서브메뉴 이벤트 추가
            tool = (ToolStripDropDownItem)(((MainForm)MdiParent).신규ToolStripMenuItem);

            if (tool.DropDownItems.Count < 1)
            {
                tool.DropDownItems.Add("반제품");
                tool.DropDownItems.Add("완제품");

                tool.DropDownItemClicked += new ToolStripItemClickedEventHandler(ItemSelect);
            }

        }

        private void BOM_Deactivate(object sender, EventArgs e)
        {
            //서브메뉴 이벤트 삭제
            tool.DropDownItems.Clear();
            tool.DropDownItemClicked -= ItemSelect;
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void InitMessage()
        {
            frm.NoticeMessage = "메세지";
        }

        private void ItemSelect(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "반제품")
            {
                SemiProductComp frm = new SemiProductComp(SemiProductComp.EditMode.Insert, null);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dgvBOM.DataSource = null;
                    LoadGridView();
                }
            }
            else
            {
                ProductComp frm = new ProductComp(ProductComp.EditMode.Insert, null);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    frm.Close();
                    dgvBOM.DataSource = null;
                    LoadGridView();
                }
            }
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
            InitMessage();
            dgvBOM.DataSource = null;
            dgvBOMDetail.DataSource = null;
            searchUserControl1.CodeTextBox.Text = "";
            dgvBOM.CurrentCell = null;
            dgvBOMDetail.CurrentCell = null;
            LoadGridView();
        }

        public override void New(object sender, EventArgs e)
        {

        }

        public override void Modify(object sender, EventArgs e)
        {
            //if (dgvFactory.SelectedRows.Count > 0 || dgvLine.SelectedRows.Count > 0)
            //{
            //    if (dgvLine.SelectedRows.Count < 1)
            //    {
            //        FactoryInsUp frm = new FactoryInsUp(FactoryInsUp.EditMode.Update, factoryItem);
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            frm.Close();
            //            dgvFactory.DataSource = null;
            //            LoadGridView();
            //        }
            //    }
            //    else if (dgvFactory.SelectedRows.Count < 1)
            //    {
            //        LineInsUp frm = new LineInsUp(LineInsUp.EditMode.Update, lineItem);
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            frm.Close();
            //            dgvFactory.DataSource = null;
            //            LoadGridView();
            //        }
            //    }
            //}
            //else
            //{
            //    frm.NoticeMessage = "수정할 목록을 선택해주세요.";
            //}
        }

        public override void Delete(object sender, EventArgs e)
        {
            //InitMessage();

            //if (dgvLine.SelectedRows.Count < 1)
            //{
            //    if (factoryItem == null)
            //    {
            //        frm.NoticeMessage = "삭제할 공장을 선택해주세요.";
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            StandardService service = new StandardService();
            //            service.DeleteFactory(factoryItem.Factory_ID);
            //            dgvFactory.DataSource = null;
            //            LoadGridView();
            //        }
            //    }
            //}
            //else if (dgvFactory.SelectedRows.Count < 1)
            //{
            //    if (lineItem == null)
            //    {
            //        frm.NoticeMessage = "삭제할 공정을 선택해주세요.";
            //    }
            //    else
            //    {
            //        if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            StandardService service = new StandardService();
            //            service.DeleteLine(lineItem.Factory_ID);
            //            dgvFactory.DataSource = null;
            //            LoadGridView();
            //        }
            //    }
            //}
        }

        public override void Search(object sender, EventArgs e)
        {
            ////공장, 공정 두개 다 검색할 때
            //if (searchUserControl1.CodeTextBox.Text.Length > 0 && searchUserControl2.CodeTextBox.Text.Length > 0)
            //{
            //    dgvFactory.DataSource = null;
            //    List<FactoryVO> searchFList = (from item in FList where item.Factory_ID == Convert.ToInt32(searchUserControl1.CodeTextBox.Tag) && item.Factory_DeletedYN == false select item).ToList();
            //    dgvFactory.DataSource = searchFList;

            //    dgvLine.DataSource = null;
            //    List<LineVO> searchLList = (from item in LList where item.Line_ID == Convert.ToInt32(searchUserControl2.CodeTextBox.Tag) && item.Line_DeletedYN == false select item).ToList();
            //    dgvLine.DataSource = searchLList;
            //}
            ////공장만 검색할 때
            //else if (searchUserControl1.CodeTextBox.Text.Length > 0)
            //{
            //    dgvFactory.DataSource = null;
            //    List<FactoryVO> searchList = (from item in FList where item.Factory_ID == Convert.ToInt32(searchUserControl1.CodeTextBox.Tag) && item.Factory_DeletedYN == false select item).ToList();
            //    dgvFactory.DataSource = searchList;
            //}
            ////공정만 검색할 때
            //else if (searchUserControl2.CodeTextBox.Text.Length > 0)
            //{
            //    dgvLine.DataSource = null;
            //    List<LineVO> searchLList = (from item in LList where item.Line_ID == Convert.ToInt32(searchUserControl2.CodeTextBox.Tag) && item.Line_DeletedYN == false select item).ToList();
            //    dgvLine.DataSource = searchLList;
            //}
            //else
            //{
            //    frm.NoticeMessage = "검색할 공장이나 공정을 선택해주세요.";
            //}
        }

        private void dgvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            item = new ProductVO
            {
                Product_ID = dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString()
            };

            if(e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Equals("원자재"))
            {
                dgvBOMDetail.DataSource = null;
            }
            else if(e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Equals("반제품"))
            {
                StandardService service = new StandardService();
                List<BOMVO> bomList = service.GetAllCombination(item.Product_ID);
                bomList = (from item in bomList where item.Combination_DeletedYN == false select item).ToList();
                dgvBOMDetail.DataSource = bomList;
            }
            else if(e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Equals("완제품"))
            {
                dgvBOMDetail.DataSource = null;
            }
        }

        private void BOM_Shown(object sender, EventArgs e)
        {
            dgvBOM.CurrentCell = null;
        }
    }
}
