using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDb
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new WallpaperContext())
            //{
            //    Console.WriteLine(context.Wallpapers.Count());
            //}
            foreach (string item in GetCollection())
            {
                Console.WriteLine(item);
            }

            int x = 10;
            Console.WriteLine($"x={x}");

            string s = "a,b,c,d";
            string[] array = s.Split(new[] { ',' });
        }

        class Test
        {
            int x;
        }

        static IEnumerable GetCollection()
        {
            return new[] { "aaa", "bbb", "ccc" };
        }
    }

    class WallpaperContext : DbContext
    {
        public WallpaperContext()
        {
            Database.SetInitializer(new WallpaperDbInitializer());
        }

        public DbSet<Wallpaper> Wallpapers { get; set; }
    }

    public class Wallpaper
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public byte[] ImagesBytes { get; set; }
    }

    class WallpaperDbInitializer : CreateDatabaseIfNotExists<WallpaperContext>
    {
        protected override void Seed(WallpaperContext context)
        {
            foreach (string path in Directory.EnumerateFiles(@"C:\Windows\Web\Wallpaper\Architecture", "*.jpg"))
            {
                context.Wallpapers.Add(new Wallpaper {
                    Name = Path.GetFileNameWithoutExtension(path),
                    ImagesBytes = File.ReadAllBytes(path)
                });
            }

            base.Seed(context);
        }
    }
}
