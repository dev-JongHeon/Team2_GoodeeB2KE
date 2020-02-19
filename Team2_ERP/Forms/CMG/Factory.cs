using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Properties;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP
{
    public partial class Factory : Base2Dgv
    {
        List<FactoryVO> FList;
        List<LineVO> LList;

        MainForm frm;

        ToolStripDropDownItem tool;

        FactoryVO factoryItem;
        LineVO lineItem;

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
            UtilClass.AddNewColum(dgvFactory, "우편번호", "Factory_AddrNumber", true, 100);
            UtilClass.AddNewColum(dgvFactory, "주소", "Factory_Address", true, 100);

            dgvFactory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            UtilClass.SettingDgv(dgvLine);

            UtilClass.AddNewColum(dgvLine, "공정코드", "Line_ID", true, 100);
            UtilClass.AddNewColum(dgvLine, "라인이름", "Line_Name", true, 100);
            UtilClass.AddNewColum(dgvLine, "공장이름", "Factory_Name", true, 100);
            UtilClass.AddNewColum(dgvLine, "비가동상태", "Line_Downtome_Name", true, 100);

            dgvLine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // DataGridView 가져오기
        private void LoadGridView()
        {
            try
            {
                StandardService service = new StandardService();
                FList = service.GetAllFactory();
            }
            catch (Exception err)
            {
                Log.WriteError(err.Message, err);
            }
            dgvFactory.DataSource = FList;
            dgvFactory.CurrentCell = null;
            dgvLine.DataSource = null;
        }

        private void Factory_Load(object sender, EventArgs e)
        {
            InitGridView();
            frm = (MainForm)this.ParentForm;
            searchLineName.Visible = false;
        }

        private void InitMessage()
        {
            frm.NoticeMessage = notice;
        }

        private void Factory_Activated(object sender, EventArgs e)
        {
            MenuByAuth(Auth);
            InitMessage();

            //등록 서브메뉴 이벤트 추가
            tool = (ToolStripDropDownItem)(((MainForm)MdiParent).신규ToolStripMenuItem);

            if (tool.DropDownItems.Count < 1)
            {
                tool.DropDownItems.Add("공장");
                tool.DropDownItems.Add("공정");

                tool.DropDownItemClicked += new ToolStripItemClickedEventHandler(ItemSelect);
            }
        }

        private void Factory_Deactivate(object sender, EventArgs e)
        {
            //서브메뉴 이벤트 삭제
            tool.DropDownItems.Clear();
            tool.DropDownItemClicked -= ItemSelect;
            ((MainForm)MdiParent).인쇄ToolStripMenuItem.Visible = true;
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
            frm.NoticeMessage = Resources.RefreshDone;
            dgvFactory.DataSource = null;
            dgvLine.DataSource = null;
            searchFactoryName.CodeTextBox.Clear();
            searchLineName.CodeTextBox.Clear();
            searchLineName.Visible = false;
        }

        public override void New(object sender, EventArgs e)
        {
            
        }

        public override void Modify(object sender, EventArgs e)
        {
            if (dgvFactory.SelectedRows.Count > 0 || dgvLine.SelectedRows.Count > 0)
            {
                if (dgvLine.SelectedRows.Count < 1)
                {
                    FactoryInsUp popup = new FactoryInsUp(FactoryInsUp.EditMode.Update, factoryItem);
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        frm.NoticeMessage = Resources.ModDone;
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
                else if (dgvFactory.SelectedRows.Count < 1)
                {
                    LineInsUp popup = new LineInsUp(LineInsUp.EditMode.Update, lineItem);
                    if (popup.ShowDialog() == DialogResult.OK)
                    {
                        frm.NoticeMessage = Resources.ModDone;
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
            }
            else
            {
                frm.NoticeMessage = Resources.ModEmpty;
            }
        }

        public override void Delete(object sender, EventArgs e)
        {
            if (dgvLine.SelectedRows.Count < 1)
            {
                if (factoryItem == null)
                {
                    frm.NoticeMessage = Resources.DelEmpty;
                }
                else
                {
                    if(MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            StandardService service = new StandardService();
                            service.DeleteFactory(factoryItem.Factory_ID);
                        }
                        catch (Exception err)
                        {
                            Log.WriteError(err.Message, err);
                        }
                        frm.NoticeMessage = Resources.DeleteDone;
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
            }
            else if (dgvFactory.SelectedRows.Count < 1)
            {
                if(lineItem == null)
                {
                    frm.NoticeMessage = Resources.DelEmpty;
                }
                else
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "안내", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            StandardService service = new StandardService();
                            service.DeleteLine(lineItem.Factory_ID);
                        }
                        catch (Exception err)
                        {
                            Log.WriteError(err.Message, err);
                        }
                        frm.NoticeMessage = Resources.DeleteDone;
                        dgvFactory.DataSource = null;
                        LoadGridView();
                    }
                }
            }
        }

        public override void Search(object sender, EventArgs e)
        {
            LoadGridView();

            //공장, 공정 두개 다 검색할 때
            if (searchFactoryName.CodeTextBox.Text.Length > 0 && searchLineName.CodeTextBox.Text.Length > 0)
            {
                dgvFactory.DataSource = null;
                List<FactoryVO> searchFList = (from item in FList where item.Factory_ID == Convert.ToInt32(searchFactoryName.CodeTextBox.Tag) select item).ToList();
                dgvFactory.DataSource = searchFList;

                dgvLine.DataSource = null;
                List<LineVO> searchLList = (from item in LList where item.Line_ID == Convert.ToInt32(searchLineName.CodeTextBox.Tag) select item).ToList();
                dgvLine.DataSource = searchLList;
            }
            //공장만 검색할 때
            else if (searchFactoryName.CodeTextBox.Text.Length > 0)
            {
                dgvFactory.DataSource = null;
                dgvLine.DataSource = null;
                List<FactoryVO> searchList = (from item in FList where item.Factory_ID == Convert.ToInt32(searchFactoryName.CodeTextBox.Tag) select item).ToList();
                dgvFactory.DataSource = searchList;
            }
            //공정만 검색할 때
            else if (searchLineName.CodeTextBox.Text.Length > 0)
            {
                dgvLine.DataSource = null;
                List<LineVO> searchLList = (from item in LList where item.Line_ID == Convert.ToInt32(searchLineName.CodeTextBox.Tag) select item).ToList();
                dgvLine.DataSource = searchLList;
            }

            frm.NoticeMessage = Resources.SearchDone;
            dgvFactory.CurrentCell = null;
            dgvLine.CurrentCell = null;
        }

        private void ItemSelect(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "공장")
            {
                FactoryInsUp popup = new FactoryInsUp(FactoryInsUp.EditMode.Insert, null);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.AddDone;
                    dgvFactory.DataSource = null;
                    LoadGridView();
                }
            }
            else
            {
                LineInsUp popup = new LineInsUp(LineInsUp.EditMode.Insert, null);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    frm.NoticeMessage = Resources.AddDone;
                    dgvFactory.DataSource = null;
                    LoadGridView();
                }
            }
        }

        private void dgvFactory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLine.CurrentCell = null;

            if (e.RowIndex < dgvFactory.Rows.Count && e.RowIndex > -1)
            {
                if (dgvFactory.Rows[e.RowIndex].Cells[4].Value == null)
                {
                    factoryItem = new FactoryVO()
                    {
                        Factory_ID = Convert.ToInt32(dgvFactory.Rows[e.RowIndex].Cells[0].Value),
                        Factory_Name = dgvFactory.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Factory_Number = dgvFactory.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Factory_AddrNumber = dgvFactory.Rows[e.RowIndex].Cells[5].Value.ToString(),
                        Factory_Address = dgvFactory.Rows[e.RowIndex].Cells[6].Value.ToString()
                    };
                }
                else
                {
                    factoryItem = new FactoryVO()
                    {
                        Factory_ID = Convert.ToInt32(dgvFactory.Rows[e.RowIndex].Cells[0].Value),
                        Factory_Name = dgvFactory.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        Factory_Number = dgvFactory.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        Factory_Fax = dgvFactory.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        Factory_AddrNumber = dgvFactory.Rows[e.RowIndex].Cells[5].Value.ToString(),
                        Factory_Address = dgvFactory.Rows[e.RowIndex].Cells[6].Value.ToString()
                    };
                }
            }
        }

        private void dgvLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFactory.CurrentCell = null;

            if (e.RowIndex < dgvLine.Rows.Count && e.RowIndex > -1)
            {
                lineItem = new LineVO()
                {
                    Line_ID = Convert.ToInt32(dgvLine.Rows[e.RowIndex].Cells[0].Value),
                    Line_Name = dgvLine.Rows[e.RowIndex].Cells[1].Value.ToString()
                };
            }
        }

        private void dgvFactory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactory.Rows.Count > 0)
            {
                searchLineName.Visible = true;
            }

            if (e.RowIndex < dgvFactory.Rows.Count && e.RowIndex > -1)
            {
                try
                {
                    StandardService service = new StandardService();
                    LList = service.GetAllLine(Convert.ToInt32(dgvFactory.Rows[e.RowIndex].Cells[0].Value));
                }
                catch (Exception err)
                {
                    Log.WriteError(err.Message, err);
                }
                dgvLine.DataSource = LList;
                dgvLine.CurrentCell = null;
            }
        }
    }
}