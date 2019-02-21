using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebApplication2.Models;

namespace WebApplication2
{
    public class BaseController : Controller
    {
        static Quizz[] quizzes;

        protected Quizz[] LoadQuizzes()
        {
            if (quizzes == null)
            {
                //XDocument xdoc = XDocument.Load(HostingEnvironment.MapPath("/App_Data/quizzes.xml"));
                //quizzes = xdoc.Element("quizzes")
                //    .Elements("quiz")
                //    .Select((xquizz, idx) => new Quizz
                //    {
                //        Index = idx + 1,
                //        Name = xquizz.Attribute("name").Value,
                //        Questions = xquizz.Elements("q").Select(xq => new Question
                //        {
                //            Text = xq.Attribute("text").Value,
                //            Answers = xq.Elements("a").Select(xa => new Answer
                //            {
                //                Text = xa.Attribute("text").Value,
                //                IsCorrect = xa.Attribute("correct")?.Value == "yes"
                //                //IsCorrect = xa.Attribute("correct") == null ? false : xa.Attribute("correct").Value == "yes"
                //            }).ToArray()
                //        }).ToArray()
                //    }).ToArray();
                string xmlPath = HostingEnvironment.MapPath("/App_Data/quizzes.xml");
                using (var fstream = System.IO.File.OpenRead(xmlPath))
                {
                    var serializer = new XmlSerializer(typeof(Quizzes));
                    Quizzes xmlQuizzes = (Quizzes)serializer.Deserialize(fstream);
                    quizzes = xmlQuizzes.AllQuizzes;
                }

                int index = 1;
                foreach (var quizz in quizzes)
                {
                    quizz.Index = index++;
                }
            }
            return quizzes;
        }
    }
}