using HotChocolate.Types;

namespace CCache.GraphQL.Entities.ObjectTypes;

public class BaseStatType : ObjectType<BaseStat>
{
    protected override void Configure(IObjectTypeDescriptor<BaseStat> descriptor)
    {
        descriptor.Name("baseStat");
        
        descriptor
            .Field(t => t.PokemonId)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.HitPoints)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.Attack)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.Defense)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.SpAttack)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.SpDefense)
            .Type<IntType>();
        
        descriptor
            .Field(t => t.Speed)
            .Type<IntType>();
    }
}