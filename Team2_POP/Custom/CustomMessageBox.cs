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
    public partial class CustomMessageBox : Form
    {

        static string buttonText = "확인";
        static bool buttonCancelVisible = false;

        static string headerText;
        static string bodyText;

        static CustomMessageBox frm = null;
        static MessageBoxIcon option;

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {            
            ImageList list = new ImageList();
            list.Images.Add(Properties.Resources.Img_Close);

            list.ImageSize = btnExit.Size;
            btnExit.Image = list.Images[0];

            lblHeader.Text = headerText;
            lblMessage.Text = bodyText;

            btnCancel.Visible = buttonCancelVisible;
            btnOK.Text = buttonText;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            switch (option)
            {
                // DB에서 에러났을 경우
                case MessageBoxIcon.Error:
                    pictureBox1.Image = Properties.Resources.Img_Error;
                    break;
                // 유효성검사에서 실패한 경우
                case MessageBoxIcon.Warning:
                    pictureBox1.Image = Properties.Resources.Img_Warning;
                    break;
                // 정상적으로 성공했을 경우
                case MessageBoxIcon.Information:
                    pictureBox1.Image = Properties.Resources.Img_Information;
                    break;
                case MessageBoxIcon.Question:
                    pictureBox1.Image = Properties.Resources.Img_Success;
                    break;
                default:
                    pictureBox1.Image = Properties.Resources.Img_Information;
                    break;
            }
        }

        /// <summary>
        /// Error : DB에러 Warning : 유효성검사 실패 Information : 정보 Question : 성공 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="msg"></param>
        /// <param name="options"></param>
        public static DialogResult ShowDialog(string header, string msg, MessageBoxIcon iconOption,
            MessageBoxButtons btnOption = MessageBoxButtons.OK)
        {
            headerText = header;
            bodyText = msg;
            option = iconOption;
            
            if(btnOption == MessageBoxButtons.OKCancel)
            {
                buttonText = "예";
                buttonCancelVisible = true;
            }
            frm = new CustomMessageBox();
            frm.ShowDialog();

            return frm.DialogResult;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;            
        }
    }
}
