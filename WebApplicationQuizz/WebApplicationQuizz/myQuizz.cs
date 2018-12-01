using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplicationQuizz
{
 
    [XmlRoot("quizzes")]
    public class QuizzData

    {
        [XmlElement("quiz")]
        public List<Quizz> QuizzCollection { get; set; }
        
        public QuizzData()
        {
            QuizzCollection = new List<Quizz>();
        }

    }

    public class Quizz
    {
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("q")]
        public List<Question> Questions {get;set;}

        public Quizz()
        {
            Questions = new List<Question>();
        }

        [XmlAttribute("url")]
        public string Url { get; set; }

    }
    public class Question
    {
        [XmlAttribute("text")]
        public string QuestionText { get; set; }

        [XmlElement("a")]
        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }

        //private string _selectedAnswer;
        //public string SelectedAnswer { get { return _selectedAnswer == null ? "" : _selectedAnswer; } set { _selectedAnswer = value == null ? "" : value; } }
    }
    public class Answer
    {
        [XmlAttribute("text")]
        public string AnswerText { get; set; }

        public bool _correct;
        [XmlAttribute("correct")]
        public string AnswerCorrect
        {
            get { return !_correct ? "no" : "yes"; }
            set { _correct = value == "yes" ? true : false; }
        }

        [XmlText]
        public string AnswerComment { get; set; }
  
    }

    

}