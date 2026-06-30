using MongoDB.Driver;
using Telewise.Api.Constants;
using Telewise.Api.Domain.Entities;
using Telewise.Api.Infrastructure.Mongo;

namespace Telewise.Api.Infrastructure.Repositories;

public sealed class SettingsRepository : ISettingsRepository
{
    private readonly IMongoCollection<ApplicationSettings> _collection;

    public SettingsRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<ApplicationSettings>(
            CollectionNames.Settings);
    }

    public async Task<ApplicationSettings?> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _collection
            .Find(_ => true)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task SaveAsync(
        ApplicationSettings settings,
        CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(
            x => x.Id == settings.Id,
            settings,
            new ReplaceOptions
            {
                IsUpsert = true
            },
            cancellationToken);
    }
}