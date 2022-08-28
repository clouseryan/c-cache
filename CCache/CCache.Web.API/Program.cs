using CCache.Data.DataAccess;
using CCache.GraphQL.Mutations.MutationTypes;
using CCache.GraphQL.Queries.Queries;
using CCache.GraphQL.Queries.QueryTypes;
using CCache.GraphQL.Subscriptions.SubscriptionTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Todo - implement with Dashboard MovesRepositoryCached
//         implement with Dashboard Application

builder.Services.Configure<CacheDbSettings>(builder.Configuration.GetSection("CacheDbSettings"));
builder.Services.AddScoped<CacheDb>();

builder.Services.AddInMemorySubscriptions();

builder.Services.AddGraphQLServer()
    .AddQueryType<PokemonQueryType>()
    .AddMutationType<PokemonMutationType>()
    .AddSubscriptionType<PokemonUpsertSubscriptionType>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseWebSockets();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();