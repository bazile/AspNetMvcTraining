using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationQuizz
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Context.Application["quizzRepository"] = new QuizzRepository(Server.MapPath("/App_Data/quizzes.xml"));
        }
    }
}
