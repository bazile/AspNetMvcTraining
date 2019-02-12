using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fifa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.AllWorldCups = WorldCups.All;
            return View(WorldCups.All.OrderByDescending(s => s.Year).ToArray());
        }

        //// /Home/InYear?year=1930
        //public ActionResult InYear(int year)
        //{
        //    return View();
        //}

        // /Home/InYear/1930
        public ActionResult InYear(int id)
        {
            Stat oneWorldCup = WorldCups.All.Single(wc => wc.Year == id);
            //ViewBag.OneWorldCup = oneWorldCup;
            ViewBag.Title = "ЧМ " + oneWorldCup.Year + " " + string.Join(", ", oneWorldCup.Hosts);
            return View(oneWorldCup);
        }

    }
}