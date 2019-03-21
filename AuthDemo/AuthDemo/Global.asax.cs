using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace AuthDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var identity = HttpContext.Current.User?.Identity;
            if (identity?.IsAuthenticated == true)
            {
                if (identity is FormsIdentity id) // pattern matching
                {
                    FormsAuthenticationTicket ticket = id.Ticket;

                    // Get the stored user-data, in this case, our roles
                    //string userData = ticket.UserData;
                    //string[] roles = userData.Split(',');
                    string[] roles = new[] { ticket.UserData };
                    HttpContext.Current.User = new GenericPrincipal(id, roles);
                }
            }
        }
    }
}
