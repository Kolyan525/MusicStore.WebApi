using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Core
{
    public interface IArtistService
    {
        List<Artist> GetArtists();
        Artist GetArtist(string id);
        Artist AddArtist(Artist artist);
        void DeleteArtist(string id);
        Artist UpdateArtist(Artist artist);
    }
}
