using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Factory : Base2Dgv
    {
        List<FactoryVO> FList;
        List<LineVO> LList;

        MainForm frm;

        ToolStripDropDownItem tool1;
        ToolStripDropDownItem tool2;

        FactoryVO factoryItem;
        LineVO lineItem;

        string mode = string.Empty;

        public Factory()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvFactory);

            UtilClass.AddNewColum(dgvFactory, "공장코드", "Factory_ID", true, 100);
            UtilClass.AddNewColum(dgvFactory, "공장이름", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvFactory, "공장구분", "Factory_Division_Name", true, 100);
            UtilClass.AddNewColum(dgvFactory, "전화번호", "Factory_Number", true, 100);
            UtilClass.AddNewColum(dgvFactory, "FAX번호", "Factory_Fax", true, 100);
            UtilClass.AddNewColum(dgvFactory, "주소", "Factory_Address", true, 100);

            dgvFactory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvFactory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UtilClass.SettingDgv(dgvLine);

            UtilClass.AddNewColum(dgvLine, "라인이름", "Line_Name", true, 100);
            UtilClass.AddNewColum(dgvLine, "공장이름", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvLine, "비가동상태", "Line_Downtome_Name", true, 100);

            dgvFactory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvFactory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            StandardService service = new StandardService();
            FList = service.GetAllFactory();
            List<FactoryVO> factoryList = (from item in FList where item.Factory_DeletedYN == false select item).ToList();
            dgvFactory.DataSource = factoryList;

            LList = service.GetAllLine();
            List<LineVO> lineList = (from item in LList where item.Line_DeletedYN == false select item).ToList();
            dgvLine.DataSource = lineList;
        }

        private void Factory_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            LoadGridView();
        }

        private void InitMessage()
        {
            frm.NoticeMessage = "메세지";
        }

        private void Factory_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
        }

        private void Factory_Deactivate(object sender, EventArgs e)
        {
            tool1.DropDownItems.Clear();
            tool1.DropDownItemClicked -= ItemSelect;
            tool2.DropDownItems.Clear();
            tool2.DropDownItemClicked -= ItemSelect;
            new SettingMenuStrip().UnsetMenu(this);
        }

        public override void MenuStripONOFF(bool flag)
        {
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = flag;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        public override void Refresh(object sender, EventArgs e)
        {
            InitMessage();
            dgvFactory.DataSource = null;
            searchUserControl1.CodeTextBox.Text = "";
            dgvFactory.CurrentCell = null;
            LoadGridView();
        }

        public override void New(object sender, EventArgs e)
        {
            tool1 = (ToolStripDropDownItem)(((MainForm)MdiParent).신규ToolStripMenuItem);

            if (tool1.DropDownItems.Count < 1)
            {
                tool1.DropDownItems.Add("공장");
                tool1.DropDownItems.Add("공정");

                tool1.DropDownItemClicked += new ToolStripItemClickedEventHandler(ItemSelect);
            }

            mode = "Insert";
        }

        public override void Modify(object sender, EventArgs e)
        {
            tool2 = (ToolStripDropDownItem)(((MainForm)MdiParent).수정ToolStripMenuItem);

            if (tool2.DropDownItems.Count < 1)
            {
                tool2.DropDownItems.Add("공장");
                tool2.DropDownItems.Add("공정");

                tool2.DropDownItemClicked += new ToolStripItemClickedEventHandler(ItemSelect);
            }

            mode = "Update";
        }

        public override void Delete(object sender, EventArgs e)
        {
            InitMessage();

            //if (item == null)
            //{
            //    frm.NoticeMessage = "삭제할 제품을 선택해주세요.";
            //}

            //else
            //{
            //    if (MessageBox.Show("삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        StandardService service = new StandardService();
            //        service.DeleteResource(item.Product_ID);
            //        dataGridView1.DataSource = null;
            //        LoadGridView();
            //    }
            //}
        }

        public override void Search(object sender, EventArgs e)
        {
            if (searchUserControl1.CodeTextBox.Text.Length > 0)
            {
                dgvFactory.DataSource = null;
                List<FactoryVO> searchList = (from item in FList where item.Factory_ID == Convert.ToInt32(searchUserControl1.CodeTextBox.Tag) && item.Factory_DeletedYN == false select item).ToList();
                dgvFactory.DataSource = searchList;
            }
            else
            {
                frm.NoticeMessage = "검색할 공장을 선택해주세요.";
            }
        }

        private void ItemSelect(object sender, ToolStripItemClickedEventArgs e)
        {
            if(mode.Equals("Insert"))
            {
                if (e.ClickedItem.Text == "공장")
                {
                    FactoryInsUp frm = new FactoryInsUp(FactoryInsUp.EditMode.Insert, null);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
                else
                {
                    LineInsUp frm = new LineInsUp(LineInsUp.EditMode.Insert, null);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
            }
            else if(mode.Equals("Update"))
            {
                if (e.ClickedItem.Text == "공장")
                {
                    FactoryInsUp frm = new FactoryInsUp(FactoryInsUp.EditMode.Update, factoryItem);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
                else
                {
                    LineInsUp frm = new LineInsUp(LineInsUp.EditMode.Update, lineItem);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        frm.Close();
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
            }
        }

        private void Factory_Shown(object sender, EventArgs e)
        {
            dgvFactory.CurrentCell = null;
        }

        private void dgvFactory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvFactory.Rows[e.RowIndex].Cells[4].Value == null)
            {
                factoryItem = new FactoryVO()
                {
                    Factory_ID = Convert.ToInt32(dgvFactory.Rows[e.RowIndex].Cells[0].Value),
                    Factory_Name = dgvFactory.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Factory_Number = dgvFactory.Rows[e.RowIndex].Cells[3].Value.ToString()
                };
            }
            else
            {
                factoryItem = new FactoryVO()
                {
                    Factory_ID = Convert.ToInt32(dgvFactory.Rows[e.RowIndex].Cells[0].Value),
                    Factory_Name = dgvFactory.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    Factory_Number = dgvFactory.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Factory_Fax = dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString()
                };
            }
        }
    }
}
