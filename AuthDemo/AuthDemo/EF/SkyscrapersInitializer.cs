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

            byte[] salt = UserHelper.GenerateSalt();
            context.Users.Add(new User
            {
                Login = "admin",
                PasswordHash = PBKDF2HashHelper.CreatePasswordHash("qwerty", 3000),
            });

            base.Seed(context);
        }
    }
}
