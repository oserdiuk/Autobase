using BBL.DbManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autobase.Helpers
{
    public class LogExceptionAttribute : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            RouteDbManager dbManager = new RouteDbManager();
            dbManager.AddException(exceptionContext.Exception);
            if (!exceptionContext.ExceptionHandled)
            {
                exceptionContext.ExceptionHandled = true;
            }
        }

    }
}