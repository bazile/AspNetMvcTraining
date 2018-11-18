using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace TitanicWebApplication.Controllers
{
    public class PassengersController : Controller
    {
		ITitanicRepository _repository;

		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			//_repository = new XmlTitanicRepository(@"D:\Петрухин\Temp\TitanicWebApplication\TitanicWebApplication\App_Data\titanic.xml");
			_repository = new XmlTitanicRepository(Server.MapPath("/App_Data/titanic.xml"));
		}

		// GET: Passengers
		public ActionResult Index()
        {
			return View(_repository.GetPassengers().OrderByDescending(pax => pax.TicketPrice).Take(25));
        }

		// GET: Passengers/Info
		public ActionResult Info(string id)
		{
			//string paxId = Request.QueryString["id"];

			TitanicPassenger[] passengers = _repository.GetPassengers();
			TitanicPassenger pax = passengers.SingleOrDefault(p => p.Id == id);
			if (pax == null) return HttpNotFound();
			return View(pax);
		}

		// GET: Passengers/Search
		public ActionResult Search(string search)
		{
			TitanicPassenger[] passengers = _repository.Find(search);
			return View(passengers);
		}
	}
}