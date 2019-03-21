using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthDemo.EF
{
    public class SkyscrapersContext : IdentityDbContext<SkyscrapersUser>
    {
        public SkyscrapersContext()
            : base("name=Skyscrapers")
        {
            Database.SetInitializer(new SkyscrapersInitializer());
        }

        public DbSet<Skyscraper> Skyscrapers { get; set; }
    }

    public static class SkyscrapersContextExtensions
    {
        public static UserManager<SkyscrapersUser> CreateUserManager(this SkyscrapersContext context)
        {
            var userStore = new UserStore<SkyscrapersUser>(context);
            return new UserManager<SkyscrapersUser>(userStore);
        }
    }
}
