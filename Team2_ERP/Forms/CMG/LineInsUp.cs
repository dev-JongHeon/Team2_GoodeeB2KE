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
    public partial class LineInsUp : BasePopup
    {
        public string LName { get; set; }
        public string Value { get; set; }

        public enum EditMode { Insert, Update }

        int code = 0;
        string mode = string.Empty;

        public LineInsUp(EditMode editMode, LineVO item)
        {
            InitializeComponent();

            if(editMode == EditMode.Insert)
            {
                mode = "Insert";
                lblName.Text = "공정등록";
            }
            else if(editMode == EditMode.Update)
            {
                mode = "Update";
                lblName.Text = "공정수정";
                code = item.Line_ID;
                txtLineName.Text = item.Line_Name;
            }
        }

        private void InitCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("LName", typeof(string)));
            dt.Columns.Add(new DataColumn("Value", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["LName"] = "선택";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["LName"] = "가동";
            dr["Value"] = 0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["LName"] = "비가동";
            dr["Value"] = 1;
            dt.Rows.Add(dr);

            cboDownTime.DataSource = dt;
            cboDownTime.DisplayMember = "LName";
            cboDownTime.ValueMember = "Value";

            StandardService service = new StandardService();
            List<ComboItemVO> factoryList = service.GetComboFactory();
            UtilClass.ComboBinding(cboFactoryName, factoryList, "선택");
        }

        private void InsertLine()
        {
            LineVO item = new LineVO
            {
                Line_Name = txtLineName.Text,
                Factory_ID = Convert.ToInt32(cboFactoryName.SelectedValue),
                Line_Downtime = Convert.ToInt32(cboDownTime.SelectedValue)
            };

            StandardService service = new StandardService();
            service.InsertLine(item);
        }

        private void UpdateLine()
        {
            LineVO item = new LineVO
            {
                Line_ID = code,
                Line_Name = txtLineName.Text,
                Factory_ID = Convert.ToInt32(cboFactoryName.SelectedValue),
                Line_Downtime = Convert.ToInt32(cboDownTime.SelectedValue)
            };

            StandardService service = new StandardService();
            service.UpdateLine(item);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LineInsUp_Load(object sender, EventArgs e)
        {
            InitCombo();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(mode.Equals("Insert"))
            {
                InsertLine();
            }
            else if(mode.Equals("Update"))
            {
                UpdateLine();
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
