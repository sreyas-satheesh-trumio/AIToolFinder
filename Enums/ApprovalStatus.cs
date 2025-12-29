using System.Text.Json.Serialization;

namespace AIToolFinder.Services
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}