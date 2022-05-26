using MongoDB.Bson.Serialization.Attributes;

namespace MusicStore.Core
{
    public class Genre
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
