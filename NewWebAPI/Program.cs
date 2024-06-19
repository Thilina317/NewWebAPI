using Microsoft.Azure.Cosmos;
using NewWebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICosmosDbService>(options => {
    var configuration = builder.Configuration.GetSection("CosmosDb");

    string endpointUri = configuration.GetValue<string>("EndpointUri");
    string primaryKey = configuration.GetValue<string>("PrimaryKey");
    string dbName = configuration.GetValue<string>("DatabaseName");
    string containerName = configuration.GetValue<string>("ContainerName");

    var cosmosClient = new CosmosClient(endpointUri, primaryKey);

    return new CosmosDbService(cosmosClient, dbName, containerName);
});

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

app.Run();
