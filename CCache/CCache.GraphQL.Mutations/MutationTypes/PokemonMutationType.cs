using CCache.GraphQL.Mutations.Mutations;
using HotChocolate.Types;

namespace CCache.GraphQL.Mutations.MutationTypes;

public class PokemonMutationType : ObjectType<PokemonMutation>
{
    protected override void Configure(IObjectTypeDescriptor<PokemonMutation> descriptor)
    {
        
        
        descriptor.Name("addPokemonWithKey")
            .Field( f => f.AddPokemonWithKeyAsync(default, default));
        
        descriptor.Name("addPokemonWithNoKey")
            .Field(f => f.AddPokemonWithNoKeyAsync(default, default));
    }
}