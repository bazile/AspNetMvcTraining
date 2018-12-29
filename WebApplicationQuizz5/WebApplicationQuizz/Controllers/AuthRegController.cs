using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQuizz.Db;
using WebApplicationQuizz.Models;

namespace WebApplicationQuizz.Controllers
{
    public class AuthRegController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Err = String.Empty;
            return View();
        }


        [HttpPost]
        public ActionResult Login(RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var context = new QuizzDbContext())
            {
                //string passHash = HashHelper.CalculatePasswordHash(pass);
                //if (context.QuizzUsers.SingleOrDefault(u => u.Login == user && u.Password == pass) != null)
                //if (context.QuizzUsers.SingleOrDefault(u => u.Login == user && u.PasswordHash == passHash) != null)
                //{
                //    Response.Cookies.Add(new HttpCookie("user", user) { Expires = DateTime.Now.AddMonths(6) });
                //    return RedirectToAction("Index","Home"); // авторизация и регистрация будут только на основном окне
                //}

                var dbUser = context.QuizzUsers.SingleOrDefault(u => u.Login == model.User);
                if (dbUser != null)
                {
                    string passHash = HashHelper.CalculatePasswordHash(model.Pass, Convert.FromBase64String(dbUser.PasswordSalt));
                    if (passHash == dbUser.PasswordHash)
                    {
                        Response.Cookies.Add(new HttpCookie("user", model.User) { Expires = DateTime.Now.AddMonths(6) });
                        return RedirectToAction("Index", "Home"); // авторизация и регистрация будут только на основном окне
                    }
                }

            }
            
            ViewBag.Err = "Проверьте имя пользователя и пароль";
            return View(model);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //if (user.Trim().Length == 0)
            //{
            //    ViewBag.Err = "Поле Login не может быть пустым!";
            //    return View("Login",(object)"Registration");
            //}

            //if (pass.Trim().Length == 0)
            //{
            //    ViewBag.Err = "Поле Password не может быть пустым!";
            //    return View("Login",(object)"Registration");
            //}

            model.User = model.User.Trim();
            using (var context = new QuizzDbContext())
            {
                string passwordSalt;
                byte[] saltBytes = new byte[10];
                using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    rng.GetBytes(saltBytes);
                    passwordSalt = Convert.ToBase64String(saltBytes);
                }

                // добавляем нового пользователя
                QuizzDbUser newUser = new QuizzDbUser
                {
                    Login = model.User,
                    //Password = pass
                    PasswordSalt = passwordSalt,
                    PasswordHash = HashHelper.CalculatePasswordHash(model.Pass, saltBytes)
                };
                context.QuizzUsers.Add(newUser);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException ex)
                //catch (SqlException ex) when (ex.ErrorCode == 2601)
                {
                    var baseEx = ex.GetBaseException();
                    if (baseEx is SqlException sqlEx)
                    {
                        if (sqlEx.Number != 2601) throw;

                        // AJAX Async JavaScript and XML
                        //ModelState.AddModelError("uniqueUser", "Данное имя пользователя уже используется");
                        ModelState[nameof(model.User)].Errors.Add("Данное имя пользователя уже используется");
                        return View(model);
                    }
                }

                Response.Cookies.Add(new HttpCookie("user", model.User) {Expires = DateTime.Now.AddMonths(6) });
                return RedirectToAction("Index", "Home"); 
            }
            
        }

        public ActionResult Logout()
        {
            Response.Cookies.Add(new HttpCookie("user") { Expires = DateTime.Now.AddDays(-1) });
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult CheckUserName(string user)
        {
            bool userExists;
            using (var context = new QuizzDbContext())
            {
                userExists = context.QuizzUsers.Count(u => u.Login == user) == 1;
            }
            // false - ошибка валидации
            return Json(!userExists, JsonRequestBehavior.DenyGet);
        }
    }
}