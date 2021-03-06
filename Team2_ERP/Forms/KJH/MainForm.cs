﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_VO;

namespace Team2_ERP
{
    public partial class MainForm : Form
    {
        #region 전역변수
        public EventHandler M_Refresh;
        public EventHandler M_New;
        public EventHandler M_Modify;
        public EventHandler M_Delete;
        public EventHandler M_Search;
        public EventHandler M_Print;
        public EventHandler M_Close;
        public EventHandler M_Print_Excel;
        public EventHandler M_Print_Printer;
        int tindex;
        bool isLogout = false;
        
        LoginVO logininfo = new LoginVO();

        public LoginVO Logininfo { get => logininfo; set => logininfo = value; }
        public string NoticeMessage { get => lblNoticeMsg.Text; set => lblNoticeMsg.Text = value; }

        public static Dictionary<string, string> menulist = new Dictionary<string, string>
        {
            {"UserAuth","사용자권한설정" },
            {"Work","작업지시현황" },
            {"Produce","생산실적현황" },
            {"DowntimeType","비가동유형" },
            {"Downtime","비가동현황" },
            {"DefectiveType","불량유형" },
            {"DefectiveHandle","불량처리유형" },
            {"Defective","불량처리현황" },
            {"StockStatus","재고현황" },
            {"InOutList_MaterialWarehouse","자재수불현황" },
            {"InOutList_SemiProductWarehouse","반제품수불현황" },
            {"BaljuList","발주현황" },
            {"BaljuList_Completed","발주완료현황" },
            {"OrderMainForm","주문현황" },
            {"OrderCompleteForm","주문처리완료현황" },
            {"ShipmentMainForm","출하현황" },
            {"ShipmentCompleteForm","출하완료현황" },
            {"SalesMainForm","매출현황" },
            {"Department","부서관리" },
            {"Employees","사원관리" },
            {"Company","거래처관리" },
            {"Customer","고객관리" },
            {"Category","카테고리관리" },
            {"Factory","공장&공정관리" },
            {"Resource","원자재관리" },
            {"Warehouse","창고관리" },
            {"BOM","BOM관리" },
        };
        #endregion

        #region 메인폼
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(LoginVO info)
        {
            InitializeComponent();
            Logininfo = info;
            lblUserName.Text = Session.Employee_ID.ToString("0000") + " " + Session.Employee_Name;
            lblUserDept.Text = Session.Employee_Depart;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            FillMenu();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogout)
            {
                if (MessageBox.Show(Resources.ProgramExit, Resources.MsgBoxTitleExit, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!logininfo.Employee_IsAdmin)
            {
                menu_System.Visible = false;
                panel_System.Visible = false;
            }
            SettingAuth();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            foreach (Panel p in mpanel.Controls)
            {
                if (p.Tag.ToString() != string.Empty)
                {
                    p.Visible = false;
                }
            }
            OpenTabForm<MainTab>("메인화면");
            NoticeMessage = Resources.Welcome;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                btnLogOut.PerformClick();
            }
        }
        #endregion

        #region 좌측 메뉴
        private void button1_Click(object sender, EventArgs e)
        {
            panel_Menu.Visible = !panel_Menu.Visible;
            if (panel_Menu.Visible)
            {
                button1.Location = new Point(splitter1.Location.X, button1.Location.Y);
                button1.Image = Resources.left_arrow__2_;
            }
            else
            {
                button1.Image = Resources.right_arrow;
                button1.Location = new Point(0, button1.Location.Y);
            }

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            button1.Location = new Point(splitter1.Location.X, button1.Location.Y);
        }



        private void label_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            string tag = lbl.Tag.ToString();
            string ptag = string.Empty;
            string lname = string.Empty;
            switch (tag)
            {
                case "system":
                    ptag = "panel_System";
                    lname = "lblSystem";
                    break;
                case "production":
                    ptag = "panel_Production";
                    lname = "lblProduction";
                    break;
                case "stock":
                    ptag = "panel_Stock";
                    lname = "lblStock";
                    break;
                case "sales":
                    ptag = "panel_Sales";
                    lname = "lblSales";
                    break;
                case "info":
                    ptag = "panel_Info";
                    lname = "lblInfo";
                    break;
                default:
                    break;
            }
            SelectMenu(ptag, lname);
            FillMenu();
        }

        private void SelectMenu(string ptag, string lname)
        {
            foreach (var item in mpanel.Controls)
            {
                if (item is Panel)
                {
                    Panel tmp = (Panel)item;
                    if (tmp.Tag.ToString() != string.Empty && tmp.Tag.ToString() == ptag)
                    {
                        tmp.Height = 100;
                        tmp.Visible = true;

                    }
                    else if (tmp.Tag.ToString() == string.Empty)
                    {
                        if (tmp.Name == "menu_System" && !logininfo.Employee_IsAdmin)
                        {
                            tmp.Visible = false;
                        }
                        else
                        {
                            tmp.Visible = true;
                        }
                        foreach (var pa in tmp.Controls)
                        {
                            if (pa is Panel)
                            {
                                Panel p = (Panel)pa;
                                if (p.Tag.ToString() == "labelpanel")
                                {
                                    foreach (var la in p.Controls)
                                    {
                                        if (la is Label)
                                        {
                                            Label l = (Label)la;
                                            if (l.Name == lname)
                                            {
                                                //tmp.BackColor = Color.FromArgb(193, 210, 232);
                                                tmp.BackColor = Color.FromArgb(187, 209, 232);
                                                l.Image = Resources.down_16x16;
                                            }
                                            else
                                            {
                                                tmp.BackColor = Color.FromArgb(236, 236, 236);
                                                l.Image = Resources.Prev_16x16;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        tmp.Height = 0;
                        tmp.Visible = false;
                    }
                }
            }
        }

        public void FillMenu()
        {
            int sumheight = 0;
            foreach (var item in mpanel.Controls)
            {
                if (item is Panel)
                {
                    Panel tmp = (Panel)item;
                    if (tmp.Tag.ToString() == string.Empty && tmp.Visible)
                    {
                        sumheight += tmp.Height;
                    }
                }
            }
            foreach (var item in mpanel.Controls)
            {
                if (item is Panel)
                {
                    Panel tmp = (Panel)item;
                    if (tmp.Tag.ToString() != string.Empty && tmp.Visible)
                    {
                        tmp.Height = mpanel.Height - sumheight;
                    }
                }
            }
        }

        private void menu_System_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            string name = panel.Name.ToString();
            string ptag = string.Empty;
            string lname = string.Empty;
            switch (name)
            {
                case "menu_System":
                    ptag = "panel_System";
                    lname = "lblSystem";
                    break;
                case "menu_Production":
                    ptag = "panel_Production";
                    lname = "lblProduction";
                    break;
                case "menu_Stock":
                    ptag = "panel_Stock";
                    lname = "lblStock";
                    break;
                case "menu_Sales":
                    ptag = "panel_Sales";
                    lname = "lblSales";
                    break;
                case "menu_Info":
                    ptag = "panel_Info";
                    lname = "lblInfo";
                    break;
                default:
                    break;
            }
            SelectMenu(ptag, lname);
            FillMenu();
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null&&e.Node.IsSelected)
            {
                OpenForm(e);
            }
        }

        private void OpenForm(TreeNodeMouseClickEventArgs e)
        {
            Type type = Type.GetType($"Team2_ERP.{e.Node.Name},{Assembly.GetExecutingAssembly().GetName().Name}");
            var info = type.GetTypeInfo();
            object obj = GetInstance(type);
            if (obj != null)
            {
                if (info.BaseType.Name == "BaseForm")
                {
                    OpenBaseForm(e.Node.Text, e, (BaseForm)obj);
                }
                else if (info.BaseType.Name == "Base1Dgv")
                {
                    OpenBase1DgvForm(e.Node.Text, e, (Base1Dgv)obj);
                }
                else
                {
                    OpenBase2DgvForm(e.Node.Text, e, (Base2Dgv)obj);
                }
            }
        }

        public object GetInstance(Type type)
        {
            if (type != null)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                return null;
            }
        }

        private void SettingAuth()
        {
            string[] authlist = Session.Auth.Split(',');
            List<TreeNode> mlist = new List<TreeNode>();
            GetMenuNodes(mlist, treeView_System.Nodes);
            GetMenuNodes(mlist, treeView_Production.Nodes);
            GetMenuNodes(mlist, treeView_Stock.Nodes);
            GetMenuNodes(mlist, treeView_Sales.Nodes);
            GetMenuNodes(mlist, treeView_Info.Nodes);
            for (int i = 0; i < mlist.Count; i++)
            {
                mlist[i].Tag = authlist[i];
            }
        }

        private void GetMenuNodes(List<TreeNode> mlist, TreeNodeCollection node)
        {
            foreach (TreeNode item in node)
            {
                foreach (TreeNode item2 in item.Nodes)
                {
                    foreach (string frmname in menulist.Keys)
                    {
                        if (item2.Name == frmname)
                        {
                            mlist.Add(item2);
                        }
                    }
                }
            }
        }
        #endregion

        #region MDI 자식폼 열기
        private void OpenBaseForm<T>(string name, TreeNodeMouseClickEventArgs e) where T : BaseForm, new()
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child.GetType() == typeof(T))
                {
                    Child.Activate();
                    return;
                }
            }
            T frm = new T();
            frm.Auth = e.Node.Tag.ToString();
            frm.Text = name;
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.TabCtrl = tabControl1;
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = frm.Text;
            tp.Show();
            frm.TabPag = tp;
            tabControl1.SelectedTab = tp;
            frm.FormName = name;
            frm.Show();
        }

        private void OpenTabForm<T>(string name) where T : TabForm, new()
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child.GetType() == typeof(T))
                {
                    Child.Activate();
                    return;
                }
            }
            T frm = new T();
            frm.Text = name;
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.TabCtrl = tabControl1;
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = frm.Text;
            tp.Show();
            frm.TabPag = tp;
            tabControl1.SelectedTab = tp;
            frm.Show();
        }


        private void OpenBaseForm<T>(string name, TreeNodeMouseClickEventArgs e, T a) where T : BaseForm, new()
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child.GetType() == a.GetType())
                {
                    Child.Activate();
                    return;
                }
            }
            T frm = a;
            frm.Auth = e.Node.Tag.ToString();
            frm.Text = name;
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.TabCtrl = tabControl1;
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = frm.Text;
            tp.Show();
            frm.TabPag = tp;
            tabControl1.SelectedTab = tp;
            frm.FormName = name;
            frm.Show();
        }

        private void OpenBase1DgvForm<T>(string name, TreeNodeMouseClickEventArgs e, T a) where T : Base1Dgv, new()
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child.GetType() == a.GetType())
                {
                    Child.Activate();
                    return;
                }
            }
            T frm = a;
            frm.Auth = e.Node.Tag.ToString();
            frm.Text = name;
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.TabCtrl = tabControl1;
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = frm.Text;
            tp.Show();
            frm.TabPag = tp;
            tabControl1.SelectedTab = tp;
            frm.FormName = name;
            frm.Show();
        }
        private void OpenBase2DgvForm<T>(string name, TreeNodeMouseClickEventArgs e, T a) where T : Base2Dgv, new()
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child.GetType() == a.GetType())
                {
                    Child.Activate();
                    return;
                }
            }
            T frm = a;
            frm.Auth = e.Node.Tag.ToString();
            frm.Text = name;
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.TabCtrl = tabControl1;
            TabPage tp = new TabPage();
            tp.Parent = tabControl1;
            tp.Text = frm.Text;
            tp.Show();
            frm.TabPag = tp;
            tabControl1.SelectedTab = tp;
            frm.FormName = name;
            frm.Show();
        }
        #endregion

        #region 탭컨트롤
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Form Child in Application.OpenForms) // 열려있는 전체 자식폼들 중
            {
                if (Child is MainTab) // BOM관리화면
                {
                    MainTab tmp = (MainTab)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Select();
                        break;
                    }
                }
                else if (Child is BaseForm)
                {
                    BaseForm tmp = (BaseForm)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Select();
                        break;
                    }
                }
                else if (Child is Base1Dgv)
                {
                    Base1Dgv tmp = (Base1Dgv)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Select();
                        break;
                    }
                }
                else if (Child is Base2Dgv)
                {
                    Base2Dgv tmp = (Base2Dgv)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Select();
                        break;
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl1.TabPages[e.Index];
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;  //optional

            // This is the rectangle to draw "over" the tabpage title
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);
            // This is the default colour to use for the non-selected tabs
            SolidBrush sb = new SolidBrush(Color.FromArgb(42, 76, 105));
            SolidBrush co = new SolidBrush(Color.White);
            // This changes the colour if we're trying to draw the selected tabpage
            if (tabControl1.SelectedIndex == e.Index)
            {
                co.Color = Color.DarkBlue;
                var bshBack = new LinearGradientBrush(
                    e.Bounds,
                    Color.White,
                    Color.LightSteelBlue,
                    LinearGradientMode.ForwardDiagonal);
                g.FillRectangle(bshBack, e.Bounds);
            }
            else
            {
                g.FillRectangle(sb, e.Bounds);

            }
            //Remember to redraw the text - I'm always using black for title text
            g.DrawString(tp.Text, new Font(tabControl1.Font, FontStyle.Bold), co, headerRect, sf);

            SolidBrush fillbrush = new SolidBrush(Color.FromArgb(42, 76, 105));
            Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
            Rectangle background = new Rectangle();
            background.Location = new Point(lasttabrect.Right + 10, 0);

            //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
            background.Size = new Size(tabControl1.Right - background.Left, lasttabrect.Height + 1);
            g.FillRectangle(fillbrush, background);

        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left) // 마우스 왼쪽 클릭시
            {
                TabControl tc = (TabControl)sender;
                int hover_index = this.getHoverTabIndex(tc);
                if (hover_index >= 0)
                {
                    tc.Tag = tc.TabPages[hover_index];
                }
                tindex = tabControl1.SelectedIndex;
            }
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }
            return -1;
        }

        private void tabControl1_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }

        private void tabControl1_MouseUp(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
            Point p = this.tabControl1.PointToClient(Cursor.Position);
            for (int i = 0; i < this.tabControl1.TabCount; i++)
            {
                Rectangle r = this.tabControl1.GetTabRect(i);
                if (r.Contains(p))
                {
                    tindex = i;
                    this.tabControl1.SelectedIndex = i; // i is the index of tab under cursor
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (tabControl1.SelectedTab.Text != "메인화면")
                {
                    contextMenuStrip1.Show(tabControl1, e.Location);
                }
            }
        }

        private void tabControl1_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }

        private void swapTabPages(TabControl tc, TabPage dragTab, TabPage hoverTab)
        {
            int index_src = tc.TabPages.IndexOf(dragTab);
            int index_dst = tc.TabPages.IndexOf(hoverTab);
            tc.TabPages[index_dst] = dragTab;
            tc.TabPages[index_src] = hoverTab;
            tc.Refresh();
        }

        private void 닫기ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseTab();
        }

        private void 모든창닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form Child in this.MdiChildren)
            {
                if (Child.Text != "메인화면")
                {
                    Child.Close();
                }

            }
            tabControl1.Invalidate();
        }
        #endregion

        #region 메뉴스트립 버튼이벤트
        private void 새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (M_Refresh != null)
                M_Refresh.Invoke(this, null);
        }
        private void 신규ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_New != null)
                M_New.Invoke(this, null);
        }

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Modify != null)
                M_Modify.Invoke(this, null);
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Delete != null)
                M_Delete.Invoke(this, null);
        }

        private void 검색toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Search != null)
                M_Search.Invoke(this, null);
        }


        private void 엑셀로내보내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Print_Excel != null)
                M_Print_Excel.Invoke(this, null);
        }

        private void 프린트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Print != null)
                M_Print.Invoke(this, null);
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseTab();
        }


        private void CloseTab()
        {
            tindex = tabControl1.SelectedIndex;
            foreach (Form Child in Application.OpenForms)
            {
                if (Child is BaseForm)
                {
                    BaseForm tmp = (BaseForm)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Close();
                        break;
                    }
                }
                else if (Child is Base1Dgv)
                {
                    Base1Dgv tmp = (Base1Dgv)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Close();
                        break;
                    }
                }
                else if (Child is Base2Dgv)
                {
                    Base2Dgv tmp = (Base2Dgv)Child;
                    if (tmp.TabPag == tabControl1.SelectedTab)
                    {
                        tmp.Close();
                        break;
                    }
                }
            }
            if (tindex != 0)
            {
                tabControl1.SelectedIndex = tindex - 1;
                tabControl1.Invalidate();
            }
            if (tindex == 0 && tabControl1.TabCount == 1)
            {
                this.Close();
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            isLogout = true;
            Logininfo.IsLogout = isLogout;
            this.Close();
        }

        #endregion

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if ((this.Location.X + this.Width >= Screen.PrimaryScreen.WorkingArea.Width)||(this.Location.X< Screen.PrimaryScreen.WorkingArea.X))
                tabControl1.Invalidate();

            if (this.Location.Y + this.Height >= Screen.PrimaryScreen.WorkingArea.Height)
                tabControl1.Invalidate();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("http://gdb2keshop.azurewebsites.net/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
