namespace Shared
{
    public class PlaylistTrackDto
    {
        public int Id { get; set; }
        public int TrackId { get; set; }
        public int PlaylistId { get; set; }
        public int OrderNo { get; set; }
        public TrackDto Track { get; set; }
        public PlaylistDto Playlist { get; set; }
    }
}
