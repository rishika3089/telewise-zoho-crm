using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Telewise.Api.Domain.Entities;

public sealed class ApplicationSettings
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public bool NotificationsEnabled { get; set; } = true;

    public string DefaultWebhook { get; set; } = string.Empty;

    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}