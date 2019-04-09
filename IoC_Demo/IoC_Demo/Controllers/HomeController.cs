using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IoC_Demo.Controllers
{
    public class HomeController : Controller
    {
        // IoC = Inversion of Control
        ISmtpSender _smtp;

        //public HomeController(ISmtpSender smtp)
        //{
        //    _smtp = smtp;
        //}

        public async Task<ActionResult> Index()
        {
            await _smtp.SendEmail("somebody@gamial.com", "Hello!", "<b>Hello</b>");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}