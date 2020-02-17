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
        

        public Image PictureStateImage
        {
            get { return picState.Image; }
            set { picState.Image = value; }
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
        }

        private void InitData()
        {
            panelMain.BackColor = Color.FromArgb(11, 11, 11);
            panelMain.BorderStyle = BorderStyle.Fixed3D;

            panelContent.Size = new Size(panelMain.Size.Width - 10, panelMain.Size.Height - 10);
            panelContent.Location = new Point(panelMain.Location.X + 3, panelMain.Location.Y + 2);
            panelContent.BackColor = Color.FromArgb(93, 93, 93);

            // 스플릿 컨테이너 설정
            splitBody.IsSplitterFixed = splitHeader.IsSplitterFixed = splitLeftTable.IsSplitterFixed 
                = splitRightContent.IsSplitterFixed = splitRightTable.IsSplitterFixed 
                = splitTable.IsSplitterFixed = splitContainer1.IsSplitterFixed = splitContainer2.IsSplitterFixed 
                = true;

            picState.SizeMode = PictureBoxSizeMode.StretchImage;
            picState.Image = Properties.Resources.Img_CircleRed;
        }
    }
}
