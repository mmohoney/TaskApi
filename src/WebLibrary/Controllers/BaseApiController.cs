using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace WebLibrary.Controllers
{
    /// <summary>
    /// Base api controller logic
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// Return an error response with 400 code
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        protected IHttpActionResult CreateErrorResponse(string error)
        {
            return CreateErrorResponse(new List<string> { error });
        }

        /// <summary>
        /// Return an error response with 400 code
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        protected IHttpActionResult CreateErrorResponse(List<string> errors)
        {
            return Content(HttpStatusCode.BadRequest, errors);
        }
    }
}