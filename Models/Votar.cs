using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Programacion_NoSQL.Models
{
    public class Votar
    {
        [BsonId]
        [BsonElement("_id")]
        [JsonIgnore]
        public ObjectId IdObj { get; set; }
        public int Id { get; set; }
        public Votante votante { get; set; }
        public Presidente presidente { get; set;}
        
    }
}
