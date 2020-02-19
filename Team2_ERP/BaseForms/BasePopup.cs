using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    /// <summary>
    /// 팝업용 베이스폼
    /// </summary>
    public partial class BasePopup : Form
    {
        #region 전역변수
        private Point mousePoint; // 마우스 
        public string Labelname { get => lblName.Text; set => lblName.Text = value; } // 제목라벨이름 프로퍼티
        public Image Titleimg { get => pbxTitle.Image; set => pbxTitle.Image = value; } //제목 아이콘이미지 프로퍼티
        #endregion

        public BasePopup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 닫기버튼 클릭시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 상단 패널 마우스누를때 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Title_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y); // 마우스커서위치 저장
        }

        /// <summary>
        /// 상단 패널 마우스 움직일때 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Title_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) //누른버튼이 왼쪽버튼이면
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y)); //위치 재조정
            }
        }
    }
}
