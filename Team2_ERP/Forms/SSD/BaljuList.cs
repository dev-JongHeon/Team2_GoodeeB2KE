using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2_DAC;
using Team2_ERP.Service;
using Team2_VO;

namespace Team2_ERP
{
    public partial class BaljuList : Base2Dgv
    {
        BaljuService service = new BaljuService();
        List<BaljuDetail> BaljuDetail_AllList = null;  // 발주디테일 List
        List<Balju> Balju_AllList = null;  // 발주 List
        List<Balju> Balju_SearchList = null;  // 검색용 List

        public BaljuList()
        {
            InitializeComponent();
        }

        private void BaljuList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            UtilClass.SettingDgv(dgv_Balju);
            UtilClass.AddNewColum(dgv_Balju, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_Balju, "거래처코드", "Company_ID", true);
            UtilClass.AddNewColum(dgv_Balju, "거래처명칭", "Company_Name", true);
            UtilClass.AddNewColum(dgv_Balju, "발주요청일시", "Balju_Date", true);
            UtilClass.AddNewColum(dgv_Balju, "등록사원", "Employees_Name", true);
            UtilClass.AddNewColum(dgv_Balju, "삭제여부", "Balju_DeletedYN", false);
            //UtilClass.AddNewColum(dgv_Balju, "X", "Balju_ReceiptDate", false);
            dgv_Balju.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Balju.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Balju.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_Balju.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Balju_AllList = service.GetBaljuList();  // 발주리스트 갱신
            dgv_Balju.DataSource = Balju_AllList; 

            UtilClass.SettingDgv(dgv_BaljuDetail);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주지시번호", "Balju_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목코드", "Product_ID", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "품목명", "Product_Name", true);
            UtilClass.AddNewColum(dgv_BaljuDetail, "발주요청수량", "BaljuDetail_Qty", true);
            dgv_BaljuDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_BaljuDetail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_BaljuDetail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_BaljuDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            BaljuDetail_AllList = service.GetBalju_DetailList(); // 발주디테일 AllList 갱신

        }

        private void dgv_Balju_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string Balju_ID = dgv_Balju.CurrentRow.Cells[0].Value.ToString();
            List<BaljuDetail> BaljuDetail_List = (from list_detail in BaljuDetail_AllList
                                                  where list_detail.Balju_ID == Balju_ID
                                                  select list_detail).ToList();
            dgv_BaljuDetail.DataSource = BaljuDetail_List;
        }

        private void Search()
        {
            if (!Search_Company.CodeTextBox.Tag.Equals("")) // Tag값 존재하면 = 검색조건 들어가 있으면
            {
                Balju_SearchList = (from item in Balju_AllList
                                    where item.Company_Name == Search_Company.CodeTextBox.Text
                                    select item).ToList();
            }
            if (true)
            {

            }
        }
    }
}
