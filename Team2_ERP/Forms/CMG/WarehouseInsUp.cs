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
    public partial class WarehouseInsUp : BasePopup
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }

        string mode = string.Empty;
        int code = 0;

        public enum EditMode { Insert, Update }

        public WarehouseInsUp(EditMode editMode, WarehouseVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                mode = "Update";

                code = item.Warehouse_ID;
                txtWarehouseName.Text = item.Warehouse_Name;
                txtWarehouseNumber.Text = item.Warehouse_Number;
                txtWarehouseFaxNumber.Text = item.Warehouse_Fax;
            }
            else if(editMode == EditMode.Insert)
            {
                mode = "Insert";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertWarehouse()
        {
            WarehouseVO item = new WarehouseVO
            {
                Warehouse_Name = txtWarehouseName.Text,
                Warehouse_Division = Convert.ToInt32(cboWarehouseDivision.SelectedValue),
                Warehouse_Number = txtWarehouseNumber.Text,
                Warehouse_Fax = txtWarehouseFaxNumber.Text,
                Warehouse_Address = addressControl1.Address1 + "　" + addressControl1.Address2
            };

            StandardService service = new StandardService();
            service.InsertWarehouse(item);
        }

        private void UpdateWarehouse()
        {
            WarehouseVO item = new WarehouseVO
            {
                Warehouse_ID = code,
                Warehouse_Division = Convert.ToInt32(cboWarehouseDivision.SelectedValue),
                Warehouse_Name = txtWarehouseName.Text,
                Warehouse_Number = txtWarehouseNumber.Text,
                Warehouse_Fax = txtWarehouseFaxNumber.Text,
                Warehouse_Address = addressControl1.Address1 + "　" + addressControl1.Address2
            };
        }

        private void InitCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["Name"] = "원자재 창고";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Name"] = "반제품 창고";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            cboWarehouseDivision.DataSource = dt;
            cboWarehouseDivision.DisplayMember = "Name";
            cboWarehouseDivision.ValueMember = "Value";
        }


        private void WarehouseInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(mode == "Insert")
            {
                InsertWarehouse();
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
