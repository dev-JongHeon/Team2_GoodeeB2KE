using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team2_DAC;
using Team2_VO;

namespace Team2_ERP.Service.CMG
{
    public class BOMService
    {
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

        public List<ComboItemVO> GetComboWarehouse(int division)
        {
            ResourceDAC dac = new ResourceDAC();
            return dac.GetComboWarehouse(division);
        }
    }
}
