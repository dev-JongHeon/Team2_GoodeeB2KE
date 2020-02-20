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
    /// 처리중 폼
    /// </summary>
    public partial class WaitForm : Form
    {
        /// <summary>
        /// 처리할 메서드 동작
        /// </summary>
        public Action Processing { get; set; } 

        public WaitForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 폼 로드시 이벤트 메서드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaitForm_Load(object sender, EventArgs e)
        {
            
            Task.Factory.StartNew(Processing).ContinueWith(t => { this.Close(); },
               TaskScheduler.FromCurrentSynchronizationContext()); //Processing을 비동기시작하면 처리중폼을 닫는다.
        }
    }
}
