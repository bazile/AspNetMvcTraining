using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using TitanicWebApplication.Db;
using TitanicWebApplication.Models;

namespace TitanicWebApplication.Controllers
{
    public class PassengersController : Controller
    {
        //ITitanicRepository _repository;
        TitanicDbContext _dbContext;

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

            //_repository = new XmlTitanicRepository(Server.MapPath("/App_Data/titanic.xml"));
            //_repository = new TitanicDbRepository();
            _dbContext = new TitanicDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            base.Dispose(disposing);
        }

        // GET: Passengers
        public ActionResult Index(int? page)
        {
            page = page ?? 1;
            if (page < 1) page = 1;

            int paxCount = _dbContext.Passengers.Count();
            const int PAGE_SIZE = 50;
            var passengers = _dbContext.Passengers
                .OrderBy(pax => pax.FamilyName)
                .ThenBy(pax => pax.GivenName)
                .ThenByDescending(pax => pax.BirthDate)
                .Skip((page.Value - 1)*PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToArray();
            var model = new PassengersViewModel
            {
                Passengers = passengers,
                CurrentPage = 1,
                TotalPages = paxCount / PAGE_SIZE
            };
            return View(model);
			//return View(_repository.GetPassengers().OrderByDescending(pax => pax.TicketPrice).Take(25));
        }

		// GET: Passengers/Countries
		public ActionResult Countries()
		{
            //var countries = _repository.GetCountries();
            //return View(countries);

            var countries = _dbContext.Countries
                .OrderBy(c => c.Name)
                .Select(c => c.Name)
                .ToArray();
            return View(countries);
        }


		// GET: Passengers/Info
		public ActionResult Info(string id)
		{
            //string paxId = Request.QueryString["id"];

            //TitanicPassenger[] passengers = _repository.GetPassengers();
            //TitanicPassenger pax = passengers.SingleOrDefault(p => p.Id == id);
            var pax = _dbContext.Passengers.SingleOrDefault(p => p.UniqueId == id);
			if (pax == null) return HttpNotFound();
			return View(pax);
		}

		// GET: Passengers/Search
		public ActionResult Search(string search, string country)
		{
            //TitanicPassenger[] passengers = _repository.Find(search);
            //IEnumerable<TitanicPassenger> passengers = _repository.GetPassengers();
            IQueryable<TitanicDbPassenger> passengers = _dbContext.Passengers;
            if (!string.IsNullOrEmpty(search))
			{
				search = search.Trim();
				passengers = passengers.Where(pax =>
					(pax.FamilyName ?? "").Contains(search)
					|| (pax.GivenName ?? "").Contains(search)
					|| (pax.JobTitle ?? "").Contains(search));
			}
			if (!string.IsNullOrEmpty(country))
			{
				country = country.Trim();
				passengers = passengers.Where(pax => pax.Country.Name == country);
			}

			return View(passengers.ToArray());
		}
	}
}