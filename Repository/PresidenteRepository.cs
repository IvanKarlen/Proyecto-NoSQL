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
            var mongoDatabase = ConexionMongo(configuration);
            _presidentesCollection = mongoDatabase.GetCollection<Presidente>("Presidente");
        }

        private IMongoDatabase ConexionMongo(IConfiguration configuration)
        {
            var mongoConnectionString = configuration.GetSection("Mongo")["ConnectionString"];
            var databaseName = configuration.GetSection("Mongo").GetValue<string>("MongoDB");

            var mongoClient = new MongoClient(mongoConnectionString);
            return mongoClient.GetDatabase(databaseName);
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

        public Presidente ObtenerPorId(int id)
        {
            // Crea un filtro para buscar el presidente por su ID
            var filtro = Builders<Presidente>.Filter.Eq(p => p.Id, id);

            // Realiza la consulta en la colección de presidentes
            return _presidentesCollection.Find(filtro).SingleOrDefault();
        }
    }
}
