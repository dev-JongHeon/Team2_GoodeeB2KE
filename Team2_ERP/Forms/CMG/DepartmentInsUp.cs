using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team2_ERP.Service.CMG;
using Team2_VO;

namespace Team2_ERP.Forms
{
    public partial class DepartmentInsUp : BasePopup
    {
        public DepartmentInsUp()
        {
            InitializeComponent();
        }

        // 부서 등록
        private void InsertDepartMent()
        {
            CodeTableVO dept = new CodeTableVO();
            CodeTableService service = new CodeTableService();

            dept.CodeTable_CodeName = txtName.Text;
            dept.CodeTable_CodeExplain = txtContext.Text;

            service.InsertDepart(dept);
        }
    }
}
