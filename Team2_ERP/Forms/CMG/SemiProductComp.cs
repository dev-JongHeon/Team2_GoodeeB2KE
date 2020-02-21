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
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else if (editMode == EditMode.Update)
            {
                lblName.Text = "반제품 수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;
                pCode = item.Product_ID;
                pCategory = item.Product_Category;
                txtSemiproductName.Text = item.Product_Name;
                numSafety.Value = item.Product_Safety;
            }
        }

        //반제품 카테고리 목록을 가져오는 콤보 바인딩 메서드
        private void InitCombo()
        {
            try
            {
                BOMService service = new BOMService();
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
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        //데이터그리드뷰 설정
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvSemiProduct);

            UtilClass.AddNewColum(dgvSemiProduct, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvSemiProduct, "제품가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dgvSemiProduct, "제품카테고리", "Product_Category", false, 100);
            UtilClass.AddNewColum(dgvSemiProduct, "제품ID", "Product_ID", false, 100);
            dgvSemiProduct.Columns[1].DefaultCellStyle.Format = "#,##0원";

            dgvSemiProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                BOMService service = new BOMService();
                list = service.GetAllProduct();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
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
                    txtSemiproductMoney.Text = Convert.ToInt32(txtSemiproductMoney.Tag).ToString("#,##0") + "원";
                }
            }
        }

        //수정할 반제품의 조합데이터를 List에 받아서 사용자 컨트롤에 할당
        private void UpdateInfoLoad()
        {
            try
            { 
            BOMService service = new BOMService();
            list = service.GetAllProduct();
            List<BOMVO> productList = service.GetAllCombination($"'{pCode}'");
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        for (int i = 0; i < productList.Count; i++)
                        {
                            if (spc.LblName.Tag.ToString().Equals(productList[i].Product_Category))
                            {
                                spc.TxtName.Text = productList[i].Product_Name;
                                spc.TxtName.Tag = productList[i].Combination_Product_ID;
                                spc.Qty.Tag = productList[i].Product_Price;
                                spc.Qty.Value = productList[i].Combination_RequiredQty;
                                spc.LblMoney.Tag = 1;
                                spc.LblMoney.Text = productList[i].Product_Price.ToString("#,##0") + "원";
                            }
                        }
                        spc.Qty.ValueChanged += new EventHandler(TotalPrice);
                    }
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
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
            if(mode.Equals("Update"))
            {
                UpdateInfoLoad();
            }
        }

        //반제품의 카테고리 목록을 보여주고 해당하는 카테고리를 선택하면 유저컨트롤 생성 메서드에 해당하는 카테고리의 ID를 보낸다.
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex < 1)
                return;

            if (!cboCategory.SelectedValue.ToString().Contains("CS"))
                return;

            try
            {
                BOMService service = new BOMService();
                if (mode.Equals("Insert"))
                {
                    List<ComboItemVO> resourceList = service.GetComboResourceCategory(cboCategory.SelectedValue.ToString());
                    UtilClass.ComboBinding(cboCategoryDetail, resourceList, "선택");
                    splitContainer2.Panel1.Controls.Clear();
                    CategoryLabelName(resourceList);
                }
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
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

        //Product 테이블과 Combination 테이블에 등록
        private void InsertSemiProduct()
        {
            ProductVO Pitem = new ProductVO
            {
                Product_Name = txtSemiproductName.Text,
                Product_Price = Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")),
                Warehouse_ID = Convert.ToInt32(cboWarehouse.SelectedValue),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Product_Category = cboCategory.SelectedValue.ToString()
            };

            List<BOMVO> citemList = new List<BOMVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    BOMVO citem = new BOMVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    citemList.Add(citem);
                }
            }

            try
            {
                BOMService service = new BOMService();
                service.InsertSemiProduct(Pitem, citemList, splitContainer2.Panel1.Controls.Count);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        //Product 테이블과 Combination 테이블 수정
        private void UpdateSemiProduct()
        {
            ProductVO Pitem = new ProductVO
            {
                Product_ID = pCode,
                Product_Name = txtSemiproductName.Text,
                Product_Price = Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Warehouse_ID = Convert.ToInt32(cboWarehouse.SelectedValue),
                Product_Category = cboCategory.SelectedValue.ToString()
            };

            List<BOMVO> citemList = new List<BOMVO>();

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    BOMVO citem = new BOMVO
                    {
                        Combination_Product_ID = spc.TxtName.Tag.ToString(),
                        Combination_RequiredQty = Convert.ToInt32(spc.Qty.Value)
                    };

                    citemList.Add(citem);
                }
            }

            try
            {
                BOMService service = new BOMService();
                service.UpdateSemiProduct(Pitem, citemList, splitContainer2.Panel1.Controls.Count);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool check = true;

            foreach (Control control in splitContainer2.Panel1.Controls)
            {
                if (control is SemiProductCompControl)
                {
                    SemiProductCompControl spc = (SemiProductCompControl)control;

                    if (spc.TxtName.Tag == null)
                    {
                        check = false;
                    }
                }
            }

            if (Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")) > 0)
            {
                if (cboCategory.SelectedValue != null && check && cboWarehouse.SelectedValue != null && txtSemiproductName.Text.Length > 0 && numSafety.Value > 0 && txtSemiproductMoney.Text.Length > 0)
                {
                    if (mode.Equals("Insert"))
                    {
                        InsertSemiProduct();
                        DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        UpdateSemiProduct();
                        DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //원자재를 선택하면 해당하는 원자재 카테고리 ID와 유저컨트롤 태그 ID를 비교해서 맞는 부분에 원자재 이름과 가격을 설정한다.
        private void dgvSemiProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dgvSemiProduct.SelectedRows.Count > 0)
            {
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        //데이터그리드뷰에서 선택한 원자재 카테고리와 사용자 컨트롤 원자재 카테고리가 같을 때
                        if (spc.LblName.Tag.ToString() == dgvSemiProduct.SelectedRows[0].Cells[2].Value.ToString())
                        {
                            //사용자컨트롤에 아무정보가 없을 때
                            if (spc.TxtName.Tag == null)
                            {
                                spc.TxtName.Text = dgvSemiProduct.SelectedRows[0].Cells[0].Value.ToString(); //제품이름
                                spc.TxtName.Tag = dgvSemiProduct.SelectedRows[0].Cells[3].Value; //제품ID
                                spc.LblMoney.Text = Convert.ToInt32(dgvSemiProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원"; //제품가격
                                spc.LblMoney.Tag = 1;
                                spc.Qty.Tag = dgvSemiProduct.SelectedRows[0].Cells[1].Value; //제품가격
                                spc.Qty.Value += 1;
                            }
                            //사용자컨트롤에 정보가 있을 때
                            else
                            {
                                //데이터그리드뷰에서 선택한 원자재 ID와 사용자컨트롤에 있는 원자재의 ID가 같을 때
                                if (spc.TxtName.Tag.ToString() == dgvSemiProduct.SelectedRows[0].Cells[3].Value.ToString())
                                {
                                    spc.Qty.Value += 1;
                                }
                                else
                                {
                                    spc.TxtName.Text = dgvSemiProduct.SelectedRows[0].Cells[0].Value.ToString(); //제품이름
                                    spc.TxtName.Tag = dgvSemiProduct.SelectedRows[0].Cells[3].Value; //제품ID
                                    spc.LblMoney.Text = Convert.ToInt32(dgvSemiProduct.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원"; //제품가격
                                    spc.LblMoney.Tag = 2;
                                    spc.Qty.Tag = dgvSemiProduct.SelectedRows[0].Cells[1].Value; //제품가격
                                    spc.Qty.Value = 0;
                                    spc.Qty.Value += 1;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
