using System;
using System.Collections.Generic;
using System.Data;
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

        public List<ComboItemVO> GetComboWarehouse(int division)
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboWarehouse(division);
        }

        public List<ComboItemVO> GetComboMeterial()
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboMeterial();
        }

        public List<ComboItemVO> GetComboCompany()
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboCompany();
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

        public List<LineVO> GetAllLine(int code)
        {
            LineDAC dac = new LineDAC();
            return dac.GetAllLine(code);
        }

        public List<ComboItemVO> GetComboFactory()
        {
            LineDAC dac = new LineDAC();
            return dac.GetComboFactory();
        }

        public List<ComboItemVO> GetComboCategory()
        {
            LineDAC dac = new LineDAC();
            return dac.GetComboCategory();
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

        public bool InsertCompany(CompanyVO item)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.InsertCompany(item);
        }

        public bool UpdateCompany(CompanyVO item)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.UpdateCompany(item);
        }

        public List<ComboItemVO> GetComboSector()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetComboSector();
        }

        public bool DeleteCompany(int code)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.DeleteCompany(code);
        }

        public List<ProductVO> GetAllProduct()
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetAllProduct();
        }

        public List<ProductVO> GetProductList(string type)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetProductList(type);
        }

        public List<BOMVO> GetAllCombination(string code)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetAllCombination(code);
        }

        public List<BOMVO> GetAllCombinationReverse(string type)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetAllCombinationReverse(type);
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

        public void InsertSemiProduct(ProductVO Pitem, List<BOMVO> citemList, int count)
        {
            BOMDAC dac = new BOMDAC();
            dac.InsertSemiProduct(Pitem, citemList, count);
        }

        public void UpdateSemiProduct(ProductVO Pitem, List<BOMVO> citemList, int count)
        {
            BOMDAC dac = new BOMDAC();
            dac.UpdateSemiProduct(Pitem, citemList, count);
        }

        public void DeleteSemiProduct(ProductVO Pitem)
        {
            BOMDAC dac = new BOMDAC();
            dac.DeleteSemiProduct(Pitem);
        }

        public void InsertProduct(ProductVO Pitem, List<BOMVO> citemList, int count)
        {
            BOMDAC dac = new BOMDAC();
            dac.InsertProduct(Pitem, citemList, count);
        }

        public void UpdateProduct(ProductVO Pitem, List<BOMVO> citemList, int count)
        {
            BOMDAC dac = new BOMDAC();
            dac.UpdateProduct(Pitem, citemList, count);
        }

        public void DeleteProduct(ProductVO Pitem)
        {
            BOMDAC dac = new BOMDAC();
            dac.DeleteProduct(Pitem);
        }

        public List<ProductVO> GetImage(string code)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetImage(code);
        }

        public List<EmployeeVO> GetAllEmployee()
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetAllEmployee();
        }

        public List<ComboItemVO> GetComboEmployee()
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.GetComboEmployee();
        }

        public bool InsertEmployee(EmployeeVO item)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.InsertEmployee(item);
        }

        public bool UpdateEmployee(EmployeeVO item)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.UpdateEmployee(item);
        }

        public bool DeleteEmployee(int code)
        {
            EmployeeDAC dac = new EmployeeDAC();
            return dac.DeleteEmployee(code);
        }
    }
}
