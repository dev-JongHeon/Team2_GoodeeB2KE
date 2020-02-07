﻿using System;
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

            UtilClass.AddNewColum(dgvBOM, "분류", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvBOM, "품목명", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dgvBOM, "제품ID", "Product_ID", false, 100);
            UtilClass.AddNewColum(dgvBOM, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOM, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOM.Columns[4].DefaultCellStyle.Format = "#,###원";

            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "전개";
            btn.Width = 100;
            dgvBOM.Columns.Add(btn);
            dgvBOM.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvBOM.Columns[5].Width = 70;

            UtilClass.SettingDgv(dgvBOMDetail1);

            UtilClass.AddNewColum(dgvBOMDetail1, "분류", "Category_Division", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail1, "개수", "Combination_RequiredQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail1, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOMDetail1.Columns[2].DefaultCellStyle.Format = "#,###개";
            dgvBOMDetail1.Columns[3].DefaultCellStyle.Format = "#,###원";

            dgvBOMDetail1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            UtilClass.SettingDgv(dgvBOMDetail2);

            UtilClass.AddNewColum(dgvBOMDetail2, "분류", "Category_Division", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOMDetail2, "개수", "Combination_RequiredQty", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvBOMDetail2, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOMDetail2.Columns[2].DefaultCellStyle.Format = "#,###개";
            dgvBOMDetail2.Columns[3].DefaultCellStyle.Format = "#,###원";

            dgvBOMDetail2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();

            if(rdoResource.Checked)
            {
                list = service.GetProductList("Resource");
                dgvBOM.DataSource = list;
            }
            else if(rdoSemiProduct.Checked)
            {
                list = service.GetProductList("SemiProduct");
                dgvBOM.DataSource = list;
            }
            else
            {
                list = service.GetProductList("Product");
                dgvBOM.DataSource = list;
            }

            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewRow item in dgvBOM.Rows)
                sb.Append($"'{item.Cells[2].Value.ToString()}',");

            bomList = service.GetAllCombination(sb.ToString().Trim(','));
            bomReverseList = service.GetAllCombinationReverse(sb.ToString().Trim(','));
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
            rdoResource.Checked = true;
        }

        private void dgvBOM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
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
            new SettingMenuStrip().UnsetMenu(this);
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
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
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            GridViewReset();
            searchProductName.CodeTextBox.Text = "";
        }

        public override void New(object sender, EventArgs e)
        {

        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvBOM.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "수정하실 항목을 선택해주세요.";
            }
            else
            {
                if (item.Product_Category.Contains("CS"))
                {
                    SemiProductComp frm = new SemiProductComp(SemiProductComp.EditMode.Update, item);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("수정되었습니다.", "안내");
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else if (item.Product_Category.Contains("CP"))
                {
                    ProductComp frm = new ProductComp(ProductComp.EditMode.Update, item);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("수정되었습니다.", "안내");
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else
                {
                    frm.NoticeMessage = "원자재 항목은 원자재 탭에서 수정 가능합니다.";
                }
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            if (dgvBOM.SelectedRows.Count < 1)
            {
                frm.NoticeMessage = "삭제하실 항목을 선택해주세요.";
            }
            else
            {
                if (item.Product_Category.Contains("CS"))
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        StandardService service = new StandardService();
                        service.DeleteSemiProduct(item);
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else if (item.Product_Category.Contains("CP"))
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        StandardService service = new StandardService();
                        service.DeleteProduct(item);
                        GridViewReset();
                        InitMessage();
                        LoadGridView();
                    }
                }
                else
                {
                    frm.NoticeMessage = "원자재 항목은 원자재 탭에서 삭제 가능합니다.";
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            GridViewReset();
            LoadGridView();

            if(searchProductName.CodeTextBox.Tag != null)
            {
                list = (from item in list where item.Product_ID.Equals(searchProductName.CodeTextBox.Tag.ToString()) select item).ToList();
                dgvBOM.DataSource = list;
            }

            dgvBOM.CurrentCell = null;
            InitMessage();
        }

        public override void Excel(object sender, EventArgs e)
        {

        }

        private void dgvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvBOM.Rows.Count && e.RowIndex > -1)
            {
                item = new ProductVO
                {
                    Product_Category = dgvBOM.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    Product_ID = dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    Product_Name = dgvBOM.Rows[e.RowIndex].Cells[3].Value.ToString()
                };

                dgvBOMDetail1.DataSource = null;
                dgvBOMDetail2.DataSource = null;

                if (e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Contains("CM"))
                {
                    List<BOMVO> productList = (from item in bomReverseList where item.Combination_Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString()) select item).ToList();
                    dgvBOMDetail2.DataSource = productList;
                }
                else if (e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Contains("CS"))
                {
                    List<BOMVO> semiProductList = (from item in bomList where item.Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString()) select item).ToList();
                    dgvBOMDetail1.DataSource = semiProductList;

                    List<BOMVO> productList = (from item in bomReverseList where item.Combination_Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString()) select item).ToList();
                    dgvBOMDetail2.DataSource = productList;
                }
                else if (e.ColumnIndex == 5 && dgvBOM.CurrentRow.Cells[0].Value.ToString().Contains("CP"))
                {
                    List<BOMVO> semiProductList = (from item in bomList where item.Product_ID.Equals(dgvBOM.Rows[e.RowIndex].Cells[2].Value.ToString()) select item).ToList();
                    dgvBOMDetail1.DataSource = semiProductList;
                }
            }
        }
    }
}