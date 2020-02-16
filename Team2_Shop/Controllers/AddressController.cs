using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Team2_Shop.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult FindAddress()
        {            
            return View();
        }
        

        public string RoadAddress(string confmKey, int currentPage = 1, int countPerPage = 10, string keyword ="")
        {
            string responseFromServer;

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.juso.go.kr/addrlink/addrLinkApiTest.do");
                httpRequest.Method = WebRequestMethods.Http.Post;
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                responseFromServer = reader.ReadToEnd();
            }
            catch(Exception ex)
            {
                responseFromServer = $" Error Message = {ex.Message}";
            }

            return responseFromServer;
        }
    }
}