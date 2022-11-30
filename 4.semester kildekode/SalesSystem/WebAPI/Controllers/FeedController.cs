using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class FeedController : ApiController
    {



        [HttpPost]
        public HttpResponseMessage Post()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);  
        }
	}
}
