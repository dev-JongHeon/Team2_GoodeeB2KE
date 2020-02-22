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
    public partial class BOM : BaseForm
    {
        List<ProductVO> list;
        List<ProductVO> rdoList;
        List<BOMVO> bomList;
        List<BOMVO> bomReverseList;

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

            UtilClass.AddNewColum(dgvBOM, "제품ID", "Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOM, "분류", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvBOM, "품목명", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvBOM, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOM, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOM, "창고ID", "Warehouse_ID", false, 100);
            UtilClass.AddNewColum(dgvBOM, "창고이름", "Warehouse_Name", false, 100);
            UtilClass.AddNewColum(dgvBOM, "개수", "Product_Qty", false, 100);
            UtilClass.AddNewColum(dgvBOM, "안전개수", "Product_Safety", false, 100);
            UtilClass.AddNewColum(dgvBOM, "삭제여부", "Product_DeletedYN", false, 100);
            UtilClass.AddNewColum(dgvBOM, "카테고리이름", "Category_Division", false, 100);
            UtilClass.AddNewColum(dgvBOM, "이미지", "Product_Image", false, 100);
            UtilClass.AddNewColum(dgvBOM, "원가", "Product_Origin", false, 100);
            dgvBOM.Columns[4].DefaultCellStyle.Format = "#,##0원";

            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "전개";
            btn.Width = 100;
            dgvBOM.Columns.Add(btn);
            dgvBOM.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvBOM.Columns[12].Width = 70;

            UtilClass.SettingDgv(dgvBOMDetail1);

            UtilClass.AddNewColum(dgvBOMDetail1, "제품ID", "Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "분류", "Category_Division", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "조합개수", "Combination_RequiredQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail1, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail1, "조합ID", "Combination_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "조합제품ID", "Combination_Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "조합삭제여부", "Combination_DeletedYN", false, 100);
            dgvBOMDetail1.Columns[3].DefaultCellStyle.Format = "#,##0개";
            dgvBOMDetail1.Columns[4].DefaultCellStyle.Format = "#,##0원";

            dgvBOMDetail1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            UtilClass.SettingDgv(dgvBOMDetail2);

            UtilClass.AddNewColum(dgvBOMDetail2, "제품ID", "Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "분류", "Category_Division", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "조합개수", "Combination_RequiredQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail2, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail2, "조합ID", "Combination_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "조합제품ID", "Combination_Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "조합삭제여부", "Combination_DeletedYN", false, 100);
            dgvBOMDetail2.Columns[3].DefaultCellStyle.Format = "#,##0개";
            dgvBOMDetail2.Columns[4].DefaultCellStyle.Format = "#,##0원";

            dgvBOMDetail2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                BOMService service = new BOMService();

                //원자재 리스트
                if (rdoResource.Checked)
                {
                    list = service.GetProductList("Resource");
                    dgvBOM.DataSource = list;
                }
                //반제품 리스트
                else if (rdoSemiProduct.Checked)
                {
                    list = service.GetProductList("SemiProduct");
                    dgvBOM.DataSource = list;
                }
                //완제품 리스트
                else if (rdoProduct.Checked)
                {
                    list = service.GetProductList("Product");
                    dgvBOM.DataSource = list;
                }
                else
                {
                    dgvBOM.DataSource = null;
                }
                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewRow item in dgvBOM.Rows)
                    sb.Append($"'{item.Cells[0].Value.ToString()}',");

                //정전개 리스트
                bomList = service.GetAllCombination(sb.ToString().Trim(','));
                //역전개 리스트
                bomReverseList = service.GetAllCombinationReverse(sb.ToString().Trim(','));
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void GridViewReset()
        {
            dgvBOM.DataSource = null;
            dgvBOMDetail1.DataSource = null;
            dgvBOMDetail2.DataSource = null;
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
        }

        private void dgvBOM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                string str = dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString();

                e.Value = "전  개";
            }
        }

        private void BOM_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();

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
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.DropDownItems[1].Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        private void ItemSelect(object sender, ToolStripItemClickedEventArgs e)
        {
            //DropDown 메뉴 중 반제품을 선택했을 때 반제품 조합 팝업을 띄우고 완제품을 선택하면 완제품 조합 팝업을 띄운다.
            if (e.ClickedItem.Text == "반제품")
            {
                SemiProductComp popup = new SemiProductComp(SemiProductComp.EditMode.Insert, null);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.AddDone;
                    GridViewReset();
                    LoadGridView();
                }
            }
            else
            {
                ProductComp popup = new ProductComp(ProductComp.EditMode.Insert, null);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.AddDone;
                    GridViewReset();
                    LoadGridView();
                }
            }
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.DropDownItems[1].Visible = false;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            frm.NoticeMessage = Resources.RefreshDone;
            GridViewReset();
            searchProductName.CodeTextBox.Clear();
            rdoResource.Checked = false;
            rdoSemiProduct.Checked = false;
            rdoProduct.Checked = false;
        }

        public override void New(object sender, EventArgs e)
        {

        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvBOM.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
            else
            {
                if (item.Product_Category.Contains("CS"))
                {
                    SemiProductComp popup = new SemiProductComp(SemiProductComp.EditMode.Update, item);
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        frm.NoticeMessage = Resources.ModDone;
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else if (item.Product_Category.Contains("CP"))
                {
                    ProductComp popup = new ProductComp(ProductComp.EditMode.Update, item);
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        frm.NoticeMessage = Resources.ModDone;
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else
                {
                    frm.NoticeMessage = Resources.ModResourceError;
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvBOM.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = Resources.DelEmpty;
            }
            else
            {
                if (item.Product_Category.Contains("CS"))
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            BOMService service = new BOMService();
                            service.DeleteSemiProduct(item);
                        }
                        catch (Exception err)
                        {
                            Log.WriteError(err.Message, err);
                        }
                        frm.NoticeMessage = Resources.DeleteDone;
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else if (item.Product_Category.Contains("CP"))
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            BOMService service = new BOMService();
                            service.DeleteProduct(item);
                        }
                        catch (Exception err)
                        {
                            Log.WriteError(err.Message, err);
                        }
                        frm.NoticeMessage = Resources.DeleteDone;
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else
                {
                    frm.NoticeMessage = Resources.DelResourceError;
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            if (rdoResource.Checked || rdoSemiProduct.Checked || rdoProduct.Checked)
            {
                GridViewReset();

                if (searchProductName.CodeTextBox.Tag != null)
                {
                    list = (from item in list where item.Product_ID.Equals(searchProductName.CodeTextBox.Tag.ToString()) select item).ToList();
                    dgvBOM.DataSource = list;
                }

                dgvBOM.CurrentCell = null;
                frm.NoticeMessage = Resources.SearchDone;
            }
            else
            {
                frm.NoticeMessage = Properties.Resources.rdoWorkError;
            }
        }

        public override void Excel(object sender, EventArgs e)
        {
            if (dgvBOM.Rows.Count > 0)
            {
                using (WaitForm frm = new WaitForm())
                {
                    frm.Processing = ExcelExport;
                    frm.ShowDialog();
                }
            }
            else
            {
                frm.NoticeMessage = Resources.ExcelError;
            }
        }

        private void ExcelExport()
        {
            //엑셀로 내보내기 위한 list들을 복사해서 보이지 않는 컬럼은 엑셀에서 제외시킨다.
            List<ProductVO> allList = list.ToList();
            List<BOMVO> detail1 = bomList.ToList();
            List<BOMVO> detail2 = bomReverseList.ToList();
            string[] gg = new string[] { "Product_Category", "Warehouse_ID", "Warehouse_Name", "Product_Qty", "Product_Safety", "Product_DeletedYN", "Category_Division", "Product_Image", "Combination_ID", "Combination_Product_ID", "Combination_DeletedYN", "Product_Origin" };
            UtilClass.ExportTo2DataGridView(allList, detail1, detail2, gg);
        }

        private void dgvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvBOM.Rows.Count && e.RowIndex > -1)
            {
                item = new ProductVO
                {
                    Product_ID = dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    Product_Category = dgvBOM.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Product_Name = dgvBOM.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Product_Price = Convert.ToInt32(dgvBOM.Rows[e.RowIndex].Cells[4].Value),
                    Warehouse_ID = Convert.ToInt32(dgvBOM.Rows[e.RowIndex].Cells[5].Value),
                    Product_Safety = Convert.ToInt32(dgvBOM.Rows[e.RowIndex].Cells[8].Value),
                    Product_Origin = Convert.ToInt32(dgvBOM.Rows[e.RowIndex].Cells[12].Value)
                };

                dgvBOMDetail1.DataSource = null;
                dgvBOMDetail2.DataSource = null;

                //원자재 품목일 때 전개를 누르면 역전개만 보인다.
                if (e.ColumnIndex == 13 && dgvBOM.CurrentRow.Cells[1].Value.ToString().Contains("CM"))
                {
                    List<BOMVO> productList = (from item in bomReverseList where item.Combination_Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString()) select item).ToList();
                    dgvBOMDetail2.DataSource = productList;
                }
                //반제품 품목일 때 전개를 누르면 정전개, 역전개 모두 보인다.
                else if (e.ColumnIndex == 13 && dgvBOM.CurrentRow.Cells[1].Value.ToString().Contains("CS"))
                {
                    List<BOMVO> semiProductList = (from item in bomList where item.Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString()) select item).ToList();
                    dgvBOMDetail1.DataSource = semiProductList;

                    List<BOMVO> productList = (from item in bomReverseList where item.Combination_Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString()) select item).ToList();
                    dgvBOMDetail2.DataSource = productList;
                }
                //완제품 품목일 때 전개를 누르면 정전개만 보인다.
                else if (e.ColumnIndex == 13 && dgvBOM.CurrentRow.Cells[1].Value.ToString().Contains("CP"))
                {
                    List<BOMVO> semiProductList = (from item in bomList where item.Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString()) select item).ToList();
                    dgvBOMDetail1.DataSource = semiProductList;
                }
            }
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridView();
            searchProductName.CodeTextBox.Clear();
        }
    }
}