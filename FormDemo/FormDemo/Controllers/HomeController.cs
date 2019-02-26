using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormDemo.Models;

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

        [HttpGet]
        public ActionResult Calc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calc(InputCalcData data)
        {
            double? result = null;
            switch (data.Op)
            {
                case "+": result = data.Num1 + data.Num2; break;
                case "-": result = data.Num1 - data.Num2; break;
                case "*": result = data.Num1 * data.Num2; break;
                case "/": result = (double)data.Num1 / data.Num2; break;
            }
            CalcData model = null;
            if (result != null) model = new CalcData
            {
                Num1 = data.Num1, Num2 = data.Num2,
                Op = data.Op,
                Result = result.Value
            };
            return View("Calc", model);
        }
    }
}
