using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebLibrary.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IHttpActionResult CreateErrorResponse(string error)
        {
            return CreateErrorResponse(new List<string> { error });
        }

        protected IHttpActionResult CreateErrorResponse(List<string> errors)
        {
            return Content(HttpStatusCode.BadRequest, errors);
        }
    }
}