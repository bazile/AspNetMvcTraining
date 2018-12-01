using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplicationQuizz
{
    public class QuizzRepository
    {
        //private static QuizzData quizzList;
        private Quizz[] quizzes;
        private string _xmlPath;
        public QuizzRepository(string path)
        {
            _xmlPath = path;
        }

        public Quizz[] GetQuizzes()
        {
            if (quizzes == null)
            {
                using (var fstream = File.OpenRead(_xmlPath))
                {
                    XmlSerializer s = new XmlSerializer(typeof(QuizzData));
                    quizzes = ((QuizzData)s.Deserialize(fstream)).QuizzCollection.ToArray();
                    for (int i = 0; i < quizzes.Length; i++)
                    {
                        quizzes[i].Id = i + 1;
                    }
                }
            }
         
            return quizzes;
        }

        public Quizz FindQuizz(string testTxt)
        {
            return GetQuizzes().SingleOrDefault(t => t.Name == testTxt);
        }

        public Quizz FindQuizzById(int id)
        {
            return GetQuizzes().SingleOrDefault(t => t.Id == id);
        }

        public bool IsCorrect(Quizz q, string curQName ,string Answ)
        {
            Question curQ = q.Questions.Find(a => a.QuestionText.Contains(curQName));
            string corrAnsw = curQ.Answers.Find(a => a._correct == true).AnswerText;
            return (Answ == corrAnsw);
        }
    }
}