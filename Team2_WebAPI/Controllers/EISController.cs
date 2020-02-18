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
    /// <summary>
    /// EIS화면을 위한 API
    /// </summary>
    [RoutePrefix("api/EIS")]
    public class EISController : ApiController
    {
        EISProcess dac = new EISProcess();
        DataSet ds = new DataSet();

        /// <summary>
        /// EIS화면에 보여줄 모든 정보를 DataSet에 담아옵니다.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEIS")]
        public DataSet GetEIS()
        {
            return dac.GetEIS(ds);
        }
    }
}
