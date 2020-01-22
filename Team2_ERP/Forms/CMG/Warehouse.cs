using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class Warehouse : BaseForm
    {
        public Warehouse()
        {
            InitializeComponent();
        }

        private void InitGridView()
        {
            UtilClass.SettingDgv(dataGridView1);

            UtilClass.AddNewColum(dataGridView1, "창고코드", "Warehouse_ID", true, 100);
            UtilClass.AddNewColum(dataGridView1, "창고이름", "Warehouse_Name", true, 100);
            UtilClass.AddNewColum(dataGridView1, "창고주소", "Warehouse_Address", true, 100);
            UtilClass.AddNewColum(dataGridView1, "전화번호", "Warehouse_Number", true, 100);
            UtilClass.AddNewColum(dataGridView1, "FAX번호", "Warehouse_Fax", true, 100);
            UtilClass.AddNewColum(dataGridView1, "구분", "Warehouse_Division", true, 100);

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}