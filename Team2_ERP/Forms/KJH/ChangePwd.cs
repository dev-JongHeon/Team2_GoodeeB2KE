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
                        MessageBox.Show("성공적으로 암호가 변경되었습니다.", "변경완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("이전 암호가 정확하지 않습니다.", "변경실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("이전 암호를 입력하지 않으셨습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtPrevPwd;
                    txtPrevPwd.SelectAll();
                }
                else if (txtNewPwd.TextLength < 1)
                {
                    MessageBox.Show("새로운 암호를 입력하지 않으셨습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.ActiveControl = txtNewPwd;
                    txtNewPwd.SelectAll();
                }
                else if (txtNewPwd2.TextLength < 1)
                {
                    MessageBox.Show("변경할 새로운 암호를 입력하지 않으셨습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                errorProvider1.SetError(txtNewPwd2, "입력한 비밀번호와 다릅니다.");
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
