using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2_Shop.DAC;
using Team2_Shop.Models;

namespace Team2_Shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart        
        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public ActionResult AddToCart(string productId, string returnUrl)
        {
            //productID에 해당하는 Product 조회
            Service product = new Service();
            Product item = product.GetProductInfo(productId);

            GetCart().AddItem(item, 1);

            return RedirectToAction("Index", new { returnUrl });
        }
            
        public ActionResult RemoveFromCart(string productId, string returnUrl)
        {
            Service product = new Service();
            Product item = product.GetProductInfo(productId);

            GetCart().RemoveItem(item);

            return RedirectToAction("Index", new { returnUrl });
        }

        //장바구니 요약정보(상단메뉴 우측)
        public ActionResult Summary()
        {
            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(ShipInfo info)
        {
            //사용자가 로직상 체크
            Cart cart = GetCart();
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "장바구니가 비었습니다.");
            }

            if (ModelState.IsValid) //유효성검사
            {
                //입력받은 배송정보로 주문완료 메일을 발송
                EmailOrderProcessor order = new EmailOrderProcessor(new EmailSettings());
                order.ProcessOrder(cart, info);
                //장바구니 비워주기
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(info);
            }
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}