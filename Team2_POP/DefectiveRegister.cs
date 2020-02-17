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
    /// <summary>
    /// 불량유형을 처리하는 POPUP 창
    /// </summary>
    public partial class DefectiveRegister : Form
    {
        public string Performance_ID { get; set; }

        public DefectiveRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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

            #endregion
        }

        private bool Save()
        {
            StringBuilder msg = new StringBuilder();

            if (lblDefItem.Text != cboDefItem.Text)
                msg.AppendLine(string.Format(Properties.Resources.MsgChoice1, "불량번호"));

            if (lblDefectiveName.Tag == null)
                msg.AppendLine(string.Format(Properties.Resources.MsgChoice2, "불량유형"));

            if (lblHandle.Tag == null)
                msg.AppendLine(string.Format(Properties.Resources.MsgChoice2, "불량처리유형"));

            if (msg.Length > 1)
            {
                CustomMessageBox.ShowDialog(Properties.Resources.MsgDefectiveValidate, msg.ToString(), MessageBoxIcon.Warning, MessageBoxButtons.OK);
                ResetData();
                return false;
            }

            string defectiveID = lblDefItem.Text;                    // 불량번호
            string defecCode = lblDefectiveName.Tag.ToString();      // 불량유형코드
            string handleCode = lblHandle.Tag.ToString();            // 불량처리코드


            bool bResult = new Service().SetDefective(defectiveID, handleCode, defecCode);
            if (bResult) // 성공한 경우
                CustomMessageBox.ShowDialog(Properties.Resources.MsgDefectiveResultSucceesHeader
                    , string.Format(Properties.Resources.MsgDefectiveResultSucceesContents, defectiveID, lblDefectiveName.Text, lblHandle.Text)
                    , MessageBoxIcon.Question);

            else // 실패한 경우
            {
                CustomMessageBox.ShowDialog(Properties.Resources.MsgDefectiveResultFailHeader
                    , string.Format(Properties.Resources.MsgDefectiveResultFailContents, defectiveID), MessageBoxIcon.Error);
            }

            return bResult;
        }

        // 데이터 초기화해주는 함수
        private void ResetData()
        {
            cboDefectiveName.SelectedIndex = cboDefItem.SelectedIndex = cboHandle.SelectedIndex = 0;

            // 초기화

            lblDefectiveName.Text = "선택된 불량유형";
            lblDefItem.Text = "선택된 불량품목";
            lblHandle.Text = "선택된 불량 처리유형";
            lblDefectiveName.Tag = null;
            lblHandle.Tag = null;

            InitData();
        }

        //저장을 누를때
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                DialogResult = DialogResult.OK;
        }

        // 계속 저장 누를때
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            Save();
            ResetData();

            // 모든 불량을 다 처리한 경우
            if (cboDefItem.Items.Count < 2)
            {
                DialogResult = CustomMessageBox.ShowDialog(Properties.Resources.MsgDefectiveResultSucceesHeader
                    , Properties.Resources.MsgDefectiveSaveAsAllCompleteContent, MessageBoxIcon.Information, MessageBoxButtons.OK);
            }
        }

        #region 버튼 이벤트
        private void btnDefProSelect_Click(object sender, EventArgs e)
        {
            if (cboDefItem.SelectedIndex != 0)
                lblDefItem.Text = cboDefItem.Text;
        }

        private void btnDefNameSelect_Click(object sender, EventArgs e)
        {
            if (cboDefectiveName.SelectedIndex != 0)
            {
                lblDefectiveName.Tag = cboDefectiveName.SelectedValue.ToString();
                lblDefectiveName.Text = cboDefectiveName.Text;
            }
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            if (cboDefectiveName.SelectedIndex != 0)
            {
                lblHandle.Tag = cboHandle.SelectedValue.ToString();
                lblHandle.Text = cboHandle.Text;
            }
        }
        #endregion


        #region 콤보박스 선택 이벤트

        // 불량코드를 선택한 경우
        private void cboDefItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDefItem.SelectedIndex != 0)
                lblDefItem.Text = cboDefItem.Text;
        }

        // 불량유형을 선택한 경우
        private void cboDefectiveName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDefectiveName.SelectedIndex != 0)
            {
                lblDefectiveName.Tag = cboDefectiveName.SelectedValue.ToString();
                lblDefectiveName.Text = cboDefectiveName.Text;
            }
            else
            {
                lblDefectiveName.Tag = null;
                lblDefectiveName.Text = cboDefectiveName.Text;
            }
        }

        // 불량처리를 선택한 경우
        private void cboHandle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHandle.SelectedIndex != 0)
            {
                lblHandle.Tag = cboHandle.SelectedValue.ToString();
                lblHandle.Text = cboHandle.Text;
            }
            else
            {
                lblHandle.Tag = null;
                lblHandle.Text = cboHandle.Text;
            }
        }
        #endregion
    }
}
