using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanicWebApplication.Db
{
    //[Table("Passengers")]
    public class TitanicDbPassenger
    {
        public int Id { get; set; }
        public Class Class { get; set; }
        public string HonorificPrefix { get; set; }
        public string HonorificSuffix { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public Sex Sex { get; set; }
        public bool HasSurvived { get; set; }
        public bool IsGuaranteeGroupMember { get; set; }
        public bool IsServant { get; set; }

        public int? AgeMonths { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public TitanicDbCountry Country { get; set; }
        public string AddressState { get; set; }
        public string AddressCity { get; set; }
        public string TicketNo { get; set; }
        public string CabinNo { get; set; }
        public int PriceTotalPence { get; set; }
        public City Boarded { get; set; } // Переименовать в Embarked?
        public string JobTitle { get; set; }
        public string Lifeboat { get; set; }
        public string Url { get; set; }
        public string UniqueId { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return HonorificPrefix + " " + FamilyName + ", " + GivenName + (string.IsNullOrEmpty(HonorificSuffix) ? "" : " " + HonorificSuffix); }
        }

        [NotMapped]
        public Price TicketPrice => new Price(PriceTotalPence);
    }
}
