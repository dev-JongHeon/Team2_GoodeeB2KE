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
    public partial class LineInsUp : BasePopup
    {
        public string LName { get; set; }
        public string Value { get; set; }

        public enum EditMode { Insert, Update }

        int code = 0;
        string mode = string.Empty;

        public LineInsUp(EditMode editMode, LineVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                mode = "Insert";
                lblName.Text = "공정등록";
                pbxTitle.Image = Resources.AddFile_32x32;
            }
            else
            {
                mode = "Update";
                lblName.Text = "공정수정";
                pbxTitle.Image = Resources.Edit_32x32;
                code = item.Line_ID;
                txtLineName.Text = item.Line_Name;
            }
        }

        private void InitCombo()
        {
            try
            {
                StandardService service = new StandardService();
                List<ComboItemVO> factoryList = service.GetComboFactory();
                UtilClass.ComboBinding(cboFactoryName, factoryList, "선택");
                List<ComboItemVO> categoryList = service.GetComboCategory();
                UtilClass.ComboBinding(cboCategory, categoryList, "선택");
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void InsertLine()
        {
            LineVO item = new LineVO
            {
                Line_Name = txtLineName.Text,
                Factory_ID = Convert.ToInt32(cboFactoryName.SelectedValue),
                Line_CodeID = cboCategory.SelectedValue.ToString()
            };

            try
            {
                StandardService service = new StandardService();
                service.InsertLine(item);
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
        }

        private void UpdateLine()
        {
            LineVO item = new LineVO
            {
                Line_ID = code,
                Line_Name = txtLineName.Text,
                Factory_ID = Convert.ToInt32(cboFactoryName.SelectedValue),
                Line_CodeID = cboCategory.SelectedValue.ToString()
            };

            try
            {
                StandardService service = new StandardService();
                service.UpdateLine(item);
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

        private void LineInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtLineName.Text.Length > 0 && cboFactoryName.SelectedValue != null)
            {
                if(mode.Equals("Insert"))
                {
                    InsertLine();
                    DialogResult = MessageBox.Show(Resources.AddDone, Resources.AddDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateLine();
                    DialogResult = MessageBox.Show(Resources.ModDone, Resources.ModDone, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(Resources.isEssential, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
