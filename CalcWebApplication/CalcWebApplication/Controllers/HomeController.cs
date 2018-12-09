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
            ViewData["a"] = Request.Cookies["a"]?.Value ?? "";
            ViewData["op"] = Request.Cookies["op"]?.Value ?? "";
            ViewData["b"] = Request.Cookies["b"]?.Value ?? "";

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

            if (result.HasValue)
            {
                var prevCalculations = (List<CalcModel>)Session["prevCalculations"];
                if (prevCalculations == null)
                {
                    prevCalculations = new List<CalcModel>();
                    Session["prevCalculations"] = prevCalculations;
                }
                prevCalculations.Add(model);
            }

            return View(new CalcViewModel
            {
                A = model.A, B = model.B, Op = model.Op, Result = result
            });
        }

        public ActionResult Configure()
        {
            ViewData["a"] = Request.Cookies["a"]?.Value ?? "";
            ViewData["op"] = Request.Cookies["op"]?.Value ?? "";
            ViewData["b"] = Request.Cookies["b"]?.Value ?? "";
            return View();
        }

        [HttpPost]
        public ActionResult Configure(string a, string op, string b)
        {
            DateTime defaultExpire = DateTime.Now.AddYears(1);

            if (int.TryParse(a, out _))
            {
                // "Постоянная" cookie
                Response.Cookies.Add(new HttpCookie("a", a.Trim()) { Expires = defaultExpire });
            }

            if (int.TryParse(b, out _))
            {
                // "Постоянная" cookie
                Response.Cookies.Add(new HttpCookie("b", b.Trim()) { Expires = defaultExpire });
            }

            string[] validOperators = { "+", "-", "/", "*" };
            if (validOperators.Contains(op))
            {
                // Сессионная cookie
                //Response.Cookies.Add(new HttpCookie("op", op));
                // "Постоянная" cookie
                Response.Cookies.Add(new HttpCookie("op", op) { Expires = defaultExpire });
            }

            return RedirectToAction("Index");
        }
    }
}