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

        public bool DeleteWarehouse(int code)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.DeleteWarehouse(code);
        }

        public List<CustomerVO> GetAllCustomer()
        {
            CustomerDAC dac = new CustomerDAC();
            return dac.GetAllCustomer();
        }

        public List<FactoryVO> GetAllFactory()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetAllFactory();
        }

        public bool InsertFactory(FactoryVO item)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.InsertFactory(item);
        }

        public bool UpdateFactory(FactoryVO item)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.UpdateFactory(item);
        }

        public bool DeleteFactory(int code)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteFactory(code);
        }

        public List<LineVO> GetAllLine()
        {
            LineDAC dac = new LineDAC();
            return dac.GetAllLine();
        }

        public List<ComboItemVO> GetComboFactory()
        {
            LineDAC dac = new LineDAC();
            return dac.GetComboFactory();
        }

        public bool InsertLine(LineVO item)
        {
            LineDAC dac = new LineDAC();
            return dac.InsertLine(item);
        }

        public bool UpdateLine(LineVO item)
        {
            LineDAC dac = new LineDAC();
            return dac.UpdateLine(item);
        }

        public bool DeleteLine(int code)
        {
            LineDAC dac = new LineDAC();
            return dac.DeleteLine(code);
        }

        public List<CompanyVO> GetAllCompany()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetAllCompany();
        }

        public List<ProductVO> GetAllProduct()
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetAllProduct();
        }

        public List<BOMVO> GetAllCombination(string code)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetAllCombination(code);
        }

        public List<ComboItemVO> GetComboProductCategory()
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetComboProductCategory();
        }

        public List<ComboItemVO> GetComboResourceCategory(string div)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetComboResourceCategory(div);
        }
    }
}
