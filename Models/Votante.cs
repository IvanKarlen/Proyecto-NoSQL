using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Programacion_NoSQL.Models
{
    public class Votante
    {
        [BsonId]
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId IdObj { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Cuil { get; set; }
        public PadronElectoral padronElectoral { get; set; }
    }
}
