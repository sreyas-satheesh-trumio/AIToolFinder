using System.Text.Json.Serialization;

namespace AIToolFinder.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PricingModel {
        Free = 1,
        Paid = 2, 
        Subscription = 3
    }
}