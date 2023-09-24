using Programacion_NoSQL.Models;
using MongoDB.Driver;

namespace Programacion_NoSQL.Repository
{
    public class VotanteRepository
    {
        private readonly IMongoCollection<Votante> _votanteCollection;

        public VotanteRepository(IMongoDatabase database)
        {
            _votanteCollection = database.GetCollection<Votante>("Votante");
        }

        public Votante ObtenerPorCuil(string cuil)
        {
            var filter = Builders<Votante>.Filter.Eq(v => v.Cuil, cuil);
            var votante = _votanteCollection.Find(filter).FirstOrDefault();

            return votante;
        }
    }
}
