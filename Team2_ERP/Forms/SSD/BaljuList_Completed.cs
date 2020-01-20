using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP
{
    public partial class BaljuList_Completed : Base2Dgv
    {
        BaljuDAC dac = new BaljuDAC();
        List<BaljuDetail> BaljuDetail_AllList = null;
        public BaljuList_Completed()
        {
            InitializeComponent();
        }

        private void BaljuList_Completed_Load(object sender, EventArgs e)
        {
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처코드", "Company_ID", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "거래처명칭", "Company_Name", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "발주요청일시", "Balju_Date", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "수령일시", "Balju_ReceiptDate", true);
            UtilClass.AddNewColum(dgv_BaljuCompleted, "삭제여부", "Balju_DeletedYN", false);
            dgv_BaljuCompleted.DataSource = dac.GetBalju_CompletedList(); // 발주리스트 갱신

            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true);
            BaljuDetail_AllList = dac.GetBalju_DetailList(); // 발주디테일 AllList 갱신
        }

        private void dgv_BaljuCompleted_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Balju_ID = dgv_BaljuCompleted.CurrentRow.Cells[0].Value.ToString();
            List<BaljuDetail> BaljuDetail_List = (from list_detail in BaljuDetail_AllList
                                                  where list_detail.Balju_ID == Balju_ID
                                                  select list_detail).ToList();
            dgv_BaljuDetail.DataSource = BaljuDetail_List;
        }
    }
}
