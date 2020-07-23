using System.Collections.Generic;

namespace Shared
{
    public class TrackDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Label { get; set; }
        public List<PlaylistTrackDto> PlaylistTrackList { get; set; }
        public List<TrackArtistDto> TrackArtistList { get; set; }
        public List<TrackGenreDto> TrackGenreList { get; set; }
    }
}
