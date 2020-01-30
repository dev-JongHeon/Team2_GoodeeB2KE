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

        SemiProductCompControl[] spc;

        ProductVO item;

        public SemiProductComp(EditMode editMode, BOMVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Insert)
            {
                lblName.Text = "반제품 등록";
            }
        }

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

        private void CategoryLabelName(List<ComboItemVO> countList)
        {
            spc = new SemiProductCompControl[countList.Count];

            for (int i = 1; i < countList.Count; i++)
            {
                spc[i] = new SemiProductCompControl();
                spc[i].Location = new Point(0, i * 40);
                spc[i].CategoryName = countList[i].Name;
                spc[i].CategoryTag = countList[i].ID;
                splitContainer2.Panel1.Controls.Add(spc[i]);
            }
        }

        private void SelectResourceInfo()
        {
            for(int i = 0; i < spc.Length; i++)
            {
               
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

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboCategory.SelectedValue.ToString().Contains("CS"))
                return;

            StandardService service = new StandardService();
            List<ComboItemVO> resourceList = service.GetComboResourceCategory(cboCategory.SelectedValue.ToString());
            UtilClass.ComboBinding(cboCategoryDetail, resourceList, "선택");

            splitContainer2.Panel1.Controls.Clear();
            CategoryLabelName(resourceList);
        }

        private void cboCategoryDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategoryDetail.SelectedIndex < 1)
                return;

            if (!cboCategoryDetail.SelectedValue.ToString().Contains("CM"))
                return;

            LoadGridView();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            item = new ProductVO
            {
                Product_Name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                Product_Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value),
                Product_Category = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
            };

            SelectResourceInfo();
        }
    }
}
