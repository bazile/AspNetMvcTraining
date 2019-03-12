using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson08.EF
{
    [Table("PartOfWorld")]
    public partial class PartOfWorld
    {
        public PartOfWorld()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
