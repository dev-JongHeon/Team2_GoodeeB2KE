using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_VO;

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

            Service service = new Service();

            List<ComboItemVO> list = service.GetDefectiveCode();
            
            UtilClass.ComboBinding(cboDefectiveName, list.FindAll(c => c.CodeType.Contains("Defec")), "불량유형 선택");
            UtilClass.ComboBinding(cboHandle, list.FindAll(c => c.CodeType.Contains("Handle")), "불량처리유형 선택");



            #endregion

            #region 콤보박스 바인딩 - 생산실적에 있는 불량 유형
            List<string> listDefective = service.GetDefective(Performance_ID);

            UtilClass.ComboBinding(cboDefItem, listDefective, "코드 선택");

            //cboDefItem.DataSource = new Service().GetDefective(Performance_ID);
            #endregion
        }

        private bool Save()
        {
            StringBuilder msg = new StringBuilder();

            if (lblDefItem.Text != cboDefItem.Text)
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
            lblHandle.Text = cboHandle.Text;
        }
    }
}
