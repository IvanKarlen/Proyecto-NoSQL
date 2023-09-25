using MongoDB.Driver;
using Programacion_NoSQL.Models;
using Programacion_NoSQL.Repository;
using Programacion_NoSQL.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Agregar configuración desde appsettings.json
var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true);

// Obtener la cadena de conexión a Redis desde la configuración
var redisConnectionString = builder.Configuration.GetSection("Redis")["ConnectionString"];

// Configurar la conexión a Redis
var redisConfiguration = ConfigurationOptions.Parse(redisConnectionString);
var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration);
var redisDatabase = redisConnection.GetDatabase();

// Obtener la configuración de MongoDB desde appsettings.json
var mongoDbConfiguration = builder.Configuration.GetSection("Mongo");
var mongoConnectionString = mongoDbConfiguration.GetValue<string>("ConnectionString");
var mongoDatabaseName = mongoDbConfiguration.GetValue<string>("MongoDB");

// Configurar la conexión a MongoDB
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var presidenteCollection = mongoDatabase.GetCollection<Presidente>("Presidentes");

// Registrar servicios en el contenedor
builder.Services.AddControllers();

// Añadir servicios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar las conexiones y colecciones en el contenedor
builder.Services.AddSingleton(redisConnection);
builder.Services.AddSingleton(redisDatabase);
builder.Services.AddSingleton(presidenteCollection);

// Agregar los repositorios de /Repository
builder.Services.AddScoped<PresidenteRepository>();
builder.Services.AddScoped<VotarRepository>();
builder.Services.AddScoped<VotanteRepository>();

// Luego, registra los servicios de /Service
builder.Services.AddScoped<PresidenteService>();
builder.Services.AddScoped<VotarService>();

builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

var app = builder.Build();

// Configure el middleware y el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
