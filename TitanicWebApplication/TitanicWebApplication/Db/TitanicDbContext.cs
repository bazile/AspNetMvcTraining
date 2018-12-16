using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TitanicWebApplication.Db
{
    public class TitanicDbContext : DbContext
    {
        public TitanicDbContext()
        {
            Database.SetInitializer(new TitanicDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TitanicDbPassenger>().ToTable("Passengers");
            modelBuilder.Entity<TitanicDbPassenger>().Property(p => p.FamilyName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TitanicDbPassenger>().Property(p => p.GivenName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<TitanicDbPassenger>().Property(p => p.UniqueId).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<TitanicDbCountry>().ToTable("Countries");
            modelBuilder.Entity<TitanicDbCountry>().Property(c => c.Name).IsRequired().HasMaxLength(30);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TitanicDbPassenger> Passengers { get; set; }

        public DbSet<TitanicDbCountry> Countries { get; set; }
    }
}
