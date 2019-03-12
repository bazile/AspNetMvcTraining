using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson08.EF
{
    [Table("CountryCapital")]
    public class CountryCapital
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Часть света"), Required, MaxLength(20)]
        public string PartOfWorld { get; set; }

        [Display(Name = "Страна"), Required, MaxLength(30)]
        public string Country { get; set; }

        [Display(Name = "Столица"), Required, MaxLength(40)]
        public string CapitalCity { get; set; }
    }
}
