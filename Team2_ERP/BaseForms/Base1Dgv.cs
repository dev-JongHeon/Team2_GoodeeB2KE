using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_ERP
{
    /// <summary>
    /// DatagridView가 1개인 베이스폼
    /// </summary>
    public partial class Base1Dgv : BaseForm
    {
        /// <summary>
        /// 폼의 상단 Label 텍스트 설정 프로퍼티
        /// </summary>
        public new string FormName
        {
            get { return lblFormName.Text; }
            set { lblFormName.Text = value; }
        }

        public Base1Dgv()
        {
            InitializeComponent();
        }

    }
}
