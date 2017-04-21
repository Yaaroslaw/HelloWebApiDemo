using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloApiTemplateDemo.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        static readonly List<string> Data =InitList();

        private static List<string> InitList()
        {
            var ret = new List<string>
            {
                "value1",
                "value2"
            };
            return ret;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return Data;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            if (Data.Count > id)
                return Request.CreateResponse(HttpStatusCode.OK, Data[id]);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found!");
            {
                
            }


        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            Data.Add(value);
            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + (Data.Count - 1).ToString());
            return msg;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            Data[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Data.RemoveAt(id);
        }
    }
}
