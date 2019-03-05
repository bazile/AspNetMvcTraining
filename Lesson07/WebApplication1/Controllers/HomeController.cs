using System.Linq;
using System.Web.Mvc;
using WebApplication1.EF;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var context = new SkyscraperContext())
            {
                var skyscrapers = context.Skyscrapers.ToArray();
                return View(skyscrapers);
            }
        }
    }
}