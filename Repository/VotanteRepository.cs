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


        public Votante Actualizar(Votante votante)
        {
            // Filtro para identificar el documento por su Id
            var filtro = Builders<Votante>.Filter.Eq(v => v.Id, votante.Id);

            if(filtro == null)
            {
                return null;
            }

            // Actualizaciones
            var actualizaciones = Builders<Votante>.Update
                .Set(v => v.Nombre, votante.Nombre)
                .Set(v => v.Apellido, votante.Apellido)
                .Set(v => v.IdTipoDocumento, votante.IdTipoDocumento)
                .Set(v => v.Documento, votante.Documento)
                .Set(v => v.Cuil, votante.Cuil)
                .Set(v => v.padronElectoral, votante.padronElectoral)
                .Set(v => v.Voto, votante.Voto);

            // Actualización en la colección de Votantes
            var resultado = _votanteCollection.UpdateOne(filtro, actualizaciones);

            if (resultado.IsModifiedCountAvailable && resultado.ModifiedCount > 0)
            {
                // La actualización fue exitosa
                return votante;
            }
            else
            {
                // La actualización no tuvo ningún efecto, ocurre por ejemplo, si el Votante con ese _id no existe
                return null;
            }
        }

    }
}
