using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Team2_EIS.DAC;
using Team2_EIS.Models;

namespace Team2_EIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EISInfo eis = new EISInfo();
            eis.info = new DataSet();
            EISProcess proc = new EISProcess();
            eis.info=proc.GetTop(eis.info);
            return View(eis);
        }
    }
}