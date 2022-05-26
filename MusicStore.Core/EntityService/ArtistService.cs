using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MusicStore.Core
{
    public class ArtistService : IArtistService
    {
        readonly IMongoCollection<Artist> _artists;

        public ArtistService(IDbClient dbClient)
        {
            _artists = dbClient.GetArtistsCollection();
        }

        public Artist AddArtist(Artist artist)
        {
            _artists.InsertOne(artist);
            return artist;
        }

        public void DeleteArtist(string id)
        {
            _artists.DeleteOne(artist => artist.Id == id);
        }

        public Artist GetArtist(string id) => _artists.Find(artist => artist.Id == id).First();

        public List<Artist> GetArtists() => _artists.Find(artist => true).ToList();

        public Artist UpdateArtist(Artist artist)
        {
            GetArtist(artist.Id);
            _artists.ReplaceOne(b => b.Id == artist.Id, artist);
            return artist;
        }

        public Artist UpdateArtist(string id)
        {
            GetArtist(id);
            var artist = _artists.Find(b => b.Id == id).First();
            _artists.ReplaceOne(b => b.Id == artist.Id, artist);
            return artist;
        }
    }
}
