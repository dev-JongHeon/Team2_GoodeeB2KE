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

        MainForm frm;

        public Factory()
        {
            InitializeComponent();
        }

        // 그리드 뷰 디자인 
        private void InitGridView()
        {
            UtilClass.SettingDgv(dgvFactory);

            UtilClass.AddNewColum(dgvFactory, "공장이름", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvFactory, "공장구분", "Factory_Division_Name", true, 100);
            UtilClass.AddNewColum(dgvFactory, "전화번호", "Factory_Number", true, 100);
            UtilClass.AddNewColum(dgvFactory, "FAX번호", "Factory_Fax", true, 100);
            UtilClass.AddNewColum(dgvFactory, "주소", "Factory_Address", true, 100);

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
            ((MainForm)MdiParent).신규ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).수정ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).삭제ToolStripMenuItem.Visible = true;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = false;
        }

        private void Factory_Deactivate(object sender, EventArgs e)
        {
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
            new SettingMenuStrip().UnsetMenu(this);
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
            //InitMessage();

            //ResourceInsUp frm = new ResourceInsUp(ResourceInsUp.EditMode.Insert, null);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    frm.Close();
            //    dgvFactory.DataSource = null;
            //    LoadGridView();
            //}

            ToolStripDropDownItem tool = (ToolStripDropDownItem)(((MainForm)MdiParent).신규ToolStripMenuItem);

            if (tool.DropDownItems.Count < 1)
            {
                tool.DropDownItems.Add("공장");
                tool.DropDownItems.Add("공정");

                tool.DropDownItemClicked += new ToolStripItemClickedEventHandler(ItemSelect);
            }
        }

        private void ItemSelect(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "공장")
            {
                FactoryInsUp frm = new FactoryInsUp();
                frm.ShowDialog();
            }
            else
            {
                LineInsUp frm = new LineInsUp();
                frm.ShowDialog();
            }
        }

        public override void Modify(object sender, EventArgs e)
        {
            //InitMessage();

            //if (item == null)
            //{
            //    frm.NoticeMessage = "수정할 제품을 선택해주세요.";
            //}
            //else
            //{
            //    ResourceInsUp frm = new ResourceInsUp(ResourceInsUp.EditMode.Update, item);
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {
            //        frm.Close();
            //        dataGridView1.DataSource = null;
            //        LoadGridView();
            //    }
            //}
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

        private void Factory_Shown(object sender, EventArgs e)
        {
            dgvFactory.CurrentCell = null;
        }
    }
}
