using MongoDB.Driver;
using Telewise.Api.Constants;
using Telewise.Api.Domain.Entities;
using Telewise.Api.Infrastructure.Mongo;

namespace Telewise.Api.Features.OAuth.Repositories;

public sealed class OAuthRepository : IOAuthRepository
{
    private readonly IMongoCollection<OAuthToken> _collection;

    public OAuthRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<OAuthToken>(
            CollectionNames.OAuthTokens);
    }

    public async Task<OAuthToken?> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _collection
            .Find(_ => true)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task SaveAsync(
        OAuthToken token,
        CancellationToken cancellationToken = default)
    {
        var existing = await GetAsync(cancellationToken);

        token.UpdatedAtUtc = DateTime.UtcNow;

        if (existing == null)
        {
            token.CreatedAtUtc = DateTime.UtcNow;

            await _collection.InsertOneAsync(
                token,
                cancellationToken: cancellationToken);

            return;
        }

        token.Id = existing.Id;
        token.CreatedAtUtc = existing.CreatedAtUtc;

        await _collection.ReplaceOneAsync(
            x => x.Id == existing.Id,
            token,
            cancellationToken: cancellationToken);
    }
}