using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuthAuthorization.Controllers
{
    [Authorize]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new[] {"You", "are", "authorized"});
        }
    }
}
