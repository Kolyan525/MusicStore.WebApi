using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Core
{
    public interface IDbClient
    {
        IMongoCollection<Song> GetSongsCollection();
        IMongoCollection<Genre> GetGenresCollection();
        IMongoCollection<Artist> GetArtistsCollection();
    }
}
