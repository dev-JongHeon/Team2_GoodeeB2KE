﻿using System;
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

        public enum EditMode { Insert, Update }

        public ResourceInsUp(EditMode editMode, ResourceVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                mode = "update";
                txtResourceName.Text = item.Product_Name;
                txtResourceMoney.Text = item.Product_Price.ToString();
                numResourceNum.Value = item.Product_Qty;
                txtResourceSafe.Text = item.Product_Safety.ToString();
            }
            else if(editMode == EditMode.Insert)
            {
                mode = "insert";
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
            List<ComboItemVO> warehouseList = service.GetComboWarehouse();
            UtilClass.ComboBinding(cboResourceWarehouse, warehouseList, "선택");
            List<ComboItemVO> meterialList = (from item in service.GetComboMeterial() where item.ID.Contains("M") select item).ToList();
            UtilClass.ComboBinding(cboResourceCategory, meterialList, "선택");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(mode == "insert")
            {
                ResourceVO item = new ResourceVO
                {
                    Product_Name = txtResourceName.Text,
                    Warehouse_ID = Convert.ToInt32(cboResourceWarehouse.SelectedValue),
                    Product_Price = Convert.ToInt32(txtResourceMoney.Text),
                    Product_Qty = Convert.ToInt32(numResourceNum.Value),
                    Product_Safety = Convert.ToInt32(txtResourceSafe.Text),
                    Product_Category = cboResourceCategory.SelectedValue.ToString()
                };

                StandardService service = new StandardService();
                service.InsertResource(item);
            }
        }
    }
}
