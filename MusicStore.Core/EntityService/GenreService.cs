using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MusicStore.Core
{
    public class GenreService : IGenreService
    {
        readonly IMongoCollection<Genre> _Genres;

        public GenreService(IDbClient dbClient)
        {
            _Genres = dbClient.GetGenresCollection();
        }

        public Genre AddGenre(Genre Genre)
        {
            _Genres.InsertOne(Genre);
            return Genre;
        }

        public void DeleteGenre(string id)
        {
            _Genres.DeleteOne(Genre => Genre.Id == id);
        }

        public Genre GetGenre(string id) => _Genres.Find(Genre => Genre.Id == id).First();

        public List<Genre> GetGenres() => _Genres.Find(Genre => true).ToList();

        public Genre UpdateGenre(Genre Genre)
        {
            GetGenre(Genre.Id);
            _Genres.ReplaceOne(b => b.Id == Genre.Id, Genre);
            return Genre;
        }

        public Genre UpdateGenre(string id)
        {
            GetGenre(id);
            var Genre = _Genres.Find(b => b.Id == id).First();
            _Genres.ReplaceOne(b => b.Id == Genre.Id, Genre);
            return Genre;
        }
    }
}
