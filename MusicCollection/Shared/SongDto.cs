using System.Collections.Generic;

namespace Shared
{
    public class SongDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Label { get; set; }
        public List<SongPlaylistDto> SongPlaylistList { get; set; }
        public List<SongArtistDto> SongArtistList { get; set; }
        public List<SongGenreDto> SongGenreList { get; set; }
    }
}
