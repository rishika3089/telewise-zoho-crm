using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Telewise.Api.Domain.Entities;

public sealed class NotificationLog
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string EventType { get; set; } = string.Empty;

    public string Destination { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;

    public DateTime SentAtUtc { get; set; } = DateTime.UtcNow;
}