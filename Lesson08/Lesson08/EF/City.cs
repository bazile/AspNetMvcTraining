using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lesson08.EF
{
    [Table("City")]
    public partial class City
    {
        public City()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        public int CountryId { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        public bool IsCapital { get; set; }

        public int? Population { get; set; }

        [StringLength(100)]
        public string OfficialSite { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
