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
    public partial class LoginPOP : Form
    {
        List<ComboItemVO> factory;


        public LoginPOP()
        {
            InitializeComponent();
        }

        private void LoginPOP_Load(object sender, EventArgs e)
        {
            SettingControl();
            InitData();

        }

        private void SettingControl()
        {
            cboFactory.DropDownStyle = cboLine.DropDownStyle = cboWorker.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitData()
        {
            Service service = new Service();
            factory = service.GetFactoryList();


            UtilClass.ComboBinding(cboFactory, factory, "공장 선택");
            UtilClass.ComboBinding(cboLine, null, "공장을 먼저 선택해주세요");
            UtilClass.ComboBinding(cboWorker, null, "공장을 먼저 선택해주세요");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();

            if (cboFactory.SelectedIndex < 1)
                msg.AppendLine("공장을 선택해주세요.");

            if (cboLine.SelectedIndex < 1)
                msg.AppendLine("공정을 선택해주세요.");

            if (cboWorker.SelectedIndex < 1)
                msg.AppendLine("작업자를 선택해주세요.");

            if (msg.Length > 1)
            {
                MessageBox.Show(msg.ToString());
                return;
            }

            // 유효성 검사
            WorkerInfoPOP workerInfo = new WorkerInfoPOP
            {
                WorkID = Convert.ToInt32(cboWorker.SelectedValue),
                Worker = cboWorker.Text,
                LineID = Convert.ToInt32(cboLine.SelectedValue),
                LineName = cboLine.Text,
                FactoryID = cboFactory.SelectedValue.ToString(),
                FactoryName = cboFactory.Text
            };
          
            using(PopMain Main = new PopMain())
            {
                this.Hide();
                Main.WorkerInfo = workerInfo;

                Main.ShowDialog();
            }


            // 초기값
            this.Show();
        }

        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFactory.SelectedIndex > 0)
            {
                string facDivision = factory.Find(f => f.ID == cboFactory.SelectedValue.ToString()).CodeType;

                UtilClass.ComboBinding(cboWorker, new Service().GetWorker(Convert.ToInt32(facDivision)), "작업자 선택");
                UtilClass.ComboBinding(cboLine, new Service().GetLineList(Convert.ToInt32(cboFactory.SelectedValue)), "공정 선택");
            }
            else
            {
                UtilClass.ComboBinding(cboLine, null, "공장을 먼저 선택해주세요");
                UtilClass.ComboBinding(cboWorker, null, "공장을 먼저 선택해주세요");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
