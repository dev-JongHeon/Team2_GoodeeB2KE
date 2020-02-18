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
    public partial class WarehouseInsUp : BasePopup
    {
        public string WName { get; set; }
        public string Value { get; set; }

        string mode = string.Empty;
        int code = 0;
        string division = string.Empty;

        public enum EditMode { Insert, Update }

        public WarehouseInsUp(EditMode editMode, WarehouseVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                mode = "Update";
                lblName.Text = "창고 수정";
                pbxTitle.Image = Resources.Edit_32x32;

                UpdateInfo(item);
            }
            else
            {
                mode = "Insert";
                lblName.Text = "창고 등록";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
        }

        private void UpdateInfo(WarehouseVO item)
        {
            code = item.Warehouse_ID;
            txtWarehouseName.Text = item.Warehouse_Name;
            maskedWarehouseNumber.Text = item.Warehouse_Number;
            maskedWarehouseFaxNumber.Text = item.Warehouse_Fax;
            division = item.Warehouse_Division_Name;
            string[] str = item.Warehouse_Address.Split('　');
            addrWarehouse.Address1 = str[0];
            addrWarehouse.Address2 = str[1];
            addrWarehouse.Zipcode = item.Warehouse_AddrNumber;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertWarehouse()
        {
            if (cboWarehouseDivision.SelectedIndex != 0)
            {
                WarehouseVO item = new WarehouseVO
                {
                    Warehouse_Name = txtWarehouseName.Text,
                    Warehouse_Division = Convert.ToInt32(cboWarehouseDivision.SelectedValue),
                    Warehouse_Number = maskedWarehouseNumber.Text,
                    Warehouse_Fax = maskedWarehouseFaxNumber.Text,
                    Warehouse_Address = addrWarehouse.Address1 + "　" + addrWarehouse.Address2,
                    Warehouse_AddrNumber = addrWarehouse.Zipcode
                };

                if(item.Warehouse_Number.Replace("-", "").Trim().Length < 10)
                {
                    item.Warehouse_Number = null;
                }

                if(item.Warehouse_Fax.Replace("-", "").Trim().Length < 10)
                {
                    item.Warehouse_Fax = null;
                }

                StandardService service = new StandardService();
                service.InsertWarehouse(item);
            }
        }

        private void UpdateWarehouse()
        {
            if (cboWarehouseDivision.SelectedIndex != 0)
            {
                WarehouseVO item = new WarehouseVO
                {
                    Warehouse_ID = code,
                    Warehouse_Division = Convert.ToInt32(cboWarehouseDivision.SelectedValue),
                    Warehouse_Name = txtWarehouseName.Text,
                    Warehouse_Number = maskedWarehouseNumber.Text,
                    Warehouse_Fax = maskedWarehouseNumber.Text,
                    Warehouse_Address = addrWarehouse.Address1 + "　" + addrWarehouse.Address2,
                    Warehouse_AddrNumber = addrWarehouse.Zipcode
                };

                if (item.Warehouse_Number.Replace("-", "").Trim().Length < 10)
                {
                    item.Warehouse_Number = null;
                }

                if (item.Warehouse_Fax.Replace("-", "").Trim().Length < 10)
                {
                    item.Warehouse_Fax = null;
                }

                StandardService service = new StandardService();
                service.UpdateWarehouse(item);
            }
        }

        private void InitCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("WName", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["WName"] = "선택";
            dr["Value"] = 2;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["WName"] = "원자재 창고";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["WName"] = "반제품 창고";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            cboWarehouseDivision.DataSource = dt;
            cboWarehouseDivision.DisplayMember = "WName";
            cboWarehouseDivision.ValueMember = "Value";

            if(mode.Equals("Update"))
            {
                if(division.Contains("반제품"))
                {
                    cboWarehouseDivision.SelectedValue = 1;
                }
                else
                {
                    cboWarehouseDivision.SelectedValue = 0;
                }
            }
        }


        private void WarehouseInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtWarehouseName.Text.Length > 0 && !cboWarehouseDivision.SelectedValue.Equals(2) && addrWarehouse.Address1.Length > 0 && addrWarehouse.Address2.Length > 0)
            {
                if(mode.Equals("Insert"))
                {
                    InsertWarehouse();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK);
                }
                else
                {
                    UpdateWarehouse();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
