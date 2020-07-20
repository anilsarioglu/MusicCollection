using System.Collections.Generic;

namespace Shared
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SongGenreDto> SongGenreList { get; set; }
    }
}
