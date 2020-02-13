using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    public partial class SemiProductCompControl : UserControl
    {
        public Label LblName
        {
            get { return lblName; }
            set { lblName = value; }
        }
        public TextBox TxtName
        {
            get { return txtName; }
            set { txtName = value; }
        }
        public Label LblMoney
        {
            get { return lblMoney; }
            set { lblMoney = value; }
        }

        public NumericUpDown Qty
        {
            get { return numericUpDown1; }
            set { numericUpDown1 = value; }
        }
        public SemiProductCompControl()
        {
            InitializeComponent();
        }

        //개수를 수정할 때 0보다 크면 해당하는 원자재 제품의 가격과 개수를 곱한다. 만약 개수가 0이면 0원으로 보여준다.
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                if (numericUpDown1.Value > 0)
                {
                    lblMoney.Text = (int.Parse(numericUpDown1.Tag.ToString()) * Convert.ToInt32(numericUpDown1.Value)).ToString("#,##0") + "원";
                }
                else
                {
                    if (numericUpDown1.Value == 0 && lblMoney.Tag.ToString() == "1")
                    {
                        if (MessageBox.Show("상품을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            lblMoney.Text = "";
                            lblMoney.Tag = null;
                            txtName.Clear();
                            txtName.Tag = null;
                            numericUpDown1.Value = 0;
                        }
                        else
                        {
                            numericUpDown1.Value = 1;
                        }
                    }
                    else
                    {
                        lblMoney.Tag = 1;
                        return;
                    }
                }
            }
            else
            {
                numericUpDown1.Value = 0;
            }
        }
    }
}
