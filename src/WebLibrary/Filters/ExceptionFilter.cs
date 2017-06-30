using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebLibrary.Filters
{
    public class UnhandledExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}