using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
//using System.Web.Mvc;

namespace WebLibrary.Filters
{
    //public class UnhandledExceptionHandler : FilterAttribute, IExceptionFilter
    //{
    //    public void OnException(ExceptionContext filterContext)
    //    {
    //        filterContext.HttpContext.Response.StatusCode = 500;
    //        filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
    //        filterContext.ExceptionHandled = true;
    //        filterContext.Result = new JsonResult
    //        {
    //            Data = new {errorMessage = filterContext.Exception.Message},
    //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
    //        };
    //    }
    //}

    public class UnhandledExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}