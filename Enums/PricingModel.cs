using System.Text.Json.Serialization;

namespace AIToolFinder.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PricingModel {
<<<<<<< HEAD
        Free, // 0
        Paid, // 1
        Subscription // 2
=======
        Free = 1,
        Paid = 2, 
        Subscription = 3
>>>>>>> e65616d551932908e341e7eb48b6c3c84f0ed9ac
    }
}