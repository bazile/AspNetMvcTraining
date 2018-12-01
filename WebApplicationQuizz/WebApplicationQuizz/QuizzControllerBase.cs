using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationQuizz
{
    public class QuizzControllerBase : Controller
    {
        protected QuizzRepository quizzRepository;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            quizzRepository = (QuizzRepository)HttpContext.Application["quizzRepository"];
        }
    }
}
