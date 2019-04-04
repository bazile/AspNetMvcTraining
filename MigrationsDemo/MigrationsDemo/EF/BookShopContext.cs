using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MigrationsDemo.EF
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShop")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion
                    <BookShopContext, MigrationsDemo.Migrations.Configuration>
                ()
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
