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
    public partial class ResourceInsUp : BasePopup
    {
        List<ResourceVO> list;
        string mode = string.Empty;
        string code = string.Empty;
        string category = string.Empty;
        int wID = 0;
        int cID = 0;

        public enum EditMode { Insert, Update }

        public ResourceInsUp(EditMode editMode, ResourceVO item)
        {
            InitializeComponent();

            if (editMode == EditMode.Update)
            {
                lblName.Text = "자재 수정";
                mode = "Update";
                pbxTitle.Image = Resources.Edit_32x32;

                UpdateInfo(item);
            }
            else
            {
                lblName.Text = "자재 등록";
                mode = "Insert";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
        }

        private void UpdateInfo(ResourceVO item)
        {
            code = item.Product_ID;
            txtResourceName.Text = item.Product_Name;
            txtResourceMoney.Text = item.Product_Price.ToString();
            numResourceNum.Value = item.Product_Qty;
            numSafety.Value = item.Product_Safety;
            wID = item.Warehouse_ID;
            category = item.Product_Category;
            cID = item.Company_ID;
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
            try
            {
                StandardService service = new StandardService();
                list = service.GetAllResource();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }
        
        //원자재가 보관될 창고목록과 원자재가 속하는 카테고리 목록과 어느 거래처와 거래하는지 설정하기 위해 거래처 목록을 콤보바인딩
        private void InitCombo()
        {
            try
            {
                StandardService service = new StandardService();
                List<ComboItemVO> warehouseList = service.GetComboWarehouse(0);
                UtilClass.ComboBinding(cboResourceWarehouse, warehouseList, "선택");
                List<ComboItemVO> meterialList = (from item in service.GetComboMeterial() where item.ID.Contains("M") select item).ToList();
                UtilClass.ComboBinding(cboResourceCategory, meterialList, "선택");
                List<ComboItemVO> companyList = service.GetComboCompany();
                UtilClass.ComboBinding(cboCompany, companyList, "선택");
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }

            if(mode.Equals("Update"))
            {
                cboResourceCategory.SelectedValue = category;
                cboCompany.SelectedValue = cID.ToString("0000");
                cboResourceWarehouse.SelectedValue = wID.ToString("0000");
            }
        }

        private void InsertResource()
        {
            ResourceVO item = new ResourceVO
            {
                Product_Name = txtResourceName.Text,
                Warehouse_ID = Convert.ToInt32(cboResourceWarehouse.SelectedValue),
                Product_Price = Convert.ToInt32(txtResourceMoney.Text),
                Product_Qty = Convert.ToInt32(numResourceNum.Value),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Product_Category = cboResourceCategory.SelectedValue.ToString(),
                Company_ID = Convert.ToInt32(cboCompany.SelectedValue)
            };

            try
            {
                StandardService service = new StandardService();
                service.InsertResource(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void UpdateResource()
        {
            ResourceVO item = new ResourceVO
            {
                Product_ID = code,
                Product_Name = txtResourceName.Text,
                Warehouse_ID = Convert.ToInt32(cboResourceWarehouse.SelectedValue),
                Product_Price = Convert.ToInt32(txtResourceMoney.Text),
                Product_Qty = Convert.ToInt32(numResourceNum.Value),
                Product_Safety = Convert.ToInt32(numSafety.Value),
                Product_Category = cboResourceCategory.SelectedValue.ToString(),
                Company_ID = Convert.ToInt32(cboCompany.SelectedValue)
            };

            try
            {
                StandardService service = new StandardService();
                service.UpdateResource(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtResourceName.Text.Length > 0 && cboResourceWarehouse.SelectedValue != null && txtResourceMoney.Text.Length > 0 && numResourceNum.Value != 0 && numSafety.Value != 0 && cboResourceCategory.SelectedValue != null)
            {
                if (mode.Equals("Insert"))
                {
                    InsertResource();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK);
                }
                else
                {
                    UpdateResource();
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
