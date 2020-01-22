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
        private Point mousePoint;
        SearchedInfoVO info = new SearchedInfoVO();
        LoginVO logininfo = new LoginVO();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(info);
            frm.Mode = SearchUserControl.Mode.Employee;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                info = frm.info;
                txtEmpID.Text = info.ID.ToString();
                txtEmpName.Text = info.Name.ToString();
                this.ActiveControl = txtEmpPwd;
                
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmpID.TextLength > 0)
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
                                txtEmpID.Text = logininfo.Employee_ID.ToString();
                                txtEmpName.Text = logininfo.Employee_Name;
                                txtEmpPwd.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("입력한 비밀번호가 잘못되었습니다.", "비밀번호 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                MessageBox.Show("사원번호가 비어있습니다.\n사원을 선택하여주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSearch.PerformClick();
            }
        }

        private void SetSession()
        {
            Session.Employee_ID = logininfo.Employee_ID;
            Session.Employee_Name = logininfo.Employee_Name;
            Session.Employee_IsAdmin = logininfo.Employee_IsAdmin;
            Session.Employee_Depart = logininfo.Employee_Depart;
            Session.Auth = logininfo.Auth;
        }

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
                    MessageBox.Show("사원번호가 비어있습니다.\n사원을 선택하여주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();
                }
                else if (txtEmpName.TextLength < 1)
                {
                    MessageBox.Show("사원명이 비어있습니다.\n사원을 선택하여주세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnSearch.PerformClick();
                }
            }

        }

        private void txtEmpPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back))) 
            {
                e.Handled = true;
            }
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
