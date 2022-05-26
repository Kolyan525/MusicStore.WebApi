using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Core
{
    public interface ISongService
    {
        List<Song> GetSongs();
        Song GetSong(string id);
        Song AddSong(Song song);
        void DeleteSong(string id);
        Song UpdateSong(Song song);
        Song UpdateSong(string id);
    }
}
