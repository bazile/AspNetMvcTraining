using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Xml.Serialization;

namespace TitanicWebApplication.Db
{
    class TitanicDatabaseInitializer : DropCreateDatabaseIfModelChanges<TitanicDbContext>
    {
        protected override void Seed(TitanicDbContext context)
        {
            TitanicPassenger[] passengers;
            using (var fstream = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/titanic.xml")))
            {
                XmlSerializer s = new XmlSerializer(typeof(TitanicPassenger[]));
                passengers = (TitanicPassenger[])s.Deserialize(fstream);
            }

            var countries = new Dictionary<string, TitanicDbCountry>();

            foreach (var pax in passengers)
            {
                TitanicDbCountry country = null;
                string countryName = pax.BirthAddress?.Country;
                if (!string.IsNullOrEmpty(countryName))
                {
                    if (!countries.TryGetValue(countryName, out country))
                    {
                        country = new TitanicDbCountry { Name = countryName };
                        countries.Add(countryName, country);
                        context.Countries.Add(country);
                    }
                }

                var dbPax = new TitanicDbPassenger
                {
                    HonorificPrefix = pax.HonorificPrefix,
                    HonorificSuffix = pax.HonorificSuffix,
                    FamilyName = pax.FamilyName,
                    GivenName = pax.GivenName,

                    Country = country,
                    AddressState = pax.BirthAddress?.State,
                    AddressCity = pax.BirthAddress?.City,

                    UniqueId = pax.Id
                };
                context.Passengers.Add(dbPax);
            }

            base.Seed(context);
        }
    }
}
