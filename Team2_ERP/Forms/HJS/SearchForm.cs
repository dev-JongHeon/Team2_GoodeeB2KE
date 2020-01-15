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
    public partial class SearchForm : Form
    {
        public SearchUserControl.Mode Mode { get; set; }
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            SettingData();
        }

        private void SettingData()
        {
            // Mode값에 따라 그리드뷰 컬럼명 및 검색 결과 
            this.Text = Mode.ToString();
            this.placeHolderTextBox1.PlaceHolderText = string.Concat(Mode.ToString(), " ", "키워드 입력");
        }
    }
}
