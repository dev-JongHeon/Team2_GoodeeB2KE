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

namespace Team2_ERP
{
    public partial class LoginForm : Form
    {
        #region 전역변수
        private Point mousePoint;
        SearchedInfoVO info = new SearchedInfoVO();
        LoginVO logininfo = new LoginVO();
        LoginService service = new LoginService();
        #endregion

        #region 폼 관련
        /// <summary>
        /// 생성자
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 로그인폼 누르면 현재위치저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// 마우스 누르고 이동시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        /// <summary>
        /// 세션에 로그인정보 저장
        /// </summary>
        private void SetSession()
        {
            Session.Employee_ID = logininfo.Employee_ID;
            Session.Employee_Name = logininfo.Employee_Name;
            Session.Employee_IsAdmin = logininfo.Employee_IsAdmin;
            Session.Employee_Depart = logininfo.Employee_Depart;
            Session.Auth = logininfo.Auth;
        }
        #endregion

        #region 버튼관련
        /// <summary>
        /// 돋보기아이콘 클릭시 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(info);
            frm.Mode = SearchUserControl.Mode.Employee;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                info = frm.info;
                txtEmpID.Text = info.ID.ToString();
                txtEmpName.Text = info.Name.ToString();
                txtEmpPwd.Clear();
                this.ActiveControl = txtEmpPwd;
            }

        }

        /// <summary>
        /// 취소버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 로그인 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmpID.TextLength > 0&&txtEmpName.TextLength>0&&txtEmpPwd.TextLength>0)
            {
                try
                {
                    LoginService service = new LoginService();
                    LoginVO user = service.DoLogin(int.Parse(txtEmpID.Text), txtEmpPwd.Text);
                    if (user != null)
                    {
                        logininfo = user;
                        SetSession();
                        MainForm frm = new MainForm(logininfo);
                        this.Hide();
                        if (frm.ShowDialog() == DialogResult.Cancel)
                        {
                            logininfo = frm.Logininfo;
                            if (!logininfo.IsLogout)
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Show();
                                txtEmpID.Text = logininfo.Employee_ID.ToString("0000");
                                txtEmpName.Text = logininfo.Employee_Name;
                                txtEmpPwd.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.LoginPwdError, Properties.Resources.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmpPwd.Focus();
                        txtEmpPwd.SelectAll();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                if (txtEmpID.TextLength < 1)
                {
                    MessageBox.Show(Properties.Resources.LoginEmpIDError, Properties.Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();
                }
                else if (txtEmpName.TextLength < 1)
                {
                    MessageBox.Show(Properties.Resources.LoginEmpNameError, Properties.Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();
                }
                else if (txtEmpPwd.TextLength == 0)
                {
                    MessageBox.Show(Properties.Resources.LoginPwdInputNone, Properties.Resources.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpPwd.Focus();
                    txtEmpPwd.SelectAll();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.LoginPwdError, Properties.Resources.MsgBoxTitleError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpPwd.Focus();
                    txtEmpPwd.SelectAll();
                }
            }
        }

        /// <summary>
        /// 암호변경 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPwdChange_Click(object sender, EventArgs e)
        {
            if (txtEmpID.TextLength > 0 && txtEmpName.TextLength > 0)
            {
                logininfo.Employee_ID = int.Parse(txtEmpID.Text);
                logininfo.Employee_PWD = txtEmpPwd.Text;
                ChangePwd frm = new ChangePwd(logininfo);
                frm.ShowDialog();
                this.ActiveControl = txtEmpPwd;
            }
            else
            {
                if (txtEmpID.TextLength < 1)
                {
                    MessageBox.Show(Properties.Resources.LoginEmpIDError, Properties.Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();

                }
                else if (txtEmpName.TextLength < 1)
                {
                    MessageBox.Show(Properties.Resources.LoginEmpNameError, Properties.Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();
                }
            }
        }
        #endregion

        #region KeyPress클릭
        /// <summary>
        /// 암호텍스트 상자에서 엔터 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmpPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.PerformClick();
            }
        }

        /// <summary>
        /// 사원번호 텍스트박스 백스페이스만 가능하게
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back))) 
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 사원명 텍스트박스 백스페이스만 가능하게
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        #endregion

        private void txtEmpID_Click(object sender, EventArgs e)
        {
            txtEmpID.SelectAll();
        }

        private void txtEmpName_Click(object sender, EventArgs e)
        {
            txtEmpName.SelectAll();
        }

        private void txtEmpPwd_Click(object sender, EventArgs e)
        {
            txtEmpPwd.SelectAll();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                service.OrderProcess();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
    }
}
