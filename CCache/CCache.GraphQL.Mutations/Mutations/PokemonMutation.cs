using CCache.Data.DataAccess;
using CCache.GraphQL.Entities;
using LiteDB;

namespace CCache.GraphQL.Mutations.Mutations;

public class PokemonMutation
{
    private readonly CacheDb _cacheDb;

    public PokemonMutation(CacheDb cacheDb)
    {
        _cacheDb = cacheDb ?? throw new ArgumentNullException(nameof(cacheDb));
    }

    public Pokemon AddPokemonWithKey(Pokemon pokemon)
    {
        _cacheDb.UpsertWithKey("pokemon", pokemon, new BsonValue(pokemon.Id));
        return pokemon;
    }
    
    public Pokemon AddPokemonWithNoKey(Pokemon pokemon)
    {
        _cacheDb.UpsertWithoutKey("pokemonAll", pokemon);
        return pokemon;
    }
        
}