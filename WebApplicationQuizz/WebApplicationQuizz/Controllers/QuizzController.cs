using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationQuizz.Models;

namespace WebApplicationQuizz.Controllers
{
    public class QuizzController : QuizzControllerBase
    {
        //
        // GET: /Quizz/

        public ActionResult Index(int id)
        {
            var quizz = quizzRepository.FindQuizzById(id);
            ViewBag.Title = quizz.Name;
            return View(quizz);
        }

        public ActionResult Edit(int id)
        {
            var quizz = quizzRepository.FindQuizzById(id);
            ViewBag.Title = quizz.Name;
            var model = new EditQuizzModel { Id = quizz.Id, CurrentName = quizz.Name, OriginalName = quizz.Name };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, string name)
        {
            var quizz = quizzRepository.FindQuizzById(id);
            name = (name ?? "").Trim();
            if (name.Length > 0)
            {
                quizz.Name = name;
                return RedirectToAction("Index", "Home");
            }

            var model = new EditQuizzModel
            {
                Id = quizz.Id,
                CurrentName = name,
                OriginalName = quizz.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Results(int id, FormCollection frms) 
        {
            Quizz quizz = quizzRepository.FindQuizzById(id);
            ViewBag.Title = "Результаты для теста " + quizz.Name;

            int kolvoCorrect = 0;

            for (int i = 0; i < frms.Count; i++)
            {
                if (quizzRepository.IsCorrect(quizz, frms.AllKeys[i],frms[i])) kolvoCorrect++;
            }

            ViewData["res"] = "Вы ответили верно на " +kolvoCorrect + " вопросов из "+ quizz.Questions.Count;
            return View();
        }
    }
}
