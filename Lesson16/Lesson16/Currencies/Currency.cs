using System.Runtime.Serialization;

namespace Lesson16.Currencies
{
    [DataContract]
    public enum Currency
    {
        [EnumMember(Value = "USD")] USD,
        [EnumMember(Value = "EUR")] EUR,
        [EnumMember(Value = "RUB")] RUB
    }
}
