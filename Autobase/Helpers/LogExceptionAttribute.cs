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
            if (!exceptionContext.ExceptionHandled &&
                                exceptionContext.Exception is ArgumentOutOfRangeException)
            {
                int val = (int)(((ArgumentOutOfRangeException)exceptionContext.Exception).ActualValue);
                exceptionContext.Result = new ViewResult
                {
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary<int>(val)
                };
                exceptionContext.ExceptionHandled = true;
            }
        }

    }
}