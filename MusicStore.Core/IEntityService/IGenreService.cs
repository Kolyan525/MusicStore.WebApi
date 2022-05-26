using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Core
{
    public interface IGenreService
    {
        List<Genre> GetGenres();
        Genre GetGenre(string id);
        Genre AddGenre(Genre genre);
        void DeleteGenre(string id);
        Genre UpdateGenre(Genre genre);
    }
}
