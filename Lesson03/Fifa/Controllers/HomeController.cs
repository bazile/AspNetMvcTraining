using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        // /Home/InYear/1930?mode=detailed
        public ActionResult InYear(int? id, string mode)
        {
            Stat oneWorldCup = id == null ? null : WorldCups.All.SingleOrDefault(wc => wc.Year == id.Value);
            if (oneWorldCup != null)
            {
                ViewBag.Title = "ЧМ " + oneWorldCup.Year + " " + string.Join(", ", oneWorldCup.Hosts);
                return mode == "detailed"
                    ? View("InYearDetailed", oneWorldCup)
                    : View(oneWorldCup);
            }
            else
            {
                return HttpNotFound(); // 404
            }
        }

        public ActionResult TestContent()
        {
            return Content("<h1>Привет!</h1>");
        }

        public ActionResult ExportToCsv()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var stat in WorldCups.All)
            {
                sb.AppendLine($"{stat.Year},{stat.Hosts[0]},{stat.Team1},{stat.Team2},{stat.Score12}");
            }
            return Content(sb.ToString(), "text/plain");
        }
    }
}