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
    public partial class ChangePwd : Form
    {
        LoginVO loginvo = new LoginVO();
        public ChangePwd(LoginVO info)
        {
            InitializeComponent();
            loginvo = info;
        }

        public LoginVO LoginVO { get => loginvo; set => loginvo = value; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPrevPwd.TextLength > 0 && txtNewPwd.TextLength > 0 && txtNewPwd2.TextLength > 0)
            {
                try
                {
                    LoginService service = new LoginService();
                    loginvo.Employee_PWD = txtPrevPwd.Text;
                    if(service.ChangePwd(loginvo, txtNewPwd.Text))
                    {
                        MessageBox.Show(Resources.PwdSucess, Resources.MsgBoxTitleSuccess, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Resources.PwdFail, Resources.MsgBoxTitleFail, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.ActiveControl = txtPrevPwd;
                        txtPrevPwd.SelectAll();
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                if (txtPrevPwd.TextLength < 1)
                {
                    MessageBox.Show(Resources.PwdNoInsertPrev, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtPrevPwd;
                    txtPrevPwd.SelectAll();
                }
                else if (txtNewPwd.TextLength < 1)
                {
                    MessageBox.Show(Resources.PwdNoInsertNew, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd;
                    txtNewPwd.SelectAll();
                }
                else if (txtNewPwd2.TextLength < 1)
                {
                    MessageBox.Show(Resources.PwdNoInsertValid, Resources.MsgBoxTitleWarn, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd2;
                    txtNewPwd2.SelectAll();
                }
            }
        }

        private void txtNewPwd2_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPwd2.TextLength == 0)
            {
                errorProvider1.SetError(txtNewPwd2, "");
            }
            else if (txtNewPwd.Text.Trim() != txtNewPwd2.Text.Trim())
            {
                errorProvider1.SetError(txtNewPwd2, Resources.PwdErrorValid);
                txtNewPwd2.Focus();
                txtNewPwd2.SelectAll();
            }
            else
            {
                errorProvider1.SetError(txtNewPwd2, "");
            }
        }
    }
}
