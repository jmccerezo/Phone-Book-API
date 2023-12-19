using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookAPI.Models
{
    public class PhoneNumber
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public Int64 Number { get; set; }
    }
}
