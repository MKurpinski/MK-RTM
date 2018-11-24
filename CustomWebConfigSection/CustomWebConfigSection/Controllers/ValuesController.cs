using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomWebConfigSection.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<(string, string)> Get()
        {
            var config = CustomSection.CustomConfigSection.Collection;
            var elems = new List<CustomConfigElement>();
            for (var i = 0; i < config.Count; i++)
            {
                elems.Add(config[i]);
            }

            return elems.Select(x => (Name: x.Name, Email: x.Email));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
