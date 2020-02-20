using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
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
        #region 전역변수
        List<ComboItemVO> factory;
        WorkerInfoPOP workerInfo;
        private Point mousePoint;
        #endregion

        public LoginPOP()
        {
            InitializeComponent();
        }

        #region 화면 초기
        /* ===================================
         *  SettingControl : 콤보박스 디자인
         *  InitData : 콤보박스 바인딩
        =====================================*/
        private void LoginPOP_Load(object sender, EventArgs e)
        {
            SettingControl();
            InitData();
            CheckUpdate();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment appDeployment = ApplicationDeployment.CurrentDeployment;

                lblVersion.Text = $"Version : {appDeployment.CurrentVersion.ToString()} ";  // 현재버전의 정보를 가져옴
            }
            else
            {
                lblVersion.Text = "Version : Not Deployed";
            }
        }

        private void SettingControl()
        {
            // 콤보박스 디자인
            cboFactory.DropDownStyle = cboLine.DropDownStyle = cboWorker.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitData()
        {
            try
            {

                Service service = new Service();
                factory = service.GetFactoryList();

                List<ComboItemVO> list = null;

                UtilClass.ComboBinding(cboFactory, factory, "공장 선택");
                UtilClass.ComboBinding(cboLine, list, "공장을 먼저 선택해주세요");
                UtilClass.ComboBinding(cboWorker, list, "공장을 먼저 선택해주세요");
            }
            catch (Exception ex)
            {

                Program.Log.WriteError(ex.Message, ex);
            }
        }
        #endregion

        // 연결 선택시
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
                CustomMessageBox.ShowDialog("접속실패", msg.ToString(), MessageBoxIcon.Warning, MessageBoxButtons.OK);
                return;
            }

            // 유효성 검사
            workerInfo = new WorkerInfoPOP
            {
                WorkID = Convert.ToInt32(cboWorker.SelectedValue),
                Worker = cboWorker.Text,
                LineID = Convert.ToInt32(cboLine.SelectedValue),
                LineName = cboLine.Text,
                FactoryID = cboFactory.SelectedValue.ToString(),
                FactoryName = cboFactory.Text
            };

            // 로그인이 완료되면 메인 화면을 띄워주는 코드
            PopMain Main = new PopMain();
            Hide();
            Main.WorkerInfo = workerInfo;

            // 로그아웃버튼을 누른 경우
            // 폼을 다시 로드하는 효과를 줌.
            if (Main.ShowDialog() == DialogResult.OK)
            {
                InitData();

                cboFactory.SelectedValue = Main.WorkerInfo.FactoryID;
                Show();
            }
            // 종료 버튼을 누른 경우
            // 로그인 화면도 닫음
            else
                Close();

        }

        /* =============================================
         *  공장 콤보박스를 선택했을경우 발생하는 이벤트
        =============================================== */
        private void cboFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cboFactory.SelectedIndex > 0)
                {
                    // 공장리스트에서 공장타입번호가 같은것만 찾아서 공정 리스트를 호출 바인딩함
                    string facDivision = factory.Find(f => f.ID == cboFactory.SelectedValue.ToString()).CodeType;

                    UtilClass.ComboBinding(cboWorker, new Service().GetWorker(Convert.ToInt32(facDivision)), "작업자 선택");
                    UtilClass.ComboBinding(cboLine, new Service().GetLineList(Convert.ToInt32(cboFactory.SelectedValue)), "공정 선택");

                    if (workerInfo != null)
                    {
                        cboLine.SelectedValue = workerInfo.LineID.ToString();
                        //cboLine.SelectedIndex = ((List<ComboItemVO>)cboLine.DataSource).FindIndex(k => k.ID == workerInfo.LineID.ToString());
                        workerInfo = null;
                    }
                }
                else
                {
                    List<ComboItemVO> list = null;
                    UtilClass.ComboBinding(cboLine, list, "공장을 먼저 선택해주세요");
                    UtilClass.ComboBinding(cboWorker, list, "공장을 먼저 선택해주세요");
                }
            }
            catch (Exception ex)
            {
                Program.Log.WriteError(ex.Message, ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 로그인 화면 Dragable
        private void LoginPOP_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void LoginPOP_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
        #endregion

        private void CheckUpdate()
        {
            UpdateCheckInfo info = null;

            if (!ApplicationDeployment.IsNetworkDeployed)  // 로컬실행
            {
                Program.Log.WriteInfo("배포된 버젼이 아닙니다.");
            }
            else
            {
                ApplicationDeployment AppDeploy = ApplicationDeployment.CurrentDeployment;

                info = AppDeploy.CheckForDetailedUpdate();

                if (info.UpdateAvailable)
                {
                    bool doUpdate = true;

                    if (doUpdate)
                    {
                        AppDeploy.Update();
                        MessageBox.Show("최신버젼의 업데이트가 있습니다.\n업데이트 적용을 위해 프로그램을 재시작합니다.");
                        this.Close();
                        Application.Restart();
                    }
                }
            }
        }
    }
}
