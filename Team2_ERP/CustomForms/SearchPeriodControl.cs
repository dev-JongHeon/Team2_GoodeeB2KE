using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using Team2_ERP.Properties;

namespace Team2_ERP
{
    /// <summary>
    /// 공통기간검색을 위한 UserControl
    /// </summary>
    public partial class SearchPeriodControl : UserControl
    {
        #region 전역변수
        CalendarForm frm;//캘린더폼
        
        /// <summary>
        /// 검색명 프로퍼티
        /// </summary>
        public string Labelname
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        /// <summary>
        /// 시작날짜 TextBox 프로퍼티
        /// </summary>
        public MaskedTextBox Startdate
        {
            set { txtStart = value; }
            get { return txtStart; }
        }

        /// <summary>
        /// 종료날짜 TextBox 프로퍼티
        /// </summary>
        public MaskedTextBox Enddate
        {
            set { txtEnd = value; }
            get { return txtEnd; }
        }

        /// <summary>
        /// 시작날짜 프로퍼티
        /// </summary>
        public DateTime sdate { set => txtStart.Text = value.ToString(); }

        /// <summary>
        /// 종료날짜 프로퍼티
        /// </summary>
        public DateTime edate { set => txtEnd.Text = value.ToString(); }
        #endregion

        #region 폼관련
        /// <summary>
        /// 생성자
        /// </summary>
        public SearchPeriodControl()
        {
            InitializeComponent();

        }
        #endregion

        #region 이벤트 관련
        /// <summary>
        /// 검색버튼 클릭 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStart.Tag != null && txtEnd.Tag != null)
            {
                DateTime start;
                DateTime end;
                if (!DateTime.TryParse(txtEnd.Tag.ToString(), out end) || !DateTime.TryParse(txtStart.Tag.ToString(), out start)) // 유효하지않은 날짜형식이 입력되면
                {
                    frm = new CalendarForm(); //기본으로 달력폼을 연다.
                }
                else // 유효한 날짜형식이면
                {
                    frm = new CalendarForm(start, end); //시작날짜와 종료날짜를 전달해 달력폼을 연다.
                }
            }
            else
            {
                frm = new CalendarForm();
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                sdate = frm.Startdate;
                txtStart.Tag = frm.Startdate;
                edate = frm.Enddate;
                txtEnd.Tag = frm.Enddate;
            }
        }

        /// <summary>
        /// 종료날짜 TextBox 클릭 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnd_Click(object sender, EventArgs e)
        {
            txtEnd.SelectAll(); //전부 선택
        }

        /// <summary>
        /// 시작날짜 TextBox 클릭 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStart_Click(object sender, EventArgs e)
        {
            txtStart.SelectAll(); //전부 선택
        }

        /// <summary>
        /// 시작날짜 Text값 변경 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStart_TextChanged(object sender, EventArgs e)
        {
            if (txtStart.Text == "    -  -") // 비어있다면
            {
                txtStart.Tag = null; // Tag = null
            }
            else // 값이 있다면
            {
                txtStart.Tag = txtStart.Text; // Tag=값
            }
        }

        /// <summary>
        /// 종료날짜 Text값 변경 시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtEnd.Text == "    -  -") // 비어있다면
            {
                txtEnd.Tag = null; // Tag=null
            }
            else //값이 있다면
            {
                txtEnd.Tag = txtEnd.Text; // Tag=값
            }

        }

        /// <summary>
        /// 키보드 입력시 이벤트 (ReadOnly를 사용함으로써 사용안함)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == Convert.ToChar(Keys.Back))) // 백스페이스만 입력가능
            {
                e.Handled = true;
                txtStart.Tag = null;
                txtEnd.Tag = null;
            }
        }
        #endregion
    }
}
