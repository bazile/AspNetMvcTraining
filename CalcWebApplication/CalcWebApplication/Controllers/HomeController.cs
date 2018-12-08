using CalcWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalcWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calculate(CalcModel model)
        {
            //int numA = int.Parse(a);
            //int numB = int.Parse(b);
            int? result = null;
            //model.Result = null;
            switch (model.Op)
            {
                case "+": result = model.A + model.B; break;
                case "-": result = model.A - model.B; break;
                case "*": result = model.A * model.B; break;
                case "/": result = model.A / model.B; break;
            }

            return View(new CalcViewModel
            {
                A = model.A, B = model.B, Op = model.Op, Result = result
            });
        }
    }
}