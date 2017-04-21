using System;
using System.Globalization;
using System.Web.Http;

namespace HelloWebApiDemo
{
    public class HelloApiController: ApiController
    {
        public string Get()
        {
            return "Hello from API at " +
                   DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
    }
}