using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Team2_EIS.DAC;
using Team2_EIS.Models;
using Team2_EIS.Service;

namespace Team2_EIS.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            EISInfo eis = new EISInfo();
            eis.info = new DataSet();
            EISService service = new EISService();
            eis.info=await service.GetAsync<DataSet>("GetEIS",eis.info);
            
            //EISProcess proc = new EISProcess();
            //eis.info=proc.GetTop(eis.info);
            return View(eis);
        }
    }
}