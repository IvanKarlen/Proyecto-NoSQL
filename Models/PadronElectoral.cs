using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Programacion_NoSQL.Models
{
    public class PadronElectoral
    {
        [BsonId]
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId IdObj { get; set; }
        public int Id { get; set; }
        public int NroOrden { get; set; }
        public int Distrito { get; set; }
        public int CIRC { get; set; }
        public int Seccion { get; set; }
        public int Mesa { get; set; }
    }
}
