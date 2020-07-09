using System.Collections.Generic;

namespace DAL.entities
{
    public class Song
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Label { get; set; }
        public Genre Genre { get; set; }
        public List<SongPlaylist> SongPlaylistList { get; set; }
        public List<SongArtist> SongArtistList { get; set; }

        public Song()
        {
            
        }

        public Song(int genreId, string title, int duration, string label, List<SongPlaylist> songPlaylistList, List<SongArtist> songArtistList)
        {
            GenreId = genreId;
            Title = title;
            Duration = duration;
            Label = label;
            SongPlaylistList = songPlaylistList;
            SongArtistList = songArtistList;
        }
    }
}
