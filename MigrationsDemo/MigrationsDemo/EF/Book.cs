using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationsDemo.EF
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Author { get; set; }

        [Required, MaxLength(150)]
        public string Publisher { get; set; }

        //[Required, MaxLength(13)]
        //public string ISBN { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
