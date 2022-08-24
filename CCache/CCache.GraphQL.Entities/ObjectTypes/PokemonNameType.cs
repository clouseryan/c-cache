using HotChocolate.Types;

namespace CCache.GraphQL.Entities.ObjectTypes;

public class PokemonNameType : ObjectType<PokemonName>
{
    protected override void Configure(IObjectTypeDescriptor<PokemonName> descriptor)
    {
        descriptor.Name("pokemonName");

        descriptor
            .Field(t => t.PokemonId)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.English)
            .Type<StringType>();
        
        descriptor
            .Field(t => t.Japanese)
            .Type<StringType>();

        descriptor
            .Field(f => f.Chinese)
            .Type<StringType>();
    }
}