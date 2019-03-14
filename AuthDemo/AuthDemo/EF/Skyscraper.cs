using System.ComponentModel.DataAnnotations;

namespace AuthDemo.EF
{
    public class Skyscraper
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        public double Height { get; set; }

        public int Year { get; set; }
    }
}
