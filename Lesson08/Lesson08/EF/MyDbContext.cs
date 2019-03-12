using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lesson08.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=TrainingCenter_Capitals")
        {
            Database.SetInitializer<MyDbContext>(null);
        }

        public DbSet<CountryCapital> Parts { get; set; }
        public DbSet<CountryCapital> Countries { get; set; }
        public DbSet<CountryCapital> Cities { get; set; }
    }
}
