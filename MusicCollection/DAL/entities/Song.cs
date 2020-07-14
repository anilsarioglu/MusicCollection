using System.Collections.Generic;

namespace DAL.entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Label { get; set; }
        public List<SongPlaylist> SongPlaylistList { get; set; }
        public List<SongArtist> SongArtistList { get; set; }
        public List<SongGenre> SongGenreList { get; set; }

        public Song()
        {
            
        }

        public Song(string title, int duration, string label, 
            List<SongPlaylist> songPlaylistList, List<SongArtist> songArtistList, List<SongGenre> songGenreList)
        {
            Title = title;
            Duration = duration;
            Label = label;
            SongPlaylistList = songPlaylistList;
            SongArtistList = songArtistList;
            SongGenreList = songGenreList;
        }
    }
}
