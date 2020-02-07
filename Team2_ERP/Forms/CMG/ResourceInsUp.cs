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
    public partial class ResourceInsUp : BasePopup
    {
        List<ResourceVO> list;
        string mode = string.Empty;
        string code = string.Empty;

        public enum EditMode { Insert, Update }

        public ResourceInsUp(EditMode editMode, ResourceVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                lblName.Text = "자재 수정";
                mode = "Update";
                pbxTitle.Image = Properties.Resources.Edit_32x32;
                code = item.Product_ID;
                txtResourceName.Text = item.Product_Name;
                txtResourceMoney.Text = item.Product_Price.ToString();
                numResourceNum.Value = item.Product_Qty;
                numSafety.Value = item.Product_Safety;
            }
            else
            {
                lblName.Text = "자재 등록";
                mode = "Insert";
                pbxTitle.Image = Properties.Resources.AddFile_32x32;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResourceInsUp_Load(object sender, EventArgs e)
        {
            LoadData();
            InitCombo();
        }

        private void LoadData()
        {
            StandardService service = new StandardService();
            list = service.GetAllResource();
        }

        private void InitCombo()
        {
            StandardService service = new StandardService();
            List<ComboItemVO> warehouseList = service.GetComboWarehouse(0);
            UtilClass.ComboBinding(cboResourceWarehouse, warehouseList, "선택");
            List<ComboItemVO> meterialList = (from item in service.GetComboMeterial() where item.ID.Contains("M") select item).ToList();
            UtilClass.ComboBinding(cboResourceCategory, meterialList, "선택");
        }

        private void InsertResource()
        {
            ResourceVO item = new ResourceVO
            {
                Product_Name = txtResourceName.Text,
                Warehouse_ID = cboResourceWarehouse.SelectedValue.ToString(),
                Product_Price = Convert.ToInt32(txtResourceMoney.Text),
                Product_Qty = Convert.ToInt32(numResourceNum.Value),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Product_Category = cboResourceCategory.SelectedValue.ToString()
            };

            StandardService service = new StandardService();
            service.InsertResource(item);
        }

        private void UpdateResource()
        {
            ResourceVO item = new ResourceVO
            {
                Product_ID = code,
                Product_Name = txtResourceName.Text,
                Warehouse_ID = cboResourceWarehouse.SelectedValue.ToString(),
                Product_Price = Convert.ToInt32(txtResourceMoney.Text),
                Product_Qty = Convert.ToInt32(numResourceNum.Value),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Product_Category = cboResourceCategory.SelectedValue.ToString()
            };

            StandardService service = new StandardService();
            service.UpdateResource(item);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtResourceName.Text.Length > 0 && cboResourceWarehouse.SelectedValue != null && txtResourceMoney.Text.Length > 0 && numResourceNum.Value != 0 && numSafety.Value != 0 && cboResourceCategory.SelectedValue != null)
            {
                if (mode.Equals("Insert"))
                {
                    InsertResource();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.AddDone, Properties.Settings.Default.AddDone, MessageBoxButtons.OK);
                }
                else
                {
                    UpdateResource();
                    DialogResult = MessageBox.Show(Properties.Settings.Default.ModDone, Properties.Settings.Default.ModDone, MessageBoxButtons.OK);
                }
            }
        }
    }
}
