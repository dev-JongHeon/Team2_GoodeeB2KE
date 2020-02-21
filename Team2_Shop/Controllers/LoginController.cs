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
            if (loginInfo.UserID != null || loginInfo.UserPwd != null)
            {
                // 로그인정보를 넘겨줌
                WebCustomerModel customerInfo = new Service().CheckUser(loginInfo);
                if (customerInfo == null) // 값이없음 == 일치하는 정보가 없다.
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

        public ActionResult Register()
        {
            // 로그인 정보가 있는 경우 메인 페이지로 이동
            if (Session["UserInfo"] != null)
                return View("../Product/Index");
            // 없는 경우만 회원가입이 가능함
            else
            {
                return View();
            }
        }

        // 회원가입 성공한 경우
        public ActionResult Completed(RegisterModel model)
        {

            WebCustomerModel userInfo = new WebCustomerModel
            {
                Customer_Name = model.Customer_Name,
                Customer_Address1 = model.Customer_Address1,
                Customer_Address2 = model.Customer_Address2,
                Customer_Email = model.Customer_Email,
                Customer_Birth = string.Join("-", new object[] { model.Customer_Birth_Y, model.Customer_Birth_M, model.Customer_Birth_D }),
                Customer_Phone = string.Join("-", new object[] { model.Customer_Phone1, model.Customer_Phone2, model.Customer_Phone3 }),
                Customer_UserID = model.Customer_UserID,
                Customer_PWD = model.Customer_PWD
            };

            if (userInfo.Customer_Name == null || userInfo.Customer_Address1 == null || userInfo.Customer_Address2 == null
                || userInfo.Customer_Email == null || userInfo.Customer_Birth == null || userInfo.Customer_Phone == null
                || userInfo.Customer_UserID == null || userInfo.Customer_PWD == null)
            {
                ViewBag.Message = "필수 사항을 입력해주세요.!!!";
                return View("Register");
            }


            // 대충 회원가입하는코드
            Service service = new Service();
            service.CustomerInsert(userInfo);

            return View();
        }
    }
}