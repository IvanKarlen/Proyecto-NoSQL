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
        public static readonly TimeSpan VIGENCIA_CACHE_REDIS = TimeSpan.FromDays(1);

        public PresidenteRepository(IDatabase redisDatabase, IMongoDatabase mongoDatabase)
        {
            _redisDatabase = redisDatabase;
            _presidentesCollection = mongoDatabase.GetCollection<Presidente>("Presidente");
        }

        public async Task<List<Presidente>> ObtenerTodosAsync()
        {
            var data = await _redisDatabase.StringGetAsync("lista_de_presidentes");
            if (data.HasValue)
            {
                var jsonData = data.ToString();
                return JsonSerializer.Deserialize<List<Presidente>>(jsonData);
            }
            else
            {
                // Obtiene los datos de Mongo
                var presidenteData = await ObtenerDatosDeBdAsync();
                var jsonData = JsonSerializer.Serialize(presidenteData);
                
                // Guarda los valores en Redis
                await _redisDatabase.StringSetAsync("lista_de_presidentes", jsonData, VIGENCIA_CACHE_REDIS);
                return presidenteData;
            }
        }

        private async Task<List<Presidente>> ObtenerDatosDeBdAsync()
        {
            return await _presidentesCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Presidente> ObtenerPorIdAsync(int id)
        {
            // Crea un filtro para buscar el presidente por su ID
            var filtro = Builders<Presidente>.Filter.Eq(p => p.Id, id);

            // Realiza la consulta en la colección de presidentes
            return await _presidentesCollection.Find(filtro).SingleOrDefaultAsync();
        }
    }
}
