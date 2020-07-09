using System.Collections.Generic;

namespace DAL.entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Song> SongList { get; set; }

        public Genre()
        {
            
        }

        public Genre(string name, List<Song> songList)
        {
            Name = name;
            SongList = songList;
        }
    }
}
