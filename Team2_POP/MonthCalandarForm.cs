using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_POP
{
    public partial class MonthCalandarForm : Form
    {
        // 날짜 선택 프로퍼티
        public DateTime DSelected { get; set; }

        public MonthCalandarForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 다중 선택을 막기위해 최대 선택량 1로 수정
            singleMonthCalandar1.MaxSelectionCount = 1;
            singleMonthCalandar1.SelectionStart = DSelected;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void singleMonthCalandar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DSelected = e.Start;
            DialogResult = DialogResult.OK;
        }
    }
}
