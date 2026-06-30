using MongoDB.Driver;
using Telewise.Api.Constants;
using Telewise.Api.Domain.Entities;
using Telewise.Api.Infrastructure.Mongo;

namespace Telewise.Api.Features.CRM.Repositories;

public sealed class CrmEventRepository : ICrmEventRepository
{
    private readonly IMongoCollection<CrmEvent> _collection;

    public CrmEventRepository(MongoDbContext context)
    {
        _collection = context.GetCollection<CrmEvent>(
            CollectionNames.CrmEvents);
    }

    public async Task SaveAsync(
        CrmEvent crmEvent,
        CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(
            crmEvent,
            cancellationToken: cancellationToken);
    }
}