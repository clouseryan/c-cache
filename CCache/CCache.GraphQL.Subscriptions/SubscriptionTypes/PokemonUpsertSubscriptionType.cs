using CCache.GraphQL.Entities;
using CCache.GraphQL.Entities.ObjectTypes;
using HotChocolate;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace CCache.GraphQL.Subscriptions.SubscriptionTypes;

public class PokemonUpsertSubscriptionType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor
            .Field("onPokemonUpsert")
            .Type<PokemonType>()
            .Resolve(context => context.GetEventMessage<Pokemon>())
            .Subscribe(async context =>
            {
                var receiver = context.Service<ITopicEventReceiver>();
                return await receiver.SubscribeAsync<string, Pokemon>("pokemonUpsert");
            });
    }
}