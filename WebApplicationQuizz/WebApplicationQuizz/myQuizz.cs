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
        [XmlIgnore]
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
        [XmlIgnore]
        public int Id { get; set; }

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
        [XmlIgnore]
        public int Id { get; set; }

        [XmlAttribute("text")]
        public string AnswerText { get; set; }

        [XmlIgnore]
        public bool Correct { get; set; }

        [XmlAttribute("correct")]
        public string AnswerCorrect
        {
            get { return !Correct ? "no" : "yes"; }
            set { Correct = value == "yes" ? true : false; }
        }

        [XmlText]
        public string AnswerComment { get; set; }
    }
}
