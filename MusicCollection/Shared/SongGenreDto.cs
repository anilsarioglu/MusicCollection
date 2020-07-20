namespace Shared
{
    public class SongGenreDto
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public SongDto Song { get; set; }
        public GenreDto Genre { get; set; }
    }
}
