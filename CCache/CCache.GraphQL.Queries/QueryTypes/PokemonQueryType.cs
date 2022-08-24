using CCache.GraphQL.Entities.ObjectTypes;
using CCache.GraphQL.Queries.Queries;
using HotChocolate.Types;

namespace CCache.GraphQL.Queries.QueryTypes;

public class PokemonQueryType : ObjectType<PokemonQuery>
{
    protected override void Configure(IObjectTypeDescriptor<PokemonQuery> descriptor)
    {
        descriptor
            .Field(t => t.GetAllPokemon())
            .Type<ListType<PokemonType>>();

        descriptor
            .Field(t => t.GetPokemonByKey(default))
            .Type<PokemonType>();
    }
}