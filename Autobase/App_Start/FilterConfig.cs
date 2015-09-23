using Autobase.Helpers;
using System.Web;
using System.Web.Mvc;

namespace Autobase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionAttribute());
            //todo uncomment this
        }
    }
}
