using System;
using System.Collections.Generic;

namespace DAL.entities
{
    public class Album
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Artist Artist { get; set; }
        

        public Album()
        {
            
        }

        public Album(int artistId, string name, DateTime releaseDate)
        {
            ArtistId = artistId;
            Name = name;
            ReleaseDate = releaseDate;
        }
    }
}
