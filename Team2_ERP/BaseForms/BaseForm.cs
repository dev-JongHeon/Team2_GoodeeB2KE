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
    /// 기본 베이스폼
    /// </summary>
    public  partial class BaseForm : Form
    {
        public string FormName
        {
            get { return lblFormName.Text; }
            set { lblFormName.Text = value; }
        }

        #region 폼관련
        /// <summary>
        /// 생성자
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
        }       
        #endregion

        #region MDI를위한 것들
        private TabControl tabCtrl; // 탭컨트롤
        private TabPage tabPag; // 탭페이지
        public TabControl TabCtrl { get => tabCtrl; set => tabCtrl = value; } //탭컨트롤 프로퍼티
        public TabPage TabPag { get => tabPag; set => tabPag = value; } //탭페이지 프로퍼티
        public string Auth { get; set; }//권한 프로퍼티
        public string notice { get=> $"{this.Text} 화면입니다.";  } //하단 안내메시지 기본

        /// <summary>
        /// 폼이 활성화될때 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form_Activated(object sender, EventArgs e)
        {
            tabCtrl.SelectedTab = tabPag;
            if (!tabCtrl.Visible)
            {
                tabCtrl.Visible = true;
            }
            new SettingMenuStrip().SetMenu(this, Refresh, New, Modify, Delete, Search, Print, Excel); //메뉴에 이벤트를 세팅
        }
        /// <summary>
        /// 폼이 닫힐때 일어나는 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form_FormClosing(object sender, FormClosingEventArgs e)
        {

            //Destroy the corresponding Tabpage when closing MDI child form
            if (TabPag.Text != "메인화면")
                this.tabPag.Dispose();

            //If no Tabpage left
            if (!tabCtrl.HasChildren)
            {
                tabCtrl.Visible = false;
            }
            new SettingMenuStrip().UnsetMenu(this); // 메뉴버튼에 할당된 이벤트 제거
        }
        #endregion

        #region 가상메서드
        /// <summary>
        /// 새로고침버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Refresh(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 수정버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Modify(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 신규버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void New(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 삭제버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Delete(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 검색버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Search(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 인쇄버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Print(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 엑셀버튼 가상메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Excel(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 권한별로 메뉴보여주는거 설정하는 메서드
        /// </summary>
        /// <param name="auth"></param>
        public void MenuByAuth(string auth)
        {
            if (auth == "1")
            {
                MenuStripONOFF(true);
            }
            else if (auth == "0")
            {
                MenuStripONOFF(false);
            }
        }

        /// <summary>
        /// 메뉴에 보여줄것들 설정하는 메서드
        /// </summary>
        /// <param name="flag"></param>
        public virtual void MenuStripONOFF(bool flag)
        {

        }
        #endregion
    }
}
