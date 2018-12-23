using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplicationQuizz.Db;
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
        //public ActionResult Results(int id, FormCollection frms) 
        public ActionResult Index(int [] idAnswered, int quizzId)
        {
            Quizz quizz = quizzRepository.FindQuizzById(quizzId);

            int kolvoCorrect = 0;
            if (idAnswered != null)
            {
                for (int i = 0; i < idAnswered.Length; i++)
                {
                    // if (quizzRepository.IsCorrect(quizz, frms.AllKeys[i],frms[i])) kolvoCorrect++;
                    if (quizzRepository.IsCorrect(idAnswered[i])) kolvoCorrect++;
                }
            }

            //ViewData["res"] = "Вы ответили верно на " +kolvoCorrect + " вопросов из "+ quizz.Questions.Count;
            //ViewBag.Title = "Результаты для теста " + quizz.Name;

            return RedirectToAction("Results", "Quizz", new ResultsModel{Title = "Результаты для теста " + quizz.Name, sResult= "Вы ответили верно на " + kolvoCorrect + " вопросов из " + quizz.Questions.Count });
        }

        public ActionResult Results(ResultsModel s)
        {
            // если пользователь в системе сохраняем рез-ты в базе
            if (Request.Cookies["user"] != null)
            {
                using (var context = new QuizzDbContext())
                {
                    string currentUser = Request.Cookies["user"].Value;
                    QuizzDbHistory newH = new QuizzDbHistory
                    {
                        //Login = Request.Cookies["user"].Value.ToString(),
                        User = context.QuizzUsers.Single(u => u.Login == currentUser),
                        QuizzName = s.Title,
                        QuizzResult = s.sResult,
                        QuizzDate = DateTime.Now
                    };
                    context.QuizzUsersHistory.Add(newH);
                    context.SaveChanges();
                }
            }


            ViewData["res"] = s.sResult;
            ViewBag.Title = s.Title;
            return View();
        }
    }
}
