using System;
using System.Collections.Generic;

namespace DAL.entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ArtistName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<SongArtist> SongArtistList { get; set; }
        public List<Album> AlbumList { get; set; }

        public Artist()
        {
            
        }

        public Artist(string lastName, string firstName, string artistName, DateTime birthdate, List<SongArtist> songArtistList, List<Album> albumList)
        {
            LastName = lastName;
            FirstName = firstName;
            ArtistName = artistName;
            Birthdate = birthdate;
            SongArtistList = songArtistList;
            AlbumList = albumList;
        }
    }
}
