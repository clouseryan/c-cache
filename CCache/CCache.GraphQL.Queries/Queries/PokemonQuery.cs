using CCache.Data.DataAccess;
using CCache.GraphQL.Entities;
using LiteDB;

namespace CCache.GraphQL.Queries.Queries;

public class PokemonQuery
{
    private readonly CacheDb _cacheDb;

    public PokemonQuery(CacheDb cacheDb)
    {
        _cacheDb = cacheDb ?? throw new ArgumentNullException(nameof(cacheDb));
    }

    public IEnumerable<Pokemon>? GetAllPokemon()
    {
        return _cacheDb.GetMany("pokemonAll").ToList() as IEnumerable<Pokemon>;
    }

    public Pokemon? GetPokemonByKey(int key)
    {
        return _cacheDb.GetSingleOrNull("pokemon", new BsonValue(key)) as Pokemon;
    }
      
}