using System;
using System.Collections.Generic;

namespace Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<TrackArtist> TrackArtistList { get; set; }
        public List<Album> AlbumList { get; set; }

        public Artist()
        {
            
        }

        public Artist(string name, DateTime birthdate, List<TrackArtist> trackArtistList, List<Album> albumList)
        {
            Name = name;
            Birthdate = birthdate;
            TrackArtistList = trackArtistList;
            AlbumList = albumList;
        }
    }
}
