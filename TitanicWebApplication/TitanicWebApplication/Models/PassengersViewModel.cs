using System.Collections.Generic;
using TitanicWebApplication.Db;

namespace TitanicWebApplication.Models
{
    public class PassengersViewModel
    {
        public IEnumerable<TitanicDbPassenger> Passengers { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
