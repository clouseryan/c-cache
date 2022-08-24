using CCache.Data.DataAccess;
using CCache.GraphQL.Mutations.MutationTypes;
using CCache.GraphQL.Queries.Queries;
using CCache.GraphQL.Queries.QueryTypes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<CacheDbSettings>(builder.Configuration.GetSection("CacheDbSettings"));
builder.Services.AddScoped<CacheDb>();
builder.Services.AddScoped<PokemonQuery>();

builder.Services.AddGraphQLServer()
    .AddQueryType<PokemonQueryType>()
    .AddMutationType<PokemonMutationType>();

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

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();