using MongoDB.Bson.Serialization.Attributes;

namespace MusicStore.Core
{
    public class Song
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }

        public string Category { get; set; }
    }
}
