using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service
{
    public class StockService
    {
        public List<StockReceipt> GetStockReceipts(bool Warehouse_Division) // 뷰 사용
        {
            StockDAC dac = new StockDAC();
            return dac.GetStockReceipts(Warehouse_Division);
        }

        public List<Team2_VO.StockStatus> GetStockStatus() // 뷰 사용
        {
            StockDAC dac = new StockDAC();
            return dac.GetStockStatus();
        }
    }
}
