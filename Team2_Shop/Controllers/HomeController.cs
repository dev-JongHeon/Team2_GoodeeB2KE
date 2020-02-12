using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Team2_Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string id, string pwd)
        {
            if (id == null || pwd == null)
                return View("Index");
            else


                return View("Index");
        }
    }
}