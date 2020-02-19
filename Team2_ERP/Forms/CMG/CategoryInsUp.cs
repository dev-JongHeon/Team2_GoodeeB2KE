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
    public partial class CategoryInsUp : BasePopup
    {
        public enum EditMode { Insert, Update }

        string mode = string.Empty;
        string code = string.Empty;
        string info = string.Empty;

        public CategoryInsUp(EditMode editMode, CodeTableVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Update)
            {
                mode = "Update";
                lblName.Text = "카테고리 수정";
                code = item.CodeTable_CodeID;
                txtName.Text = item.CodeTable_CodeName;
                info = item.CodeTable_CodeExplain;
                pbxTitle.Image = Resources.Edit_32x32;
            }
            else
            {
                mode = "Insert";
                lblName.Text = "카테고리 등록";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
        }

        private void InsertCategory()
        {
            CodeTableVO category = new CodeTableVO();

            category.CodeTable_CodeName = txtName.Text;

            if (txtContext.Text.Length > 0)
                category.CodeTable_CodeExplain = txtContext.Text;
            else
                category.CodeTable_CodeExplain = cboContext.SelectedValue.ToString();

            try
            {
                CodeTableService service = new CodeTableService();
                service.InsertCategory(category);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        public void UpdateCategory()
        {
            CodeTableVO category = new CodeTableVO();

            category.CodeTable_CodeName = txtName.Text;

            if (txtContext.Text.Length > 0)
                category.CodeTable_CodeExplain = txtContext.Text;
            else
                category.CodeTable_CodeExplain = cboContext.SelectedValue.ToString();

            category.CodeTable_CodeID = code;

            try
            {
                CodeTableService service = new CodeTableService();
                service.UpdateCodeTable(category);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (mode.Equals("Insert"))
            {
                if(rdoResource.Checked)
                {
                    if (txtName.Text.Length > 0 && cboContext.SelectedValue != null)
                    {
                        InsertCategory();
                        DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(Resources.AddError, Resources.AddError);
                    }
                }
                else
                {
                    if (txtName.Text.Length > 0 && txtContext.Text.Length > 0)
                    {
                        InsertCategory();
                        DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(Resources.AddError, Resources.AddError);
                    }
                }
            }
            else
            {
                if(rdoResource.Checked)
                {
                    if(txtName.Text.Length > 0 && cboContext.SelectedValue != null)
                    {
                        UpdateCategory();
                        DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(Resources.ModError, Resources.ModError);
                    }
                }
                else
                {
                    if (txtName.Text.Length > 0 && txtContext.Text.Length > 0)
                    {
                        UpdateCategory();
                        DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(Resources.ModError, Resources.ModError);
                    }
                }
            }
        }

        private void CategoryInsUp_Load(object sender, EventArgs e)
        {
            if(mode.Equals("Update"))
            {
                if (code.Substring(0, 2).Equals("CM"))
                {
                    rdoSemiProduct.Enabled = false;
                    rdoResource.Checked = true;
                    cboContext.Visible = true;
                    txtContext.Visible = false;
                    InitCombo();
                }
                else if(code.Substring(0, 2).Equals("CS"))
                {
                    rdoResource.Enabled = false;
                    rdoSemiProduct.Checked = true;
                    cboContext.Visible = false;
                    txtContext.Visible = true;
                    txtContext.Text = info;
                }
            }
            else
            {
                rdoResource.Checked = true;
                cboContext.Visible = true;
                txtContext.Visible = false;
                InitCombo();
            }
        }

        private void InitCombo()
        {
            try
            {
                CodeTableService service = new CodeTableService();
                List<ComboItemVO> categoryList = (from item in service.GetComboProductCategory() where item.ID.Contains("CS") select item).ToList();
                UtilClass.ComboBinding(cboContext, categoryList, "선택");
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoResource.Checked)
            {
                label1.Text = "원자재 카테고리 이름";
                label2.Text = "원자재 카테고리 설명";
                cboContext.Visible = true;
                txtContext.Visible = false;
            }
            else
            {
                label1.Text = "반제품 카테고리 이름";
                label2.Text = "반제품 카테고리 설명";
                txtContext.Visible = true;
                cboContext.Visible = false;
            }
        }
    }
}