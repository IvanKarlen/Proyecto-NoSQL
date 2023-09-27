using Programacion_NoSQL.Models;
using MongoDB.Driver;
using MongoDB.Bson;

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
            return _votanteCollection.Find(filter).FirstOrDefault();
        }

        public Votante Actualizar(Votante votante)
        {
            var filtro = Builders<Votante>.Filter.Eq(v => v.Id, votante.Id);
            var actualizaciones = Builders<Votante>.Update
                .Set(v => v.Nombre, votante.Nombre)
                .Set(v => v.Apellido, votante.Apellido)
                .Set(v => v.IdTipoDocumento, votante.IdTipoDocumento)
                .Set(v => v.Documento, votante.Documento)
                .Set(v => v.Cuil, votante.Cuil)
                .Set(v => v.padronElectoral, votante.padronElectoral)
                .Set(v => v.Voto, votante.Voto);

            var resultado = _votanteCollection.UpdateOne(filtro, actualizaciones);

            if (resultado.ModifiedCount > 0)
            {
                return votante;
            }
            else
            {
                return null;
            }
        }

        public Votante ObtenerPorId(int id)
        {
            var filter = Builders<Votante>.Filter.Eq(v => v.Id, id);
            return _votanteCollection.Find(filter).FirstOrDefault();
        }
    }
}
