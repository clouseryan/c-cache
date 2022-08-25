using CCache.Data.DataAccess;
using CCache.GraphQL.Entities;
using HotChocolate;
using HotChocolate.Subscriptions;
using LiteDB;

namespace CCache.GraphQL.Mutations.Mutations;

public class PokemonMutation
{
    private readonly CacheDb _cacheDb;

    public PokemonMutation(CacheDb cacheDb)
    {
        _cacheDb = cacheDb ?? throw new ArgumentNullException(nameof(cacheDb));
    }

    public async Task<Pokemon> AddPokemonWithKeyAsync(Pokemon pokemon, [Service] ITopicEventSender sender)
    {
        _cacheDb.UpsertWithKey("pokemon", pokemon, new BsonValue(pokemon.Id));
        await sender.SendAsync("pokemonUpsert", pokemon);
        return pokemon;
    }
    
    public async Task<Pokemon> AddPokemonWithNoKeyAsync(Pokemon pokemon, [Service] ITopicEventSender sender)
    {
        _cacheDb.UpsertWithoutKey("pokemonAll", pokemon);
        await sender.SendAsync("pokemonUpsert", pokemon);
        return pokemon;
    }
        
}