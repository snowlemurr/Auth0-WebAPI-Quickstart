using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    public class Message
    {
        public DateTime time { get; set; }
        public string subject { get; set; }
    }

    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        [ScopeAuthorize("read:messages")]
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(new
            {
                Message = "Got all messages"
            });
        }

        [ScopeAuthorize("create:messages")]
        [Route("")]
        [HttpPost]
        public IHttpActionResult Create(Message message)
        {
            return Ok(new
            {
                Message = "Created messages"
            });
        }
    }
}
