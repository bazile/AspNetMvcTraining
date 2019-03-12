using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson08.Views
{
    public class TestOneController : Controller
    {
        // GET: TestOne
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestOne/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestOne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestOne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestOne/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestOne/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestOne/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestOne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
