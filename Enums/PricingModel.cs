using System.Text.Json.Serialization;

namespace AIToolFinder.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PricingModel {
        Free, // 0
        Paid, // 1
        Subscription // 2
    }
}