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
            lblFairName.Text = LineName;
            lblFairName.Tag = LineID;

            cboDowntime.DropDownStyle = ComboBoxStyle.DropDownList;
            UtilClass.ComboBinding(cboDowntime, new Service().GetDowntimeCode(), "비가동유형 선택");            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
           if(cboDowntime.SelectedIndex > 0)
            {
                lblDowntimeName.Text = cboDowntime.Text;
                lblDowntimeName.Tag = cboDowntime.SelectedValue;
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if(lblDowntimeName.Tag !=null)
            {
                // 비가동 처리
                new Service().SetDowntime(LineID, lblDowntimeName.Tag.ToString(), EmployeeID);

                DialogResult = DialogResult.OK;
            }
        }
    }
}
