using System;
using System.Collections.Generic;
using DAL.entities;

namespace DAL
{
    public static class DataHolder
    {
        //private static List<Playlist> GetPlaylists()
        //{
        //    var playlists = new List<Playlist>
        //    {
        //        new Playlist("My Playlist", null)
        //    };

        //    return playlists;
        //}

        //private static List<Genre> GetGenres()
        //{
        //    var genres = new List<Genre>
        //    {
        //        new Genre("Pop", null),
        //        new Genre("Hip-hop/rap", null)
        //    };

        //    return genres;
        //}

        //private static List<Song> GetSongs()
        //{
        //    var songs = new List<Song>
        //    {
        //        new Song(GetGenres()[0].Id, "Watermelon Sugar", 173, "Erskine Columbia", null, null),
        //        new Song(GetGenres()[1].Id, "The Scotts", 165, "Epic", null, null)
        //    };

        //    return songs;
        //}

        private static List<Artist> GetArtists()
        {
            var artists = new List<Artist>
            {
                new Artist("Harry Styles", new DateTime(1994, 2, 1), null, null),
                new Artist("Travis Scott", new DateTime(1992, 4, 30), null, null),
                new Artist("Kid Cudi", new DateTime(1984, 1, 30), null, null)
            };

            return artists;
        }

        public static List<Album> GetAlbums()
        {
            var albums = new List<Album>
            {
                new Album(1, "The Scotts", new DateTime(2020, 4, 23))         
            };

            return albums;
        }
    }
}
