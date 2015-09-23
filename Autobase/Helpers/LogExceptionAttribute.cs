using BBL.DbManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autobase.Helpers
{
    public class LogExceptionAttribute : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            RouteDbManager dbManager = new RouteDbManager();
            dbManager.AddException(exceptionContext.Exception);
        }
    }
}