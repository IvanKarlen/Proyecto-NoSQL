using MongoDB.Driver;
using Programacion_NoSQL.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Agregar configuraci�n desde appsettings.json
var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true)
    .AddJsonFile($"appsettings.{environmentName}.json", optional: true);


// Obtener la cadena de conexi�n a Redis desde la configuraci�n
var redisConnectionString = builder.Configuration.GetConnectionString("Redis");

// Configurar la conexi�n a Redis
var redisConfiguration = ConfigurationOptions.Parse(redisConnectionString);
var redisConnection = ConnectionMultiplexer.Connect(redisConfiguration);
var redisDatabase = redisConnection.GetDatabase();

// Obtener la configuraci�n de MongoDB desde appsettings.json
var mongoDbConfiguration = builder.Configuration.GetSection("Mongo");
var mongoConnectionString = mongoDbConfiguration.GetValue<string>("ConnectionString");
var mongoDatabaseName = mongoDbConfiguration.GetValue<string>("MongoDB");

// Configurar la conexi�n a MongoDB
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoDatabaseName);
var presidenteCollection = mongoDatabase.GetCollection<Presidente>("Presidentes");

// Registrar servicios en el contenedor
builder.Services.AddControllers();

// A�adir servicios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar las conexiones y colecciones en el contenedor
builder.Services.AddSingleton(redisConnection);
builder.Services.AddSingleton(redisDatabase);
builder.Services.AddSingleton(presidenteCollection);

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
