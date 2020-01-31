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


        public SemiProductComp(EditMode editMode, BOMVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Insert)
            {
                lblName.Text = "반제품 등록";
            }
        }

        //반제품 카테고리 목록을 가져오는 콤보 바인딩 메서드
        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
            UtilClass.ComboBinding(cboCategory, categoryList, "선택");
        }

        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            UtilClass.AddNewColum(dataGridView1, "제품카테고리", "Product_Category", false, 100);
            UtilClass.AddNewColum(dataGridView1, "제품ID", "Product_ID", false, 100);
            dataGridView1.Columns[1].DefaultCellStyle.Format = "#,###원";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllProduct();
            List<ProductVO> resourceList = (from item in list where item.Product_Category.Contains($"{cboCategoryDetail.SelectedValue.ToString()}") && item.Product_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = resourceList;
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
            List<ComboItemVO> resourceList = service.GetComboResourceCategory(cboCategory.SelectedValue.ToString());
            UtilClass.ComboBinding(cboCategoryDetail, resourceList, "선택");

            splitContainer2.Panel1.Controls.Clear();
            CategoryLabelName(resourceList);
        }

        //원자재 카테고리를 선택하면 해당하는 카테고리에 있는 모든 원자재 목록을 데이터 그리드 뷰에 바인딩한다.
        private void cboCategoryDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoryDetail.SelectedIndex < 1)
                return;

            if (!cboCategoryDetail.SelectedValue.ToString().Contains("CM"))
                return;

            LoadGridView();
        }

        //원자재를 선택하면 해당하는 원자재 카테고리 ID와 유저컨트롤 태그 ID를 비교해서 맞는 부분에 원자재 이름과 가격을 설정한다.
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && dataGridView1.SelectedRows.Count > 0)
            {
                foreach (Control control in splitContainer2.Panel1.Controls)
                {
                    if (control is SemiProductCompControl)
                    {
                        SemiProductCompControl spc = (SemiProductCompControl)control;

                        if (spc.LblName.Tag.ToString() == dataGridView1.SelectedRows[0].Cells[2].Value.ToString())
                        {
                            spc.TxtName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            spc.TxtName.Tag = dataGridView1.SelectedRows[0].Cells[3].Value;
                            spc.LblMoney.Text = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value).ToString("#,##0") + "원";
                            if (txtSemiproductMoney.Text.Equals("0원") || txtSemiproductMoney.Text.Length < 1)
                                txtSemiproductMoney.Text = spc.LblMoney.Text;
                            else
                                txtSemiproductMoney.Text = (Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")) + Convert.ToInt32(spc.LblMoney.Text.Replace(",", "").Replace("원", ""))).ToString("#,##0") + "원";
                            
                            spc.Qty.Tag = dataGridView1.SelectedRows[0].Cells[1].Value;
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ProductVO Pitem = new ProductVO
            {
                Product_Name = txtSemiproductName.Text,
                Product_Price = Convert.ToInt32(txtSemiproductMoney.Text.Replace(",", "").Replace("원", "")),
                Product_Qty = Convert.ToInt32(numericUpDown1.Value),
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

        //반제품 조합의 개수만큼 단가를 조정한다.
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value > 0)
            {
                txtSemiproductMoney.Text = (Convert.ToInt32( txtSemiproductMoney.Tag) * Convert.ToInt32(numericUpDown1.Value)).ToString("#,##0") + "원";
            }
        }
    }
}
