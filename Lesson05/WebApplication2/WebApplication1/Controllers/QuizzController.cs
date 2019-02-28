using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
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

        [HttpPost]
        public ActionResult Check()
        {
            int index = int.Parse(Request.Form["index"]);
            Quizz quizz = LoadQuizzes().SingleOrDefault(q => q.Index == index);
            if (quizz == null) return HttpNotFound();

            int correct = 0, incorrect = 0;
            for (int i=0; i<quizz.Questions.Length; i++)
            {
                //Question q = quizz.Questions[i];
                //string userAnswerText = Request.Form["q" + (i + 1)];
                //Answer answer = q.Answers.Single(a => a.Text == userAnswerText);
                //if (answer.IsCorrect)
                //    correct++;
                //else
                //    incorrect++;

                //string userAnswerText = Request.Form["q" + (i + 1)];
                //if (userAnswerText == "yes")
                //    correct++;
                //else
                //    incorrect++;

                int answerIndex = int.Parse(Request.Form["q" + quizz.Questions[i].Index]);
                Answer answer = quizz.Questions[i].Answers.Single(a => a.Index == answerIndex);
                if (answer.IsCorrect)
                    correct++;
                else
                    incorrect++;
            }
            var model = new CheckResultModel { Correct = correct, Incorrect = incorrect };
            return View(model);
        }

        [HttpPost]
        public ActionResult Check2()
        {
            int index = int.Parse(Request.Form["index"]);
            Quizz quizz = LoadQuizzes().SingleOrDefault(q => q.Index == index);
            if (quizz == null) return HttpNotFound();

            var model = new QuizzResultModel() { Name = quizz.Name };
            model.Questions = quizz.Questions.Select(q => new QuestionResultModel
            {
                Text = q.Text,
                Index = q.Index,
                Answers = q.Answers.Select(a => new AnswerResultModel { Text = a.Text, Index = a.Index, IsCorrect = a.IsCorrect }).ToArray()
            }).ToArray();

            foreach (var question in quizz.Questions)
            {
                int answerIndex = int.Parse(Request.Form["q" + question.Index]);
                Answer answer = question.Answers.Single(a => a.Index == answerIndex);

                var userQuestion = model.Questions.Single(q => q.Index == question.Index);
                var userAnswer = userQuestion.Answers.Single(a => a.Index == answerIndex);
                userQuestion.IsCorrect = answer.IsCorrect;
            }

            return View(model);
        }
    }
}
