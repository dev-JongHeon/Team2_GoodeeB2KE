using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_RealTimeMonitor
{
    public partial class LineMonitorControl : UserControl
    {
        #region 프로퍼티
        public string LabelProduceText 
        {
            get { return lblProduce.Text; }
            set { lblProduce.Text = value; }
        }
        public string LabelRequestText
        {
            get { return lblRequest.Text; }
            set { lblRequest.Text = value; }
        }
        public string LabelImportText
        {
            get { return lblImport.Text; }
            set { lblImport.Text = value; }
        }
        public string LabelDefectiveText
        {
            get { return lblDefective.Text; }
            set { lblDefective.Text = value; }
        }
        public string LabelLineNameText
        {
            get { return lblLineName.Text; }
            set { lblLineName.Text = value; }
        }

        public string LabelStateText
        {
            get { return lblState.Text; }
            set { lblState.Text = value; }
        }
       

        public CircleProgressBar CircleProgress
        {
            get { return circleProgress; }
            set { circleProgress = value; }
        }
        #endregion
               

        public LineMonitorControl()
        {
            InitializeComponent();
            InitData();

            circleProgress.ProgressColor1 = Color.FromArgb(93, 93, 93);
            circleProgress.ProgressColor2 = Color.FromArgb(93, 93, 93);
        }

        private void InitData()
        {
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.None;

            panelContent.Size = new Size(panelMain.Size.Width - 6, panelMain.Size.Height - 6);
            panelContent.Location = new Point(panelMain.Location.X + 3, panelMain.Location.Y + 3);
            panelContent.BackColor = Color.FromArgb(93, 93, 93);

            // 스플릿 컨테이너 설정
            splitBody.IsSplitterFixed = splitLeftTable.IsSplitterFixed 
                = splitRightContent.IsSplitterFixed = splitRightTable.IsSplitterFixed 
                = splitTable.IsSplitterFixed = splitContainer1.IsSplitterFixed = true;
        }
    }
}
