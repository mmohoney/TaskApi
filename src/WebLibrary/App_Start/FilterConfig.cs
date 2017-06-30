using System.Web;
using System.Web.Mvc;
using WebLibrary.Filters;

namespace WebLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new UnhandledExceptionHandler());
        }
    }
}
