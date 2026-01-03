using System.Text.Json.Serialization;

namespace AIToolFinder.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PricingModel {
        Free,
        Paid, 
        Subscription
    }
}