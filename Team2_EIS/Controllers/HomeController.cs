using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Team2_EIS.Models;
using Team2_EIS.Service;

namespace Team2_EIS.Controllers
{
    /// <summary>
    /// Home컨트롤러
    /// </summary>
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            EISInfo eis = new EISInfo
            {
                info = new DataSet()
            };

            EISService service = new EISService();
            eis.info=await service.GetAsync<DataSet>("GetEIS",eis.info); // Web API를 통해서 정보를 가져옴
            
            return View(eis);
        }
    }
}