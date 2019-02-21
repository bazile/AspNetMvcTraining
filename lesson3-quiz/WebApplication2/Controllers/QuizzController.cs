using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class QuizzController : BaseController
    {
        // GET: Quizz
        public ActionResult Index(int id)
        {
            Quizz quizz = LoadQuizzes().SingleOrDefault(q => q.Index == id);
            if (quizz != null)
            {
                return View(quizz);
            }
            else
            {
                return HttpNotFound(); // 404
            }
        }
    }
}