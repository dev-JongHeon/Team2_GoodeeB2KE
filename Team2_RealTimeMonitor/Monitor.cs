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
    public partial class Monitor : UserControl
    {
        public string LabelProductName
        {
            get { return lblProduct.Text; }
            set { lblProduct.Text = value; }
        }

        public string LabelProduceName
        {
            get { return lblProduce.Text; }
            set { lblProduce.Text = value; }
        }

        public string LabelProduceRate
        {
            get { return lblProduceRate.Text; }
            set { lblProduceRate.Text = value; }
        }

        public string LabelDefecitve
        {
            get { return lblDefecitve.Text; }
            set { lblDefecitve.Text = value; }
        }

        public string LabelLineName
        {
            get { return lblLine.Text; }
            set { lblLine.Text = value; }
        }
        public string LabelRequest
        {
            get { return lblRequest.Text; }
            set { lblRequest.Text = value; }
        }

        public Image ImagePictureBox
        {
            get { return pictureBox1.Image;}
            set { pictureBox1.Image = value; }
        }

        public Monitor()
        {
            InitializeComponent();
        }
    }
}
