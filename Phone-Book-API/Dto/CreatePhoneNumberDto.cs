using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PhoneBookAPI.Dto
{
    public class CreatePhoneNumberDto
    {
        [BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public Int64 Number { get; set; }
    }
}
