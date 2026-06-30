using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Telewise.Api.Configuration;
using Telewise.Api.Constants;

namespace Telewise.Api.Infrastructure.Mongo;

public sealed class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbOptions> options)
    {
        var settings = options.Value;

        var client = new MongoClient(settings.ConnectionString);

        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}