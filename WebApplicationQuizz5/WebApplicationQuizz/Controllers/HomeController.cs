using System.Linq;
using System.Web.Mvc;
using WebApplicationQuizz.Models;

namespace WebApplicationQuizz.Controllers
{
    public class HomeController : QuizzControllerBase
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Title = "Тесты на любой вкус";
            return View(quizzRepository.GetQuizzes()
                .Select(qn => new QuizzInfoModel { Id = qn.Id, Name = qn.Name })
                .ToList()
            );
        }
	}
}