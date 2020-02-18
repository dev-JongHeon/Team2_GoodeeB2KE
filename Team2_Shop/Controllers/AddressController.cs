using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Team2_Shop.Models;

namespace Team2_Shop.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult FindAddress()
        {            
            return View();
        }

        public ActionResult RoadAddress(string confmKey = "devU01TX0FVVEgyMDIwMDIxNjEzMTEzNjEwOTQ3MDA=", int currentPage = 1, int countPerPage = 10, string keyword ="고풍로")
        {
            string responseFromServer;
            AddressModel model = new AddressModel();

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create($"http://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage={currentPage}&countPerPage={countPerPage}&keyword={keyword}&confmKey={confmKey}");
                httpRequest.Method = WebRequestMethods.Http.Post;
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                responseFromServer = reader.ReadToEnd();


                XmlDocument xml = new XmlDocument();
                xml.LoadXml(responseFromServer);
                XmlNodeList roadAddrList = xml.GetElementsByTagName("roadAddr");

                List<string> list = new List<string>();

                for (int i = 0; i < roadAddrList.Count; i++)
                {
                   list.Add(roadAddrList[i].InnerText);
                }                
                model.gridList = list;

            }
            catch(Exception ex)
            {
                responseFromServer = $" Error Message = {ex.Message}";
            }

            return View("FindAddress", model);
        }
    }
}