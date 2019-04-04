using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MigrationsDemo.EF
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}