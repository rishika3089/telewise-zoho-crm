using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Telewise.Api.Domain.Entities;

public sealed class CrmEvent
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string EventType { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;

    public DateTime ReceivedAtUtc { get; set; } = DateTime.UtcNow;
}