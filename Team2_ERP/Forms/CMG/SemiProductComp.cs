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

        CombinationVO item;

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
            for (int i = 1; i < countList.Count; i++)
            {
                spc = new SemiProductCompControl();
                spc.Location = new Point(0, i * 40);
                spc.LblName.Text = countList[i].Name;
                spc.LblName.Tag = countList[i].ID;
                splitContainer2.Panel1.Controls.Add(spc);
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
                            spc.LblMoney.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            spc.Qty.Tag = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < splitContainer2.Panel1.Controls.Count; i++)
            {
                item = new CombinationVO
                {
                    Product_ID = cboCategory.SelectedValue.ToString()
                };
            }
        }
    }
}
