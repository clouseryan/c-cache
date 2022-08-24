using HotChocolate.Types;

namespace CCache.GraphQL.Entities.ObjectTypes;

public class PokemonType : ObjectType<Pokemon>
{
    protected override void Configure(IObjectTypeDescriptor<Pokemon> descriptor)
    {
        descriptor.Name("pokemon");
        
        descriptor
            .Field(f => f.Id)
            .Type<IntType>();
        
        descriptor
            .Field(f => f.Name)
            .Type<StringType>();
        
        descriptor
            .Field(f => f.Name)
            .Type<PokemonNameType>();

        descriptor
            .Field(t => t.BaseStat)
            .Type<BaseStatType>();

        descriptor
            .Field(f => f.Types)
            .Type<ListType<StringType>>();
    }
}