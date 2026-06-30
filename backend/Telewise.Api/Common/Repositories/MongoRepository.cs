using System.Linq.Expressions;
using MongoDB.Driver;

namespace Telewise.Api.Infrastructure.Repositories;

public class MongoRepository<T> : IRepository<T>
{
    protected readonly IMongoCollection<T> Collection;

    public MongoRepository(IMongoCollection<T> collection)
    {
        Collection = collection;
    }

    public async Task<List<T>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(_ => true)
            .ToListAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(Builders<T>.Filter.Eq("Id", id))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<T?> FirstOrDefaultAsync(
        Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await Collection
            .Find(predicate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task InsertAsync(
        T entity,
        CancellationToken cancellationToken = default)
    {
        await Collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task ReplaceAsync(
        string id,
        T entity,
        CancellationToken cancellationToken = default)
    {
        await Collection.ReplaceOneAsync(
            Builders<T>.Filter.Eq("Id", id),
            entity,
            cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(
        string id,
        CancellationToken cancellationToken = default)
    {
        await Collection.DeleteOneAsync(
            Builders<T>.Filter.Eq("Id", id),
            cancellationToken);
    }
}