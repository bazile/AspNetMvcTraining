using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lesson16.Currencies
{
    /// <summary>
    /// Курсы валют с сайта НБ РБ
    /// </summary>
    public class NbrbCurrencyRatesXml : ICurrencyRates
    {
        public async Task<ExchangeRate[]> GetCurrentRatesAsync()
        {
            string address = string.Format("http://www.nbrb.by/Services/XmlExRates.aspx?ondate={0:MM}/{0:dd}/{0:yyyy}", DateTime.Now);

            //string xml;
            //using (var clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
            //using (var httpClient = new HttpClient(clientHandler))
            //{
            //    xml = await httpClient.GetStringAsync(address).ConfigureAwait(false);
            //}

            //string[] supportedCode = { "USD", "EUR", "RUB" };
            //return XElement.Parse(xml)
            //    .Elements("Currency")
            //    .Where(x => x.Element("CharCode").Value.IsOneOf(supportedCode))
            //    .Select(x => new ExchangeRate {
            //        Currency = (Currency)Enum.Parse(typeof(Currency), x.Element("CharCode").Value),
            //        Rate = decimal.Parse(x.Element("Rate").Value, CultureInfo.InvariantCulture)
            //    })
            //    .ToArray();

            string[] supportedCode = { "USD", "EUR", "RUB" };
            using (var clientHandler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip })
            using (var httpClient = new HttpClient(clientHandler))
            {
                var xmlSerializer = new XmlSerializer(typeof(DailyExRates));
                var dailyExRates = (DailyExRates)xmlSerializer.Deserialize(await httpClient.GetStreamAsync(address).ConfigureAwait(false));
                return dailyExRates.Currency
                    .Where(c => c.CharCode.IsOneOf(supportedCode))
                    .Select(c => new ExchangeRate
                    {
                        Currency = (Currency)Enum.Parse(typeof(Currency), c.CharCode),
                        Rate = c.Rate
                    })
                    .ToArray();
            }
        }
    }
}
