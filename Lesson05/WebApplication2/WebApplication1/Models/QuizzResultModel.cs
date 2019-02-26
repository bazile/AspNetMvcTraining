using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class QuizzResultModel
    {
        public string Name { get; set; }
        public QuestionResultModel[] Questions { get; set; }
    }

    public class QuestionResultModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public AnswerResultModel[] Answers { get; set; }
    }

    public class AnswerResultModel
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
