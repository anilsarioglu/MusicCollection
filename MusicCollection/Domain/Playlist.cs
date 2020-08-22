using System.Collections.Generic;

namespace Domain
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PlaylistTrack> PlaylistTrackList { get; set; }

        public Playlist()
        {
            
        }

        public Playlist(string title, List<PlaylistTrack> playlistTrackList)
        {
            Title = title;
            PlaylistTrackList = playlistTrackList;
        }
    }
}
