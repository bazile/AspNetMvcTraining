using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthDemo.EF
{
    public class SkyscrapersContext : DbContext
    {
        public SkyscrapersContext()
            : base("name=Skyscrapers")
        {
            Database.SetInitializer(new SkyscrapersInitializer());
        }

        public DbSet<Skyscraper> Skyscrapers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}