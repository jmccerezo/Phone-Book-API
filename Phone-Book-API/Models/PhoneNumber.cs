using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookAPI.Models
{
    public class PhoneNumber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
    }
}
