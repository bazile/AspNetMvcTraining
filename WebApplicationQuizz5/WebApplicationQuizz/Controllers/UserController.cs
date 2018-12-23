using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQuizz.Db;
using WebApplicationQuizz.Models;

namespace WebApplicationQuizz.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult History()
        {
            string userLogin = Request.Cookies["user"]?.Value;
            if (userLogin == null)
            {
                ViewBag.Title = "Извините, для незарегистрированного пользователя данные не сохраняются";
                return View();
            }

            using (var context = new QuizzDbContext())
            {
                var resHistory = context.QuizzUsersHistory
                     .Where(h => h.User.Login == userLogin)
                     .OrderByDescending(d => d.QuizzDate)
                     .Select(h => new HistoryModel { QuizzName = h.QuizzName, QuizzResult = h.QuizzResult, QuizzDate = h.QuizzDate })
                     .ToArray();

                if (resHistory == null) ViewBag.Title = "Для пользователя " + userLogin + " результатов не найдено";
                else ViewBag.Title = "Результаты для пользователя " + userLogin;
                return View(resHistory);
            }
            
        }
    }
}