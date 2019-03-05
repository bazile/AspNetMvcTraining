using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Web.Hosting;

namespace WebApplication1.EF
{
    public class Skyscraper
    {
        public int Id { get; set; } // PK, Identity (счетчик)
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(110)]
        public string Country { get; set; }
        [Required, MaxLength(90)]
        public string City { get; set; }
        public double Height { get; set; }
        public int? YearFinished { get; set; }
    }

    class SkyscraperContext : DbContext
    {
        public SkyscraperContext()
            //: base("Server=localhost\\sqlexpress; Database=Skyscrapers; Trusted_Connection=True;")
            : base("name=Skyscrapers")
        {
            Database.SetInitializer(new SkyscraperDatabaseInitializer());
        }

        public DbSet<Skyscraper> Skyscrapers { get; set; }
    }

    class SkyscraperDatabaseInitializer : DropCreateDatabaseIfModelChanges<SkyscraperContext>
    {
        protected override void Seed(SkyscraperContext context)
        {
            string dataPath = HostingEnvironment.MapPath("~/App_Data/skyscrapers.txt");
            using (var reader = new StreamReader(dataPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length != 5) continue;

                    string name = parts[0].Trim('"');
                    string country = parts[1].Trim('"');
                    string city = parts[2].Trim('"');
                    double height = double.Parse(parts[3], CultureInfo.InvariantCulture);
                    int year = int.Parse(parts[4]);

                    var sc = new Skyscraper
                    {
                        Name = name,
                        Country = country,
                        City = city,
                        Height = height,
                        YearFinished = year
                    };
                    context.Skyscrapers.Add(sc); // INSERT
                }
            }

            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
