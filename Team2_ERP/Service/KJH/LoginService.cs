using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public class LoginService
    {
        public LoginVO DoLogin(int id, string pwd)
        {
            LoginDAC dac = new LoginDAC();
            return dac.DoLogin(id, pwd);
        }

        public bool ChangePwd(LoginVO login, string newpwd)
        {
            LoginDAC dac = new LoginDAC();
            return dac.ChangePwd(login, newpwd);
        }

        public bool InsertAuth(int id)
        {
            LoginDAC dac = new LoginDAC();
            return dac.InsertAuth(id);
        }

        public bool OrderProcess()
        {
            LoginDAC dac = new LoginDAC();
            return dac.OrderProcess();
        }
    }
}
