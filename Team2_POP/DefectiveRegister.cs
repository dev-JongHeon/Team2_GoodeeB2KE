using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_POP
{
    public partial class DefectiveRegister : Form
    {
        public string Performance_ID { get; set; }

        public DefectiveRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DefectiveRegister_Load(object sender, EventArgs e)
        {
            SettingData();
            InitData();
        }

        private void SettingData()
        {
            cboDefectiveName.DropDownStyle = cboDefItem.DropDownStyle = cboHandle.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }
        private void InitData()
        {
            lblPerformance.Text = Performance_ID;

            #region 콤보박스 바인딩 - 불량유형, 불량처리 유형

            DataTable dt = new Service().GetDefectiveCode();

            DataView dvDefect = new DataView();
            dvDefect = dt.DefaultView;
            dvDefect.RowFilter = "Div = 'Defective'";

            DataView dvHandle = new DataView();
            dvHandle = dt.Copy().DefaultView;
            dvHandle.RowFilter = "Div = 'Handle'";

            cboDefectiveName.DataSource = dvDefect;
            cboDefectiveName.DisplayMember = "Name";
            cboDefectiveName.ValueMember = "ID";

            cboHandle.DataSource = dvHandle;
            cboHandle.DisplayMember = "Name";
            cboHandle.ValueMember = "ID";

            #endregion

            #region 콤보박스 바인딩 - 생산실적에 있는 불량 유형
            cboDefItem.DataSource = new Service().GetDefective(Performance_ID);
            #endregion
        }

        private bool Save()
        {
            StringBuilder msg = new StringBuilder();

            if (char.IsDigit(Convert.ToChar(lblDefItem.Text)))
                msg.Append("불량번호를 선택해주세요");

            if (lblDefectiveName.Tag == null)
                msg.Append("불량품목을 선택해주세요.");

            if (lblHandle.Tag == null)
                msg.Append("불량처리유형을 선택해주세요");

            if (msg.Length > 1)
            {
                MessageBox.Show(msg.ToString());
                return false;
            }

            string defectiveID = lblDefItem.Text;
            string defecCode = lblDefectiveName.Tag.ToString();
            string handleCode = lblHandle.Tag.ToString();

            lblDefectiveName.Text = "선택된 불량유형";
            lblDefItem.Text = "선택된 불량품목";
            lblHandle.Text = "선택된 불량 처리유형";

            lblDefectiveName.Tag = null;
            lblHandle.Tag = null;

            return new Service().SetDefective(defectiveID, handleCode, defecCode);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                this.Close();
            else
                MessageBox.Show("정상처리되지 않았습니다. 다시 시도해주세요.");
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (Save())
                InitData();
            else
                MessageBox.Show("정상처리되지 않았습니다. 다시 시도해주세요.");
        }

        private void btnDefProSelect_Click(object sender, EventArgs e)
        {
            lblDefItem.Text = cboDefItem.Text;
        }

        private void btnDefNameSelect_Click(object sender, EventArgs e)
        {
            lblDefectiveName.Tag = cboDefectiveName.SelectedValue.ToString();
            lblDefectiveName.Text = cboDefectiveName.Text;
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            lblHandle.Tag = cboHandle.SelectedValue.ToString();
            lblHandle.Text = cboDefectiveName.Text;
        }
    }
}
