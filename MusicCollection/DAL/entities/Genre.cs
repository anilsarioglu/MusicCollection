using System.Collections.Generic;

namespace DAL.entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrackGenre> TrackGenreList { get; set; }

        public Genre()
        {
            
        }

        public Genre(string name, List<TrackGenre> trackGenreList)
        {
            Name = name;
            TrackGenreList = trackGenreList;
        }
    }
}
