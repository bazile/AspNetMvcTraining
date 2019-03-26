using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LifeCycleDemo.EF
{
    class WallpaperContext : DbContext
    {
        public WallpaperContext() : base("name=Wallpapers")
        {
            Database.SetInitializer<WallpaperContext>(null);
        }

        public DbSet<Wallpaper> Wallpapers { get; set; }
    }
}
