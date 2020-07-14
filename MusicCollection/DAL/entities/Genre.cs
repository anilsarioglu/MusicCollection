using System.Collections.Generic;

namespace DAL.entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongGenre> SongGenreList { get; set; }

        public Genre()
        {
            
        }

        public Genre(string name, List<SongGenre> songGenreList)
        {
            Name = name;
            SongGenreList = songGenreList;
        }
    }
}
