using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson06.Controllers
{
    public class CookiesController : Controller
    {
        // GET: Cookies
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            Response.Cookies.Add(new HttpCookie("mycookie1", "123") { Expires = DateTime.Now.AddDays(100) });
            Response.Cookies.Add(new HttpCookie("mycookie2", "abc"));
            //return View("Index");
            return RedirectToAction("Index");
        }

        public ActionResult Clear()
        {
            foreach (string cookieName in Request.Cookies.Cast<string>().ToArray())
            {
                Response.Cookies.Add(new HttpCookie(cookieName, "") { Expires = DateTime.Now.AddYears(-1) } );
            }

            return RedirectToAction("Index");
        }
    }
}