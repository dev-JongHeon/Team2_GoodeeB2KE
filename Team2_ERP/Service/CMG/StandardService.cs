using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service.CMG
{
    public class StandardService
    {
        public List<ResourceVO> GetAllResource()
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetAllResource();
        }

        public bool InsertResource(ResourceVO item)
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.InsertResource(item);
        }

        public bool UpdateResource(ResourceVO item)
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.UpdateResource(item);
        }

        public bool DeleteResource(string code)
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.DeleteResource(code);
        }

        public List<ComboItemVO> GetComboWarehouse()
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboWarehouse();
        }

        public List<ComboItemVO> GetComboMeterial()
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboMeterial();
        }

        public List<WarehouseVO> GetAllWarehouse()
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.GetAllWarehouse();
        }

        public bool InsertWarehouse(WarehouseVO item)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.InsertResource(item);
        }

        public bool UpdateWarehouse(WarehouseVO item)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.UpdateWarehouse(item);
        }
    }
}
