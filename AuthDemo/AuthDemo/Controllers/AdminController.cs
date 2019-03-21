using AuthDemo.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthDemo.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private SkyscrapersContext db = new SkyscrapersContext();

        [AllowAnonymous]
        // GET: Admin
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View(db.Skyscrapers);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            bool authenticated = false;
            if (!string.IsNullOrWhiteSpace(login) && !string.IsNullOrWhiteSpace(password))
            {
                //authenticated = context.Users.SingleOrDefault(u => u.Login == login && u.Password == password) != null;
                User user = db.Users.SingleOrDefault(u => u.Login == login);
                if (user != null)
                {
                    authenticated = PBKDF2HashHelper.VerifyPassword(password, user.PasswordHash);
                }
            }

            if (authenticated)
            {
                //Response.Cookies.Add(new HttpCookie("user", login) { Expires = DateTime.Now.AddDays(300) });
                //FormsAuthentication.SetAuthCookie(login, true);
                SetAuthCookie(login);
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        void SetAuthCookie(string login, string role = "Admins")
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, // Ticket version
                    login, // Username associated with ticket
                    DateTime.Now, // Date/time issued
                    DateTime.Now.AddDays(100), // Date/time to expire
                    true, // "true" for a persistent user cookie
                    role, // User-data, in this case the roles
                    FormsAuthentication.FormsCookiePath);// Path cookie valid for

            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash) { HttpOnly = true };
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            //if (null != Request.Cookies["user"])
            //{
            //    Response.Cookies.Add(new HttpCookie("user", "") { Expires = DateTime.Now.AddDays(-1000) });
            //}
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // -----

        
        // GET: Skyscrapers/Create
        public ActionResult CreateSkyscraper()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Skyscrapers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSkyscraper([Bind(Include = "Id,Name,Country,City,Height,Year")] Skyscraper skyscraper)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Skyscrapers.Add(skyscraper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skyscraper);
        }

        // GET: Skyscrapers/Edit/5
        public ActionResult EditSkyscraper(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skyscraper skyscraper = db.Skyscrapers.Find(id);
            if (skyscraper == null)
            {
                return HttpNotFound();
            }
            return View(skyscraper);
        }

        // POST: Skyscrapers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkyscraper([Bind(Include = "Id,Name,Country,City,Height,Year")] Skyscraper skyscraper)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                db.Entry(skyscraper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skyscraper);
        }

        // GET: Skyscrapers/Delete/5
        public ActionResult DeleteSkyscraper(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skyscraper skyscraper = db.Skyscrapers.Find(id);
            if (skyscraper == null)
            {
                return HttpNotFound();
            }
            return View(skyscraper);
        }

        // POST: Skyscrapers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkyscraperConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            Skyscraper skyscraper = db.Skyscrapers.Find(id);
            db.Skyscrapers.Remove(skyscraper);
            db.SaveChanges();
            return RedirectToAction("Index");
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