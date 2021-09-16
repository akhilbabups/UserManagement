using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Users.Infrastructure.MDO
{
    public class UserDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }

    public class Role
    {
        public string Name { get; set; }
    }
}