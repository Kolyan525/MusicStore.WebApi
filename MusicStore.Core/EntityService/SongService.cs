using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MusicStore.Core
{
    public class SongService : ISongService
    {
        readonly IMongoCollection<Song> _songs;

        public SongService(IDbClient dbClient)
        {
            _songs = dbClient.GetSongsCollection();
        }

        public Song AddSong(Song song)
        {
            _songs.InsertOne(song);
            return song;
        }

        public void DeleteSong(string id)
        {
            _songs.DeleteOne(song => song.Id == id);
        }

        public Song GetSong(string id) => _songs.Find(song => song.Id == id).First();

        public List<Song> GetSongs() => _songs.Find(song => true).ToList();

        public Song UpdateSong(Song song)
        {
            GetSong(song.Id);
            _songs.ReplaceOne(b => b.Id == song.Id, song);
            return song;
        }

        public Song UpdateSong(string id)
        {
            GetSong(id);
            var song = _songs.Find(b => b.Id == id).First();
            _songs.ReplaceOne(b => b.Id == song.Id, song);
            return song;
        }
    }
}
