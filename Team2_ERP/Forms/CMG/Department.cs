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
    public partial class Department : BaseForm
    {
        List<CodeTableVO> list;
        public Department()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "부서코드", "CodeTable_CodeID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "부서이름", "CodeTable_CodeName", true, 100);
            UtilClass.AddNewColum(dataGridView1, "부서설명", "CodeTable_CodeExplain", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            CodeTableService service = new CodeTableService();
            list = service.GetAllCodeTable();
            List<CodeTableVO> departmentList = (from item in list where item.CodeTable_CodeID.Contains("Depart") select item).ToList();
            dataGridView1.DataSource = departmentList;
        }

        private void Department_Load(object sender, EventArgs e)
        {
            InitGridView();
            LoadGridView();
        }
    }
}
