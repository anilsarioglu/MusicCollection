namespace Shared
{
    public class TrackArtistDto
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int ArtistId { get; set; }
        public TrackDto Track { get; set; }
        public ArtistDto Artist { get; set; }
    }
}
