namespace Domain
{
    public class TrackArtist
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int ArtistId { get; set; }
        public Track Track { get; set; }
        public Artist Artist { get; set; }

        public TrackArtist()
        {
            
        }

        public TrackArtist(int trackId, int artistId)
        {
            TrackId = trackId;
            ArtistId = artistId;
        }
    }
}
