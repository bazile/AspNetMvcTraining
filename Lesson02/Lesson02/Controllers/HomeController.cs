using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson02.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //public ActionResult Index()
        //{
        //    string[] monthNames = CultureInfo.CurrentCulture
        //        .DateTimeFormat
        //        .MonthNames
        //        .Take(12)
        //        .ToArray();
        //    ViewBag.MonthNames = monthNames;
        //    //System.Web.Mvc.BindAttribute
        //    return View();
        //}

        public ActionResult Index(string culture)
        {
            CultureInfo ci = string.IsNullOrEmpty(culture) ? CultureInfo.CurrentCulture : CultureInfo.GetCultureInfo(culture);
            string[] monthNames = ci.DateTimeFormat
                .MonthNames
                .Take(12)
                .ToArray();
            ViewBag.MonthNames = monthNames;

            return View();
        }

        //public ActionResult Add(string a, string b)
        //{
        //    ViewBag.Result = int.Parse(a) + int.Parse(b);
        //    return View();
        //}

        // /Home/Add/?a=100&b=-15
        public ActionResult Add(int? a, int? b)
        {
            ViewBag.Result = (a ?? 100) + (b ?? -100);
            return View();
        }

    }
}
