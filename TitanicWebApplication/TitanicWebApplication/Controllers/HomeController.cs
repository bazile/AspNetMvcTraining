using System.Web.Mvc;

namespace TitanicWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //using (var repository = new TitanicDbRepository())
            //{
            //    var passengers = repository.GetPassengers();
            //}
            return View();
        }
    }
}
