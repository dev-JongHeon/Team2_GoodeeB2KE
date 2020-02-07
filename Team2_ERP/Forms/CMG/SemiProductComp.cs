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
    public partial class SemiProductComp : BasePopup
    {
        public enum EditMode { Insert, Update }

        List<ProductVO> list;

        SemiProductCompControl spc;

        string mode = string.Empty;
        string pCode = string.Empty;
        string pCategory = string.Empty;

        public SemiProductComp(EditMode editMode, ProductVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Insert)
            {
                lblName.Text = "반제품 등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
            else if (editMode == EditMode.Update)
            {
                lblName.Text = "반제품 수정";
                mode = "Update";
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                pCode = item.Product_ID;
                pCategory = item.Product_Category;
            }
        }

        //반제품 카테고리 목록을 가져오는 콤보 바인딩 메서드
        private void InitCombo()
        {
            StandardService service = new StandardService();
            if (mode.Equals("Insert"))
            {
                List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
                UtilClass.ComboBinding(cboCategory, categoryList, "선택");
            }
            else
            {
                List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Equals(pCategory) select item).ToList();
                UtilClass.ComboBinding(cboCategory, categoryList);
                List<ComboItemVO> resourceList = service.GetComboResourceCategory(pCategory.ToString());
                UtilClass.ComboBinding(cboCategoryDetail, resourceList, "선택");
                CategoryLabelName(resourceList);
            }
            List<ComboItemVO> warehouseList = service.GetComboWarehouse(1);
            UtilClass.ComboBinding(cboWarehouse, warehouseList, "선택");
        }

        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvSemiProduct);

            UtilClass.AddNewColum(dgvSemiProduct, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvSemiProduct, "제품가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvSemiProduct, "제품카테고리", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvSemiProduct, "제품ID", "Product_ID", false, 100);
            dgvSemiProduct.Columns[1].DefaultCellStyle.Format = "#,###원";

            dgvSemiProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllProduct();
            List<ProductVO> resourceList = (from item in list where item.Product_Category.Contains($"{cboCategoryDetail.SelectedValue.ToString()}") select item).ToList();
            dgvSemiProduct.DataSource = resourceList;
        }

        //반제품의 카테고리를 선택하면 유저컨트롤을 반제품의 카테고리에 속해있는 원자재 카테고리 수 만큼 생성하고 라벨 이름을 원자재 카테고리명으로 바꾼다.
        private void CategoryLabelName(List<ComboItemVO> countList)
        {
            for (int i = 1; i < countList.Count; i++)
            {
                spc = new SemiProductCompControl();
                spc.Location = new Point(0, i * 40);
                spc.LblName.Text = countList[i].Name;
                spc.LblName.Tag = countList[i].ID;

                spc.Qty.ValueChanged += new EventHandler(TotalPrice);
                numericUpDown1.ValueChanged += new EventHandler(TotalPrice);

                splitContainer2.Panel1.Controls.Add(spc);
            }
        }

        //원자재의 개수를 수정하면 하단에 있는 단가를 수정한다.
        private void TotalPrice(object sender, EventArgs e)
        {
            int sum = 0;

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    if (!string.IsNullOrEmpty(spc.LblMoney.Text))
                        sum += Convert.ToInt32(list.Find(i => i.Product_ID == spc.TxtName.Tag.ToString()).Product_Price * spc.Qty.Value);

                    txtSemiproductMoney.Tag = sum;
                    numericUpDown1_ValueChanged(this, null);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SemiProductComp_Load(object sender, EventArgs e)
        {
            InitGridView();
            InitCombo();
        }

        //반제품의 카테고리 목록을 보여주고 해당하는 카테고리를 선택하면 유저컨트롤 생성 메서드에 해당하는 카테고리의 ID를 보낸다.
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex < 1)
                return;

            if (!cboCategory.SelectedValue.ToString().Contains("CS"))
                return;

            StandardService service = new StandardService();
            if (mode.Equals("Insert"))
            {
                List<ComboItemVO> resourceList = service.GetComboResourceCategory(cboCategory.SelectedValue.ToString());
                UtilClass.ComboBinding(cboCategoryDetail, resourceList, "선택");
                splitContainer2.Panel1.Controls.Clear();
                CategoryLabelName(resourceList);
            }

            dgvSemiProduct.DataSource = null;
        }

        //원자재 카테고리를 선택하면 해당하는 카테고리에 있는 모든 원자재 목록을 데이터 그리드 뷰에 바인딩한다.
        private void cboCategoryDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoryDetail.SelectedIndex < 1)
                return;

            if (!cboCategoryDetail.SelectedValue.ToString().Contains("CM"))
                return;

            dgvSemiProduct.DataSource = null;
            LoadGridView();
        }

        //원자재를 선택하면 해당하는 원자재 카테고리 ID와 유저컨트롤 태그 ID를 비교해서 맞는 부분에 원자재 이름과 가격을 설정한다.
        private void dgvSemiProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgvSemiProduct.SelectedRows.Count > 0)
            {
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        if (spc.LblName.Tag.ToString() == dgvSemiProduct.SelectedRows[0].Cells[2].Value.ToString())
                        {
                            spc.TxtName.Text = dgvSemiProduct.SelectedRows[0].Cells[0].Value.ToString();
                            spc.TxtName.Tag = dgvSemiProduct.SelectedRows[0].Cells[3].Value;
                            spc.LblMoney.Text = Convert.ToInt32(dgvSemiProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원";
                            if (txtSemiproductMoney.Text.Equals("0원") || txtSemiproductMoney.Text.Length < 1)
                                txtSemiproductMoney.Text = spc.LblMoney.Text;
                            else
                                txtSemiproductMoney.Text = (Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")) + Convert.ToInt32(spc.LblMoney.Text.Replace(",", "").Replace("원", ""))).ToString("#,##0") + "원";

                            spc.Qty.Tag = dgvSemiProduct.SelectedRows[0].Cells[1].Value;
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                ProductVO Pitem = new ProductVO
                {
                    Product_Name = txtSemiproductName.Text,
                    Product_Price = Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")),
                    Product_Qty = Convert.ToInt32(numericUpDown1.Value),
                    Warehouse_ID = Convert.ToInt32(cboWarehouse.SelectedValue),
                    Product_Safety = Convert.ToInt32(numSafety.Value),
                    Product_Category = cboCategory.SelectedValue.ToString()
                };

                List<CombinationVO> citemList = new List<CombinationVO>();

                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        CombinationVO citem = new CombinationVO
                        {
                            Combination_Product_ID = spc.TxtName.Tag.ToString(),
                            Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                        };

                        citemList.Add(citem);
                    }
                }

                StandardService service = new StandardService();
                service.InsertSemiProduct(Pitem, citemList, splitContainer2.Panel1.Controls.Count);
            }
            else
            {
                ProductVO Pitem = new ProductVO
                {
                    Product_ID = pCode,
                    Product_Name = txtSemiproductName.Text,
                    Product_Price = Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")),
                    Product_Qty = Convert.ToInt32(numericUpDown1.Value),
                    Product_Safety = Convert.ToInt32(numSafety.Value),
                    Warehouse_ID = Convert.ToInt32(cboWarehouse.SelectedValue),
                    Product_Category = cboCategory.SelectedValue.ToString()
                };

                List<CombinationVO> citemList = new List<CombinationVO>();

                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        CombinationVO citem = new CombinationVO
                        {
                            Combination_Product_ID = spc.TxtName.Tag.ToString(),
                            Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                        };

                        citemList.Add(citem);
                    }
                }

                StandardService service = new StandardService();
                service.UpdateSemiProduct(Pitem, citemList, splitContainer2.Panel1.Controls.Count);
            }

            this.DialogResult = DialogResult.OK;
        }

        //반제품 조합의 개수만큼 단가를 조정한다.
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                txtSemiproductMoney.Text = (Convert.ToInt32(txtSemiproductMoney.Tag) * Convert.ToInt32(numericUpDown1.Value)).ToString("#,##0") + "원";
            }
            else
            {
                txtSemiproductMoney.Text = "0원";
            }
        }
    }
}
