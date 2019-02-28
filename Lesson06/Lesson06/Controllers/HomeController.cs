using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson06.Models;

namespace Lesson06.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var favorites = LoadFavorites();
            return View(favorites);
        }


        [HttpPost]
        public ActionResult Add(WebAddressModel userModel)
        {
            var favorites = LoadFavorites();
            if (ModelState.IsValid)
            {
                favorites.Add(userModel);
                return RedirectToAction("Index");
            }
            return View("Index", favorites);
        }

        List<WebAddressModel> LoadFavorites()
        {
            //return new List<WebAddressModel>()
            //{
            //    new WebAddressModel { Address = "https://tut.by", Description = "TUT.BY "}
            //};
            var favorites = (List<WebAddressModel>)Session["Favorites"];
            if (favorites == null)
            {
                favorites = new List<WebAddressModel>();
                Session["Favorites"] = favorites;
            }
            
            return favorites;
        }


        void AddFavorite(WebAddressModel fav)
        {
            var favorites = (List<WebAddressModel>)Session["Favorites"];
            if (favorites == null)
            {
                favorites = new List<WebAddressModel>();
                Session["Favorites"] = favorites;
            }
            favorites.Add(fav);
        }
    }
}
