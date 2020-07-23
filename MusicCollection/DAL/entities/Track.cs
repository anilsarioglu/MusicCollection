using System.Collections.Generic;

namespace DAL.entities
{
    public class Track
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Label { get; set; }
        public List<PlaylistTrack> PlaylistTrackList { get; set; }
        public List<TrackArtist> TrackArtistList { get; set; }
        public List<TrackGenre> TrackGenreList { get; set; }

        public Track()
        {
            
        }

        public Track(string title, int duration, string label, 
            List<PlaylistTrack> playlistTrackList, List<TrackArtist> trackArtistList, List<TrackGenre> trackGenreList)
        {
            Title = title;
            Duration = duration;
            Label = label;
            PlaylistTrackList = playlistTrackList;
            TrackArtistList = trackArtistList;
            TrackGenreList = trackGenreList;
        }
    }
}
