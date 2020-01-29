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
        List<BOMVO> list;

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
            UtilClass.AddNewColum(dgvBOM, "제품명", "Product_Name", true, 100);
            UtilClass.AddNewColum(dgvBOM, "가격", "Product_Price", true, 100, DataGridViewContentAlignment.MiddleRight);
            dgvBOM.Columns[3].DefaultCellStyle.Format = "#,###원";

            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBOM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "전개";
            btn.Width = 100;
            dgvBOM.Columns.Add(btn);
            dgvBOM.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvBOM.Columns[4].Width = 70;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            list = service.GetAllProduct();
            List<BOMVO> productList = (from item in list where item.Product_DeletedYN == false select item).ToList();
            dgvBOM.DataSource = productList;
        }

        private void BOM_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadGridView();
        }

        private void dgvBOM_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex == 4)
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
    }
}
