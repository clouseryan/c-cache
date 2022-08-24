using CCache.Data.Entities.Abstraction;

namespace CCache.GraphQL.Entities;

public class Pokemon : CachableEntity
{
    public int Id { get; set; }
    public virtual PokemonName Name { get; set; }
    public List<string> Types { get; set; }
    public virtual BaseStat BaseStat { get; set; }
}