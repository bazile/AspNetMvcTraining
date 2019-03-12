using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson08.EF
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        public int PartOfWorldId { get; set; }

        public int? CapitalId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public int? Population { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UNMemberSince { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IndepenceDate { get; set; }

        [StringLength(3)]
        public string TLD { get; set; }

        [MaxLength(2000)]
        public byte[] Flag { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual City City { get; set; }

        public virtual PartOfWorld PartOfWorld { get; set; }
    }
}
