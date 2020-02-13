using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2_Shop.Models;

namespace Team2_Shop.DAC
{
    public class ProductController : Controller
    {
        // GET: Product

        int pageSize = 9;
        public ActionResult Index(int page = 1)
        {
            ProductDAC product = new ProductDAC();

            ProductListViewModel model = new ProductListViewModel
            {
                Products = product.GetProducts(page, pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = product.GetProductTotalCount()
                },               
            };
            
            return View(model);
        }
    }
}