using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SayHello()
        {
            return View();
        }

        public ActionResult SayHelloHandler(string personName)
        {
            string someInput = Request.QueryString["someInput"];

            return View("SayHello", (object)personName);
        }

        public ActionResult Calc()
        {
            return View();
        }

        public ActionResult CalcHandler(int num1, string op, int num2)
        {
            double result = 0;
            switch (op)
            {
                case "+": result = num1 + num2; break;
                case "-": result = num1 - num2; break;
                case "*": result = num1 * num2; break;
                case "/": result = (double)num1 / num2; break;
            }
            return View("Calc", result);
        }
    }
}
