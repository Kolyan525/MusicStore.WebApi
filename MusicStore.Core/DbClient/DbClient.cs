using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MusicStore.Core
{
    public class DbClient : IDbClient
    {
        readonly IMongoCollection<Song> _songs;
        readonly IMongoCollection<Genre> _genres;
        readonly IMongoCollection<Artist> _artists;

        public DbClient(IOptions<MusicStoreDbConfig> MusicStoreDbConfig)
        {
            var client = new MongoClient(MusicStoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(MusicStoreDbConfig.Value.Database_Name);
            _songs = database.GetCollection<Song>(MusicStoreDbConfig.Value.Songs_Collection_Name);
            _genres = database.GetCollection<Genre>(MusicStoreDbConfig.Value.Genres_Collection_Name);
            _artists = database.GetCollection<Artist>(MusicStoreDbConfig.Value.Artists_Collection_Name);
        }

        public IMongoCollection<Song> GetSongsCollection() => _songs;
        public IMongoCollection<Genre> GetGenresCollection() => _genres;
        public IMongoCollection<Artist> GetArtistsCollection() => _artists;
    }
}
