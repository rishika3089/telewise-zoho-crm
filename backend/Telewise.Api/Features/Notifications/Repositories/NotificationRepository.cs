using MongoDB.Driver;
using Telewise.Api.Constants;
using Telewise.Api.Domain.Entities;
using Telewise.Api.Infrastructure.Mongo;

namespace Telewise.Api.Features.Notifications.Repositories;

public sealed class NotificationRepository : INotificationRepository
{
    private readonly IMongoCollection<NotificationLog> _collection;

    public NotificationRepository(MongoDbContext context)
    {
        _collection =
            context.GetCollection<NotificationLog>(
                CollectionNames.NotificationLogs);
    }

    public async Task SaveAsync(
        NotificationLog notification,
        CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(
            notification,
            cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(
        NotificationLog notification,
        CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(
            x => x.Id == notification.Id,
            notification,
            cancellationToken: cancellationToken);
    }

    public async Task<List<NotificationLog>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _collection
            .Find(_ => true)
            .SortByDescending(x => x.SentAtUtc)
            .ToListAsync(cancellationToken);
    }   
}