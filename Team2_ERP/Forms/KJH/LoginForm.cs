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

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }


        private void button3_Click(object sender, EventArgs e)
        {
          
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
            SearchedInfoVO info = new SearchedInfoVO();
            SearchForm frm = new SearchForm(info);
            frm.Mode = SearchUserControl.Mode.Employee;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                info = frm.info;
                txtEmpID.Text = info.ID.ToString();
                txtEmpName.Text = info.Name.ToString();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            this.Hide();
            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void btnPwdChange_Click(object sender, EventArgs e)
        {
            ChangePwd frm = new ChangePwd();
            frm.Show();
        }
    }
}
