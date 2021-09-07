using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Users.Infrastructure.MDO
{
    public class UserDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("fullName")]
        public string FullName { get; set; }
    }
}
