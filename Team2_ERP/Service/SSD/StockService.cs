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
        public List<StockReceipt> GetStockReceipts() // 뷰 사용
        {
            StockDAC dac = new StockDAC();
            return dac.GetStockReceipts();
        }

        //public List<StockStatus> GetStockStatus() // 뷰 사용
        //{
        //    StockDAC dac = new StockDAC();
        //    return dac.GetStockStatus();
        //}
    }
}
