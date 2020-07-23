namespace Shared
{
    public class TrackGenreDto
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int GenreId { get; set; }
        public TrackDto Track { get; set; }
        public GenreDto Genre { get; set; }
    }
}
