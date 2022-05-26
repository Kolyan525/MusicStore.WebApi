using MongoDB.Bson.Serialization.Attributes;

namespace MusicStore.Core
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Genre { get; set; }
        public int Albums { get; set; }
    }
}
