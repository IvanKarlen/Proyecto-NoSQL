using MongoDB.Driver;
using Programacion_NoSQL.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace Programacion_NoSQL.Repository
{
    public class PresidenteRepository
    {
        private readonly IDatabase _redisDatabase;
        private readonly IMongoCollection<Presidente> _presidentesCollection;

        public PresidenteRepository(IDatabase redisDatabase, IConfiguration configuration)
        {
            _redisDatabase = redisDatabase;
            _presidentesCollection = InitializoMongoCollection(configuration);
        }

        public List<Presidente> ObtenerTodos()
        {
            var data = _redisDatabase.StringGet("lista_de_presidentes");
            if (data.HasValue)
            {
                var jsonData = data.ToString();
                return JsonSerializer.Deserialize<List<Presidente>>(jsonData);
            }
            else
            {
                var presidenteData = ObtenerDatosDeBD();
                var jsonData = JsonSerializer.Serialize(presidenteData);
                _redisDatabase.StringSet("lista_de_presidentes", jsonData);
                return presidenteData;
            }
        }

        private List<Presidente> ObtenerDatosDeBD()
        {
            return _presidentesCollection.Find(_ => true).ToList();
        }

        private IMongoCollection<Presidente> InitializoMongoCollection(IConfiguration configuration)
        {
            var mongoDatabase = ConexionMongo(configuration);
            return mongoDatabase.GetCollection<Presidente>("Presidentes");
        }

        private IMongoDatabase ConexionMongo(IConfiguration configuration)
        {
            var mongoConnectionString = configuration.GetConnectionString("Mongo:ConnectionString");
            var databaseName = configuration.GetSection("Mongo").GetValue<string>("MongoDB");

            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);
            return mongoDatabase;
        }
    }
}
