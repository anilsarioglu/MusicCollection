using System;
using System.Collections.Generic;

namespace DAL.entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<SongArtist> SongArtistList { get; set; }
        public List<Album> AlbumList { get; set; }

        public Artist()
        {
            
        }

        public Artist(string name, DateTime birthdate, List<SongArtist> songArtistList, List<Album> albumList)
        {
            Name = name;
            Birthdate = birthdate;
            SongArtistList = songArtistList;
            AlbumList = albumList;
        }
    }
}
