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
using Team2_VO;

namespace Team2_ERP
{
    /// <summary>
    /// 비밀번호 변경 폼
    /// </summary>
    public partial class ChangePwd : Form
    {
        #region 전역변수
        LoginVO loginvo = new LoginVO();
        /// <summary>
        /// 로그인정보를 갖는 VO 프로퍼티
        /// </summary>
        public LoginVO LoginVO { get => loginvo; set => loginvo = value; }
        #endregion

        #region 폼관련
        /// <summary>
        /// 로그인정보를 갖는 생성자
        /// </summary>
        /// <param name="info"></param>
        public ChangePwd(LoginVO info)
        {
            InitializeComponent();
            loginvo = info;
        }
        #endregion

        #region 이벤트 관련
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPrevPwd.TextLength > 0 && txtNewPwd.TextLength > 0 && txtNewPwd2.TextLength > 0&&errorProvider1.GetError(txtNewPwd2)==string.Empty) //모든항목이 입력이 되면
            {
                try
                {
                    LoginService service = new LoginService();
                    loginvo.Employee_PWD = txtPrevPwd.Text;
                    if(service.ChangePwd(loginvo, txtNewPwd.Text)) // 입력한 비밀번호 유효성검사 성공시
                    {
                        MessageBox.Show(Resources.PwdSucess, Resources.MsgBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else // 유효성검사 실패시
                    {
                        MessageBox.Show(Resources.PwdFail, Resources.MsgBoxTitleFail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ActiveControl = txtPrevPwd;
                        txtPrevPwd.SelectAll();
                    }
                }
                catch (Exception err)
                {
                    Log.WriteError(err.Message,err);
                }
            }
            else //모든항목이 입력되지 않았으면
            {
                if (txtPrevPwd.TextLength < 1) //이전 비밀번호가 입력되지않았으면
                {
                    MessageBox.Show(Resources.PwdNoInsertPrev, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtPrevPwd;
                    txtPrevPwd.SelectAll();
                }
                else if (txtNewPwd.TextLength < 1) // 신규 비밀번호가 입력되지 않았으면
                {
                    MessageBox.Show(Resources.PwdNoInsertNew, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd;
                    txtNewPwd.SelectAll();
                }
                else if (txtNewPwd2.TextLength < 1) // 신규 비밀번호 확인이 입력되지 않으면
                {
                    MessageBox.Show(Resources.PwdNoInsertValid, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd2;
                    txtNewPwd2.SelectAll();
                }
                else if (errorProvider1.GetError(txtNewPwd2) != string.Empty)
                {
                    MessageBox.Show(Resources.PwdNewNotCorrect, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd2;
                    txtNewPwd2.SelectAll();
                }
            }
        }

        /// <summary>
        /// 유효성 검사 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNewPwd2_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPwd2.TextLength == 0) // 길이가 0이라면
            {
                errorProvider1.SetError(txtNewPwd2, ""); //에러해제
            }
            else if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim()) // 신규비밀번호와 신규비밀번호확인이 같지않으면
            {
                errorProvider1.SetError(txtNewPwd2, Resources.PwdErrorValid); //에러설정
                txtNewPwd2.Focus();
                txtNewPwd2.SelectAll();
            }
            else
            {
                errorProvider1.SetError(txtNewPwd2, ""); //에러해제
            }
        }

        /// <summary>
        /// 키보드 입력 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNewPwd2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //엔터클릭시
            {
                btnOK.PerformClick(); // 확인버튼 클릭
            }
        }
        #endregion
    }
}
