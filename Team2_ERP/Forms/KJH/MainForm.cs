using System;
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


namespace Team2_ERP
{
    public partial class MainForm : Form
    {
        public EventHandler M_Refresh;
        public EventHandler M_New;
        public EventHandler M_Modify;
        public EventHandler M_Delete;
        public EventHandler M_Search;
        public EventHandler M_Print;
        public EventHandler M_Close;

        public MainForm()
        {
            InitializeComponent();
        }

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
        private void 새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M_Refresh?.Invoke(this, e);

            OpenBaseForm<Defective>("매출현황");
        }
        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            button1.Location = new Point(splitter1.Location.X, button1.Location.Y);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            treeView_System.ExpandAll();
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


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            FillMenu();
        }

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

        private void 신규ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyInsUp frm = new CompanyInsUp();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenBaseForm<Defective>("불량현황");

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
