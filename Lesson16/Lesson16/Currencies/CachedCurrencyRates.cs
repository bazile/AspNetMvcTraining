using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Lesson16.Currencies
{
    public class CachedCurrencyRates : ICurrencyRates
    {
        ICurrencyRates _source;
        static ExchangeRate[] _cachedRates;

        public CachedCurrencyRates(ICurrencyRates rates)
        {
            if (rates == null) throw new ArgumentNullException(nameof(rates));
            _source = rates;
        }

        public async Task<ExchangeRate[]> GetCurrentRatesAsync()
        {
            if (_cachedRates == null)
            {
                _cachedRates = await _source.GetCurrentRatesAsync();
            }
            return _cachedRates;
        }
    }
}