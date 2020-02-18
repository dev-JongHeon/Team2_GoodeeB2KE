using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Team2_WebAPI.DAC;

namespace Team2_WebAPI.Controllers
{
    [RoutePrefix("api/EIS")]
    public class EISController : ApiController
    {
        EISProcess dac = new EISProcess();
        DataSet ds = new DataSet();

        [HttpGet]
        [Route("GetEIS")]
        public DataSet GetEIS()
        {
            return dac.GetEIS(ds);
        }
    }
}
