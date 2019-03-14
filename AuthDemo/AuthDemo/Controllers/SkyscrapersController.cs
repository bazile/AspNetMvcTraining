using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthDemo.EF;

namespace AuthDemo.Controllers
{
    public class SkyscrapersController : Controller
    {
        private SkyscrapersContext db = new SkyscrapersContext();

        // GET: Skyscrapers
        public ActionResult Index()
        {
            return View(db.Skyscrapers.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
