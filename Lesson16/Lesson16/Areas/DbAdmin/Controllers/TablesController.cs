using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson16.Areas.DbAdmin.Controllers
{
    public class TablesController : Controller
    {
        // GET: DbAdmin/Tables
        public ActionResult Index()
        {
            return View();
        }
    }
}
