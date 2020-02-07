using System.Collections.Generic;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service
{
    public class ShipmentService
    {
        public List<Shipment> GetShipmentList() // 뷰 사용
        {
            ShipmentDAC dac = new ShipmentDAC();
            return  dac.GetShipmentList();
        }

        public List<Shipment> GetShipmentCompletedList() // 뷰 사용
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.GetShipmentCompletedList();
        }

        public List<ShipmentDetail> GetShipmentDetailList(string sb)  // 뷰사용
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.GetShipmentDetailList(sb);
        }
    }

}
