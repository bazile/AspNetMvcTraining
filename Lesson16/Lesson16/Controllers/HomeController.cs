using Lesson16.Currencies;
using Lesson16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson16.Controllers
{
    public class HomeController : Controller
    {
        PersonViewModel[] famousPeople = new PersonViewModel[]
        {
                new PersonViewModel { Id = 1, Name = "Lawrence N. Guarino", BirthDate = new DateTime(1922, 4, 16) },
                new PersonViewModel { Id = 2, Name = "Vadim Kuzmin", BirthDate = new DateTime(1936, 4, 16) },
                new PersonViewModel { Id = 3, Name = "José de Diego", BirthDate = new DateTime(1866, 4, 16) },
        };

        public ActionResult Index()
        {
            return View(famousPeople);
        }

        public ActionResult EditPerson(int id)
        {
            PersonViewModel person = famousPeople.Single(p => p.Id == id);
            return View(person);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public async Task<PartialViewResult> GetRatesHtml()
        {
            ICurrencyRates rateSource = new CachedCurrencyRates(new NbrbCurrencyRates());
            var rates = await rateSource.GetCurrentRatesAsync();
            return PartialView("CurrencyRates", rates);
        }
    }
}