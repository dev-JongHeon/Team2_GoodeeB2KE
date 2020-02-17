using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2_Shop.DAC;
using Team2_Shop.Models;


namespace Team2_Shop
{
    public class Service
    {        
        /// <summary>
        /// 정보가 맞는경우 아이디와 비밀번호를 가져옴
        /// </summary>
        /// <param name="id">유저의 아이디</param>
        /// <param name="pwd">유저의 비밀번호</param>
        public WebCustomerModel CheckUser(WebLoginModel loginInfo)
        {
            return new ShopDAC().CheckUser(loginInfo);
        }

        public List<Product> GetProducts(int page, int pageSize)
        {
            return new ProductDAC().GetProducts(page, pageSize);
        }

        public int GetProductTotalCount()
        {
            return new ProductDAC().GetProductTotalCount();
        }
        
        public Product GetProductInfo(string productID)
        {
            return new ProductDAC().GetProductInfo(productID);
        }

        public bool CheckOut(Cart cart, ShipInfo shipInfo)
        {
            return new ShopDAC().CheckOut(cart, shipInfo);
        }
    }
}