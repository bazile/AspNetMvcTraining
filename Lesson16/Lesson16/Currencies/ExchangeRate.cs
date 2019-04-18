using System;
using System.Runtime.Serialization;

namespace Lesson16.Currencies
{
    [DataContract]
    public class ExchangeRate
    {
        public Currency Currency { get; set; }
        public decimal Rate { get; set; }
    }
}
