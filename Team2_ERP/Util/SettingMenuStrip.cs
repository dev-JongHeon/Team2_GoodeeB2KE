using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    /// <summary>
    /// MenuStrip이벤트를 등록하는 화면 입니다.
    /// <br></br> 사용방법
    /// <br></br> Activated ==> SetMenu(this, 새로고침 메서드, 신규 메서드, 수정 메서드, 삭제 메서드, 검색 메서드, 프린트 메서드, 닫기 메서드);
    /// <br></br> Deactivated ==> UnSetMenu(this, 새로고침 메서드, 신규 메서드, 수정 메서드, 삭제 메서드, 검색 메서드, 프린트 메서드, 닫기 메서드);
    /// </summary>
    public class SettingMenuStrip
    {

        /// <summary>
        /// e_new => 
        /// </summary>        
        public void SetMenu<T>(T frm,
            Action<object, EventArgs> e_refresh,
            Action<object, EventArgs> e_new,
            Action<object, EventArgs> e_modify,
            Action<object, EventArgs> e_delete,
            Action<object, EventArgs> e_search,
            Action<object, EventArgs> e_print,
            Action<object, EventArgs> e_excel) where T : BaseForm, new()
        {
            MainForm m = (MainForm)frm.MdiParent;
            if (e_refresh != null)
            {
                m.M_Refresh += new EventHandler(e_refresh);
            }
            if (e_new != null)
            {
                m.M_New += new EventHandler(e_new);
            }
            if (e_modify != null)
            {
                m.M_Modify += new EventHandler(e_modify);
            }
            if (e_delete != null)
            {
                m.M_Delete += new EventHandler(e_delete);
            }
            if (e_search != null)
            {
                m.M_Search += new EventHandler(e_search);
            }
            if (e_print != null)
            {
                m.M_Print += new EventHandler(e_print); 
            }
            if (e_excel != null)
            {
                m.M_Print_Excel += new EventHandler(e_excel);
            }
        }

        public void UnsetMenu<T>(T frm) where T : BaseForm, new()
        {
            MainForm m = (MainForm)frm.MdiParent;

            m.M_Refresh -= m.M_Refresh;
            m.M_New -= m.M_New;
            m.M_Modify -= m.M_Modify;
            m.M_Delete -= m.M_Delete;
            m.M_Search -= m.M_Search;
            m.M_Print -= m.M_Print;
            m.M_Print_Excel -= m.M_Print_Excel;
        }
    }
}
