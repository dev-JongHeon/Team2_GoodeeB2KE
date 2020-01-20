using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Category : BaseForm
    {
        List<CodeTableVO> list;
        public Category()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        public void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "카테고리코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "카테고리설명", "CodeTable_CodeExplain", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        public void LoadGridView()
        {
            CodeTableDAC dac = new CodeTableDAC();
            list = dac.GetAllCodeTable();
            List<CodeTableVO> categoryList = (from item in list where item.CodeTable_CodeID.Contains("S") && !item.CodeTable_CodeID.Contains("e") || item.CodeTable_CodeID.Contains("M") select item).ToList();
            dataGridView1.DataSource = categoryList;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadGridView();
        }
    }
}
