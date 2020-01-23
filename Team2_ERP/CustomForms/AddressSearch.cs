using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Team2_ERP
{
    public partial class AddressSearch : BasePopup
    {
        string zip = string.Empty;
        string addr1 = string.Empty;
        string addr2 = string.Empty;

        public string Zipcode { get { return this.zip; } }
        public string Address1 { get { return this.addr1; } }
        public string Address2 { get { return this.addr2; } }

        public AddressSearch()
        {
            InitializeComponent();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    btnSearch.PerformClick();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPage = "1";
                string countPerPage = "1000";
                string confmKey = ConfigurationManager.AppSettings["LoadAPIKey"].ToString();
                string keyword = txtSearch.Text.Trim();
                string apiurl = string.Empty;

                apiurl = string.Format("http://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage={0}&countPerPage={1}&keyword={2}&confmKey={3}", currentPage, countPerPage, keyword, confmKey);

                System.Diagnostics.Debug.WriteLine(apiurl + "\r\n");

                WebClient wc = new WebClient();
                XmlReader read = new XmlTextReader(wc.OpenRead(apiurl));

                DataSet ds = new DataSet();
                ds.ReadXml(read);

                if (ds.Tables[0].Rows[0]["totalCount"].ToString() != "0")
                {
                    dataGridView1.DataSource = ds.Tables[1];
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void AddressSearch_Load(object sender, EventArgs e)
        {
            lblName.Text = "주소 검색";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AddNewColumnToDataGridView(dataGridView1, "우편번호", "zipNo", true, 80);
            AddNewColumnToDataGridView(dataGridView1, "도로명 주소", "roadAddr", true, 300);
            AddNewColumnToDataGridView(dataGridView1, "지번 주소", "jibunAddr", true, 300);
        }

        private void AddNewColumnToDataGridView(DataGridView dgv, string headerText, string dataPropertyName, bool visiblity, int colWidth = 100, DataGridViewContentAlignment textAlign = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn co1 = new DataGridViewTextBoxColumn();
            co1.HeaderText = headerText;
            co1.DataPropertyName = dataPropertyName;
            co1.Width = colWidth;
            co1.Visible = visiblity;
            co1.ValueType = typeof(string);
            co1.ReadOnly = true;
            co1.DefaultCellStyle.Alignment = textAlign;
            dgv.Columns.Add(co1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;

            if (e.RowIndex > -1 && e.RowIndex <= dt.Rows.Count)
            {
                txtLoadZipCode.Text = txtJibunZipCode.Text = dt.Rows[e.RowIndex]["zipNo"].ToString();
                txtLoadaddr1.Text = dt.Rows[e.RowIndex]["roadAddrPart1"].ToString();
                txtLoadAddr2.Text = dt.Rows[e.RowIndex]["roadAddrPart2"].ToString();

                txtJibunAddr1.Text = dt.Rows[e.RowIndex]["jibunAddr"].ToString();
                txtJibunAddr2.Text = "";

                txtLoadAddr2.Enabled = txtJibunAddr2.Enabled = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (txtLoadAddr2.Text.Length > 0)
            {
                this.zip = txtLoadZipCode.Text;
                this.addr1 = txtLoadaddr1.Text;
                this.addr2 = txtLoadAddr2.Text;

                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("상세주소를 입력하여 주세요.");
        }

        private void btnJibun_Click(object sender, EventArgs e)
        {
            if (txtLoadAddr2.Text.Length > 0)
            {
                this.zip = txtJibunZipCode.Text;
                this.addr1 = txtJibunAddr1.Text;
                this.addr2 = txtJibunAddr2.Text;

                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("상세주소를 입력하여 주세요.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
