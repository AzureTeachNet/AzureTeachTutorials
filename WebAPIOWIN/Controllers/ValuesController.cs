using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIOWIN.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("GetMessage")]
        public string GetMessage()
        {
            return "Api Working!!!";
        }
    }
}
