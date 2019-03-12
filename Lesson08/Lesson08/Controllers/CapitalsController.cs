using Lesson08.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson08.Controllers
{
    public class CapitalsController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new MyDbContext())
            {
                var capitals = context.Cities.AsNoTracking().ToArray();
                return View(capitals);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var context = new MyDbContext())
            {
                var capital = context.Cities.AsNoTracking().SingleOrDefault(c => c.Id == id);
                if (capital == null) return HttpNotFound();
                return View(capital);
            }
        }

        public ActionResult Edit2(int id)
        {
            using (var context = new MyDbContext())
            {
                var capital = context.Cities.AsNoTracking().SingleOrDefault(c => c.Id == id);
                if (capital == null) return HttpNotFound();
                return View(capital);
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, string partOfWorld, string country, string capitalCity)
        {
            using (var context = new MyDbContext())
            {
                var capital = context.Cities.SingleOrDefault(c => c.Id == id);
                if (capital == null) return HttpNotFound();

                capital.PartOfWorld = partOfWorld;
                capital.Country = country;
                capital.CapitalCity = capitalCity;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}