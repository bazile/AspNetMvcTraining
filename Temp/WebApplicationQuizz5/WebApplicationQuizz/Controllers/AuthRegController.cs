using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQuizz.Db;

namespace WebApplicationQuizz.Controllers
{
    public class AuthRegController : Controller
    {
        // GET: AuthReg
        public ActionResult Login(string d)
        {
            ViewBag.Err = String.Empty;
            return View((object)d);
        }


        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            using (var context = new QuizzDbContext())
            {
                //string passHash = HashHelper.CalculatePasswordHash(pass);
                //if (context.QuizzUsers.SingleOrDefault(u => u.Login == user && u.Password == pass) != null)
                //if (context.QuizzUsers.SingleOrDefault(u => u.Login == user && u.PasswordHash == passHash) != null)
                //{
                //    Response.Cookies.Add(new HttpCookie("user", user) { Expires = DateTime.Now.AddMonths(6) });
                //    return RedirectToAction("Index","Home"); // авторизация и регистрация будут только на основном окне
                //}

                var dbUser = context.QuizzUsers.SingleOrDefault(u => u.Login == user);
                if (dbUser != null)
                {
                    string passHash = HashHelper.CalculatePasswordHash(pass, Convert.FromBase64String(dbUser.PasswordSalt));
                    if (passHash == dbUser.PasswordHash)
                    {
                        Response.Cookies.Add(new HttpCookie("user", user) { Expires = DateTime.Now.AddMonths(6) });
                        return RedirectToAction("Index", "Home"); // авторизация и регистрация будут только на основном окне
                    }
                }

            }
            
            ViewBag.Err = "Проверьте имя пользователя и пароль";
            return View((object)"Login");
        }

        [HttpPost]
        public ActionResult Registration(string user, string pass)
        {
            if (user.Trim().Length == 0)
            {
                ViewBag.Err = "Поле Login не может быть пустым!";
                return View("Login",(object)"Registration");
            }

            if (pass.Trim().Length == 0)
            {
                ViewBag.Err = "Поле Password не может быть пустым!";
                return View("Login",(object)"Registration");
            }


            using (var context = new QuizzDbContext())
            {
                // проверка на существование
                if (context.QuizzUsers.SingleOrDefault(u => u.Login == user) != null)
                {
                    ViewBag.Err = "Пользователь " + user + " уже существует! Пожалуйста, выберите другое имя.";
                    return View("Login",(object)"Registration");
                }

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
                    Login = user,
                    //Password = pass
                    PasswordSalt = passwordSalt,
                    PasswordHash = HashHelper.CalculatePasswordHash(pass, saltBytes)
                };
                context.QuizzUsers.Add(newUser);
                context.SaveChanges();

                //сразу авторизация
                //RedirectToAction("Login", "AuthReg", new {user = user, pass = pass}) // тогда обращаться к базе придётся дважды
                Response.Cookies.Add(new HttpCookie("user", user) {Expires = DateTime.Now.AddMonths(6) });
                return RedirectToAction("Index", "Home"); 
            }
            
        }

        public ActionResult Logout()
        {
            Response.Cookies.Add(new HttpCookie("user") { Expires = DateTime.Now.AddDays(-1) });
            return RedirectToAction("Index", "Home");
        }
    }
}