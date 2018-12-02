﻿using System.Linq;
using System.Web.Mvc;
using WebApplicationQuizz.Models;

namespace WebApplicationQuizz.Controllers
{
    public class QuizzAdminController : QuizzControllerBase
    {
        public ActionResult EditQuestion(int id, int quizzId)
        {
            var question = quizzRepository.GetQuizzes()
                .SingleOrDefault(q => q.Id == quizzId)?.Questions
                .SingleOrDefault(q => q.Id == id);
            if (question == null) return HttpNotFound();

            return View(question);
        }

        public ActionResult EditAnswer(int id, int quizzId, int questionId)
        {
            //var answer = quizzRepository.GetQuizzes()
            //    .SelectMany(q => q.Questions)
            //    .SelectMany(q => q.Answers)
            //    .SingleOrDefault(a => a.Id == id);
            var answer = quizzRepository.GetQuizzes()
                .SingleOrDefault(q => q.Id == quizzId)?.Questions
                .SingleOrDefault(q => q.Id == questionId)?.Answers
                .SingleOrDefault(a => a.Id == id);
            if (answer == null) return HttpNotFound();
            var model = new EditAnswerModel
            {
                Id = answer.Id,
                QuizzId = quizzId,
                QuestionId = questionId,
                Text = answer.AnswerText,
                Comment = answer.AnswerComment,
                Correct = answer.Correct
            };
            return View(model);
        }

        [HttpPost]
        //public ActionResult EditAnswer(int id, string text, string comment, bool correct)
        public ActionResult EditAnswer(EditAnswerModel model)
        {
            //var answer = quizzRepository.GetQuizzes()
            //    .SelectMany(q => q.Questions)
            //    .SelectMany(q => q.Answers)
            //    .SingleOrDefault(a => a.Id == id);
            var answer = quizzRepository.GetQuizzes()
                .SingleOrDefault(q => q.Id == model.QuizzId)?.Questions
                .SingleOrDefault(q => q.Id == model.QuestionId)?.Answers
                .SingleOrDefault(a => a.Id == model.Id);

            if (answer == null) return HttpNotFound();

            answer.AnswerText = model.Text.Trim();
            answer.AnswerComment = model.Comment?.Trim() ?? "";
            // TODO Добавить свойство Question
            //foreach (var ans in answer.Question.Answers)
            //{
            //    ans.Correct = false;
            //}
            answer.Correct = true;

            return RedirectToAction("Index", "Quizz", new { id = model.QuizzId });
        }
    }
}