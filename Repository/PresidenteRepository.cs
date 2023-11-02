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
            var cachedData = await _redisDatabase.StringGetAsync("lista_de_presidentes");
            var expirationDate = await _redisDatabase.StringGetAsync("lista_de_presidentes_expiracion");

            if (cachedData.HasValue && expirationDate.HasValue)
            {
                var jsonData = cachedData.ToString();
                var expirationDateTime = DateTime.Parse(expirationDate.ToString());

                // Verificar si la fecha de expiración ha pasado
                if (DateTime.UtcNow < expirationDateTime)
                {
                    return JsonSerializer.Deserialize<List<Presidente>>(jsonData);
                }
            }

            // Si no hay datos en caché o la caché ha expirado
            var presidenteData = await ObtenerDatosDeBdAsync();

            // Se verifica si los datos han cambiado antes de actualizar la caché
            var newJsonData = JsonSerializer.Serialize(presidenteData);
            if (!newJsonData.Equals(cachedData))
            {
                // Establecer la nueva fecha de vencimiento (1 día a partir de ahora)
                var newExpirationDateTime = DateTime.UtcNow.Add(VIGENCIA_CACHE_REDIS);

                // Guardar los datos y la nueva fecha de expiración en Redis
                await _redisDatabase.StringSetAsync("lista_de_presidentes", newJsonData);
                await _redisDatabase.StringSetAsync("lista_de_presidentes_expiracion", newExpirationDateTime.ToString());
            }

            return presidenteData;
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
