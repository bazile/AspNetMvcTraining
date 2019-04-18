using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Lesson16.Currencies
{
    public class CachedCurrencyRates : ICurrencyRates
    {
        ICurrencyRates _source;
        System.Web.Caching.Cache _cache;

        public CachedCurrencyRates(System.Web.Caching.Cache cache, ICurrencyRates rates)
        {
            if (rates == null) throw new ArgumentNullException(nameof(rates));
            if (cache == null) throw new ArgumentNullException(nameof(cache));

            _source = rates;
            _cache = cache;
        }

        public async Task<ExchangeRate[]> GetCurrentRatesAsync()
        {
            const string CACHE_KEY = "CurrencyRates";

            var rates = (ExchangeRate[])_cache.Get(CACHE_KEY);
            if (rates == null)
            {
                rates = await _source.GetCurrentRatesAsync();
                _cache.Add(
                    CACHE_KEY, rates,
                    /* dependencies */ null,
                    DateTime.Now.AddHours(4),
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Normal,
                    null /* callback */
                );
            }
            return rates;
        }
    }
}