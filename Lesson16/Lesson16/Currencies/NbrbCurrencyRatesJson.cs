using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web;

namespace Lesson16.Currencies
{
    public class NbrbCurrencyRatesJson : ICurrencyRates
    {
        public async Task<ExchangeRate[]> GetCurrentRatesAsync()
        {
            const string address = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";

            using (var clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
            using (var httpClient = new HttpClient(clientHandler))
            {
                // Стандартный DataContractJsonSerializer
                //var serializer = new DataContractJsonSerializer(typeof(JsonCurrency[]));
                //var jsonRates = (JsonCurrency[])serializer.ReadObject(await httpClient.GetStreamAsync(address).ConfigureAwait(false));
                //string[] supportedCodes = { "USD", "EUR", "RUB" };
                //return jsonRates
                //    .Where(c => c.Cur_Abbreviation.IsOneOf(supportedCodes))
                //    .Select(c => new ExchangeRate
                //    {
                //        Currency = (Currency)Enum.Parse(typeof(Currency), c.Cur_Abbreviation),
                //        Rate = (decimal)c.Cur_OfficialRate
                //    })
                //    .ToArray();

                // С помощью Json.Net
                var rates = new List<ExchangeRate>();
                string[] supportedCodes = { "USD", "EUR", "RUB" };
                string json = await httpClient.GetStringAsync(address);
                JArray jrates = JArray.Parse(json);
                for (int i = 0; i < jrates.Count; i++)
                {
                    string abbr = (string)jrates[i]["Cur_Abbreviation"];
                    string officialRate = (string)jrates[i]["Cur_OfficialRate"];
                    if (!supportedCodes.Contains(abbr)) continue;

                    rates.Add(new ExchangeRate
                    {
                        Currency = (Currency)Enum.Parse(typeof(Currency), abbr),
                        Rate = decimal.Parse(officialRate, CultureInfo.InvariantCulture)
                    });
                }
                return rates.ToArray();
            }
        }
    }

    public class JsonCurrency
    {
        public int Cur_ID { get; set; }
        public string Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public float Cur_OfficialRate { get; set; }
    }
}