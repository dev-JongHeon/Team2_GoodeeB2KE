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
    public partial class Resource : BaseForm
    {
        List<ResourceVO> list;
        public Resource()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "제품코드", "Product_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품이름", "Product_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품보관창고", "Warehouse_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품가격", "Product_Price", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품개수", "Product_Qty", true, 100);
            UtilClass.AddNewColum(dataGridView1, "안전재고량", "Product_Safety", true, 100);
            UtilClass.AddNewColum(dataGridView1, "제품카테고리", "Product_Category", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllResource();
            List<ResourceVO> resourceList = (from item in list where item.Product_ID.Contains("M") && item.Product_DeletedYN == false select item).ToList();
            dataGridView1.DataSource = resourceList;
        }

        private void Resource_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadGridView();
        }
    }
}
