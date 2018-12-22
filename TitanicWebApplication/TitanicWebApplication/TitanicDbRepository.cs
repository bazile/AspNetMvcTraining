using System;
using System.Collections.Generic;
using System.Linq;
using TitanicWebApplication.Db;

namespace TitanicWebApplication
{
    public class TitanicDbRepository : ITitanicRepository, IDisposable
    {
        Lazy<TitanicDbContext> _dbContext = new Lazy<TitanicDbContext>(() => new TitanicDbContext());

        public void Dispose()
        {
            if (_dbContext != null && _dbContext.IsValueCreated)
            {
                _dbContext.Value.Dispose();
                _dbContext = null;
            }
        }

        public TitanicPassenger[] Find(string query)
        {
            throw new NotImplementedException();
        }

        public string[] GetCountries()
        {
            throw new NotImplementedException();
        }

        public TitanicPassenger[] GetPassengers()
        {
            List<TitanicPassenger> passengers = new List<TitanicPassenger>();
            foreach (var dbPax in _dbContext.Value.Passengers)
            {
                passengers.Add(new TitanicPassenger
                {
                    UniqueId = dbPax.UniqueId,
                    HonorificPrefix = dbPax.HonorificPrefix,
                    HonorificSuffix = dbPax.HonorificSuffix,
                    FamilyName = dbPax.FamilyName,
                    GivenName = dbPax.GivenName
                });
            }
            return passengers.ToArray();
        }
    }
}
