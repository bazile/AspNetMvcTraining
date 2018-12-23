using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WebApplicationQuizz
{
    public class QuizzRepository
    {
        //private static QuizzData quizzList;
        private Quizz[] quizzes;
        private string _xmlPath;
        private Dictionary<int, Answer> dAnswers;
        private Dictionary<int, Question> dQuestions;

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
                    dAnswers = new Dictionary<int, Answer>();
                    dQuestions = new Dictionary<int, Question>();
                    for (int i = 0, qid=1, aid=1; i < quizzes.Length; i++)
                    {
                        quizzes[i].Id = i + 1;
                        foreach (var question in quizzes[i].Questions)
                        {
                            question.Id = qid++;
                            question.IdQuizz = quizzes[i].Id;
                            dQuestions.Add(question.Id, question);
                            foreach (var answer in question.Answers)
                            {
                                answer.Id = aid++;
                                answer.IdQuestion = question.Id;
                                answer.IdQuizz = quizzes[i].Id;
                                answer.AnswerComment = answer.AnswerComment?.Trim() ?? "";
                                dAnswers.Add(answer.Id, answer);
                            }
                        }
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

        public Answer FindAnswerById(int id)
        {
            GetQuizzes();
            Answer ans = null;
            dAnswers.TryGetValue(id, out ans);
            return ans;
        }

        public Question FindQuestionById(int id)
        {
            GetQuizzes();
            Question ques = null;
            dQuestions.TryGetValue(id, out ques);
            return ques;
        }

        //public bool IsCorrect(Quizz q, string curQName, string Answ)
        public bool IsCorrect(int idAnsw)
        {
            // TODO Переписать используя SelectMany
            // использован словарь
            
            return FindAnswerById(idAnsw).Correct;
            
            //Question curQ = q.Questions.Find(a => a.QuestionText.Contains(curQName));
            //string corrAnsw = curQ.Answers.Find(a => a.Correct).AnswerText;
            //return (Answ == corrAnsw);
        }
    }
}