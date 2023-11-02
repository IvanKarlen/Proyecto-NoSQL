using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Programacion_NoSQL.Models
{
    public class Presidente
    {
        [BsonId]
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId IdObj { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string VicePresidente { get; set; }
        public List<JefeDeGobierno> JefeDeGobierno { get; set; }
    }
}
