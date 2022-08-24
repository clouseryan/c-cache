namespace CCache.Data.Entities.Abstraction;

public abstract class CachableEntity
{
    /// <summary>
    /// The expiration time for the cache entry in UTC.
    /// </summary>
    public DateTime Expiration { get; set; } = DateTime.UtcNow.AddMinutes(10);
}