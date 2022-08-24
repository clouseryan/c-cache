using CCache.Data.Entities.Abstraction;
using LiteDB;
using Microsoft.Extensions.Options;

namespace CCache.Data.DataAccess;

public class CacheDb : IDisposable
{
    private readonly CacheDbSettings _settings;
    private readonly ILiteDatabase _db;

    public CacheDb(IOptionsSnapshot<CacheDbSettings> settings)
    {
        _settings = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        _db = new LiteDatabase(_settings.ConnectionString);
    }

    public IEnumerable<string> GetCollectionNames()
        => _db.GetCollectionNames();

    private ILiteCollection<CachableEntity> GetCollection(string name)
        => _db.GetCollection<CachableEntity>(name);

    /// <summary>
    /// Return an object of type T from the database or null.
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public CachableEntity GetSingleOrNull(string collectionName, BsonValue key)
        => GetCollection(collectionName).FindById(key);

    /// <summary>
    /// Get all object from a given collection.
    /// </summary>
    /// <param name="collectionName"></param>
    /// <returns></returns>
    public IEnumerable<CachableEntity> GetMany(string collectionName)
        => GetCollection(collectionName).FindAll();

    /// <summary>
    /// Upsert object in a given collection with a given key.
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="entity"></param>
    /// <param name="key"></param>
    public void UpsertWithKey(string collectionName, CachableEntity entity, BsonValue key)
        => GetCollection(collectionName).Upsert(key, entity);

    /// <summary>
    /// Upsert an object into a collection without any key.
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="entity"></param>
    public void UpsertWithoutKey(string collectionName, CachableEntity entity)
        => GetCollection(collectionName).Upsert(entity);


    public void Dispose()
    {
        _db.Dispose();
    }
}