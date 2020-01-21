﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        int tindex;
        bool isLogout = false;
        LoginVO logininfo = new LoginVO();
        public LoginVO Logininfo { get => logininfo; set => logininfo = value; }
        public string NoticeMessage { get => lblNoticeMsg.Text; set => lblNoticeMsg.Text = value; }
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
            lblUserName.Text = Session.Employee_ID.ToString() + " " + Session.Employee_Name;
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
                if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //SettingTreeView();
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            foreach (Panel p in mpanel.Controls)
            {
                if (p.Tag.ToString() != string.Empty)
                {
                    p.Visible = false;
                }
            }
            OpenTabForm<MainTab>("메인화면");
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
                        tmp.Visible = true;
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
                    if (tmp.Tag.ToString() == string.Empty)
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
            if (e.Node.Name == "Category")
            {
                OpenBaseForm<Category>("카테고리관리");
            }
            else if (e.Node.Name == "UserAuth")
            {
                MessageBox.Show(e.Node.Tag.ToString());
            }
            else if(e.Node.Name== "Resource")
            {
                OpenBaseForm<Resource>("원자재관리");
            }
        }

        private void SettingTreeView()
        {
            foreach (TreeView item in mpanel.Controls)
            {
                TreeView tmp = item;
                foreach (TreeNode i in tmp.Nodes)
                {
                    if (i.Name == "UserAuth")
                    {
                        i.Tag = "테스트";
                    }
                }
            }
        }
        #endregion

        #region MDI 자식폼 열기
        private void OpenBaseForm<T>(string name) where T : BaseForm, new()
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
                else if (Child is Base1Dgv)
                {
                    Base1Dgv tmp = (Base1Dgv)Child;
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
            e.Graphics.FillRectangle(fillbrush, background);
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

        private void 인쇄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (M_Print != null)
                M_Print.Invoke(this, null);
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form Child in Application.OpenForms)
            {
                if (Child is Category)
                {
                    Category tmp = (Category)Child;
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
            }
            else
            {
                tabControl1.SelectedIndex = tindex;

            }
            tabControl1.Invalidate();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            isLogout = true;
            Logininfo.IsLogout = isLogout;
            this.Close();
        }
        #endregion





    }
}
