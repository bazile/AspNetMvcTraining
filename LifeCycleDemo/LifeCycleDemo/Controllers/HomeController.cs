using LifeCycleDemo.EF;
using LifeCycleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LifeCycleDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            const int PAGE_SIZE = 2;
            page = page ?? 1;

            using (var db = new WallpaperContext())
            {
                int totalCount = db.Wallpapers.Count(); // SELECT COUNT(*) FROM Wallpaper

                var model = new WallpaperListViewModel { Page = page.Value };
                model.Wallpapers = db.Wallpapers
                    .Select(w => new WallpaperViewModel
                    {
                        Id = w.Id,
                        Name = w.Name
                    }) // SELECT Id, Name FROM Wallparer
                    .OrderBy(w => w.Id)
                    .Skip((page.Value - 1)*PAGE_SIZE).Take(PAGE_SIZE).ToArray();
                return View(model);
            }
        }

        public ActionResult Wallpaper(int id)
        {
            using (var db = new WallpaperContext())
            {
                var wallpaper = db.Wallpapers.Find(id);
                if (wallpaper == null) return HttpNotFound();

                return View(new WallpaperViewModel { Id = wallpaper.Id } );
            }
        }

        public ActionResult WallpaperImage(int id)
        {
            using (var db = new WallpaperContext())
            {
                var wallpaper = db.Wallpapers.Find(id);
                if (wallpaper == null) return HttpNotFound();

                return new FileContentResult(wallpaper.ImagesBytes, "image/jpeg");
            }
        }
    }
}
