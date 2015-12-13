using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Autobase.Helpers
{
    //Check authorized user for a role
    public class RoleAuthorizedAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole(this.Roles))
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new
                {
                    controller = "Error",
                    action = "AccessDenied",
                    area = ""
                }));
            }
        }
    }
}