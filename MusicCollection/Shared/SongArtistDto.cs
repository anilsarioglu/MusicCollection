namespace Shared
{
    public class SongArtistDto
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public SongDto Song { get; set; }
        public ArtistDto Artist { get; set; }
    }
}
