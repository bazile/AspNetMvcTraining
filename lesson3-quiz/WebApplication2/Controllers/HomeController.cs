using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var quizzes = LoadQuizzes();
            return View(quizzes);
        }
    }
}
