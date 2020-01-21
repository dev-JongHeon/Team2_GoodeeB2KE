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
            Action<object, EventArgs> e_print) where T : BaseForm, new()
        {
            MainForm m = (MainForm)frm.MdiParent;

            m.M_Refresh += new EventHandler(e_refresh);
            m.M_New += new EventHandler(e_new);
            m.M_Modify += new EventHandler(e_modify);
            m.M_Delete += new EventHandler(e_delete);
            m.M_Search += new EventHandler(e_search);
            m.M_Print += new EventHandler(e_print);

            foreach (ToolStripMenuItem item in m.menuStrip.Items)
            {
                item.Visible = true;
            }
        }

        public void UnsetMenu<T>(T frm,
            Action<object, EventArgs> e_refresh,
            Action<object, EventArgs> e_new,
            Action<object, EventArgs> e_modify,
            Action<object, EventArgs> e_delete,
            Action<object, EventArgs> e_search,
            Action<object, EventArgs> e_print) where T : BaseForm, new()
        {

            MainForm m = (MainForm)frm.MdiParent;

            m.M_Refresh -= new EventHandler(e_refresh);
            m.M_New -= new EventHandler(e_new);
            m.M_Modify -= new EventHandler(e_modify);
            m.M_Delete -= new EventHandler(e_delete);
            m.M_Search -= new EventHandler(e_search);
            m.M_Print -= new EventHandler(e_print);           
        }
    }
}
