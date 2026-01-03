using System.Text.Json.Serialization;

namespace AIToolFinder.Services
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApprovalStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}