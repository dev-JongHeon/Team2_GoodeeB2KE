using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team2_Shop;
using Team2_Shop.DAC;
using Team2_Shop.Models;

namespace Team2_Shop.Controllers
{
    public class LoginController : Controller
    {
        // Post: Login
        public ActionResult Index()
        {
            return View();
        }

        // 로그인이 성공하면 사이트로 실패하면 로그인 페이지로 이동
        public ActionResult Login(WebLoginModel loginInfo)
        {
            if(loginInfo.UserID != null || loginInfo.UserPwd != null)
            {  
                // 로그인정보를 넘겨줌
                WebCustomerModel customerInfo = new Service().CheckUser(loginInfo);
                if(customerInfo == null) // 값이없음 == 일치하는 정보가 없다.
                {
                    return View("Index");
                }
                else
                {
                    Session["UserInfo"] = customerInfo;
                    return RedirectToAction("Index", "Product");
                }
            }
            else
            {
                return View("Index");
            }            
        }

        public ActionResult LogOut()
        {
            Session["UserInfo"] = null;
            return RedirectToAction("../Product/Index");
        }

        public ActionResult Register(WebCustomerModel model)
        {
            // 로그인 정보가 있는 경우 메인 페이지로 이동
            if (Session["UserInfo"] != null) 
                return View("../Product/Index");
            // 없는 경우만 회원가입이 가능함
            else
            {
                return View(model);
            }
        }
    }
}