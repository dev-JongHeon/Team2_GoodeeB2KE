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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //제품의 이름이 없을 때
            if (txtName.Text != string.Empty)
            {
                //제품의 개수가 0이상 일 때
                if (numericUpDown1.Value > 0)
                {
                    //제품의 가격 * 제품의 개수
                    lblMoney.Text = (int.Parse(numericUpDown1.Tag.ToString()) * Convert.ToInt32(numericUpDown1.Value)).ToString("#,##0") + "원";
                }
                else
                {
                    //제품의 개수가 0이고 맨 처음 등록할 때
                    if (numericUpDown1.Value == 0 && lblMoney.Tag.ToString() == "1")
                    {
                        if (MessageBox.Show("상품을 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //제품정보 삭제
                            lblMoney.Text = "";
                            lblMoney.Tag = null;
                            txtName.Clear();
                            txtName.Tag = null;
                            numericUpDown1.Value = 0;
                        }
                        else
                        {
                            //개수를 다시 1로 늘린다.
                            numericUpDown1.Value = 1;
                        }
                    }
                    //제품의 개수가 0이고 맨 처음 등록이 아닐 때
                    else
                    {
                        lblMoney.Tag = 1;
                        return;
                    }
                }
            }
            //제품정보가 없는데 제품의 개수를 조정하려고 할 때
            else
            {
                numericUpDown1.Value = 0;
            }
        }
    }
}
