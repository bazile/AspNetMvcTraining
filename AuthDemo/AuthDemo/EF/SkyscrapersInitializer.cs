using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Web.Hosting;

namespace AuthDemo.EF
{
    internal class SkyscrapersInitializer : CreateDatabaseIfNotExists<SkyscrapersContext>
    {
        protected override void Seed(SkyscrapersContext context)
        {
            string path = HostingEnvironment.MapPath("/App_data/skyscrapers.txt");
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split(',');
                if (parts.Length != 5) continue;

                var sc = new Skyscraper
                {
                    Name = parts[0].Trim('"'),
                    Country = parts[1].Trim('"'),
                    City = parts[2].Trim('"'),
                    Height = double.Parse(parts[3], CultureInfo.InvariantCulture),
                    Year = int.Parse(parts[4])
                };
                context.Skyscrapers.Add(sc);
            }

            var userManager = context.CreateUserManager();
            userManager.Create(new SkyscrapersUser { UserName = "admin" }, "qwerty");
            var user = new SkyscrapersUser { UserName = "vasya" };
            user.Claims.Add(new IdentityUserClaim { ClaimType = "timezone", ClaimValue = "+5" });

            base.Seed(context);
        }
    }
}
