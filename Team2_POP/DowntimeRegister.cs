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
    public partial class DowntimeRegister : Form
    {
        public int LineID { get; set; }
        public string LineName { get; set; }
        public int EmployeeID { get; set; }

        public DowntimeRegister()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DowntimeRegister_Load(object sender, EventArgs e)
        {
            try
            {

                lblFairName.Text = LineName;
                lblFairName.Tag = LineID;
                cboDowntime.DropDownStyle = ComboBoxStyle.DropDownList;

                Service service = new Service();

                List<ComboItemVO> list = service.GetDowntimeCode();
                UtilClass.ComboBinding(cboDowntime, list, "비가동유형 선택");

                // 바인딩한 값이 없는 경우
                if (list == null)
                {
                    if (CustomMessageBox.ShowDialog(Properties.Resources.MsgDowntimeGetResultFailHeader
                            , Properties.Resources.MsgDowntimeGetResultFailContent, MessageBoxIcon.Information, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        list = service.GetDowntimeCode();
                        UtilClass.ComboBinding(cboDowntime, list, "비가동유형 선택");
                    }
                }
            }
            catch (Exception ex)
            {
                Program.Log.WriteError(ex.Message, ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
          
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDowntimeName.Tag != null)
                {
                    // 비가동 처리
                    bool bResult = new Service().SetDowntime(LineID, lblDowntimeName.Tag.ToString(), EmployeeID);


                    if (bResult)
                        DialogResult = DialogResult.OK;
                    else
                        CustomMessageBox.ShowDialog(Properties.Resources.MsgDowntimeSetResultFailHeader
                            , Properties.Resources.MsgDowntimeSetResultFailContent, MessageBoxIcon.Error);
                }
                else
                {
                    CustomMessageBox.ShowDialog("비가동 전환오류", "비가동 유형을 선택해주세요.", MessageBoxIcon.Warning, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Program.Log.WriteError(ex.Message, ex);
            }
        }

        private void cboDowntime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDowntime.SelectedIndex > 0)
            {
                lblDowntimeName.Text = cboDowntime.Text;
                lblDowntimeName.Tag = cboDowntime.SelectedValue;
            }
            else
            {
                lblDowntimeName.Text = cboDowntime.Text;
                lblDowntimeName.Tag = null;
            }
        }
    }
}
