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
    public partial class PopMain : Form
    {
        public PopMain()
        {
            InitializeComponent();
        }

        private void PopMain_Load(object sender, EventArgs e)
        {
            SettingData();
        }

        private void SettingData()
        {
            splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed = splitContainer3.IsSplitterFixed
                = splitContainer4.IsSplitterFixed = splitContainer5.IsSplitterFixed = true;
        }

        // 비가동 전환버튼을 누른경우
        private void btnDownTime_Click(object sender, EventArgs e)
        {
            DowntimeRegister downtime = new DowntimeRegister();            
            downtime.ShowDialog();
        }

        // 작업자 설정버튼을 누른 경우
        private void btnWorker_Click(object sender, EventArgs e)
        {
            WorkRegister work = new WorkRegister();
            work.ShowDialog();
        }

        // 불량유형 버튼을 누른 경우
        private void btnDefective_Click(object sender, EventArgs e)
        {
            DefectiveRegister defective = new DefectiveRegister();
            defective.ShowDialog();
        }

        // 공정조회 버튼을 누른 경우
        private void btnLineSearch_Click(object sender, EventArgs e)
        {
            // DAC단에서 오늘날짜의 작업을 가져옴
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 해당 날짜의 작업을 가져옴
        }

        private void btnPreDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 어제 날짜의 작업을 가져옴
            // 라벨 날짜를 어제 날짜로 변경
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            // DAC단에서 내일 날짜의 작업을 가져옴
            // 라벨 날짜를 내일 날짜로 변경
        }
    }
}
