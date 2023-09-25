using Programacion_NoSQL.Models;
using MongoDB.Driver;

namespace Programacion_NoSQL.Repository
{
    public class VotarRepository
    {
        private readonly IMongoCollection<Votar> _votarCollection;

        public VotarRepository(IMongoDatabase database)
        {
            // referencia a la colección Votar
            _votarCollection = database.GetCollection<Votar>("Votar");
        }

        public Votar Cargar(Votar voto)
        {
            _votarCollection.InsertOne(voto);
            return voto;
        }
    }
}
