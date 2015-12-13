using BBL.DbManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autobase.Helpers
{
    //Adding exception logs to database
    public class LogExceptionAttribute : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            DbManager dbManager = new DbManager();
            dbManager.AddException(exceptionContext.Exception);
        }
    }
}