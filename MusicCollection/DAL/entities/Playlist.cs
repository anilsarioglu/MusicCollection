using System.Collections.Generic;

namespace DAL.entities
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<SongPlaylist> SongPlaylistList { get; set; }

        public Playlist()
        {
            
        }

        public Playlist(string title, List<SongPlaylist> songPlaylistList)
        {
            Title = title;
            SongPlaylistList = songPlaylistList;
        }
    }
}
