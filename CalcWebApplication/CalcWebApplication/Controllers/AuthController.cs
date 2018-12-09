using CalcWebApplication.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalcWebApplication.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string user, string pwd)
        {
            using (var context = new CalcContext())
            {
                //if (user == "admin" && pwd == "1234")
                if (context.Users.SingleOrDefault(u => u.Login == user && u.Password == pwd) != null)
                {
                    Response.Cookies.Add(new HttpCookie("user", user));
                    return RedirectToAction("Index", "Home");
                }
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            Response.Cookies.Add(new HttpCookie("user") { Expires = DateTime.Now.AddMonths(-6) });
            return RedirectToAction("Index", "Home");
        }
    }
}